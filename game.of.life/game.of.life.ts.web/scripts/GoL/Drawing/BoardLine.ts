/// <reference path="../../../typings/knockout.d.ts"/>

'use strict';

namespace GoL.Drawing {
	export class BoardLine {
		public ButtonCells: CellButton[];

		constructor(buttonCells: CellButton[]) {
			this.ButtonCells = buttonCells;
		}
	}
}