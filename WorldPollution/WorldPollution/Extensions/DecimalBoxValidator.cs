using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace WorldPollution.Extensions
{
    class DecimalBoxValidator:TextBox
    {

        public DecimalBoxValidator()
        {
            PreviewTextInput += DecimalValidationTextBox;
        }

        private void DecimalValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
