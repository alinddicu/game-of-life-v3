var RectangularInfinite2DGrid = (function () {
    function RectangularInfinite2DGrid(cells) {
        this.cells = cells;
        this._cells = new Array();
        this._cells.concat(cells);
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
    return RectangularInfinite2DGrid;
}());
//# sourceMappingURL=RectangularInfinite2DGrid.js.map