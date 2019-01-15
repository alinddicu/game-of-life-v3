/// <reference path="../../typings/linq.d.ts"/>

namespace GoL {
	export class Cell {
		private _computeNextMutations: IComputeNextMutation[] =
			[
				new ShouldResurectNextMutation(),
				new ShouldStayAliveNextMutation(),
				new ShouldDieNextMutation()
			];

		public X: number;
		public Y: number;
		public State: CellState;
		public NextState: CellState;

		constructor(x: number, y: number, state: CellState = CellState.Dead, nextState: CellState = CellState.Unknown) {
			this.X = x;
			this.Y = y;
			this.State = state;
			this.NextState = nextState;
		}

		public IsAlive(): boolean {
			return this.State === CellState.Alive;
		}

		public ComputeNextMutation(aliveNeighboursCount: number): void {
			const nextComputation = Enumerable.from(this._computeNextMutations)
				.firstOrDefault((m: IComputeNextMutation) => m.CanComputeNextMutation(this, aliveNeighboursCount));
			
			if (nextComputation) {
				nextComputation.ComputeNextMutation(this);
			}
		}

		public CompleteMutation(): void {
			if (this.NextState === CellState.Unknown) {
				return;
			}

			this.State = this.NextState;
			this.NextState = CellState.Unknown;
		}

		public static equals(a: Cell, b: Cell): boolean {
			if (!a || !b) {
				return false;
			}

			return a.X === b.X && a.Y === b.Y;
		}
		
		public toString(): string
		{
			return `(${this.X},${this.Y})`;
		}
	}

	interface IComputeNextMutation {
		CanComputeNextMutation(cell: GoL.Cell, aliveNeighboursCount: number): boolean;

		ComputeNextMutation(cell: GoL.Cell): void;
	}

	class ShouldResurectNextMutation implements IComputeNextMutation {
		public CanComputeNextMutation(cell: GoL.Cell, aliveNeighboursCount: number): boolean {
			return cell.State === GoL.CellState.Dead && aliveNeighboursCount === 3;
		}

		public ComputeNextMutation(cell: GoL.Cell): void {
			cell.NextState = GoL.CellState.Alive;
		}
	}

	class ShouldStayAliveNextMutation implements IComputeNextMutation {
		public CanComputeNextMutation(cell: GoL.Cell, aliveNeighboursCount: number): boolean {
			return cell.State === GoL.CellState.Alive && (aliveNeighboursCount === 2 || aliveNeighboursCount === 3);
		}

		public ComputeNextMutation(cell: GoL.Cell): void {
			cell.NextState = GoL.CellState.Alive;
		}
	}

	class ShouldDieNextMutation implements IComputeNextMutation {
		public CanComputeNextMutation(cell: GoL.Cell, aliveNeighboursCount: number): boolean {
			return cell.State === GoL.CellState.Alive && (aliveNeighboursCount < 2 || aliveNeighboursCount >= 4);
		}

		public ComputeNextMutation(cell: GoL.Cell): void {
			cell.NextState = GoL.CellState.Dead;
		}
	}
}
