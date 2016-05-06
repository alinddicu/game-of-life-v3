namespace game.of.life.v3.desktop
{
    using System;
    using System.Windows.Forms;

    public partial class GoLForm : Form
    {
        private const int ButtonsNumber = 15;

        private readonly GoLRunner _goLRunner;
        private readonly GoLOptions _goLOptions = new GoLOptions();
        private OptionsForm _optionsForm;

        public GoLForm()
        {
            InitializeComponent();
            this.SeFormProperties();
            _goLRunner = new GoLRunner(_cellsPanel);
        }

        private void GoLForm_Load(object sender, EventArgs e)
        {
            Wait(() => _goLRunner.InitCellButtons(_goLOptions));
        }

        private void cycleButton_Click(object sender, EventArgs e)
        {
            Wait(_goLRunner.Cycle);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            Wait(() => _goLRunner.Reset(_goLOptions));
        }

        private static void Wait(Action userAction)
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
            Wait(() => _goLRunner.InitCellButtons(_goLOptions));
        }
    }
}
