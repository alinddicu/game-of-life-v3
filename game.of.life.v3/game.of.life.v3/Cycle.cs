namespace game.of.life.v3
{
    using System.Linq;

    public class Cycle
    {
        private readonly InfiniteGrid _grid;

        public Cycle(InfiniteGrid grid)
        {
            _grid = grid;
        }

        public void Run()
        {
            var cells = _grid.Cells.ToList();

            cells.ForEach(cell => cell.ComputeMutation(cell.GetNeighbours(_grid).Count(c => c.IsAlive)));
            cells.ForEach(cell => cell.CompleteMutation());

            _grid.Clean();
        }
    }
}
