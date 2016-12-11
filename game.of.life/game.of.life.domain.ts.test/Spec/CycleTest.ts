/// <reference path= "../../game.of.life.domain.ts/Cell.ts" />
/// <reference path= "../../game.of.life.domain.ts/CellState.ts" />
/// <reference path= "../../game.of.life.domain.ts/RectangularInfinite2DGrid.ts" />
/// <reference path= "../../game.of.life.domain.ts/CellEqualityComparer.ts" />
/// <reference path= "../../game.of.life.domain.ts/Cycle.ts" />
/// <reference path= "../Scripts/typings/jasmine/jasmine.d.ts" />

describe("Cycle", () => {

    it("GivenSimpleMutationCompletionWith1CellWhenDiscoverCleanRevivalThenGridHas16Cells", () => {
        var initialCells = [
            new Cell(0, 0, CellState.Alive), new Cell(1, 0, CellState.Alive), new Cell(0, 1, CellState.Alive)
        ];
        var grid = new RectangularInfinite2DGrid(initialCells);

        var cycle = new Cycle();

        var cells = cycle.run(grid).Cells;

        expect(cells.ToList<Cell>().Count(c => c.isAlive())).toBe(4);
        initialCells.push(new Cell(1, 1, CellState.Alive));
        var newAliveCells = initialCells;
        newAliveCells.forEach(c =>
            expect(cells.ToList<Cell>().Contains(c, new CellEqualityComparer())).toBeTruthy());
        expect(cells.length).toBe(16);
    });


    it("Given2CyclesThenHistoryIsCorrect", () => {
        var cycle = new Cycle();
        var initialCells = [
            new Cell(5, 3, CellState.Alive),
            new Cell(5, 4, CellState.Alive),
            new Cell(5, 5, CellState.Alive)
        ];

        var grid1 = new RectangularInfinite2DGrid(initialCells);

        var grid2 = cycle.run(grid1);
        var grid3 = cycle.run(grid2);

        var expectedGrid2Cells = [
            new Cell(5, 4, CellState.Alive),
            new Cell(6, 4, CellState.Alive),
            new Cell(4, 4, CellState.Alive)
        ];
        
        expect(grid2.Cells.ToList<Cell>().Count(c => c.isAlive())).toBe(3);
        expectedGrid2Cells.forEach(
            ec => expect(grid2.Cells.ToList<Cell>().Contains(ec, new CellEqualityComparer())).toBeTruthy());
        //Check.That(grid3.Cells.Where(c => c.IsAlive())).IsOnlyMadeOf(initialCells);
        expect(grid3.Cells.ToList<Cell>().Count(c => c.isAlive())).toBe(3);
        initialCells.forEach(
            ec => expect(grid3.Cells.ToList<Cell>().Contains(ec, new CellEqualityComparer())).toBeTruthy());
    });
});