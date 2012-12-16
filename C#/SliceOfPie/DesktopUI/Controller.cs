using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DesktopUI
{
    class Controller
    {
        private static Controller instance;

        /// <summary>
        /// This method returns a instance of this class. 
        /// If no instance is created the method then creates one.
        /// </summary>
        /// <returns></returns>
        public static Controller GetInstance()
        {
            if(instance == null){
                instance = new Controller();
            }
            return instance;
        }
        /// <summary>
        /// Creates a document
        /// </summary>
        /// <returns></returns>
        internal void CreateDocument(string file)
        {
            Model.GetInstance().CreateDocument(file);
        }
        /// <summary>
        /// Creates a folder
        /// </summary>
        internal void CreateFolder(string folder)
        {
            Model.GetInstance().CreateFolder(folder);
        }
        /// <summary>
        /// Read a file from the disk
        /// </summary>
        /// <returns></returns>
        internal string ReadFile(string currentPath)
        {
            return Model.GetInstance().ReadFile(currentPath);
        }
        /// <summary>
        /// Saves a file
        /// </summary>
        /// <returns></returns>
        internal void SaveFile(string currentPath, string text)
        {
            Model.GetInstance().SaveFile(currentPath, text);
        }
        /// <summary>
        /// Deletes a file
        /// </summary>
        /// <returns></returns>
        internal void DeleteFile(string file)
        {
            Model.GetInstance().DeleteFile(file);
        }
        /// <summary>
        /// Deletes a folder
        /// </summary>
        /// <returns></returns>
        internal void DeleteFolder(DirectoryInfo CurrentDirectoryInfo)
        {
            Model.GetInstance().DeleteFolder(CurrentDirectoryInfo);
        }
        /// <summary>
        /// Synchronize local directory with the servers directory
        /// </summary>
        /// <returns></returns>
        internal void Synchronize()
        {
            Model.GetInstance().Synchronize();
        }
        /// <summary>
        /// Share documents with another user
        /// </summary>
        /// <returns></returns>
        internal void ShareDocuments(string[] users, string[] documents, string permission)
        {
            Model.GetInstance().ShareDocuments(users, documents, permission);
        }
        /// <summary>
        /// Share folder with another user
        /// </summary>
        /// <returns></returns>
        internal void ShareFolder(string[] users, string folder, string permission)
        {
            Model.GetInstance().ShareFolder(users, folder, permission);
        }
        /// <summary>
        /// Get inviations for this user
        /// </summary>
        /// <returns></returns>
        internal string[] GetInvitations()
        {
            return Model.GetInstance().GetInvitations();
        }
        /// <summary>
        /// Accept given invitations
        /// </summary>
        /// <returns></returns>
        internal void AcceptInvitations(string[] accepts)
        {
            Model.GetInstance().AcceptInvitations(accepts);
        }
        /// <summary>
        /// Sets the user credentials
        /// </summary>
        /// <returns></returns>
        internal void SetCredentials(string user, string pass)
        {
            Model.GetInstance().SetCredentials(user, pass);
        }
        /// <summary>
        /// Ignore given invitations
        /// </summary>
        /// <returns></returns>
        internal void IgnoreInvitations(string[] ignorations)
        {
            Model.GetInstance().IgnoreInvitaions(ignorations);
        }

        internal void SetRootDirectory(string p)
        {
            Model.GetInstance().SetRootDirectory(p);
        }
    }
}
