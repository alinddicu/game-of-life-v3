namespace game.of.life.v3.test
{
    using System.Linq;
    using NFluent;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RectangularInfinite2DGridTest
    {
        [TestMethod]
        public void GivenGridWith1CellWhenGetCellsReturnTheCellAnd8Neighbours()
        {
            var cell = new Cell(0, 0);
            var grid = new RectangularInfinite2DGrid(cell);

            Check.That(grid.Cells).IsOnlyMadeOf(
                new Cell(-1, -1),
                new Cell(0, -1),
                new Cell(1, -1),
                new Cell(0, -1),
                new Cell(-1, 0),
                new Cell(0, 0),
                new Cell(1, 0),
                new Cell(-1, 1),
                new Cell(0, 1),
                new Cell(1, 1));
        }

        [TestMethod]
        public void GivenGridWith1CellWhenGetNeighboursOfThatCellsThenReturn8DeadCells()
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
        public void SimpleMutationCompletionWith1CellRevival()
        {
            var initialCells = new[] { new Cell(0, 0, CellState.Alive), new Cell(1, 0, CellState.Alive), new Cell(0, 1, CellState.Alive) };
            var grid = new RectangularInfinite2DGrid(initialCells);

            grid.Discover();

            grid.Cells.ToList().ForEach(cell => cell.ComputeMutation(grid.GetNeighbours(cell).Count(c => c.IsAlive)));
            grid.Cells.ToList().ForEach(cell => cell.CompleteMutation());

            Check.That(grid.Cells).HasSize(15);
            Check.That(grid.Cells).Not.Contains(new Cell(2, 2));
        }

        [TestMethod]
        public void SimpleMutationCompletionWith1CellRevivalThenDiscover()
        {
            var initialCells = new[] { new Cell(0, 0, CellState.Alive), new Cell(1, 0, CellState.Alive), new Cell(0, 1, CellState.Alive) };
            var grid = new RectangularInfinite2DGrid(initialCells);

            grid.Discover();

            grid.Cells.ToList().ForEach(cell => cell.ComputeMutation(grid.GetNeighbours(cell).Count(c => c.IsAlive)));
            grid.Cells.ToList().ForEach(cell => cell.CompleteMutation());

            grid.Discover();

            Check.That(grid.Cells).HasSize(35);
            Check.That(grid.Cells).Not.Contains(new Cell(3, 3));
        }

        [TestMethod]
        public void GRidWith1AliveCellThenMutateThenDiscoverThenClean()
        {
            var initialCells = new[] { new Cell(0, 0, CellState.Alive) };
            var grid = new RectangularInfinite2DGrid(initialCells);

            grid.Discover();
            Check.That(grid.Cells).HasSize(9);

            grid.Cells.ToList().ForEach(cell => cell.ComputeMutation(grid.GetNeighbours(cell).Count(c => c.IsAlive)));
            grid.Cells.ToList().ForEach(cell => cell.CompleteMutation());

            grid.Discover();
            Check.That(grid.Cells.Count(c => c.IsAlive)).IsEqualTo(0);
            grid.Clean();

            Check.That(grid.Cells).HasSize(0);
        }

        [TestMethod]
        public void GivenGridWithSomeCellsWhenResetThenCellsAreEmptied()
        {
            var initialCells = new[] { new Cell(0, 0, CellState.Alive), new Cell(1, 0), new Cell(0, 1, CellState.Unknown) };
            var grid = new RectangularInfinite2DGrid(initialCells);

            grid.Reset();

            Check.That(grid.Cells).IsEmpty();
        }
    }
}
