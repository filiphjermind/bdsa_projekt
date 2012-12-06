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

        public static Controller GetInstance()
        {
            if(instance == null){
                instance = new Controller();
            }
            return instance;
        }

        internal void CreateDocument(string file)
        {
            Model.GetInstance().CreateDocument(file);
        }

        internal void CreateFolder(string folder)
        {
            Model.GetInstance().CreateFolder(folder);
        }

        internal string ReadFile(string currentPath)
        {
            return Model.GetInstance().ReadFile(currentPath);
        }

        internal void SaveFile(string currentPath, string text)
        {
            Model.GetInstance().SaveFile(currentPath, text);
        }

        internal void DeleteFile(string file)
        {
            Model.GetInstance().DeleteFile(file);
        }

        internal void DeleteFolder(DirectoryInfo CurrentDirectoryInfo)
        {
            Model.GetInstance().DeleteFolder(CurrentDirectoryInfo);
        }

        internal void Synchronize(string username, string password)
        {
            Model.GetInstance().Synchronize(username,password);
        }

        internal void ShareDocuments(string[] users, string[] documents)
        {
            Model.GetInstance().ShareDocuments(users, documents);
        }

        internal void ShareFolder(string[] users, string folder)
        {
            Model.GetInstance().ShareFolder(users, folder);
        }

        internal string[] GetInvitations()
        {
            return Model.GetInstance().GetInvitations();
        }

        internal void AcceptInvitations(string[] accepts)
        {
            Model.GetInstance().AcceptInvitations(accepts);
        }

        internal void SetCredentials(string user, string pass)
        {
            Model.GetInstance().SetCredentials(user, pass);
        }

        internal void IgnoreInvitations(string[] ignorations)
        {
            Model.GetInstance().IgnoreInvitaions(ignorations);
        }
    }
}
