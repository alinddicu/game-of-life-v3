using System.Linq;

namespace game.of.life.v3.test
{
    using NFluent;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class InfiniteGridTest
    {
        [TestMethod]
        public void GivenGridWith1CellWhenGetCellsReturnTheCellAnd8Neighbours()
        {
            var cell = new Cell(0, 0);
            var grid = new InfiniteGrid();
            grid.Add(cell);

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
        public void GivenGridWith1CellWhenGetCellOnThatCellThenReturnTheThatCell()
        {
            var cell = new Cell(0, 0, CellState.Alive);
            var grid = new InfiniteGrid();
            grid.Add(cell);

            Check.That(grid.Get(0, 0).State).IsEqualTo(CellState.Alive);
        }

        [TestMethod]
        public void GivenEmptyGridWhenGetAnyCellThenReturnDeadCell()
        {
            var grid = new InfiniteGrid();

            Check.That(grid.Get(0, 0).State).IsEqualTo(default(CellState));
        }

        [TestMethod]
        public void GivenGridWith1DeadCellWhenCleanThenGridIsEmpty()
        {
            var cell = new Cell(0, 0);
            var grid = new InfiniteGrid();
            grid.Add(cell);

            grid.Clean();

            Check.That(grid.Cells).IsEmpty();
        }

        [TestMethod]
        public void SimpleMutationCompletionWith1CellRevival()
        {
            var initialCells =
            new[] 
            {
                new Cell(0,0, CellState.Alive), 
                new Cell(1,0, CellState.Alive), 
                new Cell(0,1, CellState.Alive)
            };
            var grid = new InfiniteGrid();
            grid.Add(initialCells);

            grid.Discover();

            grid.Cells.ToList().ForEach(cell => cell.ComputeMutation(cell.GetNeighbours(grid).Count(c => c.IsAlive)));
            grid.Cells.ToList().ForEach(cell => cell.CompleteMutation());

            Check.That(grid.Cells).HasSize(15);
            Check.That(grid.Cells).Not.Contains(new Cell(2, 2));
        }

        [TestMethod]
        public void SimpleMutationCompletionWith1CellRevivalThenDiscover()
        {
            var initialCells =
            new[] 
            {
                new Cell(0,0, CellState.Alive), 
                new Cell(1,0, CellState.Alive), 
                new Cell(0,1, CellState.Alive)
            };
            var grid = new InfiniteGrid();
            grid.Add(initialCells);

            grid.Discover();

            grid.Cells.ToList().ForEach(cell => cell.ComputeMutation(cell.GetNeighbours(grid).Count(c => c.IsAlive)));
            grid.Cells.ToList().ForEach(cell => cell.CompleteMutation());

            grid.Discover();

            Check.That(grid.Cells).HasSize(35);
            Check.That(grid.Cells).Not.Contains(new Cell(3, 3));
        }

        [TestMethod]
        [Ignore]
        public void SimpleMutationCompletionWith1CellRevivalThenDiscoverThenClean()
        {
            var initialCells =
            new[] 
            {
                new Cell(0,0, CellState.Alive), 
                new Cell(1,0, CellState.Alive), 
                new Cell(0,1, CellState.Alive)
            };
            var grid = new InfiniteGrid();
            grid.Add(initialCells);

            grid.Discover();

            grid.Cells.ToList().ForEach(cell => cell.ComputeMutation(cell.GetNeighbours(grid).Count(c => c.IsAlive)));
            grid.Cells.ToList().ForEach(cell => cell.CompleteMutation());

            grid.Discover();
            grid.Clean();

            Check.That(grid.Cells).HasSize(16);
            Check.That(grid.Cells).Not.Contains(new Cell(-2, 3));
        }

        [TestMethod]
        public void GRidWith1AliveCellThenMutateThenDiscoverThenClean()
        {
            var initialCells = new[] { new Cell(0, 0, CellState.Alive) };
            var grid = new InfiniteGrid();
            grid.Add(initialCells);

            grid.Discover();
            Check.That(grid.Cells).HasSize(9);

            grid.Cells.ToList().ForEach(cell => cell.ComputeMutation(cell.GetNeighbours(grid).Count(c => c.IsAlive)));
            grid.Cells.ToList().ForEach(cell => cell.CompleteMutation());

            grid.Discover();
            Check.That(grid.Cells.Count(c => c.IsAlive)).IsEqualTo(0);
            grid.Clean();

            Check.That(grid.Cells).HasSize(0);
        }
    }
}
