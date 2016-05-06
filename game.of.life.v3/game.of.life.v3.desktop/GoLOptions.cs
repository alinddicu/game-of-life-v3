namespace game.of.life.v3.desktop
{
    using System.Windows.Forms;
    public class GoLOptions
    {
        public GoLOptions(bool isShowCellsButtonsText, int cellButtonsNumber)
        {
            IsShowCellsButtonsText = isShowCellsButtonsText;
            CellButtonsNumber = cellButtonsNumber;
        }

        public bool IsShowCellsButtonsText { get; private set; }

        public int CellButtonsNumber { get; private set; }

        public void WithProperties(bool isShowCellsButtonsText, int cellButtonsNumber)
        {
            IsShowCellsButtonsText = isShowCellsButtonsText;
            CellButtonsNumber = cellButtonsNumber;
        }
    }
}
