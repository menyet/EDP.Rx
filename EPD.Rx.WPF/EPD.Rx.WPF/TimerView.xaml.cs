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

        Timer timer;

        public TimerView()
        {
            InitializeComponent();

            toggle.Checked += Toggle_Checked;
            toggle.Unchecked += Toggle_Unchecked;

            timer = new Timer();
            timer.Interval = 20;

            timer.Elapsed += TimerOnElapsed;
            timer.Enabled = true;
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            Console.WriteLine("elapsed");
        }

        private void X(ElapsedEventArgs args)
        {
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
