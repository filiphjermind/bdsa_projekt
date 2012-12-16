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
        private static Model instance;
        private string password;
        private string username;

        private TcpClient client;
        private NetworkStream clientStream;
        private string rootDirectoryPath;

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

            

            /*IPEndPoint ipe = new IPEndPoint(Dns.GetHostEntry("localhost").AddressList[0],8080);
            Socket s = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            s.Connect(ipe);
            s.Send(Encoding.ASCII.GetBytes("Hello world"));*/
            //View.WriteToDocumentTextBox("Model - constructor");
            
        }

        //internal string MessageServer()
        //{
        //    client = new TcpClient();

        //    //localhost
        //    IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3000);

        //    client.Connect(serverEndPoint);

        //    NetworkStream clientStream = client.GetStream();

        //    ASCIIEncoding encoder = new ASCIIEncoding();
        //    byte[] buffer = encoder.GetBytes("Hello Server!");

        //    clientStream.Write(buffer, 0, buffer.Length);
        //    clientStream.Flush();

        //    return RecieveMessage();
        //}

        //internal string RecieveMessage()
        //{
        //    NetworkStream clientStream = client.GetStream();
        //    ASCIIEncoding encoder = new ASCIIEncoding();

        //    byte[] message = new byte[4096];
        //    int bytesRead;

        //    while (true)
        //    {
        //        bytesRead = 0;

        //        try
        //        {
        //            //blocks until it recieves a message
        //            bytesRead = clientStream.Read(message, 0, 4096);
        //        }
        //        catch{return null;}

        //        if (bytesRead == 0)return null;


        //        return encoder.GetString(message, 0, bytesRead);

        //    }
        //}

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
            string[][] files = GetAllFilesFromDisk().ToArray();
            using (ClientSystemFacade2Client proxy = new ClientSystemFacade2Client())
            {
                files = proxy.Synchronize(username, password, files);
            }
            SaveAllFilesToDisk(files);
        }

        private List<string[]> GetAllFilesFromDisk()
        {
            List<string[]> files = getFilesInDirectory(rootDirectoryPath);
            return files;
        }

        private List<string[]> getFilesInDirectory(string path)
        {
            List<string[]> result = new List<string[]>();
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles();
            foreach(FileInfo fi in files)
            {
                //owner, content, path
                string[] s = new string[3];
                s[0] = username;
                s[1] = ReadFile(fi.FullName);
                s[2] = fi.FullName.Substring(fi.FullName.IndexOf("SliceOfPie")+10);
                result.Add(s);
            }
            foreach (DirectoryInfo di2 in di.GetDirectories())
            {
                result.AddRange(getFilesInDirectory(di2.FullName));
            }
            return result;
        }

        private void SaveAllFilesToDisk(string[][] files)
        {
            foreach (string[] file in files)
            {
                SaveFile(file[2], file[1]);
            }
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

        internal void SetRootDirectory(string p)
        {
            rootDirectoryPath = p;
        }
    }
}
