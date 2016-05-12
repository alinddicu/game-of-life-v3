namespace game.of.life.v3.test
{
    using System.Linq;
    using NFluent;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RectangularInfinite2DGridTest
    {
        private RectangularInfinite2DGrid _grid;

        [TestInitialize]
        public void Initialize()
        {
            _grid = new RectangularInfinite2DGrid();
        }

        [TestMethod]
        public void GivenGridWith1CellWhenGetCellsReturnTheCellAnd8Neighbours()
        {
            _grid.AddCells(new Cell(0, 0));

            Check.That(_grid.Cells).IsOnlyMadeOf(
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
            _grid.AddCells(cell);

            var neighbours = _grid.GetNeighbours(cell).ToArray();

            Check.That(neighbours).HasSize(8);
            Check.That(neighbours.Select(n => n.State).Distinct().Single()).IsEqualTo(CellState.Dead);
        }

        [TestMethod]
        public void GivenGridWith1DeadCellWhenCleanThenGridIsEmpty()
        {
            var cell = new Cell(0, 0);
            _grid.AddCells(cell);

            _grid.Clean();

            Check.That(_grid.Cells).IsEmpty();
        }

        [TestMethod]
        public void SimpleMutationCompletionWith1CellRevival()
        {
            var initialCells = new[] { new Cell(0, 0, CellState.Alive), new Cell(1, 0, CellState.Alive), new Cell(0, 1, CellState.Alive) };
            _grid.AddCells(initialCells);

            _grid.Discover();

            _grid.Cells.ToList().ForEach(cell => cell.ComputeMutation(_grid.GetNeighbours(cell).Count(c => c.IsAlive())));
            _grid.Cells.ToList().ForEach(cell => cell.CompleteMutation());

            Check.That(_grid.Cells).HasSize(15);
            Check.That(_grid.Cells).Not.Contains(new Cell(2, 2));
        }

        [TestMethod]
        public void SimpleMutationCompletionWith1CellRevivalThenDiscover()
        {
            var initialCells = new[] { new Cell(0, 0, CellState.Alive), new Cell(1, 0, CellState.Alive), new Cell(0, 1, CellState.Alive) };
            _grid.AddCells(initialCells);

            _grid.Discover();

            _grid.Cells.ToList().ForEach(cell => cell.ComputeMutation(_grid.GetNeighbours(cell).Count(c => c.IsAlive())));
            _grid.Cells.ToList().ForEach(cell => cell.CompleteMutation());

            _grid.Discover();

            Check.That(_grid.Cells).HasSize(35);
            Check.That(_grid.Cells).Not.Contains(new Cell(3, 3));
        }

        [TestMethod]
        public void GRidWith1AliveCellThenMutateThenDiscoverThenClean()
        {
            var initialCells = new[] { new Cell(0, 0, CellState.Alive) };
            _grid.AddCells(initialCells);

            _grid.Discover();
            Check.That(_grid.Cells).HasSize(9);

            _grid.Cells.ToList().ForEach(cell => cell.ComputeMutation(_grid.GetNeighbours(cell).Count(c => c.IsAlive())));
            _grid.Cells.ToList().ForEach(cell => cell.CompleteMutation());

            _grid.Discover();
            Check.That(_grid.Cells.Count(c => c.IsAlive())).IsEqualTo(0);
            _grid.Clean();

            Check.That(_grid.Cells).HasSize(0);
        }

        [TestMethod]
        public void GivenGridWithSomeCellsWhenResetThenCellsAreEmptied()
        {
            var initialCells = new[] { new Cell(0, 0, CellState.Alive), new Cell(1, 0), new Cell(0, 1, CellState.Unknown) };
            _grid.AddCells(initialCells);

            _grid.Reset();

            Check.That(_grid.Cells).IsEmpty();
        }
    }
}
