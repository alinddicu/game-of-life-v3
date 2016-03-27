namespace game.of.life.v3.test
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class CellTest
    {
        // Any live cell with fewer than two live neighbours dies, as if caused by under-population
        [TestMethod]
        public void Rule1()
        {
            var cell = new Cell(0, 0, CellState.Alive);

            cell.Mutate(1);

            Check.That(cell.State).IsEqualTo(CellState.Dead);
        }

        // Any live cell with two or three live neighbours lives on to the next generation
        [TestMethod]
        public void Rule2()
        {
            var cell1 = new Cell(0, 0, CellState.Alive);
            cell1.Mutate(2);
            Check.That(cell1.State).IsEqualTo(CellState.Alive);

            var cell2 = new Cell(0, 0, CellState.Alive);
            cell2.Mutate(3);
            Check.That(cell2.State).IsEqualTo(CellState.Alive);
        }

        // Any live cell with more than three live neighbours dies, as if by over-population
        [TestMethod]
        public void Rule3()
        {
            var cell = new Cell(0, 0, CellState.Alive);
            cell.Mutate(4);
            Check.That(cell.State).IsEqualTo(CellState.Dead);
        }

        // Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction
        [TestMethod]
        public void Rule4()
        {
            var cell = new Cell(0, 0);
            cell.Mutate(3);
            Check.That(cell.State).IsEqualTo(CellState.Alive);
        }

        [TestMethod]
        public void GivenCellAt0Dot0WhenGetNeighboursThenReturn8()
        {
            var cell = new Cell(0, 0);

            var neighbours = cell.GetNeighbours().Distinct().ToArray();

            Check.That(neighbours).HasSize(8);
            Check.That(neighbours).Contains(
                new Cell(-1, -1),
                new Cell(0, -1),
                new Cell(1, -1),
                new Cell(1, 0),
                new Cell(1, 1),
                new Cell(0, 1),
                new Cell(-1, 1),
                new Cell(0, -1));
            Check.That(neighbours.Contains(cell)).IsFalse();
        }

        [TestMethod]
        public void WhenCompleteMutationThenNextStateIsState()
        {
            var cell = new Cell(0, 0);
            Check.That(cell.NextState).IsEqualTo(CellState.Unknown);
            cell.Mutate(3);
            Check.That(cell.NextState).IsEqualTo(CellState.Unknown);

            cell.CompleteMutation();

            Check.That(cell.NextState).IsEqualTo(cell.State);
        }
    }
}