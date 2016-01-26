using EPD.Rx.Service;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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

            var text = (sender as TextBox).Text;

            result.Text = svc.GetWords(text).Aggregate("", (x, y) => x + "\n" + y);
        }
    }
}
