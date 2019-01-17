'use strict';

import Cell = Gol.Logic.Cell;

let cell = new Cell(1, 1, GoL.Logic.CellState.Alive);
console.log(`state: ${cell.State} nextState: ${cell.NextState}`);
cell.ComputeNextMutation(4);
console.log(`state: ${cell.State} nextState: ${cell.NextState}`);
cell.CompleteMutation();
console.log(`state: ${cell.State} nextState: ${cell.NextState}`);

let cells = [new Cell(0, 0, GoL.Logic.CellState.Alive)/*, new GoL.Cell(2, 2, GoL.CellState.Alive)*/];
let grid = new GoL.Logic.RectangularInfinite2DGrid(cells);
grid.Discover();
console.log(grid.Cells);
let cycle = new GoL.Logic.Cycle();
grid = cycle.Run(grid);
console.log(grid.Cells);