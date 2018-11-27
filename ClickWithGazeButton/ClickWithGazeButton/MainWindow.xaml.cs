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

/// <summary>
/// These modules are based on three modules from the github repository https://github.com/Tobii/interaction-samples:
/// https://github.com/Tobii/interaction-samples/blob/master/WpfSamples/GazeAwareElements/MainWindow.xaml.cs - I borrowed their code structure for Event Handler functions.
/// https://github.com/Tobii/interaction-samples/blob/master/WpfSamples/GazeAwareElements/MainWindow.xaml - I borrowed their usage of EventSetter to recognize
/// the HasGazeChanged Event and to call the handler function. This was very helpful as many other github repositories had examples of this that did not work.
/// </summary>

namespace ClickWithGazeButton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// // Notice how this all has to lie in the MainWindow class. I'm not quite sure why yet.
    public partial class MainWindow : Window 
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        // Here begins the newly added code to call functions if the window is looked on.
        public void GazeChangedFunction()
        {
            System.Diagnostics.Process.Start("C:\\Windows\\Notepad.exe"); // This opens Notepad if the function is called.
        }
        /// <summary>
        /// Here there are two versions of the same function each with different names.
        /// This is to illustrate how two Grids can have different functions if either recieves your gaze.
        /// 
        /// Refer to line 13 (Notedpad_OnHasGazeChanged) and line 26 (Instruction_OnHasGazeChanged)in MainWindow.xaml to see how each is used in the .xaml file.
        /// Each is a Handler for an Event, the event being tobii:Behaviors.HasGazeChanged which corresponds to looking into the Grid which is colored black.
        /// 
        /// The functions are glitchy (in that multiple windows of Notepad tend to open) because HasGazeChanged corresponds the Gaze enter the Grid
        /// as well as the Gaze leaving the Grid. So Notepad is guaranteed to open twice if you look inside  the Grid. If you look at the edge of the box, you basically enter and exit
        /// many times due to your eye twitches so that Notepad opens many times. I will look into having OnGazeEnter  (don't know if this exists)  or something like it be the event
        /// which calls our Handler functions.
        /// 
        /// The other option is implementing "dwell clicking" so that the Gaze must "dwell" inside the grid for sometime for the Handler to be called.
        /// </summary>
        private void Notepad_OnHasGazeChanged(object sender, RoutedEventArgs e) 
        {
            var textBlock = e.Source as Grid;
            if (null == textBlock) { return; } // if the named "EventSetter" Event from MainWindow.xaml is not called.
            GazeChangedFunction(); // Our Gaze changed function will open.
        }
        private void Instruction_OnHasGazeChanged(object sender, RoutedEventArgs e)
        {
            var textBlock = e.Source as Grid;
            if (null == textBlock) { return; }
            GazeChangedFunction();
        }
    }

}
