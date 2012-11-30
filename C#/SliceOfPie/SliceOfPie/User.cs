using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SliceOfPie
{
    class User
    {
        /// <summary>
        /// Unique id of the user
        /// </summary>
        public int id
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }

        public string username
        {
            get;
            set;
        }

        public string password
        {
            get;
            set;
        }

        public User(string name, string username, string password)
        {
            this.name = name;
            this.password = password;
            this.username = username;
            //this.id = ??
        }
    }
}
