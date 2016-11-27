class RectangularInfinite2DGrid {

    private _cells: Array<Cell> = new Array<Cell>();

    public constructor(private cells: Array<Cell>) {
        cells.forEach(c => this._cells.push(c));
    }

    get Cells(): Array<Cell> {
        return this._cells;
    }

    getNeighbours(cell: Cell) : Array<Cell> {
        var neighbours = new Array<Cell>();
        neighbours.push(this.get(cell.x - 1, cell.y - 1));
        neighbours.push(this.get(cell.x, cell.y - 1));
        neighbours.push(this.get(cell.x + 1, cell.y - 1));
        neighbours.push(this.get(cell.x + 1, cell.y));
        neighbours.push(this.get(cell.x + 1, cell.y + 1));
        neighbours.push(this.get(cell.x, cell.y + 1));
        neighbours.push(this.get(cell.x - 1, cell.y + 1));
        neighbours.push(this.get(cell.x - 1, cell.y));

        return neighbours;
    }

    get(x: number, y: number): Cell {
        var neighbour = this._cells.ToList<Cell>().FirstOrDefault(c => c.x === x && c.y === y);
        return neighbour === null ? new Cell(x, y) : neighbour;
    }

    discover(): void {
        var listCells = this._cells.ToList<Cell>();
        var newCells = listCells
            .SelectMany(c => this.getNeighbours(c))
            .Where(n => !listCells.Any(c => c.equals(n)))
            .Distinct()
            .ToArray();
        
        newCells.forEach(c => this._cells.push(c as Cell));
    }
}