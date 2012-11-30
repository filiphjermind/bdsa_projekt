using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SliceOfPie
{
    class System
    {
        private Folder folder = new Folder();

        /// <summary>
        /// Creates a new user.
        /// Stores the user in the database.
        /// Creates a root folder for the user.
        /// </summary>
        /// <param name="name">Name of the user</param>
        /// <param name="username">Username of the user</param>
        /// <param name="password">Password for the user.</param>
        /// <returns>The newly created user.</returns>
        public User NewUser(string name, string username, string password)
        {
            User user = new User(name, username, password);
            folder.CreateRootFolder(username);
            return user;
        }
    }
}
