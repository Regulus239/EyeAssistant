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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// This class definition is for our Floating Window which will bring ourUI to the Foreground if another application is opened.
    /// This Window always floats above other windows so that it is always accessible.
    /// </summary>
    public partial class FloatingIconWindow : Window
    {
        MainWindow mainWindow; // you will notice that our MainWindow is passed to the FloatingIconWindow in the constructor.
        public FloatingIconWindow(MainWindow window) // Constructor
        {
            InitializeComponent();
            mainWindow = window; // This is necessary for the GetAttention function.
            this.Topmost = true; // Setting Topmost to true allows the Window to float above other Windows that the user may open.
        }

        private void GetAttention(object sender, RoutedEventArgs e) // This will bring the MainWindow to the front when FloatingIconWindow recieves your gaze.
        {
            var grid = e.Source as Grid;
            if (null == grid) { return; } // if the named "EventSetter" Event from MainWindow.xaml is not called.
            mainWindow.Activate();  // Activate() brings the Window to the foreground. So in this case, it brings our MainWindow to the foreground.
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {

        }
    }
}
