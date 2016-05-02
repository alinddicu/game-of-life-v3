﻿namespace game.of.life.v3
{
    using System.Linq;
    using System.Collections.Generic;

    public class InfiniteGrid
    {
        private readonly List<Cell> _cells = new List<Cell>();

        public IEnumerable<Cell> Cells { get { return _cells; } }

        public void Add(params Cell[] cells)
        {
            _cells.AddRange(cells);
        }

        public void Discover()
        {
            var newCells =
                (from cell in _cells
                from neighbour in cell.GetNeighbours(this)
                where !_cells.Contains(neighbour)
                 select neighbour).Distinct().ToArray();

            _cells.AddRange(newCells);
        }

        public Cell Get(int x, int y)
        {
            var existingCell = _cells.SingleOrDefault(c => c.X == x && c.Y == y);
            return existingCell ?? new Cell(x, y);
        }

        public void Clean()
        {
            var isolatedCells = _cells
                .Where(cell => cell.GetNeighbours(this).All(n => !n.IsAlive))
                .ToArray();

            _cells.RemoveAll(c => isolatedCells.Contains(c));
        }
    }
}
