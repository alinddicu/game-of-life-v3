namespace game.of.life.domain
{
    using System.Linq;

    public class Cycle
    {

        public RectangularInfinite2DGrid Run(RectangularInfinite2DGrid currentGrid)
        {
            var newGrid = InitializeNewGrid(currentGrid);

            ComputeAndCompleteMutation(newGrid);

            PrepareForNextCycle(newGrid);

            return newGrid;
        }

        private static void PrepareForNextCycle(RectangularInfinite2DGrid newGrid)
        {
            newGrid.Discover();
            newGrid.Clean();
        }

        private static RectangularInfinite2DGrid InitializeNewGrid(RectangularInfinite2DGrid currentGrid)
        {
            var newGrid = new RectangularInfinite2DGrid();
            newGrid.AddCells(currentGrid.Cells.Select(c => new Cell(c.X, c.Y, c.State)).ToArray());
            newGrid.Discover();
            return newGrid;
        }

        private static void ComputeAndCompleteMutation(RectangularInfinite2DGrid newGrid)
        {
            newGrid.Cells.ToList().ForEach(cell => cell.ComputeMutation(newGrid.GetNeighbours(cell).Count(c => c.IsAlive())));
            newGrid.Cells.ToList().ForEach(cell => cell.CompleteMutation());
        }
    }
}
