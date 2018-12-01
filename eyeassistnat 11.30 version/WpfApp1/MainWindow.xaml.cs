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
using Tobii.Interaction;
using Tobii.Interaction.Wpf;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool HasGaze_Email, HasGaze_Notepad, HasGaze_Youtube, HasGaze_Exit, HasGaze_Browser;
        private FloatingIconWindow floatingWindow;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var grid = e.Source as Grid;
            if (null == grid) { return; } // if the named "EventSetter" Event from MainWindow.xaml is not called.
            if (HasGaze_Email)
            {
                HasGaze_Email = false; // You're leaving the button.
            }
            else
            {
                HasGaze_Email = true;        // You're entering the button.
                email sec = new email(); // Our Gaze changed function will open.
                sec.Show();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var grid = e.Source as Grid;
            if (null == grid) { return; } // if the named "EventSetter" Event from MainWindow.xaml is not called.
            if (HasGaze_Browser)
            {
                HasGaze_Browser = false; // You're leaving the button.
            }
            else
            {
                HasGaze_Browser = true;        // You're entering the button.
                //System.Diagnostics.Process.Start("C:\\Users\\anqia\\Desktop\\MicrosoftEdge.lnk");
                System.Diagnostics.Process.Start("microsoft-edge:");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var grid = e.Source as Grid;
            if (null == grid) { return; } // if the named "EventSetter" Event from MainWindow.xaml is not called.
            if (HasGaze_Youtube)
            {
                HasGaze_Youtube = false; // You're leaving the button.
            }
            else
            {
                HasGaze_Youtube = true;        // You're entering the button.
                System.Diagnostics.Process.Start("https://www.youtube.com");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var grid = e.Source as Grid;
            if (null == grid) { return; } // if the named "EventSetter" Event from MainWindow.xaml is not called.
            if (HasGaze_Exit)
            {
                HasGaze_Exit = false; // You're leaving the button.
            }
            else
            {
                HasGaze_Exit = true;        // You're entering the button.
                floatingWindow.Close();
                this.Close();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var grid = e.Source as Grid;
            if (null == grid) { return; } // if the named "EventSetter" Event from MainWindow.xaml is not called.
            if (HasGaze_Notepad)
            {
                HasGaze_Notepad = false; // You're leaving the button.
            }
            else
            {
                HasGaze_Notepad = true;        // You're entering the button.
                System.Diagnostics.Process.Start("C:\\Windows\\Notepad.exe");
            }
        }
        
        public void GetFloatingIconWindow(FloatingIconWindow mainPopup)
        {
            floatingWindow = mainPopup;
        }
    }
}
