using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace MSTranslator
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        const string EmptyTextMessage = "Please type something.";
        const string textToTranslate = "I would really like to drive your car around the block a few times!";

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Button srcButton = sender as Button;
            switch (srcButton.Name)
            {
                 case "buttonTranslate":
                    {
                        if (string.IsNullOrEmpty(textBoxInput.Text))
                        { textBoxOutput.Text = EmptyTextMessage; break; }
                        textBoxOutput.Text = "Please wait...";
                        textBoxOutput.Text = await TranslatorAPI.Translate(textBoxInput.Text);
                        break;
                    }
                case "buttonClear": { textBoxOutput.Text = ""; break; }
                case "buttonPrintLang":
                    {
                        textBoxOutput.Text = "";
                        foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
                        {
                            textBoxOutput.Text += $"{ci.DisplayName}\t: {ci.Name}" + "\n";
                        }
                        break;
                    }
            }
        }

        private void textBoxInput_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (textBoxOutput.Text == EmptyTextMessage) { textBoxOutput.Text = ""; return; }
        }
    }
}
