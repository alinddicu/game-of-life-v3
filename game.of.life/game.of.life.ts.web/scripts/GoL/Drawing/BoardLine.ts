/// <reference path="../../../typings/knockout.d.ts"/>

'use strict';

namespace GoL.Drawing {
	export class BoardLine {
		public ButtonCells: KnockoutObservableArray<CellButton>;

		constructor(buttonCells: KnockoutObservableArray<CellButton>) {
			this.ButtonCells = buttonCells;
		}
	}
}