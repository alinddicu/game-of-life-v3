namespace game.of.life.v3.test
{
    using NFluent;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CycleTest
    {
        [TestMethod]
        [Ignore]
        public void Test()
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

            var cycle = new Cycle(grid);

            cycle.Run();

            var cells = grid.Cells.ToArray();

            Check.That(cells.Where(c => c.IsAlive))
                .IsOnlyMadeOf(initialCells.Union(new[] { new Cell(1, 1) }));
            Check.That(cells).HasSize(16);
        }
    }
}
