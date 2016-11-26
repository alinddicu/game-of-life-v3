var Cell = (function () {
    function Cell(x, y, state) {
        if (state === void 0) { state = CellState.Dead; }
        this.x = x;
        this.y = y;
        this.state = state;
        this.nextState = CellState.Unknown;
    }
    Object.defineProperty(Cell.prototype, "X", {
        get: function () {
            return this.x;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Cell.prototype, "Y", {
        get: function () {
            return this.y;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Cell.prototype, "State", {
        get: function () {
            return this.state;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Cell.prototype, "NextState", {
        get: function () {
            return this.nextState;
        },
        enumerable: true,
        configurable: true
    });
    return Cell;
}());
//# sourceMappingURL=Cell.js.map