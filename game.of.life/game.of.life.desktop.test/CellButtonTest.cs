﻿namespace game.of.life.desktop.test
{
    using System.Drawing;
    using System.Windows.Forms;
    using domain;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class CellButtonTest
    {
        [TestMethod]
        public void WhenNewThenPropertiesAreCorrect()
        {
            var button = new CellButton(1, 2, 21, 42);
            
            Check.That(button.Left).IsEqualTo(21);
            Check.That(button.Top).IsEqualTo(42);
            Check.That(button.Cell.X).IsEqualTo(1);
            Check.That(button.Cell.Y).IsEqualTo(2);
            Check.That(button.Cell.State).IsEqualTo(CellState.Dead);
        }

        [TestMethod]
        public void GivenButtonWhenClickThenSelectedStateChanges()
        {
            var button = new CellButton(1, 2, 21, 42);

            button.PerformClick();
            Check.That(button.Cell.State).IsEqualTo(CellState.Alive);
            Check.That(button.BackColor).IsEqualTo(Color.DeepPink);

            button.PerformClick();
            Check.That(button.Cell.State).IsEqualTo(CellState.Dead);
            Check.That(button.BackColor).IsEqualTo(Control.DefaultBackColor);
        }
    }
}
