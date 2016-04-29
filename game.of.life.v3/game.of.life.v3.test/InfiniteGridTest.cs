namespace game.of.life.v3.test
{
    using System.Linq;
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
    }
}
