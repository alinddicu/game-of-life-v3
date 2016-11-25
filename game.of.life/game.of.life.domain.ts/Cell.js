var Cell = (function () {
    function Cell(x, y, state) {
        if (state === void 0) { state = CellState.Dead; }
        this.x = x;
        this.y = y;
        this.state = state;
        this.nextState = CellState.Unknown;
    }
    Cell.prototype.X = function () {
        return this.x;
    };
    Cell.prototype.Y = function () {
        return this.y;
    };
    Cell.prototype.State = function () {
        return this.state;
    };
    Cell.prototype.NextState = function () {
        return this.nextState;
    };
    return Cell;
}());
//# sourceMappingURL=Cell.js.map