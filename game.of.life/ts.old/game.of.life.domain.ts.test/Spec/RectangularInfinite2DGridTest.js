/// <reference path= "../../game.of.life.domain.ts/Cell.ts" />
/// <reference path= "../../game.of.life.domain.ts/CellState.ts" />
/// <reference path= "../../game.of.life.domain.ts/RectangularInfinite2DGrid.ts" />
/// <reference path= "../Scripts/typings/jasmine/jasmine.d.ts" />
describe("RectangularInfinite2DGrid", function () {
    it("with 1 cell should return 8 dead cells when getNeighbours of that cell", function () {
        var cell = new Cell(0, 0, CellState.Alive);
        var grid = new RectangularInfinite2DGrid([cell]);
        var neighbours = grid.getNeighbours(cell);
        expect(neighbours.length).toBe(8);
        expect(neighbours.ToList().Select(function (n) { return n.state; }).Distinct().Single()).toBe(CellState.Dead);
    });
    it("with 1 cell should return cell and 8 neighbours when discover", function () {
        var grid = new RectangularInfinite2DGrid([new Cell(0, 0)]);
        grid.discover();
        var gridCells = grid.Cells.ToList();
        expect(gridCells.Count()).toBe(9);
        var expectedGridCells = [
            new Cell(0, 0),
            new Cell(0, 1),
            new Cell(0, -1),
            new Cell(1, 0),
            new Cell(-1, 0),
            new Cell(1, 1),
            new Cell(1, -1),
            new Cell(-1, 1),
            new Cell(-1, -1)
        ];
        expectedGridCells
            .ToList()
            .ForEach(function (egc) {
            return expect(gridCells.Any(function (gc) { return egc.equals(gc); })).toBeTruthy();
        });
    });
    it("with 1 dead cell should be empty after clean", function () {
        var grid = new RectangularInfinite2DGrid([new Cell(0, 0)]);
        grid.clean();
        expect(grid.Cells.length).toBe(0);
    });
    it("with Cell(0, 1, Alive) and Cell(1, 2, Alive) should return \"(0, 1), (1, 2)\" when toString()", function () {
        var grid = new RectangularInfinite2DGrid([new Cell(0, 1, CellState.Alive), new Cell(1, 2, CellState.Alive)]);
        expect(grid.toString()).toBe("(0, 1), (1, 2)");
    });
    it("with Cell(0, 1, Alive) and Cell(1, 2, Dead) should return \"(0, 1)\" when toString()", function () {
        var grid = new RectangularInfinite2DGrid([new Cell(0, 1, CellState.Alive), new Cell(1, 2, CellState.Dead)]);
        expect(grid.toString()).toBe("(0, 1)");
    });
    it("with Cell(0, 1, Alive) should return \"(0, 1)\" when toString()", function () {
        var grid = new RectangularInfinite2DGrid([new Cell(0, 1, CellState.Alive)]);
        expect(grid.toString()).toBe("(0, 1)");
    });
    it("with Cell(0, 1, Dead) should return \"(0, 1)\" when toString()", function () {
        var grid = new RectangularInfinite2DGrid([new Cell(0, 1, CellState.Dead)]);
        expect(grid.toString()).toBe("");
    });
});
//# sourceMappingURL=RectangularInfinite2DGridTest.js.map