const numberOfCellsPerRow: number = 12;
const options: GoL.Drawing.IGoLOptions = {
	NumberOfCellsPerRow: numberOfCellsPerRow,
	IsShowCellsCoordinates: true,
	ButtonSize: 53
};
const board: GoL.Drawing.Board = new GoL.Drawing.Board(options);