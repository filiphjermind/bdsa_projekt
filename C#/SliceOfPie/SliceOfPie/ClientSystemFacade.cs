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
        private UserAuth userAuth = UserAuth.instance;
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
        public Document NewDocument(User owner)
        {
            Document doc = engine.userhandler.docHandler.NewDocument(owner);
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
        public void DeleteDocument(User user, Document doc)
        {
            engine.userhandler.docHandler.DeleteDocument(doc);
        }

        public User Authenticate(string username, string password)
        {
            User user = userAuth.Authenticate(username, password);
            return user;
        }
    }
}
