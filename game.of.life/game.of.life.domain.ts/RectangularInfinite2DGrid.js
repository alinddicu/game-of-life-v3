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
    Object.defineProperty(RectangularInfinite2DGrid.prototype, "listCells", {
        get: function () {
            return this._cells.ToList();
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
        var neighbour = this.listCells.FirstOrDefault(function (c) { return c.x === x && c.y === y; });
        return neighbour === null ? new Cell(x, y) : neighbour;
    };
    RectangularInfinite2DGrid.prototype.discover = function () {
        var _this = this;
        var newCells = this.listCells
            .SelectMany(function (c) { return _this.getNeighbours(c); })
            .Where(function (n) { return !_this.listCells.Any(function (c) { return c.equals(n); }); })
            .Distinct()
            .ToArray();
        newCells.forEach(function (c) { return _this._cells.push(c); });
    };
    RectangularInfinite2DGrid.prototype.clean = function () {
        var _this = this;
        var isolatedCells = this.listCells
            .Where(function (cell) { return _this.getNeighbours(cell).ToList().All(function (n) { return !n.isAlive(); }); })
            .ToArray()
            .ToList();
        this._cells = this.listCells.RemoveAll(function (c) { return isolatedCells.Any(function (i) { return c.equals(i); }); }).ToArray();
    };
    RectangularInfinite2DGrid.prototype.toString = function () {
        return this.listCells
            .Where(function (c) { return c.isAlive(); })
            .ToArray()
            .join(", ");
    };
    return RectangularInfinite2DGrid;
}());
//# sourceMappingURL=RectangularInfinite2DGrid.js.map