﻿namespace game.of.life.desktop
{
    using System.Drawing;
    using System.Windows.Forms;
    using domain;

    public class CellButton : Button
    {
        public CellButton(int x, int y, int left, int top)
        {
            Cell = new Cell(x, y);
            Left = left;
            Top = top;
            Click += CellButtonClick;
        }

        public Cell Cell { get; private set; }

        private void CellButtonClick(object sender, System.EventArgs e)
        {
            Cell = Cell.IsAlive() 
                    ? new Cell(Cell.X, Cell.Y) 
                    : new Cell(Cell.X, Cell.Y, CellState.Alive);
            RefreshBackColor();
        }

        private void RefreshBackColor()
        {
            BackColor = Cell.IsAlive() ? Color.DeepPink : DefaultBackColor;
        }

        public void RefreshCell(RectangularInfinite2DGrid grid)
        {
            Cell = grid.Get(Cell.X, Cell.Y);
            RefreshBackColor();
        }
    }
}
