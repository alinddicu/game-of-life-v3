class Cell {

    private x: number;
    private y: number;
    private state: CellState;
    private nextState: CellState;

    public constructor(x: number, y: number, state: CellState = CellState.Dead) {
        this.x = x;
        this.y = y;
        this.state = state;
        this.nextState = CellState.Unknown;
    }

    get X(): number {
        return this.x;
    }

    get Y(): number {
        return this.y;
    }

    get State(): CellState {
        return this.state;
    }

    get NextState(): CellState {
        return this.nextState;
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