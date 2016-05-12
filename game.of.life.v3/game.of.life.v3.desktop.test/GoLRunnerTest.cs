namespace game.of.life.v3.desktop.test
{
    using System;
    using System.IO;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class GoLRunnerTest
    {
        private readonly GridLoader _gridLoader = new GridLoader(new FileSystem(),
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Grids"));

        private GoLRunner _runner;
        private Panel _panel;

        [TestInitialize]
        public void Initialize()
        {
            _panel = new Panel();
            _runner = new GoLRunner(_panel, _gridLoader);
        }

        [TestMethod]
        public void GivenSquarePanelFor4CellsWhenInitCellButtonsThenPanelHas4CellsButtons()
        {
            const int buttonWidth = 2;
            _panel.Width = buttonWidth * 2;
            _panel.Height = _panel.Width;

            _runner.InitCellButtons(new GoLOptions().WithProperties(true, 2));

            Check.That(_panel.Controls).HasSize(4);
            Check.That(_panel.Controls.OfType<CellButton>()).HasSize(4);

            CheckCellButton(_panel.Controls[0], 0, 0, "(0,0)");
            CheckCellButton(_panel.Controls[1], buttonWidth, 0, "(1,0)");
            CheckCellButton(_panel.Controls[2], 0, buttonWidth, "(0,1)");
            CheckCellButton(_panel.Controls[3], buttonWidth, buttonWidth, "(1,1)");
        }

        private static void CheckCellButton(Control control, int left, int top, string text)
        {
            Check.That(control.Width).IsEqualTo(2).And.IsEqualTo(control.Height);
            Check.That(control.Left).IsEqualTo(left);
            Check.That(control.Top).IsEqualTo(top);
            Check.That(control.Text).IsEqualTo(text);
            Check.That(control.BackColor).IsEqualTo(Control.DefaultBackColor);
        }

        [TestMethod]
        public void WhenRun1CycleThenButtonsAreRefreshed()
        {
            const int buttonWidth = 20;
            _panel.Width = buttonWidth * 3;
            _panel.Height = _panel.Width;

            _runner.InitCellButtons(new GoLOptions().WithProperties(false, 3));
            var buttonAt11 = ClickButton(_panel, 1, 1);
            Check.That(buttonAt11.BackColor).IsEqualTo(Color.DeepPink);
            _runner.NextCycle();

            Check.That(buttonAt11.BackColor).IsEqualTo(Control.DefaultBackColor);
            Check.That(
                _panel
                .Controls
                .OfType<CellButton>().Select(b => b.BackColor).Distinct().Single())
                .IsEqualTo(Control.DefaultBackColor);
        }

        private static CellButton ClickButton(Control panel, int x, int y)
        {
            var button = GetButton(panel, x, y);
            button.PerformClick();
            return button;
        }

        private static CellButton GetButton(Control panel, int x, int y)
        {
            return panel
                .Controls
                .OfType<CellButton>()
                .Single(b => b.Cell.X == x && b.Cell.Y == y);
        }

        [TestMethod]
        public void Given1RunnedCycleWhenResetThenGridIsReset()
        {
            const int buttonWidth = 20;
            _panel.Width = buttonWidth * 4;
            _panel.Height = _panel.Width;

            var golOp = new GoLOptions().WithProperties(false, 4);
            _runner.InitCellButtons(golOp);
            ClickButton(_panel, 1, 1);
            ClickButton(_panel, 2, 1);
            ClickButton(_panel, 1, 2);

            _runner.NextCycle();
            _runner.Reset(golOp);

            Check.That(
                _panel
                .Controls
                .OfType<CellButton>().Select(b => b.BackColor).Distinct().Single())
                .IsEqualTo(Control.DefaultBackColor);
        }

        [TestMethod]
        public void Given1RunnedCycleWhenPreviousCycleThenCurretGridIsPreviousGrid()
        {
            const int buttonWidth = 20;
            _panel.Width = buttonWidth * 4;
            _panel.Height = _panel.Width;

            var golOp = new GoLOptions().WithProperties(false, 4);
            _runner.InitCellButtons(golOp);
            ClickButton(_panel, 1, 1);
            ClickButton(_panel, 2, 1);
            ClickButton(_panel, 1, 2);

            _runner.NextCycle();
            _runner.PreviousCycle();

            Check.That(
                _panel
                .Controls
                .OfType<CellButton>().Where(b => b.Cell.IsAlive()))
                .HasSize(3);
        }

        [TestMethod]
        public void Given1RunnedCycleWhenPreviousCycleTwiceThenCurretGridIsPreviousGrid()
        {
            const int buttonWidth = 20;
            _panel.Width = buttonWidth * 4;
            _panel.Height = _panel.Width;

            var golOp = new GoLOptions().WithProperties(false, 4);
            _runner.InitCellButtons(golOp);
            ClickButton(_panel, 1, 1);
            ClickButton(_panel, 2, 1);
            ClickButton(_panel, 1, 2);

            _runner.NextCycle();
            _runner.PreviousCycle();
            _runner.PreviousCycle();

            Check.That(
                _panel
                .Controls
                .OfType<CellButton>().Where(b => b.Cell.IsAlive()))
                .HasSize(3);
        }
    }
}
