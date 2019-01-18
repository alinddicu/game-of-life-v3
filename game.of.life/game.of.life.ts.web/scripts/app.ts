let params: GoL.Drawing.ParamsForm;
let board: GoL.Drawing.Board;
let isInit = false;

function init(): void {
	params = new GoL.Drawing.ParamsForm();
	board = params.init();

	if (!isInit) {
		ko.applyBindings({
			board: board
		});

		isInit = true;
	}
}