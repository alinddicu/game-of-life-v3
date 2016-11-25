/// <reference path= "../../game.of.life.domain.ts/Cell.ts" />
/// <reference path= "../../game.of.life.domain.ts/CellState.ts" />
/// <reference path= "../Scripts/typings/jasmine/jasmine.d.ts" />
describe("Cell", function () {
    it("should have x=2 and y=3 and State=Alive and NextState=Unknown", function () {
        var cell = new Cell(2, 3, CellState.Alive);
        expect(cell.X()).toBe(2);
        expect(cell.Y()).toBe(3);
        expect(cell.State()).toBe(CellState.Alive);
        expect(cell.NextState()).toBe(CellState.Unknown);
    });
});
//# sourceMappingURL=CellTest.js.map