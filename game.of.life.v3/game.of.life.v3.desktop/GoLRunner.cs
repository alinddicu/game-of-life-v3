using System;
using System.IO;

namespace game.of.life.v3.desktop
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public class GoLRunner
    {
        private static readonly Cycle Cycle = new Cycle();
        private static readonly GridLoader GridLoader = 
            new GridLoader(new FileSystem(), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Grids"));

        private readonly Panel _cellsPanel;
        private readonly List<CellButton> _buttons = new List<CellButton>();
        private readonly Stack<RectangularInfinite2DGrid> _gridHistory = new Stack<RectangularInfinite2DGrid>();

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
            if (!_gridHistory.Any())
            {
                _gridHistory.Push(GetInitialGrid());
                _cellsPanel.Enabled = false;
            }

            _gridHistory.Push(Cycle.Run(_gridHistory.Peek()));
            RefreshCellButtons();
        }

        private RectangularInfinite2DGrid GetInitialGrid()
        {
            var grid = new RectangularInfinite2DGrid();
            grid.AddCells(_buttons.Select(b => b.Cell).Where(c => c.IsAlive()).ToArray());
            return grid;
        }

        private void RefreshCellButtons()
        {
            _buttons.ForEach(b => b.RefreshCell(_gridHistory.Peek()));
        }

        public void PreviousCycle()
        {
            if (_gridHistory.Count > 1)
            {
                _gridHistory.Pop();
                RefreshCellButtons();
            }
        }

        public void Reset(GoLOptions goLOptions)
        {
            InitCellButtons(goLOptions);
            _gridHistory.Clear();
            _cellsPanel.Enabled = true;
        }

        public void SaveFirstGrid()
        {
            var fileName = DateTime.Now.ToFileTime() + ".grid";
            GridLoader.SaveToAppFolder(fileName, GetInitialGrid().Cells);
        }
    }
}
