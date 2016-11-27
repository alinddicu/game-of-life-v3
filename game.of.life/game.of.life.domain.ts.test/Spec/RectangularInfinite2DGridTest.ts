/// <reference path= "../../game.of.life.domain.ts/Cell.ts" />
/// <reference path= "../../game.of.life.domain.ts/CellState.ts" />
/// <reference path= "../../game.of.life.domain.ts/RectangularInfinite2DGrid.ts" />
/// <reference path= "../Scripts/typings/jasmine/jasmine.d.ts" />

describe("RectangularInfinite2DGrid", () => {

    it("GivenGridWith1CellWhenGetNeighboursOfThatCellThenReturn8DeadCells", () => {
        var cell = new Cell(0, 0, CellState.Alive);
        var grid = new RectangularInfinite2DGrid([cell]);

        var neighbours = grid.getNeighbours(cell);

        expect(neighbours.length).toBe(8);
        expect(neighbours.ToList<Cell>().Select(n => n.state).Distinct().Single()).toBe(CellState.Dead);
    });
});