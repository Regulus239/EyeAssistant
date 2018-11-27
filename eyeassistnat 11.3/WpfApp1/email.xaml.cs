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
    /// Interaction logic for email.xaml
    /// </summary>
    public partial class email : Window
    {
        public email()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }

    public partial class Appemail : Application
    {
        private Host _hostemail;
        private WpfInteractorAgent _wpfInteractorAgentemail;

        protected override void OnStartup(StartupEventArgs e)
        {
            _hostemail = new Host();
            _wpfInteractorAgentemail = _hostemail.InitializeWpfAgent();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _hostemail.Dispose();
            base.OnExit(e);
        }
    }
}
