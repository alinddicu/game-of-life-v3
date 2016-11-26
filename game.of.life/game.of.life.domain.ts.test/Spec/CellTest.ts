/// <reference path= "../../game.of.life.domain.ts/Cell.ts" />
/// <reference path= "../../game.of.life.domain.ts/CellState.ts" />
/// <reference path= "../Scripts/typings/jasmine/jasmine.d.ts" />

describe("Cell", () => {

    it("should have x=2 and y=3 and State=Alive and NextState=Unknown", () => {
        var cell = new Cell(2, 3, CellState.Alive);

        expect(cell.X).toBe(2);
        expect(cell.Y).toBe(3);
        expect(cell.State).toBe(CellState.Alive);
        expect(cell.NextState).toBe(CellState.Unknown);
    });

    it("with fewer than 2 live neighbours dies as if caused by under population", () => {
        var cell = new Cell(0, 0, CellState.Alive);

        cell.ComputeNextMutation(1);

        expect(cell.NextState).toBe(CellState.Dead);
    });

    it("with 2 or 3 live neighbours lives on to the next generation", () => {
        var cell1 = new Cell(0, 0, CellState.Alive);
        cell1.ComputeNextMutation(2);
        expect(cell1.NextState).toBe(CellState.Alive);

        var cell2 = new Cell(0, 0, CellState.Alive);
        cell2.ComputeNextMutation(3);
        expect(cell2.NextState).toBe(CellState.Alive);
    });

    it("with more than 3 live neighbours dies as if by over population", () => {
        var cell = new Cell(0, 0, CellState.Alive);
        cell.ComputeNextMutation(4);
        expect(cell.NextState).toBe(CellState.Dead);
    });

    it("dead with exactly 3 aive neighbours becomes alive as if by reproduction", () => {
        var cell = new Cell(0, 0);
        cell.ComputeNextMutation(3);
        expect(cell.NextState).toBe(CellState.Alive);
    });

});