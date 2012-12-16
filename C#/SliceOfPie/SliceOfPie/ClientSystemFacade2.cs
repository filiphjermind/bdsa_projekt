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
            Console.WriteLine("ClientSystemFacade2 - GetInstance()");
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

        public void ShareDocuments(string username, string password, string[] users, string[] documents, string permission)
        {
            Console.WriteLine("ClientSystemFacade2 - ShareDocuments");
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

        public User Authenticate(string username, string password)
        {
            User user = UserAuth.GetInstance().Authenticate(username, password);
            Console.WriteLine(user);
            return user;
        }

        public string[][] Synchronize(string[][] documents, User user)
        {
            //authenticate?

            List<Document> usersDocuments = new List<Document>();
            List<Document> updatedList = new List<Document>();

            //reads all of the array-"documents" in the input 2D-array
            foreach (string[] sarray in documents) 
            {
                //if (sarray.Length < 3) { Console.WriteLine("ERROR, array is to small"); break; }
                string tmpOwner = sarray[0];
                string tmpContent = sarray[1];
                string tmpFilePath = sarray[2];

                Document tmpDocument = engine.userhandler.docHandler.NewDocument(user, tmpContent, Permission.Permissions.Edit);

                usersDocuments.Add(tmpDocument);
            }

            //list of users documents after "OflineSynchonization"
            updatedList = engine.userhandler.docHandler.OfflineSynchronization(usersDocuments, user);

            string[][] returnDocuments =  new string [updatedList.Count()][];

            int counting = 0;

            //creates and fills the array-"Document"s in the return 2D-array
            foreach (Document d in updatedList)
            {
                string[] documentArray = new string[3];

                documentArray[0] = d.owner.username;
                documentArray[1] = d.content;
                documentArray[2] = d.path;

                returnDocuments[counting] = documentArray;
                counting++;
            }
            Console.WriteLine("Client got "+ (counting-1) +" documents back");
                
            return returnDocuments;
        }
    }
}
