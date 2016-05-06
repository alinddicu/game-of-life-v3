namespace game.of.life.v3.desktop
{
    public class GoLOptions
    {
        public const int NumberOfCellsPerRowDefault = 15;

        public GoLOptions()
        {
            IsShowCellsCoordinates = false;
            NumberOfCellsPerRow = NumberOfCellsPerRowDefault;
        }

        public bool IsShowCellsCoordinates { get; private set; }

        public int NumberOfCellsPerRow { get; private set; }

        public GoLOptions WithProperties(bool isShowCellsCoordinates, int numberOfCellsPerRow)
        {
            IsShowCellsCoordinates = isShowCellsCoordinates;
            NumberOfCellsPerRow = numberOfCellsPerRow;

            return this;
        }
    }
}
