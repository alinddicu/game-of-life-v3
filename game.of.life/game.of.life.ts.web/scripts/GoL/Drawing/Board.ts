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
		public isReadOnly: KnockoutObservable<boolean> = ko.observable(false);

		constructor(goLOptions: IGoLOptions) {
			this.initCellButtonsInSquare(goLOptions);
		}

		private initCellButtonsInSquare(goLOptions: IGoLOptions): void {

			this.boardLines([]);
			const numberOfCellsPerRow = goLOptions.numberOfCellsPerRow;
			for (let hCounter = 0; hCounter < numberOfCellsPerRow; hCounter++) {
				const buttonCells: CellButton[] = [];
				for (let vCounter = 0; vCounter < numberOfCellsPerRow; vCounter++) {
					const cellButton = Board.createCellButton(vCounter, hCounter, goLOptions.buttonSize, goLOptions.isShowCellsCoordinates);
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
				.selectMany((bl: BoardLine) => bl.buttonCells).where((cb: CellButton) => cb.cell.isAlive())
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
			if (this.gridHistory.length === 0) {
				this.gridHistory.push(this.getCurrentGrid());
				this.isReadOnly(true);
			}

			this.gridHistory.push(this.cycle.Run(this.getLastGrid()));
			this.refreshCellButtons();
		}

		public stop(goLOptions: IGoLOptions): void {
			this.initCellButtonsInSquare(goLOptions);
			this.gridHistory = [];
			this.isReadOnly(false);
		}

		public previousCycle(): void {
			if (this.gridHistory.length > 1) {
				const lastElementIndex = this.gridHistory.length - 1;
				this.gridHistory.splice(lastElementIndex, 1);
				this.refreshCellButtons();
				this.isReadOnly(true);
			}
		}

		public play(goLOptions: IGoLOptions): void {
			this.isReadOnly(true);
			this.playIntervalId = setInterval((context: Board) => {
				context.nextCycle();
			}, goLOptions.mutationDelay, this);
		}

		public pause(goLOptions: IGoLOptions): void {
			if (this.playIntervalId) {
				clearInterval(this.playIntervalId);
			}
		}

		public rewind(): void {
			this.isReadOnly(true);
			this.playIntervalId = setInterval((context: Board) => {
				context.previousCycle();
			}, 0, this);
		}

		public fastForward(): void {
			this.isReadOnly(true);
			this.playIntervalId = setInterval((context: Board) => {
				context.nextCycle();
			}, 0, this);
		}
	}
}