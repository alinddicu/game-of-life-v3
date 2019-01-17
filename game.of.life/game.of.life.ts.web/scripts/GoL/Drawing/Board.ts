/// <reference path="../../../typings/knockout.d.ts"/>

'use strict';

namespace GoL.Drawing {
	export class Board {

		public BoardLines: BoardLine[] = [];

		constructor(goLOptions: IGoLOptions) {
			this.InitCellButtonsInSquare(goLOptions);
		}

		private InitCellButtonsInSquare(goLOptions: IGoLOptions): void  {

			const numberOfCellsPerRow = goLOptions.NumberOfCellsPerRow;
			for (let hCounter = 0; hCounter < numberOfCellsPerRow; hCounter++) {
				let oa: KnockoutObservableArray<CellButton> = ko.observableArray();
				for (let vCounter = 0; vCounter < numberOfCellsPerRow; vCounter++) {
					const cellButton = Board.CreateCellButton(vCounter, hCounter, goLOptions.ButtonSize, goLOptions.IsShowCellsCoordinates);
					oa.push(cellButton);
				}

				const boardLine = new BoardLine(oa);
				this.BoardLines.push(boardLine);
			}
		}

		private static CreateCellButton(vCounter: number, hCounter: number, buttonWidth: number, isShowCellsCoordinates: boolean): CellButton {
			const text = Board.GetCellText(vCounter, hCounter, isShowCellsCoordinates);
			return new CellButton(vCounter, hCounter, buttonWidth, buttonWidth, text);
		}

		private static GetCellText(vCounter: number, hCounter: number, isShowCellsCoordinates: boolean): string {
			return isShowCellsCoordinates ? `(${vCounter},${hCounter})` : "";
		}
	}
}