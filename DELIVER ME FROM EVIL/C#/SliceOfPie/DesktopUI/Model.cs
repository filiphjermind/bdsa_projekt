using DesktopUI.SliceOfPieReference;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DesktopUI
{
    class Model
    {
        //the instance used for singleton
        private static Model instance;
        //the users credentials
        private string password;
        private string username;
        //the path to the local root directory
        private string rootDirectoryPath;

        /// <summary>
        /// Method to get the singleton instance
        /// </summary>
        /// <returns></returns>
        public static Model GetInstance()
        {
            if (instance == null)
            {
                instance = new Model();
            }
            return instance;
        }

        /// <summary>
        /// Creates a document on the useres computer
        /// </summary>
        /// <param name="file"></param>
        internal void CreateDocument(string file)
        {
            System.IO.File.WriteAllText(file,"");
        }

        /// <summary>
        /// Creates a folder on the users computer
        /// </summary>
        /// <param name="folder"></param>
        internal void CreateFolder(string folder)
        {
            System.IO.Directory.CreateDirectory(folder);
        }

        /// <summary>
        /// Reads a file from the users computer
        /// </summary>
        /// <param name="currentPath"></param>
        /// <returns></returns>
        internal string ReadFile(string currentPath)
        {
            StreamReader streamReader = new StreamReader(currentPath);
            string text = streamReader.ReadToEnd();
            streamReader.Close();
            return text;
        }

        /// <summary>
        /// Saves a file on the users computer
        /// </summary>
        /// <param name="currentPath"></param>
        /// <param name="text"></param>
        internal void SaveFile(string currentPath, string text)
        {
            try
            {
                //deletes all existing text and writes the new text
                File.WriteAllText(currentPath, text);
            }
            catch(IOException ex){}
        }

        /// <summary>
        /// Deletes a file on the users computer
        /// </summary>
        /// <param name="file"></param>
        internal void DeleteFile(string file)
        {
            File.Delete(file);
        }

        /// <summary>
        /// Deletes a folder on the users computer
        /// </summary>
        /// <param name="CurrentDirectoryInfo"></param>
        internal void DeleteFolder(DirectoryInfo CurrentDirectoryInfo)
        {
            Directory.Delete(CurrentDirectoryInfo.FullName, true);
        }

        /// <summary>
        /// This method takes care of synchronizing the users local files with 
        /// the files on the server. First it reads the files from the disk, then
        /// it sends them to the server and at last it saves the retrieved files from
        /// the server to the local disk.
        /// </summary>
        internal void Synchronize()
        {
            string[][] files = GetAllFilesFromDisk().ToArray();
            using (ClientSystemFacade2Client proxy = new ClientSystemFacade2Client())
            {
                files = proxy.Synchronize(username, password, files);
            }
            SaveAllFilesToDisk(files);
        }

        /// <summary>
        /// This method takes care of retrieving all local files in the root directory and
        /// all subdirectories
        /// </summary>
        /// <returns></returns>
        private List<string[]> GetAllFilesFromDisk()
        {
            List<string[]> files = getFilesInDirectory(rootDirectoryPath);
            return files;
        }

        /// <summary>
        /// This method returns all the files in a directory. It is called recursivly
        /// so all the files in the subdirectories are also added to the list.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private List<string[]> getFilesInDirectory(string path)
        {
            List<string[]> result = new List<string[]>();
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles();
            foreach(FileInfo fi in files)
            {
                //The different propperties of the file is added to an array in
                //the following order:
                // 0. owner,1. content, 2. path, 3. date modified
                string[] s = new string[4];
                s[0] = username;
                s[1] = ReadFile(fi.FullName);
                s[2] = fi.FullName.Substring(fi.FullName.IndexOf("SliceOfPie")+10);
                s[3] = fi.LastWriteTime.ToShortTimeString();
                result.Add(s);
            }
            foreach (DirectoryInfo di2 in di.GetDirectories())
            {
                result.AddRange(getFilesInDirectory(di2.FullName));
            }
            return result;
        }

        /// <summary>
        /// This method saves all the files that is passed as argument to the local disk.
        /// </summary>
        /// <param name="files"></param>
        private void SaveAllFilesToDisk(string[][] files)
        {
            foreach (string[] file in files)
            {
                try
                {
                    System.IO.File.WriteAllText(rootDirectoryPath + @"\" + file[2].Substring(0), file[1]);
                }
                catch (NullReferenceException ex) { }

            }
        }

        /// <summary>
        /// This method takes care of sharing documents
        /// </summary>
        /// <param name="users"></param>
        /// <param name="documents"></param>
        /// <param name="permission"></param>
        internal void ShareDocuments(string[] users, string[] documents, string permission)
        {
            Synchronize();

            using (ClientSystemFacade2Client proxy = new ClientSystemFacade2Client())
            {
                foreach (string doc in documents)
                {
                    proxy.ShareDocuments(username, password, users, doc, permission);
                }
                

            }
        }

        /// <summary>
        /// This method takes care of sharing a folder by calling the server.
        /// </summary>
        /// <param name="users"></param>
        /// <param name="folder"></param>
        /// <param name="permission"></param>
        internal void ShareFolder(string[] users, string folder, string permission)
        {
            using (ClientSystemFacade2Client proxy = new ClientSystemFacade2Client())
            {
                proxy.ShareFolder(password, username, users, folder, permission);

            }
        }

        /// <summary>
        /// This method takes care of retriving the current invitations to the user.
        /// </summary>
        /// <returns></returns>
        internal string[] GetInvitations()
        {
            string[] result;
            using (ClientSystemFacade2Client proxy = new ClientSystemFacade2Client())
            {
                result = proxy.GetInvitations(password, username);

            }
            return result;
        }


        /// <summary>
        /// This method takes care of letting the user accept invitations by calling the
        /// server.
        /// </summary>
        /// <param name="accepts"></param>
        internal void AcceptInvitations(string[] accepts)
        {
            using (ClientSystemFacade2Client proxy = new ClientSystemFacade2Client())
            {
                proxy.AcceptInvitations(password, username, accepts);

            }
        }

        /// <summary>
        /// This method saves the credintials of the current user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        internal void SetCredentials(string user, string pass)
        {
            username = user;
            password = pass;
        }

        internal void IgnoreInvitaions(string[] ignorations)
        {
            
        }

        /// <summary>
        /// THis method sets the path of the root directory.
        /// </summary>
        /// <param name="p"></param>
        internal void SetRootDirectory(string p)
        {
            rootDirectoryPath = p;
        }
    }
}
