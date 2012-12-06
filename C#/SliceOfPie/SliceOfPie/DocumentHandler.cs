using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SliceOfPie
{
    public class DocumentHandler
    {
        // Stores the users document objects.
        public List<Document> documents = new List<Document>();

        // Handles all the database related methods.
        private DBConnector dbCon = DBConnector.Instance;

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
        public void SaveDocument(User user, Document doc, string filename)
        {
            string owner = user.username;
            string filepath = "root/" + owner + "/" + filename;

            string path = "root/" + owner;

            path = Path.Combine(path, filename);

            // Checks if the file exists, and saves it to the system.
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

            dbCon.InsertDocument(owner, filepath);
        }

        /// <summary>
        /// Opens a document based on the document id.
        /// </summary>
        /// <param name="id">Id of the document to open</param>
        /// <returns>The document</returns>
        public Document OpenDocument(int id, User user)
        {
            // Get file path from database
            string path = dbCon.GetDocument(id, user.username);

            // Open file
            string[] lines = File.ReadAllLines(path);

            // Content of the file.
            string content = "";

            // Convert lines to string
            for (int i = 0; i < lines.Length; i++)
            {
                content += lines[i] + "\n";
            }

            // Create new document object.
            Document doc = NewDocObject(user, id, content);

            // Add document to users document list
            AddDocToList(doc);

            // Return the document object.
            return doc;
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
        public void ShareDocument(string file, params User[] users)
        { 

        }

        /********************** PRIVATE HELPER METHODS ******************************/

        private List<string> splitString(string input)
        {
            List<string> output = new List<string>();

            return output;
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

        /// <summary>
        /// Creates a new document object.
        /// </summary>
        /// <param name="owner">Owner of the document.</param>
        /// <param name="id">Id of the document.</param>
        /// <param name="content">Content of the document file.</param>
        /// <returns>The new document object.</returns>
        private Document NewDocObject(User owner, int id, string content)
        {
            Document doc = new Document(owner, id, content);

            return doc;
        }
    }
}
