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
    /// Interaction logic for OneIntro.xaml
    /// </summary>
    public partial class OneIntro : UserControl
    {
        public OneIntro()
        {
            InitializeComponent();
        }

        private void btnMyGuild_Click(object sender, RoutedEventArgs e)
        {
            var Window = (MainWindow)Application.Current.MainWindow;
            Window.myControls.Content = new TwoLogin();
        }

        private void btnMyLinkedIn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/hung-le-466049211/");
        }

        private void btnMyGitHub_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/HLeDev?tab=repositories");
        }

        private void btnMyYouTube_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UC8JVhM5O_lSm5KW9BRsuVbw");
        }

        private void btnMyPower_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
