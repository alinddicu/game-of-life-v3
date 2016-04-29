namespace game.of.life.v3
{
    using System.Linq;
    using System.Collections.Generic;

    public class InfiniteGrid
    {
        private readonly List<Cell> _allCells = new List<Cell>();

        public void Add(params Cell[] cells)
        {
            _allCells.AddRange(cells);
        }

        public IEnumerable<Cell> GetCells()
        {
            DiscoverNewCells();

            return _allCells;
        }

        private void DiscoverNewCells()
        {
            var newCells =
                from cell in _allCells
                from neighbour in cell.GetNeighbours(this)
                where !_allCells.Contains(neighbour)
                select neighbour;

            _allCells.AddRange(newCells.ToArray());
        }

        public Cell Get(int x, int y)
        {
            var existingCell = _allCells.SingleOrDefault(c => c.X == x && c.Y == y);
            return existingCell ?? new Cell(x, y);
        }
    }
}
