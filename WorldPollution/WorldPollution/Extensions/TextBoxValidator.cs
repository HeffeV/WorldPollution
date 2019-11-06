using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace WorldPollution.Extensions
{
    class TextBoxValidator:TextBox
    {

        public TextBoxValidator()
        {
            PreviewTextInput += TextValidationTextBox;
        }

        private void TextValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
