'use strict';

let cell = new GoL.Cell(1, 1, GoL.CellState.Alive);
console.log(`state: ${cell.State} nextState: ${cell.NextState}`);
cell.ComputeNextMutation(4);
console.log(`state: ${cell.State} nextState: ${cell.NextState}`);
cell.CompleteMutation();
console.log(`state: ${cell.State} nextState: ${cell.NextState}`);

let cells = [new GoL.Cell(0, 0, GoL.CellState.Alive)/*, new GoL.Cell(2, 2, GoL.CellState.Alive)*/];
let grid = new GoL.RectangularInfinite2DGrid(cells);
grid.Discover();
console.log(grid.Cells);
let cycle = new GoL.Cycle();
grid = cycle.Run(grid);
console.log(grid.Cells);