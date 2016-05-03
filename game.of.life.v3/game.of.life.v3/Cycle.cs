namespace game.of.life.v3
{
    using System.Linq;

    public class Cycle
    {
        private readonly IGrid _grid;

        public Cycle(IGrid grid)
        {
            _grid = grid;
        }

        public void Run()
        {
            _grid.Discover();

            _grid.Cells.ToList().ForEach(cell => cell.ComputeMutation(_grid.GetNeighbours(cell).Count(c => c.IsAlive)));
            _grid.Cells.ToList().ForEach(cell => cell.CompleteMutation());

            _grid.Discover();
            _grid.Clean();
        }
    }
}
