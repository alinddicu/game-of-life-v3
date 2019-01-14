class Cycle {

    run(currentGrid : RectangularInfinite2DGrid): RectangularInfinite2DGrid {
        var newGrid = this.initializeNewGrid(currentGrid);
        this.computeAndCompleteMutation(newGrid);
        this.prepareForNextCycle(newGrid);
        return newGrid;
    }

    private initializeNewGrid(currentGrid : RectangularInfinite2DGrid): RectangularInfinite2DGrid {
        var newGrid = new RectangularInfinite2DGrid(currentGrid.Cells.ToList<Cell>().Select(c => new Cell(c.x, c.y, c.state)).ToArray());
        newGrid.discover();
        return newGrid;
    }

    private computeAndCompleteMutation(newGrid : RectangularInfinite2DGrid): void {
        newGrid.Cells.ToList<Cell>().ForEach(cell => cell.computeNextMutation(newGrid.getNeighbours(cell).ToList<Cell>().Count(c => c.isAlive())));
        newGrid.Cells.ToList<Cell>().ForEach(cell => cell.completeMutation());
    }

    private prepareForNextCycle(newGrid : RectangularInfinite2DGrid): void {
        newGrid.discover();
        newGrid.clean();
    }
}