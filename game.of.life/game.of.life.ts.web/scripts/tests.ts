/// <reference path="../typings/linq.d.ts"/>

'use strict';

import Cell = Gol.Logic.Cell;

let cell = new Cell(1, 1, GoL.Logic.CellState.Alive);
//console.log(`state: ${cell.State} nextState: ${cell.NextState}`);
cell.computeNextMutation(4);
//console.log(`state: ${cell.State} nextState: ${cell.NextState}`);
cell.completeMutation();
//console.log(`state: ${cell.State} nextState: ${cell.NextState}`);

function test00$22() {
	const cells = [new Cell(0, 0, GoL.Logic.CellState.Alive)/*, new GoL.Cell(2, 2, GoL.CellState.Alive)*/];
	let grid = new GoL.Logic.RectangularInfinite2DGrid(cells);
	const cycle = new GoL.Logic.Cycle();
	grid = cycle.Run(grid);
	console.log("Alive cells: " + Enumerable.from(grid.cells).where((cell: Cell) => cell.isAlive()).toArray());
}

function test00$01$10() {
	const cells = [
		new Cell(0, 0, GoL.Logic.CellState.Alive),
		new Cell(0, 1, GoL.Logic.CellState.Alive),
		new Cell(1, 0, GoL.Logic.CellState.Alive)
	];
	let grid = new GoL.Logic.RectangularInfinite2DGrid(cells);
	const cycle = new GoL.Logic.Cycle();
	grid = cycle.Run(grid);
	console.log("Alive cells: " + Enumerable.from(grid.cells).where((cell: Cell) => cell.isAlive()).toArray());
	grid = cycle.Run(grid);
	console.log("Alive cells: " + Enumerable.from(grid.cells).where((cell: Cell) => cell.isAlive()).toArray());
}

function test4Star() {
	const cells = [
		new Cell(1, 0, GoL.Logic.CellState.Alive),
		new Cell(0, 1, GoL.Logic.CellState.Alive),
		new Cell(2, 1, GoL.Logic.CellState.Alive),
		new Cell(1, 2, GoL.Logic.CellState.Alive)
	];
	let grid = new GoL.Logic.RectangularInfinite2DGrid(cells);
	const cycle = new GoL.Logic.Cycle();
	grid = cycle.Run(grid);
	console.log("Alive cells: " + Enumerable.from(grid.cells).where((cell: Cell) => cell.isAlive()).toArray());
	grid = cycle.Run(grid);
	console.log("Alive cells: " + Enumerable.from(grid.cells).where((cell: Cell) => cell.isAlive()).toArray());
}

function assertArrays(expectedArray: any[], checkedArray: any[]) {
	for (let i = 0; i < expectedArray.length; i++) {
		const expected = expectedArray[i];
		const checked = checkedArray[i];
		if (expected !== checked) {
			throw `expected '${expected}' different than '${checked}' at ${i}`;
		}
	}
}

function test5Star() {
	const cells = [
		new Cell(5, 5, GoL.Logic.CellState.Alive),
		new Cell(5, 4, GoL.Logic.CellState.Alive),
		new Cell(4, 5, GoL.Logic.CellState.Alive),
		new Cell(5, 6, GoL.Logic.CellState.Alive),
		new Cell(6, 5, GoL.Logic.CellState.Alive)
	];

	let grid = new GoL.Logic.RectangularInfinite2DGrid(cells);
	const cycle = new GoL.Logic.Cycle();
	const intermediateGridWithAliveCellsStrings: string[] = [];
	for (let i = 0; i < 9; i++) {
		grid = cycle.Run(grid);
		const toString = Enumerable.from(grid.cells).where((cell: Cell) => cell.isAlive()).toArray() + "";
		intermediateGridWithAliveCellsStrings.push(toString);
	}

	let expectedIntermediateGridWithAliveCellsStrings: string[] = [
		"(5,4),(4,5),(5,6),(6,5),(4,4),(6,4),(6,6),(4,6)",
		"(4,4),(6,4),(6,6),(4,6),(5,3),(3,5),(5,7),(7,5)",
		"(5,4),(4,5),(5,6),(6,5),(4,4),(6,4),(6,6),(4,6),(5,3),(3,5),(5,7),(7,5)",
		"(4,3),(5,3),(6,3),(3,4),(3,6),(3,5),(6,7),(5,7),(4,7),(7,4),(7,5),(7,6)",
		"(5,4),(4,5),(5,6),(6,5),(4,3),(5,3),(6,3),(3,4),(3,6),(3,5),(6,7),(5,7),(4,7),(7,4),(7,5),(7,6),(5,2),(2,5),(5,8),(8,5)",
		"(4,2),(5,2),(6,2),(2,5),(2,4),(2,6),(6,8),(5,8),(4,8),(8,4),(8,5),(8,6)",
		"(5,3),(3,5),(5,7),(7,5),(5,2),(2,5),(5,8),(8,5),(5,1),(1,5),(5,9),(9,5)",
		"(4,2),(5,2),(6,2),(2,5),(2,4),(2,6),(6,8),(5,8),(4,8),(8,4),(8,5),(8,6)",
		"(5,3),(3,5),(5,7),(7,5),(5,2),(2,5),(5,8),(8,5),(5,1),(1,5),(5,9),(9,5)"
	];

	assertArrays(intermediateGridWithAliveCellsStrings, expectedIntermediateGridWithAliveCellsStrings);
}

//test00$22();
//test00$01$10();
//test4Star();
test5Star();