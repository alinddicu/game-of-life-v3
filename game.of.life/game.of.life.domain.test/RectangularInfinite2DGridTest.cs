namespace game.of.life.domain.test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using domain;
    using NFluent;

    [TestClass]
    public class RectangularInfinite2DGridTest
    {
        [TestMethod]
        public void GivenGridWith1CellWhenDiscoverThenReturnCellAnd8Neighbours()
        {
            var grid = new RectangularInfinite2DGrid(new Cell(0, 0));

            grid.Discover();
            var gridCells = grid.Cells.OrderBy(c => c.ToString());

            Check.That(gridCells).ContainsExactly(
                new Cell(0, 0),
                new Cell(0, 1),
                new Cell(0, -1),
                new Cell(1, 0),
                new Cell(-1, 0),
                new Cell(1, 1),
                new Cell(1, -1),
                new Cell(-1, 1),
                new Cell(-1, -1));
        }

        [TestMethod]
        public void GivenGridWith1CellWhenGetNeighboursOfThatCellThenReturn8DeadCells()
        {
            var cell = new Cell(0, 0, CellState.Alive);
            var grid = new RectangularInfinite2DGrid(cell);

            var neighbours = grid.GetNeighbours(cell).ToArray();

            Check.That(neighbours).HasSize(8);
            Check.That(neighbours.Select(n => n.State).Distinct().Single()).IsEqualTo(CellState.Dead);
        }

        [TestMethod]
        public void GivenGridWith1DeadCellWhenCleanThenGridIsEmpty()
        {
            var cell = new Cell(0, 0);
            var grid = new RectangularInfinite2DGrid(cell);

            grid.Clean();

            Check.That(grid.Cells).IsEmpty();
        }

        [TestMethod]
        public void Given3AdjacentAliveCellsWhenDiscoverAndMutateThenGridHas15KnownCells()
        {
            var initialCells = new[] { new Cell(0, 0, CellState.Alive), new Cell(1, 0, CellState.Alive), new Cell(0, 1, CellState.Alive) };
            var grid = new RectangularInfinite2DGrid(initialCells);

            grid.Discover();

            grid.Cells.ToList().ForEach(cell => cell.ComputeNextMutation(grid.GetNeighbours(cell).Count(c => c.IsAlive())));
            grid.Cells.ToList().ForEach(cell => cell.CompleteMutation());

            Check.That(grid.Cells).HasSize(15);
            Check.That(grid.Cells).Not.Contains(new Cell(2, 2));
        }

        [TestMethod]
        public void Given3AdjacentAliveCellsWhenDiscoverMutateAndDiscoverThenGridHas35KnownCells()
        {
            var initialCells = new[] { new Cell(0, 0, CellState.Alive), new Cell(1, 0, CellState.Alive), new Cell(0, 1, CellState.Alive) };
            var grid = new RectangularInfinite2DGrid(initialCells);

            grid.Discover();

            grid.Cells.ToList().ForEach(cell => cell.ComputeNextMutation(grid.GetNeighbours(cell).Count(c => c.IsAlive())));
            grid.Cells.ToList().ForEach(cell => cell.CompleteMutation());

            grid.Discover();

            Check.That(grid.Cells).HasSize(35);
            Check.That(grid.Cells).Not.Contains(new Cell(3, 3));
        }

        [TestMethod]
        public void GivenGridWith1AliveCellWhenMutateAndDiscoverAndCleanThenGridIsEmpty()
        {
            var initialCells = new[] { new Cell(0, 0, CellState.Alive) };
            var grid = new RectangularInfinite2DGrid(initialCells);

            grid.Discover();
            Check.That(grid.Cells).HasSize(9);

            grid.Cells.ToList().ForEach(cell => cell.ComputeNextMutation(grid.GetNeighbours(cell).Count(c => c.IsAlive())));
            grid.Cells.ToList().ForEach(cell => cell.CompleteMutation());

            grid.Discover();
            Check.That(grid.Cells.Count(c => c.IsAlive())).IsEqualTo(0);
            grid.Clean();

            Check.That(grid.Cells).HasSize(0);
        }
    }
}
