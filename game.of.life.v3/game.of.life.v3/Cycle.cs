namespace game.of.life.v3
{
    using System.Linq;

    public class Cycle
    {

        public RectangularInfinite2DGrid Run(RectangularInfinite2DGrid grid)
        {
            var newGrid = new RectangularInfinite2DGrid();
            newGrid.AddCells(grid.Cells.Select(c => new Cell(c.X, c.Y, c.State)).ToArray());
            newGrid.Discover();

            newGrid.Cells.ToList().ForEach(cell => cell.ComputeMutation(newGrid.GetNeighbours(cell).Count(c => c.IsAlive)));
            newGrid.Cells.ToList().ForEach(cell => cell.CompleteMutation());

            newGrid.Discover();
            newGrid.Clean();

            return newGrid;
        }
    }
}
