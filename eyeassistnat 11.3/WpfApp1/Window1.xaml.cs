using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    
    public partial class FloatingIconWindow : Window
    {
        MainWindow mainWindow;
        public FloatingIconWindow(MainWindow window)
        {
            InitializeComponent();
            mainWindow = window;
            this.Topmost = true;
        }

        private void GetAttention(object sender, RoutedEventArgs e)
        {
            var grid = e.Source as Grid;
            if (null == grid) { return; } // if the named "EventSetter" Event from MainWindow.xaml is not called.
            mainWindow.Activate();
        }

    }
    public partial class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.ComponentModel.IContainer components;
        public Form1()
        {        
           
            this.components = new System.ComponentModel.Container();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();

            //Initialize contextMenu1
            this.contextMenu1.MenuItems.AddRange(
                    new System.Windows.Forms.MenuItem[] { this.menuItem1 });

            // Initialize menuItem1
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "E&xit";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);

            //Set up how the form should be displayed.
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Text = "Notify Icon Example";

            // Create the NotifyIcon.
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);

            // The Icon property sets the icon that will appear
            // in the systray for this application.
            notifyIcon1.Icon = new Icon("C:\\Users\\jsnea\\source\\repos\\EyeAssistant\\eyeassistnat 11.3\\border_48.ico");

            // The ContextMenu property sets the menu that will
            // appear when the systray icon is right clicked.
            notifyIcon1.ContextMenu = this.contextMenu1;

            // The Text property sets the text that will be displayed,
            // in a tooltip, when the mouse hovers over the systray icon.
            notifyIcon1.Text = "Form1 (NotifyIcon example)";
            notifyIcon1.Visible = true;
        }
        private void menuItem1_Click(object Sender, EventArgs e)
        {
            // Close the form, which closes the application.
            //this.Close();
        }
        
    }
   
}
