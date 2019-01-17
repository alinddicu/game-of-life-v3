/// <reference path="../../../typings/knockout.d.ts"/>
/// <reference path="../../../typings/linq.d.ts"/>

'use strict';

namespace GoL.Drawing {
	import RectangularInfinite2DGrid = Logic.RectangularInfinite2DGrid;

	export class BoardLine {
		public ButtonCells: CellButton[];

		constructor(buttonCells: CellButton[]) {
			this.ButtonCells = buttonCells;
		}

		public RefreshCells(grid: RectangularInfinite2DGrid): void {
			Enumerable.from(this.ButtonCells).forEach((cb: CellButton) => cb.RefreshCell(grid));
		}
	}
}