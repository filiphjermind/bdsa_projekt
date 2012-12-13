using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SliceOfPie;

namespace WebUI
{
    public partial class Signup : System.Web.UI.Page
    {
        ClientSystemFacade facade = ClientSystemFacade.GetInstance();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignUp(object sender, EventArgs e)
        {
            string name = fullNameSB.Text;
            string username = usernameSB.Text;
            string password = passwordSB.Text;
            string passwordRetype = retypePasswordSB.Text;

            // Check if both passwords match
            if (password.Equals(passwordRetype))
            {
                User user = facade.NewUser(name, username, password);
                // Check if the user was created correctly.
                if (user.name.Equals(name) && user.username.Equals(username) && user.password.Equals(password))
                {
                    Response.Write("User " + username + " was created successfully.\nPlease log in on the main screen");
                }
                else 
                {
                    Response.Write("An error has occurred. Please try again!");
                }
            }
            else 
            {
                Response.Write("Passwords don't match. Please try again.");
            }
        }
    }
}