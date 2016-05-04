namespace game.of.life.v3.desktop
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public partial class GoLForm : Form
    {
        private const int ButtonWidth = 60;
        private const int ButtonGap = ButtonWidth + 1;

        private readonly List<CellButton> _buttons = new List<CellButton>();
        private IGrid _grid;
        private Cycle _cycle;

        public GoLForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void GoLForm_Load(object sender, System.EventArgs e)
        {
            InitCellButtons();
        }

        private void InitCellButtons()
        {
            _buttons.Clear();
            var panelWidth = _cellsPanel.Width;
            var panelHeight = _cellsPanel.Height;

            var horizontalButtonsCount = panelWidth / ButtonGap;
            var verticalButtonsCount = panelHeight / ButtonGap;
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

        private static CellButton CreateCellButton(int vCounter, int hCounter)
        {
            return new CellButton(vCounter, hCounter, ButtonGap * vCounter, ButtonGap * hCounter)
            {
                Width = ButtonWidth,
                Height = ButtonWidth,
                Text = $"({vCounter},{hCounter})",
                BackColor = CellButton.BackColorDefault
            };
        }

        private void cycleButton_Click(object sender, System.EventArgs e)
        {
            if (_cycle == null)
            {
                _grid = new RectangularInfinite2DGrid(_buttons.Select(b => b.Cell).Where(c => c.IsAlive).ToArray());
                _cycle = new Cycle(_grid);
                _cellsPanel.Enabled = false;
            }

            _cycle.Run();
            _buttons.ForEach(b => b.RefreshCell(_grid));
        }

        private void resetButton_Click(object sender, System.EventArgs e)
        {
            InitCellButtons();
            _grid.Reset();
            _cellsPanel.Enabled = true;
        }
    }
}
