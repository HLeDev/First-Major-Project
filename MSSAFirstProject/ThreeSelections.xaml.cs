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

namespace MSSAFirstProject
{
    /// <summary>
    /// Interaction logic for ThreeSelections.xaml
    /// </summary>
    public partial class ThreeSelections : UserControl
    {
        public ThreeSelections()
        {
            InitializeComponent();
            buttonsDisplays();
        }

        private void btnMvPGuild_Click(object sender, RoutedEventArgs e)
        {
            var Window = (MainWindow)Application.Current.MainWindow;
            Window.myControls.Content = new FourMvP();
        }

        private void btnMDGuild_Click(object sender, RoutedEventArgs e)
        {
            var Window = (MainWindow)Application.Current.MainWindow;
            Window.myControls.Content = new FiveMD();
        }

        private void btnLogOff_Click(object sender, RoutedEventArgs e)
        {
            var Window = (MainWindow)Application.Current.MainWindow;
            Window.myControls.Content = new TwoLogin();
        }

        //Create an async event to hide buttons for a specific amount of time
        async void buttonsDisplays()
        {
            //Buttons is now hidden
            btnMvPGuild.Visibility = Visibility.Hidden;
            btnMDGuild.Visibility = Visibility.Hidden;
            btnLogOff.Visibility = Visibility.Hidden;
            
            //Wait 6 seconds
            await Task.Delay(6000);

            //Buttons become visible
            btnMvPGuild.Visibility = Visibility.Visible;
            btnMDGuild.Visibility = Visibility.Visible;
            btnLogOff.Visibility = Visibility.Visible;


        }
    }
}
