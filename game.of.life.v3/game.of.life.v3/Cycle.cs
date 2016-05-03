namespace game.of.life.v3
{
    using System.Linq;

    public class Cycle
    {
        private readonly RectangularInfinite2DGrid _grid;

        public Cycle(RectangularInfinite2DGrid grid)
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
