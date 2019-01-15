/// <reference path="../../typings/linq.d.ts"/>

'use strict';

namespace GoL {
	export class RectangularInfinite2DGrid {
		public Cells: Cell[] = [];

		constructor(cells: Cell[]) {
			this.Clean();
			for (let i = 0; i < cells.length; i++) {
				this.Cells.push(cells[i]);
			}
		}

		public Discover(): void {
			//var newCells = 
			//	(From cell in this.Cells
			//	From1 neighbour in this.GetNeighbours(cell)
			//	where!this.Cells.Contains(neighbour)
			//	select neighbour).Distinct().ToArray();
			
			const newCells: Cell[] = [];
			for (let i = 0; i < this.Cells.length; i++) {
				const cell = this.Cells[i];
				const neighbours = this.GetNeighbours(cell);
				for (let j = 0; j < neighbours.length; j++) {
					const neighbour = neighbours[j];

					for (let k = 0; k < this.Cells.length; k++) {
						const cell2 = this.Cells[k];

						if (!Cell.equals(neighbour, cell2)) {
							newCells.push(neighbour);
						}
					}
				}
			}

			const newDisctinctCells: Cell[] = this.uniqueCells(newCells);
			Enumerable.from(newDisctinctCells).forEach((cell: Cell) => this.Cells.push(cell));
		}

		private uniqueCells(cells: Cell[]) {
			let dict: any = {};

			for (let i = 0; i < cells.length; i++) {
				dict[i] = cells[i];
			}

			let newDisctinctCells: Cell[] = [];
			for (let key in dict) {
				newDisctinctCells.push(dict[key]);
			}

			return newDisctinctCells;
		}

		public GetNeighbours(cell: Cell): Cell[] {
			const neighbours: Cell[] = [];
			neighbours.push(this.Get(cell.X - 1, cell.Y - 1));
			neighbours.push(this.Get(cell.X, cell.Y - 1));
			neighbours.push(this.Get(cell.X + 1, cell.Y - 1));
			neighbours.push(this.Get(cell.X + 1, cell.Y));
			neighbours.push(this.Get(cell.X + 1, cell.Y + 1));
			neighbours.push(this.Get(cell.X, cell.Y + 1));
			neighbours.push(this.Get(cell.X - 1, cell.Y + 1));
			neighbours.push(this.Get(cell.X - 1, cell.Y));

			return neighbours;
		}

		public Get(x: number, y: number): Cell {
			const foundCell = Enumerable.from(this.Cells).singleOrDefault((c: Cell) => c.X === x && c.Y === y);
			return foundCell ? foundCell : new Cell(x, y);
		}

		public Clean(): void {
			const isolatedCells = Enumerable.from(this.Cells)
				.where((cell: Cell) => Enumerable.from(this.GetNeighbours(cell)).all((n: Cell) => !n.IsAlive()))
				.toArray();

			for (let i = 0; i < isolatedCells.length; i++) {
				const isolatedCell: Cell = isolatedCells[i];
				for (let j = 0; j < this.Cells.length; j++) {
					const cell = this.Cells[j];
					if (Cell.equals(isolatedCell, cell)) {
						this.Cells.splice(j, 1);
					}
				}
			}
			//Enumerable.from(this.Cells).removeAllRanges((c: Cell) => Enumerable.from(isolatedCells).contains(c));
		}

		//public override string ToString()
		//{
		//    return string.Join(", ", _cells.Where(c => c.IsAlive()));
		//}
	}
}
