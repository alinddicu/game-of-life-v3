class Cell {
    public constructor(
        private _x: number,
        private _y: number,
        private _state: CellState = CellState.Dead,
        private _nextState = CellState.Unknown) {
    }

    get x(): number {
        return this._x;
    }

    get y(): number {
        return this._y;
    }

    get state(): CellState {
        return this._state;
    }

    get nextState(): CellState {
        return this._nextState;
    }

    private shouldResurect(aliveNeighboursCount: number): boolean {
        return this._state === CellState.Dead && aliveNeighboursCount === 3;
    }

    private shouldStayAlive(aliveNeighboursCount: number): boolean {
        return this._state === CellState.Alive && (aliveNeighboursCount === 2 || aliveNeighboursCount === 3);
    }

    private shouldDie(aliveNeighboursCount: number): boolean {
        return this._state === CellState.Alive && (aliveNeighboursCount < 2 || aliveNeighboursCount >= 4);
    }

    computeNextMutation(aliveNeighboursCount: number): void {
        if (this.shouldResurect(aliveNeighboursCount)) {
            this._nextState = CellState.Alive;
        }

        if (this.shouldStayAlive(aliveNeighboursCount)) {
            this._nextState = CellState.Alive;
        }

        if (this.shouldDie(aliveNeighboursCount)) {
            this._nextState = CellState.Dead;
        }
    }

    completeMutation(): void {
        if (this._nextState === CellState.Unknown) {
            return;
        }

        this._state = this._nextState;
        this._nextState = CellState.Unknown;
    }

    toString = (): string => {
        return `(${this.x}, ${this.y})`;
    }

    equals(obj: any): boolean {
        if (null === obj) {
            return false;
        }

        if (this === obj) {
            return true;
        }

        return (typeof obj) === (typeof this) && this.equalsOther(obj);
    }

    private equalsOther(other: Cell): boolean {
        return this._x === other.x && this._y === other.y;
    }
}