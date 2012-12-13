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

        /// <summary>
        /// Deletes the root folder of a user.
        /// Used when deleting a user from the system.
        /// </summary>
        /// <param name="username">Username of the user to delete.</param>
        public void DeleteUserRootFolder(User user)
        {
            string dir = "root/" + user.username;
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
            string root = "root/" + user.username + "/";
            Console.WriteLine("FOLDRE SADFSDFSADF" + path);

            if(!Directory.Exists(root + path))
            {
                Directory.CreateDirectory(root + path);
                Console.WriteLine("FOLDER.CREATED Directory");
            }

            //string[] splitPath = path.Split('/');
            //string fileName = splitPath[splitPath.Length - 1];

            //string curDir = root;

            //// Check if the directory exists.
            //// Create if it doesn't.

            //for (int i = 2; i < splitPath.Length - 2; i++)
            //{ 
            //    if(!Directory.Exists(curDir))
            //    {
            //        Directory.CreateDirectory(curDir);
            //        Console.WriteLine("CREATED FOLDER IN FOLDER CLASS");
            //    }
            //    curDir += splitPath + "/";
            //}
        }

        /// <summary>
        /// Deletes a folder.
        /// Recursively deletes a folder, all subfolders and
        /// all files that the folder might contain.
        /// </summary>
        /// <param name="user">Name of the user (used for root directory)</param>
        /// <param name="path">The folder to delete.</param>
        public void DeleteFolder(User user, string path)
        {
            string[] splittedPath = path.Split('/');
            string dir = "";

            // Check if a full path is given or just the folder name.
            if (splittedPath[0].Contains("root") && splittedPath[1].Contains(user.username))
            {
                dir = path;
            }
            else 
            {
                dir = dir = "root/" + user.username + "/" + path;
            }

            // Check if the folder exists.
            if (Directory.Exists(dir))
            {
                // Check if directory has sub directories
                while (DirHasSubfolder(dir).Count() > 0)
                {
                    // Recursively delete all subdirectories
                    foreach (string s in DirHasSubfolder(dir))
                    {
                        DeleteFolder(user, s);
                    }
                }

                // Check if a directory has any files
                while (DirHasFiles(dir).Count() > 0)
                {
                    foreach (string s in DirHasFiles(dir))
                    {
                        File.Delete(s);
                    }
                }
                Directory.Delete(dir);
            }
        }

        /// <summary>
        /// Checks if a given folder has any subdirectories.
        /// </summary>
        /// <param name="path">The folder to check</param>
        /// <returns>List of all subdirectories</returns>
        private List<string> DirHasSubfolder(string path)
        {
            List<string> folders = new List<string>();

            foreach (string s in Directory.EnumerateDirectories(path))
            {
                folders.Add(s);
            }

            return folders;
        }

        /// <summary>
        /// Check if a folder contains any files.
        /// </summary>
        /// <param name="path">The directory to check.</param>
        /// <returns>A list of all files.</returns>
        private List<string> DirHasFiles(string path)
        {
            List<string> files = new List<string>();

            foreach (string s in Directory.EnumerateFiles(path))
            {
                files.Add(s);
            }

            return files;
        }

        /// <summary>
        /// Sets the absolute path to the root directory.
        /// </summary>
        /// <returns>The absolute path to the root directory.</returns>
        public string SetRootDirectory()
        {
            string path = "root";

            string fullPath = Path.GetFullPath(path);

            return fullPath;
        }
    }
}
