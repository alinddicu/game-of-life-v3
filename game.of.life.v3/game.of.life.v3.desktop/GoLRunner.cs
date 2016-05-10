namespace game.of.life.v3.desktop
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public class GoLRunner
    {
        private readonly Panel _cellsPanel;
        private readonly List<CellButton> _buttons = new List<CellButton>();
        private readonly RectangularInfinite2DGrid _grid = new RectangularInfinite2DGrid();
        private Cycle _cycle;

        public GoLRunner(Panel cellsPanel)
        {
            _cellsPanel = cellsPanel;
        }

        public void InitCellButtons(GoLOptions goLOptions)
        {
            _buttons.Clear();
            var numberOfCellsPerRow = goLOptions.NumberOfCellsPerRow;

            var side = new[] { _cellsPanel.Width, _cellsPanel.Height }.Min();
            var buttonWidth = side / numberOfCellsPerRow;
            for (var hCounter = 0; hCounter < numberOfCellsPerRow; hCounter++)
            {
                for (var vCounter = 0; vCounter < numberOfCellsPerRow; vCounter++)
                {
                    var cellButton = CreateCellButton(vCounter, hCounter, buttonWidth, goLOptions.IsShowCellsCoordinates);
                    _buttons.Add(cellButton);
                }
            }

            _cellsPanel.Controls.Clear();
            // ReSharper disable once CoVariantArrayConversion
            _cellsPanel.Controls.AddRange(_buttons.ToArray());
        }

        private static CellButton CreateCellButton(int vCounter, int hCounter, int buttonWidth, bool isShowCellsCoordinates)
        {
            return new CellButton(vCounter, hCounter, buttonWidth * vCounter, buttonWidth * hCounter)
            {
                Width = buttonWidth,
                Height = buttonWidth,
                Text = GetCellText(vCounter, hCounter, isShowCellsCoordinates),
                BackColor = Control.DefaultBackColor
            };
        }

        private static string GetCellText(int vCounter, int hCounter, bool isShowCellsCoordinates)
        {
            return isShowCellsCoordinates ? string.Format("({0},{1})", vCounter, hCounter) : string.Empty;
        }

        public void NextCycle()
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

        public void Reset(GoLOptions goLOptions)
        {
            InitCellButtons(goLOptions);
            _grid.Reset();
            _cellsPanel.Enabled = true;
            _cycle = null;
        }
    }
}
