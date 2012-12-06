using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SliceOfPie
{
    public class UserHandler
    {
        // Instance of the dbconnector, handles all the database related methods.
        private DBConnector dbCon = DBConnector.Instance;

        // Handles the creation of folders
        private Folder folder = new Folder();

        /// <summary>
        /// Creates a new user object and stores it's values in the database
        /// </summary>
        /// <param name="name">Full name of the user</param>
        /// <param name="username">Username for the new user</param>
        /// <param name="password">New users password.</param>
        /// <returns>New user object.</returns>
        public User NewUser(string name, string username, string password)
        {
            // Create the user object.
            User user = new User(name, username, password);

            // Store users values in the database.
            dbCon.InsertUser(name, username, password);

            // Create root folder for the user
            folder.CreateRootFolder(user);

            // Return user document.
            return user;
        }

        /// <summary>
        /// Retreives a user from the database and creates a new user object.
        /// </summary>
        /// <param name="username">username of the user</param>
        /// <param name="password">password of the user</param>
        /// <returns>the new user object.</returns>
        public User GetUser(string username, string password)
        {
            // Get data from database.
            string[] userValues = dbCon.SelectUser(username);

            // Store the users values.
            int newId = Convert.ToInt32(userValues[0]);
            string newName = userValues[1];
            string newUsername = userValues[2];
            string newPassword = userValues[3];

            // Create user object.
            User user = new User(newId, newName, newUsername, newPassword);

            // Return user object.
            return user;
        }

        /// <summary>
        /// Deletes a user from the database.
        /// </summary>
        /// <param name="username">The username of the user to delete.</param>
        public void DeleteUser(User user)
        {
            dbCon.DeleteUserByUsername(user.username);
            folder.DeleteUserRootFolder(user);
        }

        public void CheckEditUser(string username)
        { 
            //EditUserWindow()
        }

        public void EditUser(string name, string oldPassword, string newPassword)
        { 
            //password null? same as last
        }
    }
}
