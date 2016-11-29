// <reference path= "./Scripts/typings/System/Collections/Generic/List.ts" />

class RectangularInfinite2DGrid {

    private _cells: Array<Cell> = new Array<Cell>();

    public constructor(private cells: Array<Cell>) {
        cells.forEach(c => this._cells.push(c));
    }

    get Cells(): Array<Cell> {
        return this._cells;
    }

    getNeighbours(cell: Cell): Array<Cell> {
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

    clean(): void {
        var isolatedCells = this._cells.ToList<Cell>()
            .Where(cell => this.getNeighbours(cell).ToList<Cell>().All(n => !n.isAlive()))
            .ToArray()
            .ToList<Cell>();

        this._cells = this._cells.ToList<Cell>().RemoveAll(c => isolatedCells.Any(i => c.equals(i))).ToArray();
    }

    toString(): string {
        return this._cells
            .ToList<Cell>()
            .Where(c => c.isAlive())
            .ToArray()
            .join(", ");
    }
}