class RectangularInfinite2DGrid {

    private _cells: Array<Cell> = new Array<Cell>();

    public constructor(private cells: Array<Cell>) {
        this._cells.concat(cells);
    }

    get Cells(): Array<Cell> {
        return this._cells;
    }

    getNeighbours(cell: Cell) {
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
}