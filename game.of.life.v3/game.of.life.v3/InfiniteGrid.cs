namespace game.of.life.v3
{
    using System.Linq;
    using System.Collections.Generic;

    public class InfiniteGrid
    {
        private readonly List<Cell> _initialCells = new List<Cell>();
        private readonly List<Cell> _allCells = new List<Cell>();

        public void Add(params Cell[] cells)
        {
            _initialCells.AddRange(cells);
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
                from neighbour in cell.GetNeighbours() 
                where !_allCells.Contains(neighbour) 
                select neighbour;

            _allCells.AddRange(newCells.ToArray());
        }
    }
}
