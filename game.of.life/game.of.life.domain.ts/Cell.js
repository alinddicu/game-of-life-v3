var Cell = (function () {
    function Cell(_x, _y, _state, _nextState) {
        var _this = this;
        if (_state === void 0) { _state = CellState.Dead; }
        if (_nextState === void 0) { _nextState = CellState.Unknown; }
        this._x = _x;
        this._y = _y;
        this._state = _state;
        this._nextState = _nextState;
        this.toString = function () {
            return "(" + _this.x + ", " + _this.y + ")";
        };
    }
    Object.defineProperty(Cell.prototype, "x", {
        get: function () {
            return this._x;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Cell.prototype, "y", {
        get: function () {
            return this._y;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Cell.prototype, "state", {
        get: function () {
            return this._state;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Cell.prototype, "nextState", {
        get: function () {
            return this._nextState;
        },
        enumerable: true,
        configurable: true
    });
    Cell.prototype.shouldResurect = function (aliveNeighboursCount) {
        return this._state === CellState.Dead && aliveNeighboursCount === 3;
    };
    Cell.prototype.shouldStayAlive = function (aliveNeighboursCount) {
        return this._state === CellState.Alive && (aliveNeighboursCount === 2 || aliveNeighboursCount === 3);
    };
    Cell.prototype.shouldDie = function (aliveNeighboursCount) {
        return this._state === CellState.Alive && (aliveNeighboursCount < 2 || aliveNeighboursCount >= 4);
    };
    Cell.prototype.computeNextMutation = function (aliveNeighboursCount) {
        if (this.shouldResurect(aliveNeighboursCount)) {
            this._nextState = CellState.Alive;
        }
        if (this.shouldStayAlive(aliveNeighboursCount)) {
            this._nextState = CellState.Alive;
        }
        if (this.shouldDie(aliveNeighboursCount)) {
            this._nextState = CellState.Dead;
        }
    };
    Cell.prototype.completeMutation = function () {
        if (this._nextState === CellState.Unknown) {
            return;
        }
        this._state = this._nextState;
        this._nextState = CellState.Unknown;
    };
    Cell.prototype.equals = function (obj) {
        if (null === obj) {
            return false;
        }
        if (this === obj) {
            return true;
        }
        return (typeof obj) === (typeof this) && this.equalsOther(obj);
    };
    Cell.prototype.equalsOther = function (other) {
        return this._x === other.x && this._y === other.y;
    };
    Cell.prototype.isAlive = function () {
        return this._state === CellState.Alive;
    };
    return Cell;
}());
//# sourceMappingURL=Cell.js.map