namespace OnRendered
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Diagnostics;
    using System.Threading;
    using System.Windows.Threading;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() => Trace.WriteLine("DONE!", "Rendering")), DispatcherPriority.ContextIdle, null);
            Trace.WriteLine("Loaded", "Window");
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            Button button = (Button)sender;
            Trace.WriteLine("Size has been changed", button.Name);
        }
    }
}
