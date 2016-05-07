﻿namespace game.of.life.v3.desktop.test
{
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class GoLRunnerTest
    {
        [TestMethod]
        public void GivenSquarePanelFor4CellsWhenInitCellButtonsThenPanelHas4CellsButtons()
        {
            var panel = new Panel();
            const int buttonWidth = 2;
            panel.Width = buttonWidth * 2;
            panel.Height = panel.Width;

            var runner = new GoLRunner(panel);
            runner.InitCellButtons(new GoLOptions().WithProperties(true, 2));

            Check.That(panel.Controls).HasSize(4);
            Check.That(panel.Controls.OfType<CellButton>()).HasSize(4);

            CheckCellButton(panel.Controls[0], 0, 0, "(0,0)");
            CheckCellButton(panel.Controls[1], buttonWidth, 0, "(1,0)");
            CheckCellButton(panel.Controls[2], 0, buttonWidth, "(0,1)");
            CheckCellButton(panel.Controls[3], buttonWidth, buttonWidth, "(1,1)");
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
            var panel = new Panel();
            const int buttonWidth = 20;
            panel.Width = buttonWidth * 3;
            panel.Height = panel.Width;

            var runner = new GoLRunner(panel);
            runner.InitCellButtons(new GoLOptions().WithProperties(false, 3));
            var buttonAt11 = ClickButton(panel, 1, 1);
            Check.That(buttonAt11.BackColor).IsEqualTo(Color.DeepPink);
            runner.Cycle();

            Check.That(buttonAt11.BackColor).IsEqualTo(Control.DefaultBackColor);
            Check.That(
                panel
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
            var panel = new Panel();
            const int buttonWidth = 20;
            panel.Width = buttonWidth * 4;
            panel.Height = panel.Width;

            var runner = new GoLRunner(panel);
            var golOp = new GoLOptions().WithProperties(false, 4);
            runner.InitCellButtons(golOp);
            ClickButton(panel, 1, 1);
            ClickButton(panel, 2, 1);
            ClickButton(panel, 1, 2);

            runner.Cycle();
            runner.Reset(golOp);

            Check.That(
                panel
                .Controls
                .OfType<CellButton>().Select(b => b.BackColor).Distinct().Single())
                .IsEqualTo(Control.DefaultBackColor);
        }
    }
}
