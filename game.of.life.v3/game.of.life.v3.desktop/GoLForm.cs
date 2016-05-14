using System;
using System.IO;
using System.Windows.Forms;
using game.of.life.v3;

namespace game.of.life.desktop
{
    public partial class GoLForm : Form
    {
        private readonly GoLRunner _goLRunner;
        private readonly GoLOptions _goLOptions = new GoLOptions();
        private OptionsForm _optionsForm;

        public GoLForm()
        {
            InitializeComponent();
            this.SeFormProperties();
            _goLRunner = new GoLRunner(
                _cellsPanel,
                new ObjectToJsonFileConverter(new FileSystem(), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Grids")));
        }

        private void GoLForm_Load(object sender, EventArgs e)
        {
            SetWaitCursorOnAction(() => _goLRunner.InitCellButtons(_goLOptions));
        }

        private void PreviousCycleButton_Click(object sender, EventArgs e)
        {
            SetWaitCursorOnAction(_goLRunner.PreviousCycle);
        }

        private void NextCycleButton_Click(object sender, EventArgs e)
        {
            goLOptionsMenuItem.Enabled = false;
            SetWaitCursorOnAction(_goLRunner.NextCycle);
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            goLOptionsMenuItem.Enabled = true;
            SetWaitCursorOnAction(() => _goLRunner.Reset(_goLOptions));
        }

        private static void SetWaitCursorOnAction(Action userAction)
        {
            Cursor.Current = Cursors.WaitCursor;
            userAction();
            Cursor.Current = Cursors.Default;
        }

        private void golOptions_Click(object sender, EventArgs e)
        {
            if (_optionsForm == null)
            {
                _optionsForm = new OptionsForm(_goLOptions, OnFormOptions_Close);
            }

            _optionsForm.ShowDialog();
        }

        private void OnFormOptions_Close()
        {
            SetWaitCursorOnAction(() => _goLRunner.InitCellButtons(_goLOptions));
        }

        private void saveGridButton_Click(object sender, EventArgs e)
        {
            SetWaitCursorOnAction(() => _goLRunner.SaveFirstGrid());
        }
    }
}