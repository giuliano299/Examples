namespace Timers
{
    using System;
    using System.Threading;
    using System.Windows;
    using System.Windows.Threading;

    public partial class MainWindow : Window
    {
        private DispatcherTimer dispatcherTimer;

        private Timer timer;

        public MainWindow()
        {
            InitializeComponent();

            dispatcherTimer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 1) };
            dispatcherTimer.Tick += OnDispatcherTimer;

            timer = new Timer(OnTimer, null, Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
        }

        private void StartDispatcher(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Start();
            ShowTime();
            EnableStartButtons(false);
        }

        private void StartTimer(object sender, RoutedEventArgs e)
        {
            timer.Change(TimeSpan.Zero, new TimeSpan(0, 0, 1));
            EnableStartButtons(false);
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            timer.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
            dispatcherTimer.Stop();
            EnableStartButtons(true);
            clock.Content = string.Empty;
        }

        private void EnableStartButtons(bool enabled)
        {
            startDispatcher.IsEnabled = enabled;
            startTimer.IsEnabled = enabled;
            reset.IsEnabled = !enabled;
        }

        private void OnDispatcherTimer(object sender, EventArgs e)
        {
            ShowTime();
        }

        private void OnTimer(object state)
        {
            Dispatcher.Invoke(() => ShowTime());
        }

        private void ShowTime()
        {
            clock.Content = DateTime.Now.ToString("hh:mm:ss");
        }
    }
}
