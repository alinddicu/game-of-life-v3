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

        private static RectangularInfinite2DGrid InitializeNewGrid(IGrid currentGrid)
        {
            var newGrid = new RectangularInfinite2DGrid(currentGrid.Cells.Select(c => new Cell(c.X, c.Y, c.State)));
            newGrid.Discover();
            return newGrid;
        }

        private static void ComputeAndCompleteMutation(IGrid newGrid)
        {
            newGrid.Cells.ToList().ForEach(cell => cell.ComputeNextMutation(newGrid.GetNeighbours(cell).Count(c => c.IsAlive())));
            newGrid.Cells.ToList().ForEach(cell => cell.CompleteMutation());
        }

        private static void PrepareForNextCycle(IGrid newGrid)
        {
            newGrid.Discover();
            newGrid.Clean();
        }
    }
}
