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
    }
}
