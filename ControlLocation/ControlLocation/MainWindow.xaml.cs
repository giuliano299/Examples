using System.Windows;
using System.Windows.Controls;

namespace ControlLocation
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            EventManager.RegisterClassHandler(typeof(Button), MouseDownEvent, new RoutedEventHandler(OnMouseDown));
        }

        private void OnMouseDown(object sender, RoutedEventArgs e)
        {
            var element = sender as ContentControl;
            if (element != null)
            {
                ShowLocation(element);
            }
        }

        private void ShowLocation(ContentControl element)
        {
            var location = element.PointToScreen(new Point(0, 0));
            MessageBox.Show(string.Format(
                                          "{2}'s location is ({0}, {1})", 
                                          location.X, 
                                          location.Y, 
                                          element.Content));
        }
    }
}
