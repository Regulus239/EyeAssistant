using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Tobii.Interaction;
using Tobii.Interaction.Wpf;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
            private Host _host;
            private WpfInteractorAgent _wpfInteractorAgent;
            private FloatingIconWindow mainPopup;
            public MainWindow mainWindow;
            protected override void OnStartup(StartupEventArgs e)
            {
                _host = new Host();
                _wpfInteractorAgent = _host.InitializeWpfAgent();
                mainWindow = new MainWindow();
                mainWindow.Show();
                mainPopup = new FloatingIconWindow(mainWindow);
                mainPopup.Width = 100;
                mainPopup.Height = 100;
                mainPopup.Show();
        }

            protected override void OnExit(ExitEventArgs e)
            {
                _host.Dispose();
                this.mainPopup.Close();
                base.OnExit(e);
            }

        /*private void Application_Startup(object sender, StartupEventArgs e)
        {
            FloatingIconWindow mainPopup = new FloatingIconWindow();
            mainPopup.Width = 100;
            mainPopup.Height = 100;
            mainPopup.Show();
        }*/
    }
}
