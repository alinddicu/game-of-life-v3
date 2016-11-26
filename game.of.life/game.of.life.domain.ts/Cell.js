var Cell = (function () {
    function Cell(x, y, state) {
        if (state === void 0) { state = CellState.Dead; }
        this._x = x;
        this._y = y;
        this._state = state;
        this._nextState = CellState.Unknown;
    }
    Object.defineProperty(Cell.prototype, "X", {
        get: function () {
            return this._x;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Cell.prototype, "Y", {
        get: function () {
            return this._y;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Cell.prototype, "State", {
        get: function () {
            return this._state;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Cell.prototype, "NextState", {
        get: function () {
            return this._nextState;
        },
        enumerable: true,
        configurable: true
    });
    return Cell;
}());
//# sourceMappingURL=Cell.js.map