using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SliceOfPie
{
    class DocumentHandler
    {
        // Stores the users document objects.
        public List<Document> documents = new List<Document>();

        // Handles all the database related mathods.
        DBConnector dbCon = DBConnector.Instance;

        /// <summary>
        /// Creates a new document.
        /// Adds it to the users list of documents.
        /// </summary>
        /// <param name="owner">The owner of the document</param>
        /// <param name="title">The title of the document.</param>
        /// <returns>The newly created document.</returns>
        public Document NewDocument(User owner, string title)
        {
            Document doc = new Document(owner, title);
            AddDocToList(doc);
            return doc;
        }

        /// <summary>
        /// Saves a document to the database.
        /// </summary>
        /// <param name="username">Owner of the document.</param>
        /// <param name="doc">The document to be saved.</param>
        /// <param name="filename">Filename of the document</param>
        public void SaveDocument(string username, Document doc, string filename)
        {
            string owner = username;
            string filepath = username + "/" + filename;

            string path = username;

            path = Path.Combine(path, filename);

            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }
            }

            dbCon.InsertDocument(username, filepath);
        }

        /// <summary>
        /// Returns all documents from the database that belong to
        /// the specific user.
        /// </summary>
        /// <param name="user">Owner of the documents</param>
        /// <returns>List of all documents that belong to the user.</returns>
        public List<Document> GetAllUsersDocuments(User user)
        {
            return null;
        }

        /// <summary>
        /// Returns all documents stored in the system
        /// </summary>
        /// <returns>List of all documents</returns>
        public List<Document> GetAllDocuments()
        {
            return null;
        }

        /// <summary>
        /// Opens a document based on the document id.
        /// </summary>
        /// <param name="id">Id of the document to open</param>
        /// <returns>The document</returns>
        public Document OpenDocument(int id, string owner, string file)
        {

            return null;
        }

        /// <summary>
        /// Deletes a document from the system
        /// </summary>
        /// <param name="doc">The document to delete</param>
        public void DeleteDocument(Document doc)
        { 
        }

        /// <summary>
        /// Allows the owner of the document to share the
        /// document with other users.
        /// </summary>
        /// <param name="users">List of users to share with.</param>
        public void ShareDocument(params User[] users)
        { 
        }

        /// <summary>
        /// Adds a document to the users list of documents.
        /// </summary>
        /// <param name="doc">The document to be added.</param>
        private void AddDocToList(Document doc)
        {
            documents.Add(doc);
        }

        /// <summary>
        /// Prints out all documents that belong to a user.
        /// </summary>
        /// <param name="docs">List of documents</param>
        public void PrintDocList(List<Document> docs)
        {
            foreach (Document d in docs)
            {
                Console.WriteLine(d.owner.name);
                Console.WriteLine(d.title);
                Console.WriteLine();
            }
        }
    }
}
