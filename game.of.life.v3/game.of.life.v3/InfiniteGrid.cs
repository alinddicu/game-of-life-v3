namespace game.of.life.v3
{
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
            var newCells = new List<Cell>();
            foreach (var cell in _allCells)
            {
                var neighbours = cell.GetNeighbours();
                foreach (var neighbour in neighbours)
                {
                    if (!_allCells.Contains(neighbour))
                    {
                        newCells.Add(neighbour);
                    }
                }
            }

            _allCells.AddRange(newCells);
        }
    }
}
