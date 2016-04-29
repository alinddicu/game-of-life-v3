namespace game.of.life.v3
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class InfiniteGrid
    {
        private readonly List<Cell> _cells = new List<Cell>();

        public IEnumerable<Cell> Cells
        {
            get
            {
                Discover();
                return _cells;
            }
        }

        public void Add(params Cell[] cells)
        {
            _cells.AddRange(cells);
        }

        private void Discover()
        {
            var newCells =
                from cell in _cells
                from neighbour in cell.GetNeighbours(this)
                where !_cells.Contains(neighbour)
                select neighbour;

            _cells.AddRange(newCells.ToArray());
        }

        public Cell Get(int x, int y)
        {
            var existingCell = _cells.SingleOrDefault(c => c.X == x && c.Y == y);
            return existingCell ?? new Cell(x, y);
        }

        public void Clean()
        {
            var isolatedCells =
                from cell in _cells
                where cell.GetNeighbours(this).All(n => n.State == CellState.Dead)
                select cell;

            _cells.RemoveAll(c => isolatedCells.Contains(c));
        }
    }
}
