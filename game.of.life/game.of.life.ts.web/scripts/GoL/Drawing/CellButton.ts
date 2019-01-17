'use strict';

namespace GoL.Drawing {
	import CellState = Logic.CellState;
	import RectangularInfinite2DGrid = Logic.RectangularInfinite2DGrid;

	export class CellButton {

		private DefaultBackColor: string = "white";
		public Cell: Cell;
		public BackColor: KnockoutObservable<string> = ko.observable(this.DefaultBackColor);
		public Width: number;
		public Heigth: number;
		public Text: string;

		constructor(x: number, y: number, width: number, heigth: number, text: string) {
			this.Cell = new Cell(x, y);
			this.Width = width;
			this.Heigth = heigth;
			this.Text = text;
		}

		public CellButtonClick(): void {
			this.Cell = this.Cell.IsAlive()
				? new Cell(this.Cell.X, this.Cell.Y)
				: new Cell(this.Cell.X, this.Cell.Y, CellState.Alive);
			this.RefreshBackColor();
		}

		private RefreshBackColor(): void {
			this.BackColor(this.Cell.IsAlive() ? "pink" : this.DefaultBackColor);
		}

		public RefreshCell(grid: RectangularInfinite2DGrid): void {
			this.Cell = grid.Get(this.Cell.X, this.Cell.Y);
			this.RefreshBackColor();
		}
	}
}