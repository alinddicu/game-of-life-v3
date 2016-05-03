namespace game.of.life.v3
{
    using System.Linq;
    using System.Collections.Generic;

    public class RectangularInfinite2DGrid : IGrid
    {
        private readonly List<Cell> _cells = new List<Cell>();

        public RectangularInfinite2DGrid(params Cell[] cells)
        {
            _cells.AddRange(cells);
        }

        public IEnumerable<Cell> Cells { get { return _cells; } }

        public void Discover()
        {
            var newCells =
                (from cell in _cells
                from neighbour in GetNeighbours(cell)
                where !_cells.Contains(neighbour)
                 select neighbour).Distinct().ToArray();

            _cells.AddRange(newCells);
        }

        private Cell Get(int x, int y)
        {
            var existingCell = _cells.SingleOrDefault(c => c.X == x && c.Y == y);
            return existingCell ?? new Cell(x, y);
        }

        public IEnumerable<Cell> GetNeighbours(Cell cell)
        {
            yield return Get(cell.X - 1, cell.Y - 1);
            yield return Get(cell.X, cell.Y - 1);
            yield return Get(cell.X + 1, cell.Y - 1);
            yield return Get(cell.X + 1, cell.Y);
            yield return Get(cell.X + 1, cell.Y + 1);
            yield return Get(cell.X, cell.Y + 1);
            yield return Get(cell.X - 1, cell.Y + 1);
            yield return Get(cell.X - 1, cell.Y);
        }

        public void Clean()
        {
            var isolatedCells = _cells
                .Where(cell => GetNeighbours(cell).All(n => !n.IsAlive))
                .ToArray();

            _cells.RemoveAll(c => isolatedCells.Contains(c));
        }
    }
}
