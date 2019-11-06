using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Windows.Input;


namespace WorldPollution.Extensions
{
    class NumberBoxValidator :TextBox
    {

        public NumberBoxValidator()
        {
            PreviewTextInput += NumberValidationTextBox;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
