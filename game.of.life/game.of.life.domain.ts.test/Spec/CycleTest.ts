/// <reference path= "../../game.of.life.domain.ts/Cell.ts" />
/// <reference path= "../../game.of.life.domain.ts/CellState.ts" />
/// <reference path= "../../game.of.life.domain.ts/RectangularInfinite2DGrid.ts" />
/// <reference path= "../../game.of.life.domain.ts/CellEqualityComparer.ts" />
/// <reference path= "../../game.of.life.domain.ts/Cycle.ts" />
/// <reference path= "../Scripts/typings/jasmine/jasmine.d.ts" />

describe("Cycle", () => {

    it("GivenSimpleMutationCompletionWith1CellWhenDiscoverCleanRevivalThenGridHas16Cells", () => {
        var initialCells = [new Cell(0, 0, CellState.Alive), new Cell(1, 0, CellState.Alive), new Cell(0, 1, CellState.Alive)];
        var grid = new RectangularInfinite2DGrid(initialCells);

        var cycle = new Cycle();

        var cells = cycle.run(grid).Cells;

        expect(cells.ToList<Cell>().Count(c => c.isAlive())).toBe(4);
        expect(cells.ToList<Cell>().Contains(new Cell(1, 1), new CellEqualityComparer()));
        expect(cells.length).toBe(16);
    });
});