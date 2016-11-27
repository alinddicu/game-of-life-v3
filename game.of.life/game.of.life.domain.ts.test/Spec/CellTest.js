/// <reference path= "../../game.of.life.domain.ts/Cell.ts" />
/// <reference path= "../../game.of.life.domain.ts/CellState.ts" />
/// <reference path= "../Scripts/typings/jasmine/jasmine.d.ts" />
describe("Cell", function () {
    it("should have x=2 and y=3 and State=Alive and NextState=Unknown", function () {
        var cell = new Cell(2, 3, CellState.Alive);
        expect(cell.x).toBe(2);
        expect(cell.y).toBe(3);
        expect(cell.state).toBe(CellState.Alive);
        expect(cell.nextState).toBe(CellState.Unknown);
    });
    it("with fewer than 2 live neighbours dies as if caused by under population", function () {
        var cell = new Cell(0, 0, CellState.Alive);
        cell.computeNextMutation(1);
        expect(cell.nextState).toBe(CellState.Dead);
    });
    it("with 2 or 3 live neighbours lives on to the next generation", function () {
        var cell1 = new Cell(0, 0, CellState.Alive);
        cell1.computeNextMutation(2);
        expect(cell1.nextState).toBe(CellState.Alive);
        var cell2 = new Cell(0, 0, CellState.Alive);
        cell2.computeNextMutation(3);
        expect(cell2.nextState).toBe(CellState.Alive);
    });
    it("with more than 3 live neighbours dies as if by over population", function () {
        var cell = new Cell(0, 0, CellState.Alive);
        cell.computeNextMutation(4);
        expect(cell.nextState).toBe(CellState.Dead);
    });
    it("dead with exactly 3 aive neighbours becomes alive as if by reproduction", function () {
        var cell = new Cell(0, 0);
        cell.computeNextMutation(3);
        expect(cell.nextState).toBe(CellState.Alive);
    });
    it("when complete mutation then nextState is state", function () {
        var cell = new Cell(0, 0);
        expect(cell.nextState).toBe(CellState.Unknown);
        cell.computeNextMutation(3);
        expect(cell.nextState).toBe(CellState.Alive);
        cell.completeMutation();
        expect(cell.nextState).toBe(CellState.Unknown);
        expect(cell.state).toBe(CellState.Alive);
    });
    it("at (2,3) should print (2,3) when toString()", function () {
        var cell = new Cell(2, 3);
        expect(cell.toString()).toBe('(2, 3)');
    });
});
//# sourceMappingURL=CellTest.js.map