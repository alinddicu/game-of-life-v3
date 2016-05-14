using System.Windows.Forms;

namespace game.of.life.desktop
{
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
