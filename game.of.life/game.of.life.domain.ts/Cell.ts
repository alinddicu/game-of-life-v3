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

    X(): number {
        return this.x;
    }

    Y(): number {
        return this.y;
    }

    State(): CellState {
        return this.state;
    }

    NextState(): CellState {
        return this.nextState;
    }
}