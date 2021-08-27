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
using GuildResources;

namespace MSSAFirstProject
{
    /// <summary>
    /// Interaction logic for TwoLogin.xaml
    /// </summary>
    public partial class TwoLogin : UserControl
    {
        LoginClass login; //make sure the class in the class library is set to "public class"
        public TwoLogin()
        {
            InitializeComponent();

            login = new LoginClass(); //making login accessible for this class
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            if (login.LogginIn(txtUserName.Text, pwboxPassword.Password))
            {
                //need to create a new window to make this one close and display new window
                //once the new WPF window is created, call it
                var Window = (MainWindow)Application.Current.MainWindow;
                Window.myControls.Content = new ThreeSelections();
            }
            else
            {
                MessageBox.Show("The username or password is incorrect"); //display messagebox if either username or password is incorrect
                //refer to LoginClass in GuildResources Class Library to see login info
                txtUserName.Clear(); //clear out textbox for re-enter
                pwboxPassword.Clear(); //clear out password box

            }
            //Once everything is done for this window Test to it to make sure you can login and put in wrong password to make sure else statement
            //is working as intended
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            var Window = (MainWindow)Application.Current.MainWindow;
            Window.myControls.Content = new OneIntro();
        }
    }
}
