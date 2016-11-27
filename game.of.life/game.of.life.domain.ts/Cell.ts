class Cell {
    public constructor(
        private x: number,
        private y: number,
        private state: CellState = CellState.Dead,
        private nextState = CellState.Unknown) {
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

    private ShouldResurect(aliveNeighboursCount: number): Boolean {
        return this.state === CellState.Dead && aliveNeighboursCount === 3;
    }

    private ShouldStayAlive(aliveNeighboursCount: number): Boolean {
        return this.state === CellState.Alive && (aliveNeighboursCount === 2 || aliveNeighboursCount === 3);
    }

    private ShouldDie(aliveNeighboursCount: number): Boolean {
        return this.state === CellState.Alive && (aliveNeighboursCount < 2 || aliveNeighboursCount >= 4);
    }

    public ComputeNextMutation(aliveNeighboursCount: number): void {
        if (this.ShouldResurect(aliveNeighboursCount)) {
            this.nextState = CellState.Alive;
        }

        if (this.ShouldStayAlive(aliveNeighboursCount)) {
            this.nextState = CellState.Alive;
        }

        if (this.ShouldDie(aliveNeighboursCount)) {
            this.nextState = CellState.Dead;
        }
    }

    public CompleteMutation(): void {
        if (this.nextState === CellState.Unknown) {
            return;
        }

        this.state = this.nextState;
        this.nextState = CellState.Unknown;
    }

    public toString = (): string => {
        return `(${this.X}, ${this.Y})`;
    }
}