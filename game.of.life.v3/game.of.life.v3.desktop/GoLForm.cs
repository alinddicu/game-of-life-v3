namespace game.of.life.v3.desktop
{
    using System.Windows.Forms;

    public partial class GoLForm : Form
    {
        private const int ButtonWidth = 60;

        private readonly GoLRunner _goLRunner;

        public GoLForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _goLRunner = new GoLRunner(_cellsPanel, ButtonWidth);
        }

        private void GoLForm_Load(object sender, System.EventArgs e)
        {
            _goLRunner.InitCellButtons();
        }

        private void cycleButton_Click(object sender, System.EventArgs e)
        {
            _goLRunner.Cycle();
        }

        private void resetButton_Click(object sender, System.EventArgs e)
        {
            _goLRunner.Reset();
        }
    }
}
