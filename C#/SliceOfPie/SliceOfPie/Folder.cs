using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SliceOfPie
{
    public class Folder
    {
        /// <summary>
        /// Creates a root folder for a user.
        /// </summary>
        /// <param name="username">Name of the user who owns the folder.</param>
        public void CreateRootFolder(User user)
        {
            string dir = "root/" + user.username;
            Directory.CreateDirectory(dir);
        }

        public void DeleteUserRootFolder(string username)
        {
            string dir = "root/" + username;
            if (Directory.Exists(dir)) {
                Directory.Delete(dir);
            }
        }

        /// <summary>
        /// Creates a new directory.
        /// </summary>
        /// <param name="path">Path to the new directory.</param>
        public void CreateNewFolder(User user, string path)
        {
            string root = "root/" + user.username;
            Directory.CreateDirectory(root + "/" + path);
        }

        public void DeleteFolder(User user, string path)
        {
            string dir = "root/" + user.username + "/" + path;
            if (Directory.Exists(dir))
            {
                Directory.Delete(dir);
            }
        }
    }
}
