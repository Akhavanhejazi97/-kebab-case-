using System;
using System.Windows.Forms;

namespace WinFormsApp2.Controls
{
    public class NumericTextBox : TextBox
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (!char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
