namespace game.of.life.v3.desktop
{
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class GoLForm : Form
    {
        private const int ButtonWidth = 80;
        private const int ButtonGap = ButtonWidth + 1;

        private readonly List<CellButton> _buttons = new List<CellButton>();

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
            var panelWidth = _cellsPanel.Width;
            var panelHeight = _cellsPanel.Height;

            var horizontalButtonsCount = panelWidth / ButtonGap;
            var verticalButtonsCount = panelHeight / ButtonGap;
            var x = 0;
            var y = 0;
            for (var hCounter = 0; hCounter < horizontalButtonsCount; hCounter++)
            {
                for (var vCounter = 0; vCounter < verticalButtonsCount; vCounter++)
                {
                    var cellButton = new CellButton(x, y) { Width = ButtonWidth, Height = ButtonWidth, Text = $"({vCounter}, {hCounter})" };
                    _buttons.Add(cellButton);
                    x = ButtonGap * vCounter;
                    y = ButtonGap * hCounter;
                }
            }

            _cellsPanel.Controls.AddRange(_buttons.ToArray());
            _cellsPanel.Refresh();
        }
    }
}
