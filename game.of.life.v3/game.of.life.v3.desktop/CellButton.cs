namespace game.of.life.v3.desktop
{
    using System.Drawing;
    using System.Windows.Forms;

    public class CellButton : Button
    {
        public static Color BackColorDefault = Color.DarkGray;

        public CellButton(int x, int y)
        {
            Cell = new Cell(x, y);
            Left = x;
            Top = y;
            Click += CellButtonClick;
        }

        private void CellButtonClick(object sender, System.EventArgs e)
        {
            Cell = Cell.IsAlive 
                    ? new Cell(Cell.X, Cell.Y) 
                    : new Cell(Cell.X, Cell.Y, CellState.Alive);
            BackColor = Cell.IsAlive ? Color.Cyan : BackColorDefault;

            Refresh();
        }

        public Cell Cell { get; private set; }
    }
}
