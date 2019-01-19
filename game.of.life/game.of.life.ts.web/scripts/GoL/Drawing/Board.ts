/// <reference path="../../../typings/knockout.d.ts"/>
/// <reference path="../../../typings/linq.d.ts"/>

'use strict';

namespace GoL.Drawing {
	import Cycle = Logic.Cycle;
	import RectangularInfinite2DGrid = Logic.RectangularInfinite2DGrid;

	export class Board {

		private playIntervalId: number;
		private cycle: Cycle = new Cycle();
		private gridHistory: RectangularInfinite2DGrid[] = [];
		public boardLines: KnockoutObservableArray<BoardLine> = ko.observableArray([]);
		public isDisabled: KnockoutObservable<boolean> = ko.observable(false);
		public isEnabled: KnockoutObservable<boolean> = ko.observable(true);
		public isPlaying: KnockoutObservable<boolean> = ko.observable(false);
		public isPausing: KnockoutObservable<boolean> = ko.observable(false);

		constructor(goLOptions: IGoLOptions) {
			this.initCellButtonsInSquare(goLOptions);
		}

		private setEnabled(enable: boolean): void {
			this.isDisabled(!enable);
			this.isEnabled(enable);
		}

		private setIsPlayingIsPausing(isPlaying: boolean, isPausing: boolean): void {
			this.isPlaying(isPlaying);
			this.isPausing(isPausing);
		}

		public initCellButtonsInSquare(goLOptions: IGoLOptions): void {

			this.boardLines([]);
			const cellsPerRow = goLOptions.cellsPerRow;
			for (let hCounter = 0; hCounter < cellsPerRow; hCounter++) {
				const buttonCells: CellButton[] = [];
				for (let vCounter = 0; vCounter < cellsPerRow; vCounter++) {
					const cellButton = Board.createCellButton(vCounter, hCounter, goLOptions.cellSize, goLOptions.isShowCellsCoordinates);
					buttonCells.push(cellButton);
				}

				this.boardLines.push(new BoardLine(buttonCells));
			}
		}

		private static createCellButton(vCounter: number, hCounter: number, buttonWidth: number, isShowCellsCoordinates: boolean): CellButton {
			const text = Board.getCellText(vCounter, hCounter, isShowCellsCoordinates);
			return new CellButton(vCounter, hCounter, buttonWidth, buttonWidth, text);
		}

		private static getCellText(vCounter: number, hCounter: number, isShowCellsCoordinates: boolean): string {
			return isShowCellsCoordinates ? `(${vCounter},${hCounter})` : "";
		}

		private getCurrentGrid(): RectangularInfinite2DGrid {
			const cells: Cell[] = Enumerable.from(this.boardLines())
				.selectMany((bl: BoardLine) => bl.buttonCells)
				.where((cb: CellButton) => cb.cell.isAlive())
				.select((cb: CellButton) => cb.cell).toArray();
			return new RectangularInfinite2DGrid(cells);
		}

		private refreshCellButtons(): void {
			Enumerable.from(this.boardLines()).forEach((b: BoardLine) => b.refreshCells(this.getLastGrid()));
		}

		private getLastGrid(): RectangularInfinite2DGrid {
			return this.gridHistory[this.gridHistory.length - 1];
		}

		public nextCycle(): void {
			this.setEnabled(false);
			if (this.gridHistory.length === 0) {
				this.gridHistory.push(this.getCurrentGrid());
			}

			this.gridHistory.push(this.cycle.Run(this.getLastGrid()));
			this.refreshCellButtons();
		}

		public stop(goLOptions: IGoLOptions): void {
			this.stopAction();
			this.setIsPlayingIsPausing(false, false);
			this.setEnabled(true);
			this.initCellButtonsInSquare(goLOptions);
			this.gridHistory = [];
		}

		public previousCycle(): void {
			if (this.gridHistory.length > 1) {
				const lastElementIndex = this.gridHistory.length - 1;
				this.gridHistory.splice(lastElementIndex, 1);
				this.refreshCellButtons();
				this.setEnabled(false);
			}
		}

		public play(goLOptions: IGoLOptions): void {
			this.setEnabled(false);
			this.setIsPlayingIsPausing(true, false);
			this.playIntervalId = setInterval((context: Board) => {
				context.nextCycle();
			}, goLOptions.normalMutationDelay, this);
		}

		public pause(goLOptions: IGoLOptions): void {
			this.setEnabled(false);
			this.setIsPlayingIsPausing(false, true);
			if (this.playIntervalId) {
				this.stopAction();
			}
		}

		public rewind(): void {
			this.setEnabled(false);
			this.playIntervalId = setInterval((context: Board) => {
				context.previousCycle();
			}, 0, this);
		}

		public fastForward(): void {
			this.setEnabled(false);
			this.playIntervalId = setInterval((context: Board) => {
				context.nextCycle();
			}, 0, this);
		}

		private stopAction() {
			clearInterval(this.playIntervalId);
		}
	}
}