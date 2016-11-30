var Cycle = (function () {
    function Cycle() {
    }
    Cycle.prototype.run = function (currentGrid) {
        var newGrid = this.initializeNewGrid(currentGrid);
        this.computeAndCompleteMutation(newGrid);
        this.prepareForNextCycle(newGrid);
        return newGrid;
    };
    Cycle.prototype.initializeNewGrid = function (currentGrid) {
        var newGrid = new RectangularInfinite2DGrid(currentGrid.Cells.ToList().Select(function (c) { return new Cell(c.x, c.y, c.state); }).ToArray());
        newGrid.discover();
        return newGrid;
    };
    Cycle.prototype.computeAndCompleteMutation = function (newGrid) {
        newGrid.Cells.ToList().ForEach(function (cell) { return cell.computeNextMutation(newGrid.getNeighbours(cell).ToList().Count(function (c) { return c.isAlive(); })); });
        newGrid.Cells.ToList().ForEach(function (cell) { return cell.completeMutation(); });
    };
    Cycle.prototype.prepareForNextCycle = function (newGrid) {
        newGrid.discover();
        newGrid.clean();
    };
    return Cycle;
}());
//# sourceMappingURL=Cycle.js.map