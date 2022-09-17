using System.Windows;
using System.Windows.Input;

namespace Nootes
{
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();

        private void Close(object sender,
                           RoutedEventArgs e) => base.Close();

        private new void MouseDown(object sender,
                                   MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
