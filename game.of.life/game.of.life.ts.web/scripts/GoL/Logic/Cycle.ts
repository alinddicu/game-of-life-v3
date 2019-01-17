/// <reference path="../../../typings/linq.d.ts"/>

'use strict';

namespace GoL.Logic {
	import Cell = Gol.Logic.Cell;

	export class Cycle {
		public Run(currentGrid: RectangularInfinite2DGrid): RectangularInfinite2DGrid {
			const newGrid = this.InitializeNewGrid(currentGrid);

			this.ComputeAndCompleteMutation(newGrid);

			this.PrepareForNextCycle(newGrid);

			return newGrid;
		}

		private InitializeNewGrid(currentGrid: RectangularInfinite2DGrid): RectangularInfinite2DGrid {
			const cells: Cell[] = Enumerable.from(currentGrid.Cells).select((c: Cell) => new Cell(c.X, c.Y, c.State)).toArray();
			const newGrid = new RectangularInfinite2DGrid(cells);
			newGrid.Discover();
			return newGrid;
		}

		private ComputeAndCompleteMutation(newGrid: RectangularInfinite2DGrid): void {
			Enumerable.from(newGrid.Cells).forEach((cell: Cell) => cell.ComputeNextMutation(Enumerable.from(newGrid.GetNeighbours(cell)).count((c: Cell) => c.IsAlive())));
			Enumerable.from(newGrid.Cells).forEach((cell: Cell) => cell.CompleteMutation());
		}

		private PrepareForNextCycle(newGrid: RectangularInfinite2DGrid): void {
			newGrid.Discover();
			newGrid.Clean();
		}
	}
}
