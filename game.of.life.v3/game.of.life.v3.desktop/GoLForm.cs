namespace game.of.life.v3.desktop
{
    using System;
    using System.Windows.Forms;

    public partial class GoLForm : Form
    {
        private const int ButtonsNumber = 15;

        private readonly GoLRunner _goLRunner;

        public GoLForm()
        {
            InitializeComponent();
            GoLOptions.SeFormProperties(this);
            _goLRunner = new GoLRunner(_cellsPanel, ButtonsNumber);
        }

        private void GoLForm_Load(object sender, EventArgs e)
        {
            Wait(_goLRunner.InitCellButtons);
        }

        private void cycleButton_Click(object sender, EventArgs e)
        {
            Wait(_goLRunner.Cycle);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            Wait(_goLRunner.Reset);
        }

        private static void Wait(Action userAction)
        {
            Cursor.Current = Cursors.WaitCursor;
            userAction();
            Cursor.Current = Cursors.Default;
        }
    }
}
