var RectangularInfinite2DGrid = (function () {
    function RectangularInfinite2DGrid(cells) {
        var _this = this;
        this.cells = cells;
        this._cells = new Array();
        cells.forEach(function (c) { return _this._cells.push(c); });
    }
    Object.defineProperty(RectangularInfinite2DGrid.prototype, "Cells", {
        get: function () {
            return this._cells;
        },
        enumerable: true,
        configurable: true
    });
    RectangularInfinite2DGrid.prototype.getNeighbours = function (cell) {
        var neighbours = new Array();
        neighbours.push(this.get(cell.x - 1, cell.y - 1));
        neighbours.push(this.get(cell.x, cell.y - 1));
        neighbours.push(this.get(cell.x + 1, cell.y - 1));
        neighbours.push(this.get(cell.x + 1, cell.y));
        neighbours.push(this.get(cell.x + 1, cell.y + 1));
        neighbours.push(this.get(cell.x, cell.y + 1));
        neighbours.push(this.get(cell.x - 1, cell.y + 1));
        neighbours.push(this.get(cell.x - 1, cell.y));
        return neighbours;
    };
    RectangularInfinite2DGrid.prototype.get = function (x, y) {
        var neighbour = this._cells.ToList().FirstOrDefault(function (c) { return c.x === x && c.y === y; });
        return neighbour === null ? new Cell(x, y) : neighbour;
    };
    RectangularInfinite2DGrid.prototype.discover = function () {
        var _this = this;
        var listCells = this._cells.ToList();
        var newCells = listCells
            .SelectMany(function (c) { return _this.getNeighbours(c); })
            .Where(function (n) { return !listCells.Any(function (c) { return c.equals(n); }); })
            .Distinct()
            .ToArray();
        newCells.forEach(function (c) { return _this._cells.push(c); });
    };
    return RectangularInfinite2DGrid;
}());
//# sourceMappingURL=RectangularInfinite2DGrid.js.map