namespace game.of.life.domain
{
    using System.Collections.Generic;
    using System.Linq;

    public class RectangularInfinite2DGrid : IGrid
    {
        private readonly List<Cell> _cells = new List<Cell>();

        public RectangularInfinite2DGrid(IEnumerable<Cell> cells)
            :this(cells.ToArray())
        {
        }

        public RectangularInfinite2DGrid(params Cell[] cells)
        {
            _cells.Clear();
            _cells.AddRange(cells);
        }

        public IEnumerable<Cell> Cells => _cells;

        public void Discover()
        {
            var newCells =
                (from cell in _cells
                from neighbour in GetNeighbours(cell)
                where !_cells.Contains(neighbour)
                 select neighbour).Distinct().ToArray();

            _cells.AddRange(newCells);
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

        public Cell Get(int x, int y)
        {
            return _cells.SingleOrDefault(c => c.X == x && c.Y == y) ?? new Cell(x, y);
        }

        public void Clean()
        {
            var isolatedCells = _cells
                .Where(cell => GetNeighbours(cell).All(n => !n.IsAlive()))
                .ToArray();

            _cells.RemoveAll(c => isolatedCells.Contains(c));
        }

        public void Reset()
        {
            _cells.Clear();
        }

        public override string ToString()
        {
            return string.Join(", ", _cells.Where(c => c.IsAlive()));
        }
    }
}
