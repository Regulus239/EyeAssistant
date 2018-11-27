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

namespace ClickWithGazeButton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
    }

    public class Button1 : Grid
    {
        Grid buttonGrid;
        //private Host _host;
        //private Tobii.Interaction.Wpf.WpfInteractor _greetingInteractor;
        //private Tobii.Interaction.Wpf.WpfInteractorAgent _interactorAgent;
        //private Tobii.Interaction.WpfInteractorProvider _interactorProvider;
        //private string Button1Name;
        //public Tobii.Interaction.Rectangle Button1Rect;
        /*public void onGazeEnters()
        {
            System.Diagnostics.Process.Start("C:\\Windows\\Notepad.exe");
        }
        public void onGazeLeaves()
        {

        }
        */
        public Button1()
        {
            buttonGrid = new Grid();
            //Tobii.Interaction.Rectangle ButtonRect = Button1Rect;
            //Button1Name = "Button1";
            //_host = new Host();
            //_interactorProvider = new Tobii.Interaction.WpfInteractorProvider
           //_interactorAgent = new Tobii.Interaction.Wpf.WpfInteractorAgent(Button1Name, _interactorProvider); // Button1Str is the name of the Grid
            //_greetingInteractor = _interactorAgent.AddInteractorFor(this); // Need to  get rid of "this"
            /*_greetingInteractor
                .WithGazeAware()
                .HasGaze(onGazeEnters) // onGazeEnters is an action
                .LostGaze(onGazeLeaves); // onGazeLeaves is an action*/
        }
    }
}
