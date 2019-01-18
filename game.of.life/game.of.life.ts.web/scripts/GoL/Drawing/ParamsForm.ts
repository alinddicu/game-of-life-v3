namespace GoL.Drawing {
	export class ParamsForm {
		public options: IGoLOptions;

		public init(): Board {
			this.options = {
				numberOfCellsPerRow: this.valueOrDefault<number>("numberOfCellsPerRow", 12),
				isShowCellsCoordinates: this.valueOrDefault<boolean>("isShowCellsCoordinates", false),
				buttonSize: this.valueOrDefault<number>("buttonSize", 53),
				mutationDelay: this.valueOrDefault<number>("mutationDelay", 100)
			};

			return  new Board(this.options);
		}

		private valueOrDefault<T>(elementId: string, defaultValue: any): T {
			const inputField = document.getElementById(elementId) as HTMLFormElement;

			let value;
			try {
				if (typeof defaultValue === "number") {
					value = inputField.valueAsNumber;
				}
				else if (typeof defaultValue === "string") {
					value = inputField.value;
				}
				else if (typeof defaultValue === "boolean") {
					value = inputField.checked;
				} else {
					value = inputField.valueAsDate;
				}
			} catch (e) {
				console.error(`Problem parsing '${elementId}'`);
			}

			return value ? value : defaultValue;
		}
	}
}