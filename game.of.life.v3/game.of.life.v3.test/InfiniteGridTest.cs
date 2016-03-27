namespace game.of.life.v3.test
{
    using NFluent;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class InfiniteGridTest
    {
        [TestMethod]
        public void Test()
        {
            var cell = new Cell(0, 0);
            var grid = new InfiniteGrid();
            grid.Add(cell);

            var otherCells = grid.GetCells();

            Check.That(otherCells).HasSize(9);
        }
    }
}
