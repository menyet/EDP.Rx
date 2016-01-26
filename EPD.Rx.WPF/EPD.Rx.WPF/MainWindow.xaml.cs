using EPD.Rx.Service;
using System.Windows;

namespace EPD.Rx.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var svc = ServiceFactory.GetService();

            // result.Text += svc.GetWords().Aggregate; 
        }
    }
}
