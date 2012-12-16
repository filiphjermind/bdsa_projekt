using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SliceOfPie
{
    public class User
    {
        /// <summary>
        /// Unique id of the user (set by the database.)
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

        // Stores the users document objects.
		// Deprecated
        public List<Document> documents = new List<Document>();

        // Used when creating a new user.
        public User(string name, string username, string password)
        {
            this.name = name;
            this.password = password;
            this.username = username;
        }

        // Used when creating a user object from an existing user stored in the database.
        public User(int id, string name, string username, string password)
        {
            this.id = id;
            this.name = name;
            this.username = username;
            this.password = password;
        }

        public override string ToString()
        {
            string user = "Name: " + this.name + "\nUsername: " + this.username + "\nPassword: " + this.password;
            return user;
        }
    }
}
