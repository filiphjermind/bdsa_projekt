using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SliceOfPie
{
    public class UserAuth
    {
        private DBConnector DBcon;
        public static UserAuth instance;

        public UserAuth()
        {
            DBcon = DBConnector.Instance;
            

        }
        internal static UserAuth GetInstance()
        {
            if (instance == null)
            {
                instance = new UserAuth();
            }
            return instance;
        }

        public bool CheckUserAndPassword(string userName, string password)
        {
            string[] tmpUser = DBcon.SelectUser(userName);

            if (tmpUser[3] == userName && tmpUser[4] == password) return true;
            else return false;
        }

        public User Authenticate(string username, string password)
        {
            User user = DBcon.AuthenticateUser(username, password);
            return user;
        }

       
    }
}
