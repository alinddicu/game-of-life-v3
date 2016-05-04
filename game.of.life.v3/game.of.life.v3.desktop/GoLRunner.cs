namespace game.of.life.v3.desktop
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public class GoLRunner
    {
        private readonly Panel _cellsPanel;
        private readonly int _buttonWidth;
        private readonly List<CellButton> _buttons = new List<CellButton>();
        private readonly RectangularInfinite2DGrid _grid = new RectangularInfinite2DGrid();
        private Cycle _cycle;

        public GoLRunner(Panel cellsPanel, int buttonWidth)
        {
            _cellsPanel = cellsPanel;
            _buttonWidth = buttonWidth;
        }

        private int ButtonGap { get { return _buttonWidth + 1; } }

        public void InitCellButtons()
        {
            _buttons.Clear();

            var horizontalButtonsCount = _cellsPanel.Width / ButtonGap;
            var verticalButtonsCount = _cellsPanel.Height / ButtonGap;
            for (var hCounter = 0; hCounter < horizontalButtonsCount; hCounter++)
            {
                for (var vCounter = 0; vCounter < verticalButtonsCount; vCounter++)
                {
                    var cellButton = CreateCellButton(vCounter, hCounter);
                    _buttons.Add(cellButton);
                }
            }

            _cellsPanel.Controls.Clear();
            _cellsPanel.Controls.AddRange(_buttons.ToArray());
        }

        private CellButton CreateCellButton(int vCounter, int hCounter)
        {
            return new CellButton(vCounter, hCounter, ButtonGap * vCounter, ButtonGap * hCounter)
            {
                Width = _buttonWidth,
                Height = _buttonWidth,
                Text = $"({vCounter},{hCounter})",
                BackColor = CellButton.BackColorDefault
            };
        }

        public void Cycle()
        {
            if (_cycle == null)
            {
                _grid.AddCells(_buttons.Select(b => b.Cell).Where(c => c.IsAlive).ToArray());
                _cycle = new Cycle(_grid);
                _cellsPanel.Enabled = false;
            }

            _cycle.Run();
            _buttons.ForEach(b => b.RefreshCell(_grid));
        }

        public void Reset()
        {
            InitCellButtons();
            _grid.Reset();
            _cellsPanel.Enabled = true;
            _cycle = null;
        }
    }
}
