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
        private static Model instance;
        private string password;
        private string username;
        public static Model GetInstance()
        {
            if (instance == null)
            {
                instance = new Model();
            }
            return instance;
        }

        public Model()
        {
            IPEndPoint ipe = new IPEndPoint(Dns.GetHostEntry("localhost").AddressList[0],8080);
            Socket s = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            s.Connect(ipe);
            s.Send(Encoding.ASCII.GetBytes("Hello world"));
            //View.WriteToDocumentTextBox("Model - constructor");
            
        }

        internal void CreateDocument(string file)
        {
            System.IO.File.WriteAllText(file,"");
        }

        internal void CreateFolder(string folder)
        {
            System.IO.Directory.CreateDirectory(folder);
        }


        internal string ReadFile(string currentPath)
        {
            StreamReader streamReader = new StreamReader(currentPath);
            string text = streamReader.ReadToEnd();
            streamReader.Close();
            return text;
        }

        internal void SaveFile(string currentPath, string text)
        {
            //deletes all existing text and writes the new text
            File.WriteAllText(currentPath,text);
        }

        internal void DeleteFile(string file)
        {
            File.Delete(file);
        }

        internal void DeleteFolder(DirectoryInfo CurrentDirectoryInfo)
        {
            Directory.Delete(CurrentDirectoryInfo.FullName, true);
        }

        internal void Synchronize()
        {
            
        }

        internal void ShareDocuments(string[] users, string[] documents, string permission)
        {
            
        }

        internal void ShareFolder(string[] users, string folder, string permission)
        {
            
        }

        internal string[] GetInvitations()
        {
            return new string[]{"Morten/Eve/spreadsheet","Bergar/emacs/cheatsheet"};
        }

        internal void AcceptInvitations(string[] accepts)
        {
            
        }

        internal void SetCredentials(string user, string pass)
        {
            username = user;
            password = pass;
        }

        internal void IgnoreInvitaions(string[] ignorations)
        {
            
        }
    }
}
