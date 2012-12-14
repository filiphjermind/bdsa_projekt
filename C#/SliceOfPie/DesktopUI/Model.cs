﻿using DesktopUI.SliceOfPieReference;
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

            TcpClient client = new TcpClient();

            //localhost
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3000);

            client.Connect(serverEndPoint);

            NetworkStream clientStream = client.GetStream();

            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes("Hello Server!");

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();

            /*IPEndPoint ipe = new IPEndPoint(Dns.GetHostEntry("localhost").AddressList[0],8080);
            Socket s = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            s.Connect(ipe);
            s.Send(Encoding.ASCII.GetBytes("Hello world"));*/
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
            using (ClientSystemFacade2Client proxy = new ClientSystemFacade2Client())
            {
                proxy.ShareDocuments(password,username,users,documents,permission);

            }
        }

        internal void ShareFolder(string[] users, string folder, string permission)
        {
            using (ClientSystemFacade2Client proxy = new ClientSystemFacade2Client())
            {
                proxy.ShareFolder(password, username, users, folder, permission);

            }
        }

        internal string[] GetInvitations()
        {
            string[] result;
            using (ClientSystemFacade2Client proxy = new ClientSystemFacade2Client())
            {
                result = proxy.GetInvitations(password, username);

            }
            return result;
        }

        internal void AcceptInvitations(string[] accepts)
        {
            using (ClientSystemFacade2Client proxy = new ClientSystemFacade2Client())
            {
                proxy.AcceptInvitations(password, username, accepts);

            }
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
