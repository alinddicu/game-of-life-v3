using System.IO;
using Newtonsoft.Json;

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

            cell.ComputeNextMutation(1);

            Check.That(cell.NextState).IsEqualTo(CellState.Dead);
        }

        // Any live cell with two or three live neighbours lives on to the next generation
        [TestMethod]
        public void AnyLiveCellWithTwoOrThreeLiveNeighboursLivesOnToTheNextGeneration()
        {
            var cell1 = new Cell(0, 0, CellState.Alive);
            cell1.ComputeNextMutation(2);
            Check.That(cell1.NextState).IsEqualTo(CellState.Alive);

            var cell2 = new Cell(0, 0, CellState.Alive);
            cell2.ComputeNextMutation(3);
            Check.That(cell2.NextState).IsEqualTo(CellState.Alive);
        }

        // Any live cell with more than three live neighbours dies, as if by over-population
        [TestMethod]
        public void AnyLiveCellWithMoreThanThreeLiveNeighboursDiesAsIfByOverPopulation()
        {
            var cell = new Cell(0, 0, CellState.Alive);
            cell.ComputeNextMutation(4);
            Check.That(cell.NextState).IsEqualTo(CellState.Dead);
        }

        // Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction
        [TestMethod]
        public void AnyDeadCellWithExactlyThreeLiveNeighboursBecomesAliveAsIfByReproduction()
        {
            var cell = new Cell(0, 0);
            cell.ComputeNextMutation(3);
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
            cell.ComputeNextMutation(3);
            Check.That(cell.NextState).IsEqualTo(CellState.Alive);

            cell.CompleteMutation();

            Check.That(cell.NextState).IsEqualTo(CellState.Unknown);
            Check.That(cell.State).IsEqualTo(CellState.Alive);
        }

        [TestMethod]
        public void WhenNextStateIsUnknownThenDontCompleteMutation()
        {
            var cell = new Cell(0, 0, CellState.Alive);
            cell.ComputeNextMutation(0);
            cell.CompleteMutation();
            Check.That(cell.State).IsEqualTo(CellState.Dead);

            cell.CompleteMutation();
            
            Check.That(cell.State).IsEqualTo(CellState.Dead);
        }
        [TestMethod]
        [DeploymentItem("Resources/cell.json", "Resources")]
        public void WhenSaveThenJsonIsCorrect()
        {
            var loader = new ObjectToJsonFileConverter(new FileSystem(), "Resources");

            loader.Save("cell", new Cell(0, 1));

            var jsonCell = File.ReadAllText("Resources/cell.json");

            Check.That(jsonCell).IsEqualTo(@"{""X"":0,""Y"":1,""State"":0,""NextState"":2}");
        }

        [TestMethod]
        public void JsonDeserialzeTest()
        {
            var cell = JsonConvert.DeserializeObject<Cell>(@"{""X"":5,""Y"":3,""NextState"":1,""State"":1}");

            Check.That(cell.State).IsEqualTo(CellState.Alive);
            Check.That(cell.NextState).IsEqualTo(CellState.Alive);
        }
    }
}