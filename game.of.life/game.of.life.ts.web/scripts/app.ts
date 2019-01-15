let cell = new GoL.Cell(1, 1, GoL.CellState.Alive);
console.log(`state: ${cell.State} nextState: ${cell.NextState}`);
cell.ComputeNextMutation(4);
console.log(`state: ${cell.State} nextState: ${cell.NextState}`);
cell.CompleteMutation();
console.log(`state: ${cell.State} nextState: ${cell.NextState}`);