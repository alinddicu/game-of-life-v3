namespace game.of.life.v3.desktop
{
    public class GoLOptions
    {
        public const int CellButtonsNumberDefault = 15;

        public GoLOptions()
        {
            IsShowCellsButtonsText = false;
            CellButtonsNumber = CellButtonsNumberDefault;
        }

        public bool IsShowCellsButtonsText { get; private set; }

        public int CellButtonsNumber { get; private set; }

        public GoLOptions WithProperties(bool isShowCellsButtonsText, int cellButtonsNumber)
        {
            IsShowCellsButtonsText = isShowCellsButtonsText;
            CellButtonsNumber = cellButtonsNumber;

            return this;
        }
    }
}
