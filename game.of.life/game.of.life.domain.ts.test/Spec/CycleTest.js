/// <reference path= "../../game.of.life.domain.ts/Cell.ts" />
/// <reference path= "../../game.of.life.domain.ts/CellState.ts" />
/// <reference path= "../../game.of.life.domain.ts/RectangularInfinite2DGrid.ts" />
/// <reference path= "../../game.of.life.domain.ts/CellEqualityComparer.ts" />
/// <reference path= "../../game.of.life.domain.ts/Cycle.ts" />
/// <reference path= "../Scripts/typings/jasmine/jasmine.d.ts" />
describe("Cycle", function () {
    it("GivenSimpleMutationCompletionWith1CellWhenDiscoverCleanRevivalThenGridHas16Cells", function () {
        var initialCells = [new Cell(0, 0, CellState.Alive), new Cell(1, 0, CellState.Alive), new Cell(0, 1, CellState.Alive)];
        var grid = new RectangularInfinite2DGrid(initialCells);
        var cycle = new Cycle();
        var cells = cycle.run(grid).Cells;
        //Check.That(cells.Where(c => c.IsAlive())).IsOnlyMadeOf(initialCells.Union(new [] { new Cell(1, 1) }));
        expect(cells.length).toBe(16);
    });
});
//# sourceMappingURL=CycleTest.js.map