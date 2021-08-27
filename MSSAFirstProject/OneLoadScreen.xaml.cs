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
using System.Windows.Threading;

namespace MSSAFirstProject
{
    /// <summary>
    /// Interaction logic for OneLoadScreen.xaml
    /// </summary>
    public partial class OneLoadScreen : UserControl
    {
        public OneLoadScreen()
        {
            InitializeComponent();
            media1.Source = new Uri(Environment.CurrentDirectory + @"\check.gif"); //calling the file from bin folder
            //need to create timer to start/stop loading gif

            LoadingScreen();
        }

        DispatcherTimer timer = new DispatcherTimer(); //create a dispatch time thread

        //Create and event for loading and start
        void LoadingScreen()
        {
            timer.Tick += timer_tick;
            timer.Interval = new TimeSpan(0, 0, 6); //can be set to hour, min, sec
            timer.Start();
        }

        //create tick event
        private void timer_tick(object sender, EventArgs e)
        {
            timer.Stop(); //this is the stop the event
            

            //once the timer stop, next window load
            var Window = (MainWindow)Application.Current.MainWindow;
            Window.myControls.Content = new OneIntro();
        }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            //making gif go on and on

            media1.Position = new TimeSpan(0, 0, 1); //when media ended, it will reset back to 1
            media1.Play(); //play over n over again
        }
    }
}
