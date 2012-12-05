using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SliceOfPie
{
    public class UserAuth
    {
        private DBConnector DBcon;

        public UserAuth()
        {
            DBcon = DBConnector.Instance;
        }

        public bool CheckUserAndPassword(string userName, string password)
        {
            string[] tmpUser = DBcon.SelectUser(userName);

            if (tmpUser[3] == userName && tmpUser[4] == password) return true;
            else return false;
        }
    }
}
