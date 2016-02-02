using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EPD.Rx.WPF
{
    /// <summary>
    /// Interaction logic for Timer.xaml
    /// </summary>
    public partial class TimerView : UserControl
    {

        System.Timers.Timer timer;

        IObservable<ElapsedEventArgs> obs;

        public TimerView()
        {
            InitializeComponent();

            toggle.Checked += Toggle_Checked;
            toggle.Unchecked += Toggle_Unchecked;

            timer = new Timer();
            timer.Interval = 20;
            // timer.Enabled = true;

            obs = Observable.FromEvent<ElapsedEventHandler, ElapsedEventArgs>(
                handler =>
                {
                    ElapsedEventHandler kpeHandler = (sender, e) => handler(e);
                    return kpeHandler;
                },

                handler => timer.Elapsed += handler, handler => timer.Elapsed -= handler);

            obs.Throttle(TimeSpan.FromSeconds(1)).Subscribe(X);
        }

        private void X(ElapsedEventArgs args)
        {
            MessageBox.Show("asd");
        }

        private void Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            timer.Enabled = false;
        }

        private void Toggle_Checked(object sender, RoutedEventArgs e)
        {
            timer.Enabled = true;
        }
    }
}
