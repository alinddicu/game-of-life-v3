class Cell {

    private _x: number;
    private _y: number;
    private _state: CellState;
    private _nextState: CellState;

    public constructor(x: number, y: number, state: CellState = CellState.Dead) {
        this._x = x;
        this._y = y;
        this._state = state;
        this._nextState = CellState.Unknown;
    }

    public get X(): number {
        return this._x;
    }

    public get Y(): number {
        return this._y;
    }

    public get State(): CellState {
        return this._state;
    }

    public get NextState(): CellState {
        return this._nextState;
    }

    //private ShouldResurect(aliveNeighboursCount: number): Boolean {
    //    return this._state === CellState.Dead && aliveNeighboursCount === 3;
    //}

    //private ShouldStayAlive(aliveNeighboursCount: number): Boolean {
    //    return this._state === CellState.Alive && (aliveNeighboursCount === 2 || aliveNeighboursCount === 3);
    //}

    //private ShouldDie(aliveNeighboursCount: number): Boolean {
    //    return this._state === CellState.Alive && (aliveNeighboursCount < 2 || aliveNeighboursCount >= 4);
    //}

    //public ComputeNextMutation(aliveNeighboursCount: number): void {
    //    if (this.ShouldResurect(aliveNeighboursCount)) {
    //        this._nextState = CellState.Alive;
    //    }

    //    if (this.ShouldStayAlive(aliveNeighboursCount)) {
    //        this._nextState = CellState.Alive;
    //    }

    //    if (this.ShouldDie(aliveNeighboursCount)) {
    //        this._nextState = CellState.Dead;
    //    }
    //}
}