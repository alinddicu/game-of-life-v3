namespace game.of.life.v3.desktop
{
    using System;
    using System.Windows.Forms;

    public partial class OptionsForm : Form
    {
        public OptionsForm(GoLOptions goLOptions)
        {
            InitializeComponent();
            this.SeFormProperties();
            GoLOptions = goLOptions;
        }

        public GoLOptions GoLOptions { get; private set; }

        private void okButton_Click(object sender, EventArgs e)
        {
            GoLOptions.WithProperties(checkBox1.Checked, (int)numberOfCellsPerRowDropDown.SelectedItem);
            Close();
        }
    }
}
