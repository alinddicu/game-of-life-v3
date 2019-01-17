namespace game.of.life.domain.test
{
	using System.Collections.Generic;
	using System.Linq;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NFluent;

	[TestClass]
	public class CycleTest
	{
		private Cycle _cycle;

		[TestInitialize]
		public void Initialize()
		{
			_cycle = new Cycle();
		}

		[TestMethod]
		public void GivenSimpleMutationCompletionWith1CellWhenDiscoverCleanRevivalThenGridHas16Cells()
		{
			var initialCells = new[] { new Cell(0, 0, CellState.Alive), new Cell(1, 0, CellState.Alive), new Cell(0, 1, CellState.Alive) };
			var grid = new RectangularInfinite2DGrid(initialCells);

			_cycle = new Cycle();

			var cells = _cycle.Run(grid).Cells.ToArray();

			Check.That(cells.Where(c => c.IsAlive())).IsOnlyMadeOf(initialCells.Union(new[] { new Cell(1, 1) }));
			Check.That(cells).HasSize(16);
		}

		[TestMethod]
		public void Given2CyclesThenHistoryIsCorrect()
		{
			var initialCells = new[]
			{
				new Cell(5, 3, CellState.Alive),
				new Cell(5, 4, CellState.Alive),
				new Cell(5, 5, CellState.Alive)
			};

			var grid1 = new RectangularInfinite2DGrid(initialCells);

			var grid2 = _cycle.Run(grid1);
			var grid3 = _cycle.Run(grid2);

			var expectedGrid2Cells = new[]
			{
				new Cell(5, 4, CellState.Alive),
				new Cell(6, 4, CellState.Alive),
				new Cell(4, 4, CellState.Alive)
			};
			Check.That(grid2.Cells.Where(c => c.IsAlive())).ContainsExactly(expectedGrid2Cells);
			Check.That(grid3.Cells.Where(c => c.IsAlive())).IsOnlyMadeOf(initialCells);
		}

		[TestMethod]
		public void Given5CellsStarAnd9RunsThenIntermediateGridsAreCorrect()
		{
			var cells = new[]
			{
				new Cell(5, 5, CellState.Alive),
				new Cell(5, 4, CellState.Alive),
				new Cell(4, 5, CellState.Alive),
				new Cell(5, 6, CellState.Alive),
				new Cell(6, 5, CellState.Alive)
			};

			var grid = new RectangularInfinite2DGrid(cells);
			var cycle = new Cycle();
			var intermediateGridWithAliveCellsStrings = new List<string>();
			for (var i = 0; i < 9; i++)
			{
				grid = cycle.Run(grid);
				intermediateGridWithAliveCellsStrings.Add(string.Join(",", grid.Cells.Where(c => c.IsAlive())));
			}

			var expectedIntermediateGridWithAliveCellsStrings = new List<string>
			{
				"(5,4),(4,5),(5,6),(6,5),(4,4),(6,4),(6,6),(4,6)",
				"(4,4),(6,4),(6,6),(4,6),(5,3),(3,5),(5,7),(7,5)",
				"(5,4),(4,5),(5,6),(6,5),(4,4),(6,4),(6,6),(4,6),(5,3),(3,5),(5,7),(7,5)",
				"(4,3),(5,3),(6,3),(3,4),(3,6),(3,5),(6,7),(5,7),(4,7),(7,4),(7,5),(7,6)",
				"(5,4),(4,5),(5,6),(6,5),(4,3),(5,3),(6,3),(3,4),(3,6),(3,5),(6,7),(5,7),(4,7),(7,4),(7,5),(7,6),(5,2),(2,5),(5,8),(8,5)",
				"(4,2),(5,2),(6,2),(2,5),(2,4),(2,6),(6,8),(5,8),(4,8),(8,4),(8,5),(8,6)",
				"(5,3),(3,5),(5,7),(7,5),(5,2),(2,5),(5,8),(8,5),(5,1),(1,5),(5,9),(9,5)",
				"(4,2),(5,2),(6,2),(2,5),(2,4),(2,6),(6,8),(5,8),(4,8),(8,4),(8,5),(8,6)",
				"(5,3),(3,5),(5,7),(7,5),(5,2),(2,5),(5,8),(8,5),(5,1),(1,5),(5,9),(9,5)"
			};
			Check.That(intermediateGridWithAliveCellsStrings).ContainsExactly(expectedIntermediateGridWithAliveCellsStrings);
			Check.That(intermediateGridWithAliveCellsStrings).IsOnlyMadeOf(expectedIntermediateGridWithAliveCellsStrings);
		}
	}
}
