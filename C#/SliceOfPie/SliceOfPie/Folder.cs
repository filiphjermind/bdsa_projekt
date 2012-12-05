using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SliceOfPie
{
    class Folder
    {
        /// <summary>
        /// Creates a root folder for a user.
        /// </summary>
        /// <param name="username">Name of the user who owns the folder.</param>
        public void CreateRootFolder(User user)
        {
            string dir = user.username;
            Directory.CreateDirectory(dir);
        }

        /// <summary>
        /// Creates a new directory.
        /// </summary>
        /// <param name="path">Path to the new directory.</param>
        public void CreateNewFolder(User user, string path)
        {
            string root = user.username;
            Directory.CreateDirectory(root + "/" + path);
        }
    }
}
