namespace game.of.life.v3.desktop
{
    using System.Windows.Forms;

    public class CellButton : Button
    {
        public CellButton(int x, int y)
        {
            Cell = new Cell(x, y);
            Left = x;
            Top = y;
        }

        public Cell Cell { get; private set; }
    }
}
