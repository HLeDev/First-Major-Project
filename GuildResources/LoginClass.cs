using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildResources
{
    public class LoginClass
    {
        //now to create a login credential
        Dictionary<string, string> LoginCreds; //creating key and string pair for credential

        public LoginClass()
        {
            LoginCreds = new Dictionary<string, string>(); //making variable public for uses
            LoginCreds.Add("Admin", "admin"); //pairing password to key which is admin, admin can see everything
        }
        public bool LogginIn(string username, string password)
        {
            //checking if password is enterred correctly and matches the "key" which is username
            string enterredPassword;
            if (LoginCreds.TryGetValue(username, out enterredPassword))
            {
                if (enterredPassword == password)
                {
                    return true; //if password is entered correctly, return true
                }
                else
                {
                    return false; //if password is enterred incorrect, return false
                }
            }
            else { return false; } //if no password, return false
        }
    }
}
