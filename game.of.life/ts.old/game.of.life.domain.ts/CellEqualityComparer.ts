class CellEqualityComparer implements IEqualityComparer<Cell> {
    Equals(x: Cell, y: Cell): boolean {
         return x.equals(y);
    }
}