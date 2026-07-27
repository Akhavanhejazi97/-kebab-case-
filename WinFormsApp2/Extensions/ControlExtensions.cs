using System.Windows.Forms;

namespace WinFormsApp2.Extensions
{
    public static class ControlExtensions
    {
        public static void ClearAllTextBoxes(this Control control)
        {
            foreach (Control item in control.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }

                if (item.HasChildren)
                {
                    item.ClearAllTextBoxes();
                }
            }
        }
    }
}