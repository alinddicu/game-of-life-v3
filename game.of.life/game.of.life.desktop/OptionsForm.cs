﻿namespace game.of.life.desktop
{
    using System;
    using System.Linq;
    using System.Windows.Forms;

    public partial class OptionsForm : Form
    {
        private readonly Action _onClose;

        public OptionsForm(GoLOptions goLOptions, Action onClose)
        {
            _onClose = onClose;
            InitializeComponent();
            this.SeFormProperties();
            GoLOptions = goLOptions;
            numberOfCellsPerRowDropDown.SelectedItem = 
                numberOfCellsPerRowDropDown
                .Items
                .Cast<string>()
                .Single(i => i == GoLOptions.NumberOfCellsPerRowDefault.ToString());
            _onClose = onClose;
        }

        private GoLOptions GoLOptions { get; set; }

        private void okButton_Click(object sender, EventArgs e)
        {
            GoLOptions.WithProperties(isShowCellsCoordinatesCheckBox.Checked, int.Parse(numberOfCellsPerRowDropDown.SelectedItem.ToString()));
            Close();
        }

        private void OptionsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _onClose();
        }
    }
}
