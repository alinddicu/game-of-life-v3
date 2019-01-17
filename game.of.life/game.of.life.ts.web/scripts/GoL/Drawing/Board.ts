/// <reference path="../../../typings/knockout.d.ts"/>
/// <reference path="../../../typings/linq.d.ts"/>

'use strict';

namespace GoL.Drawing {
	import Cycle = Logic.Cycle;
	import RectangularInfinite2DGrid = Logic.RectangularInfinite2DGrid;

	export class Board {

		private Cycle: Cycle = new Cycle();
		private _gridHistory: RectangularInfinite2DGrid[] = [];
		public BoardLines: BoardLine[] = [];

		constructor(goLOptions: IGoLOptions) {
			this.InitCellButtonsInSquare(goLOptions);
		}

		private InitCellButtonsInSquare(goLOptions: IGoLOptions): void {

			const numberOfCellsPerRow = goLOptions.NumberOfCellsPerRow;
			for (let hCounter = 0; hCounter < numberOfCellsPerRow; hCounter++) {
				let buttonCells: CellButton[] = [];
				for (let vCounter = 0; vCounter < numberOfCellsPerRow; vCounter++) {
					const cellButton = Board.CreateCellButton(vCounter, hCounter, goLOptions.ButtonSize, goLOptions.IsShowCellsCoordinates);
					buttonCells.push(cellButton);
				}

				this.BoardLines.push(new BoardLine(buttonCells));
			}
		}

		private static CreateCellButton(vCounter: number, hCounter: number, buttonWidth: number, isShowCellsCoordinates: boolean): CellButton {
			const text = Board.GetCellText(vCounter, hCounter, isShowCellsCoordinates);
			return new CellButton(vCounter, hCounter, buttonWidth, buttonWidth, text);
		}

		private static GetCellText(vCounter: number, hCounter: number, isShowCellsCoordinates: boolean): string {
			return isShowCellsCoordinates ? `(${vCounter},${hCounter})` : "";
		}

		public NextCycle(): void {
			if (this._gridHistory.length === 0) {
				this._gridHistory.push(this.GetCurrentGrid());
				//_cellsPanel.Enabled = false;
			}

			this._gridHistory.push(this.Cycle.Run(this.GetLastGrid()));
			this.RefreshCellButtons();
		}

		private GetCurrentGrid(): RectangularInfinite2DGrid {
			let cells: Cell[] = Enumerable.from(this.BoardLines)
				.selectMany((bl: BoardLine) => bl.ButtonCells).where((cb: CellButton) => cb.Cell.IsAlive())
				.select(x => x.Cell).toArray();
			return new RectangularInfinite2DGrid(cells);
		}

		private RefreshCellButtons(): void {
			Enumerable.from(this.BoardLines).forEach((b: BoardLine) => b.RefreshCells(this.GetLastGrid()));
		}

		private GetLastGrid(): RectangularInfinite2DGrid {
			return this._gridHistory[this._gridHistory.length - 1];
		}
	}
}