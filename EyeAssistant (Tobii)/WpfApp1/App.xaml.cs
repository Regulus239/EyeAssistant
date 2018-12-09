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
    /// 
    /// I moved our App code to App.xaml.cs. For some reason it was chilling out in MainWindow.xaml.cs.
    /// While it will still exist in the same namespace (WpfApp1), its just good design to keep the class in this separate App.xaml.cs
    /// file rather than our MainWindow file. I've moved it here for this reason.
    /// </summary>
    public partial class App : Application
    {
        private Host _host;     // (1)
        private WpfInteractorAgent _wpfInteractorAgent; // (2)
        // (1) and (2) are necessary to use Tobii with your Wpf application. See Tobii's documentation for more info: 
        // https://developer.tobii.com/consumer-eye-trackers/core-sdk/getting-started/

        // Our two Windows
        private FloatingIconWindow mainPopup; // Window for bringing the MainWindow back to the foreground
        public MainWindow mainWindow;       // obviously the window containing our main menu

        protected override void OnStartup(StartupEventArgs e)
        {
            _host = new Host();
            _wpfInteractorAgent = _host.InitializeWpfAgent(); // code necessary to use Tobii. See note above.

            // Creating and displaying our two windows. We do not use StartupURI in App.xaml to start up either window.
            // This is because our FloatingIconWindow needs access to the MainWindow,
            // which only seems possible if I can pass the MainWindow as a parameter in the constructor for FloatingIconWindow
            mainWindow = new MainWindow();
            mainWindow.Show();
            mainPopup = new FloatingIconWindow(mainWindow);
            mainWindow.GetFloatingIconWindow(mainPopup);
            mainPopup.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();    // Disconnects Tobii
            this.mainPopup.Close(); // closes FloatingWindow. (this still doesn't work yet.
            base.OnExit(e);
        }

    }
}
