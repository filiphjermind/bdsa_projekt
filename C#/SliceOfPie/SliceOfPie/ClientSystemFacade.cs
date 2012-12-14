using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SliceOfPie
{
    public class ClientSystemFacade
    {
        private UserAuth userAuth = UserAuth.GetInstance();
        private Engine engine = new Engine();
        private static ClientSystemFacade instance;
        private Socket socket;
        public static ClientSystemFacade GetInstance()
        {
            if (instance == null)
            {
                instance = new ClientSystemFacade();
            }
            return instance;
        }

        private ClientSystemFacade()
        {
            //IPEndPoint ipe = new IPEndPoint(Dns.GetHostEntry("localhost").AddressList[0], 8080);
            //socket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            //socket.Bind(ipe);
            //socket.Listen(1000);
            //Socket socketConnection = socket.Accept();
            //Byte[] bytes = new Byte[100];
            //socketConnection.Receive(bytes);
            //string recievedString = Encoding.ASCII.GetString(bytes);
            //Console.WriteLine("ClientSystemFacade - constructor - recievedString: " + recievedString);
        }

        /// <summary>
        /// Creates a new document.
        /// </summary>
        /// <param name="owner">The owner of the document</param>
        /// <returns>The newly created document.</returns>
        public Document NewDocument(User owner, string content, string path, Permission.Permissions perm)
        {
            Document doc = engine.userhandler.docHandler.NewDocument(owner, content, perm);
            return doc;
        }

        /// <summary>
        /// Saves a document.
        /// </summary>
        /// <param name="user">The owner of the document</param>
        /// <param name="doc">The document to save</param>
        /// <param name="filename">Filename of the document.</param>
        public void SaveDocument(User user, Document doc, string filename)
        {
            Console.WriteLine("PATH " + doc.path);
            Console.WriteLine("FILENAME " + filename);
            engine.userhandler.docHandler.SaveDocument(user, doc, filename);
        }

        /// <summary>
        /// Opens an existing document
        /// </summary>
        /// <param name="id">ID of the document</param>
        /// <param name="user">Owner of the document.</param>
        /// <returns>The document.</returns>
        public Document OpenDocument(int id, User user)
        {
            Document doc = engine.userhandler.docHandler.OpenDocument(id, user);
            return doc;
        }

        /// <summary>
        /// Deletes a document from the disc, and deletes it's entry
        /// in the database.
        /// </summary>
        /// <param name="user">The owner of the document</param>
        /// <param name="doc">The document to delete.</param>
        public void DeleteDocument(User user, string path)
        {
            engine.userhandler.docHandler.DeleteFile(user, path);
            //engine.userhandler.docHandler.DeleteDocument(doc);
        }

        /// <summary>
        /// Authenticates a user that tries to log in to the system.
        /// </summary>
        /// <param name="username">Username of the user</param>
        /// <param name="password">Password of the user</param>
        /// <returns>User object if the authentication succeeds</returns>
        public User Authenticate(string username, string password)
        {
            Console.WriteLine("username " + username + "password " + password);
            User user = userAuth.Authenticate(username, password);
            return user;
        }

        /// <summary>
        /// Creates a new user. Used when a new user signs up for 
        /// the system.
        /// </summary>
        /// <param name="name">Full name of the user</param>
        /// <param name="username">Username of the user</param>
        /// <param name="password">Password of the user</param>
        /// <returns>The new user object.</returns>
        public User NewUser(string name, string username, string password)
        {
            return engine.userhandler.NewUser(name, username, password);
        }

        /// <summary>
        /// Retreives a user from the database
        /// </summary>
        /// <param name="username">Username of the user</param>
        /// <param name="password">Password of the user</param>
        /// <returns>The user object</returns>
        public User GetUser(string username, string password)
        {
            return engine.userhandler.GetUser(username, password);
        }

        /// <summary>
        /// Reads the content of a file.
        /// </summary>
        /// <param name="path">The path to the file</param>
        /// <returns>The content of the file as a string.</returns>
        public string ReadFile(string path)
        {
            return engine.userhandler.docHandler.ReadFile(path);
        }

        /// <summary>
        /// Retreives all users documents
        /// </summary>
        /// <param name="user">The user that owns the documents.</param>
        /// <returns>A list of all the users documents.</returns>
        public List<Document> GetAllUsersDocuments(User user)
        {
            return engine.userhandler.docHandler.GetAllUsersDocuments(user);
        }

        public List<Document> GetAllSharedDocuments(User user)
        {
            return null;
        }
    }
}
