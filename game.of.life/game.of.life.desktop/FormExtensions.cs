namespace game.of.life.desktop
{
    using System.Windows.Forms;

    public static class FormExtensions
    {
        public static void SeFormProperties(this Form form)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
        }
    }
}
