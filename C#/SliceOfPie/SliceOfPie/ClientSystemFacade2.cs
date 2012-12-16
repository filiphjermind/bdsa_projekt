using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SliceOfPie
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ClientSystemFacade2" in both code and config file together.
    public class ClientSystemFacade2 : IClientSystemFacade2
    {
        private UserAuth userAuth = UserAuth.GetInstance();
        private Engine engine = new Engine();

        private static ClientSystemFacade2 instance;



        public static ClientSystemFacade2 GetInstance()
        {

            if (instance == null)
            {
                instance = new ClientSystemFacade2();
            }
            return instance;
        }

        private void initialize()
        {
            IPEndPoint ipe = new IPEndPoint(Dns.GetHostEntry("localhost").AddressList[0], 8080);
            TcpListener tcpServerListener = new TcpListener(ipe);
            tcpServerListener.Start();
            Console.WriteLine("Server Started");
            //block tcplistener to accept incoming connection
            Socket serverSocket = tcpServerListener.AcceptSocket();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="users">
        /// Array of usernames
        /// </param>
        /// <param name="documents">
        /// [0] = owner
        /// [1] = content
        /// [2] = filePath
        /// </param>
        /// <param name="permission"></param>
        public void ShareDocuments(string username, string password, string[] users, string userDoc, string permission)
        {
            User authUser = engine.dbCon.AuthenticateUser(username, password);
            if (authUser != null)
            {
                
                User user = engine.userhandler.GetUserByUsername(username);
                Document tmpDocument = engine.userhandler.docHandler.GetDocumentByPath(user, userDoc);

                User[] newUsers = new User[users.Length];

                for (int i = 0; i < users.Length; i++)
                {
                    newUsers[i] = engine.userhandler.GetUserByUsername(users[i]);
                }
                Console.WriteLine("ClientSystemFacade2 - ShareDocuments");
                engine.userhandler.docHandler.ShareDocument(user, tmpDocument, Permission.Permissions.Edit, tmpDocument.path, newUsers);
            }
        }

        public void ShareFolder(string username, string password, string[] users, string folder, string permission)
        {
            Console.WriteLine("ClientSystemFacade2 - ShareFolder");
        }

        public string[] GetInvitations(string username, string password)
        {
            Console.WriteLine("ClientSystemFacade2 - GetInvitations");
            return null;
        }

        public void AcceptInvitations(string username, string password, string[] accepts)
        {
            Console.WriteLine("ClientSystemFacade2 - GetInvitations");
        }

        public string[][] Synchronize(string username, string password, string[][] files)
        {
            return Synchronize(files, Authenticate(username, password));

        }

        public User Authenticate(string username, string password)
        {
            User user = UserAuth.GetInstance().Authenticate(username, password);
            Console.WriteLine(user);
            return user;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="documents">
        /// [0] = Owner
        /// [1] = Content
        /// [2] = Path
        /// [3] = Last Changed
        /// </param>
        /// <param name="user"></param>
        /// <returns></returns>
        public string[][] Synchronize(string[][] documents, User user)
        {
            //authenticate?

            List<Document> usersDocuments = new List<Document>();
            List<Document> updatedList = new List<Document>();

            //reads all of the array-"documents" in the input 2D-array
            foreach (string[] sarray in documents)
            {
                Document tmpDocument = engine.userhandler.docHandler.NewDocument(user, sarray[1], Permission.Permissions.Edit);
                string[] fileinput = sarray[2].Split('\\');
                //string path = "root/" + user.username;
                string path = user.username;
                for (int i = 2; i < fileinput.Length; i++)
                {
                    path += "/" + fileinput[i];
                }
                tmpDocument.path = path;

                Console.WriteLine(path);

                tmpDocument.lastChanged = Convert.ToDateTime(sarray[3]);
                usersDocuments.Add(tmpDocument);
            }

            //list of users documents after "OflineSynchonization"
            updatedList = engine.userhandler.docHandler.OfflineSynchronization(usersDocuments, user);

            //makes the reutrn array with the sice of the numbers of documents
            string[][] returnDocuments = new string[updatedList.Count()][];

            int counting = 0;

            //creates and fills the array-"Document"s in the return 2D-array
            foreach (Document d in updatedList)
            {
                string[] documentArray = new string[4];

                try
                {
                    documentArray[0] = d.owner.username;
                    documentArray[1] = d.content;
                    documentArray[2] = d.path;
                    documentArray[3] = d.lastChanged.ToString();

                    returnDocuments[counting] = documentArray;
                    counting++;
                }
                catch (NullReferenceException ex) { }
            }
            Console.WriteLine("Client got " + (counting) + " documents back");

            return returnDocuments;
        }
    }
}
