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
using Tobii.Interaction;
using Tobii.Interaction.Wpf;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for particularEmailWindow.xaml
    /// </summary>
    
    public partial class particularEmailWindow : Window
    {
        List<Dictionary<string, string>> emailDictList;
        bool HasGaze_Exit = false;
        public particularEmailWindow()
        {
            InitializeComponent();
        }

        public void SetDictList(List<Dictionary<string, string>> dictList, int index)
        {
            emailDictList = dictList;
            toTbox.Text = emailDictList[index]["To"];
            fromTbox.Text = emailDictList[index]["From"];
            dateRecievedTbox.Text = emailDictList[index]["Date"];
            subjectTbox.Text = emailDictList[index]["Subject"];
            bodyTbox.Text = emailDictList[index]["Body"];
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
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
                this.Close();
            }
        }
    }
}
