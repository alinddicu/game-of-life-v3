namespace game.of.life.domain.test
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class CellTest
    {
        // Any live cell with fewer than two live neighbours dies, as if caused by under-population
        [TestMethod]
        public void AnyLiveCellWithFewerThanTwoLiveNeighboursDiesAsIfCausedByUnderPopulation()
        {
            var cell = new Cell(0, 0, CellState.Alive);

            cell.ComputeMutation(1);

            Check.That(cell.NextState).IsEqualTo(CellState.Dead);
        }

        // Any live cell with two or three live neighbours lives on to the next generation
        [TestMethod]
        public void AnyLiveCellWithTwoOrThreeLiveNeighboursLivesOnToTheNextGeneration()
        {
            var cell1 = new Cell(0, 0, CellState.Alive);
            cell1.ComputeMutation(2);
            Check.That(cell1.NextState).IsEqualTo(CellState.Alive);

            var cell2 = new Cell(0, 0, CellState.Alive);
            cell2.ComputeMutation(3);
            Check.That(cell2.NextState).IsEqualTo(CellState.Alive);
        }

        // Any live cell with more than three live neighbours dies, as if by over-population
        [TestMethod]
        public void AnyLiveCellWithMoreThanThreeLiveNeighboursDiesAsIfByOverPopulation()
        {
            var cell = new Cell(0, 0, CellState.Alive);
            cell.ComputeMutation(4);
            Check.That(cell.NextState).IsEqualTo(CellState.Dead);
        }

        // Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction
        [TestMethod]
        public void AnyDeadCellWithExactlyThreeLiveNeighboursBecomesAliveAsIfByReproduction()
        {
            var cell = new Cell(0, 0);
            cell.ComputeMutation(3);
            Check.That(cell.NextState).IsEqualTo(CellState.Alive);
        }

        [TestMethod]
        public void GivenCellAt0Dot0WhenGetNeighboursThenReturn8()
        {
            var cell = new Cell(0, 0);
            var grid = new RectangularInfinite2DGrid();

            var neighbours = grid.GetNeighbours(cell).Distinct().ToArray();
            
            Check.That(neighbours).IsOnlyMadeOf(
                new Cell(-1, -1),
                new Cell(0, -1),
                new Cell(1, -1),
                new Cell(-1, 0),
                new Cell(1, 0),
                new Cell(1, 1),
                new Cell(0, 1),
                new Cell(-1, 1));
            Check.That(neighbours.Contains(cell)).IsFalse();
        }

        [TestMethod]
        public void WhenCompleteMutationThenNextStateIsState()
        {
            var cell = new Cell(0, 0);
            Check.That(cell.NextState).IsEqualTo(CellState.Unknown);
            cell.ComputeMutation(3);
            Check.That(cell.NextState).IsEqualTo(CellState.Alive);

            cell.CompleteMutation();

            Check.That(cell.NextState).IsEqualTo(CellState.Unknown);
            Check.That(cell.State).IsEqualTo(CellState.Alive);
        }

        [TestMethod]
        public void WhenNextStateIsUnknownThenDontCompleteMutation()
        {
            var cell = new Cell(0, 0, CellState.Alive);
            cell.ComputeMutation(0);
            cell.CompleteMutation();
            Check.That(cell.State).IsEqualTo(CellState.Dead);

            cell.CompleteMutation();
            
            Check.That(cell.State).IsEqualTo(CellState.Dead);
        }
    }
}