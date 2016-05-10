﻿namespace game.of.life.v3.test
{
    using NFluent;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CycleTest
    {
        private Cycle _cycle;

        [TestInitialize]
        public void Initialize()
        {
            _cycle = new Cycle();
        }

        [TestMethod]
        public void GivenSimpleMutationCompletionWith1CellWhenDiscoverCleanRevivalThenGridHas16Cells()
        {
            var initialCells = new[] { new Cell(0, 0, CellState.Alive), new Cell(1, 0, CellState.Alive), new Cell(0, 1, CellState.Alive) };
            var grid = new RectangularInfinite2DGrid();
            grid.AddCells(initialCells);

            _cycle = new Cycle();

            var cells = _cycle.Run(grid).Cells.ToArray();
            
            Check.That(cells.Where(c => c.IsAlive)).IsOnlyMadeOf(initialCells.Union(new[] { new Cell(1, 1) }));
            Check.That(cells).HasSize(16);
        }
    }
}
