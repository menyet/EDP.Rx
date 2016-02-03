using System;
using System.Reactive.Linq;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

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

            // timer.Elapsed += TimerOnElapsed;
            // timer.Enabled = true;

            obs = Observable.FromEvent<ElapsedEventHandler, ElapsedEventArgs>(
                handler =>
                {
                    ElapsedEventHandler kpeHandler = (sender, e) => handler(e);
                    return kpeHandler;
                },

                handler => timer.Elapsed += handler, handler => timer.Elapsed -= handler);

            // obs.Throttle(TimeSpan.FromSeconds(1)).Subscribe(X);
            obs.Sample(TimeSpan.FromSeconds(1)).Subscribe(X);
            // obs.Subscribe(X);
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            Console.WriteLine("elapsed");
        }

        private void X(ElapsedEventArgs args)
        {
            // MessageBox.Show("asd");

            Console.WriteLine("elapsed");
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
