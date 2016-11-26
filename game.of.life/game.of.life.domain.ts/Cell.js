var Cell = (function () {
    function Cell(x, y, state, nextState) {
        if (state === void 0) { state = CellState.Dead; }
        if (nextState === void 0) { nextState = CellState.Unknown; }
        this.x = x;
        this.y = y;
        this.state = state;
        this.nextState = nextState;
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
    Cell.prototype.ShouldResurect = function (aliveNeighboursCount) {
        return this.state === CellState.Dead && aliveNeighboursCount === 3;
    };
    Cell.prototype.ShouldStayAlive = function (aliveNeighboursCount) {
        return this.state === CellState.Alive && (aliveNeighboursCount === 2 || aliveNeighboursCount === 3);
    };
    Cell.prototype.ShouldDie = function (aliveNeighboursCount) {
        return this.state === CellState.Alive && (aliveNeighboursCount < 2 || aliveNeighboursCount >= 4);
    };
    Cell.prototype.ComputeNextMutation = function (aliveNeighboursCount) {
        if (this.ShouldResurect(aliveNeighboursCount)) {
            this.nextState = CellState.Alive;
        }
        if (this.ShouldStayAlive(aliveNeighboursCount)) {
            this.nextState = CellState.Alive;
        }
        if (this.ShouldDie(aliveNeighboursCount)) {
            this.nextState = CellState.Dead;
        }
    };
    return Cell;
}());
//# sourceMappingURL=Cell.js.map