using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SliceOfPie
{
    public class DocumentHandler
    {
        // Handles all the database related methods.
        private DBConnector dbCon = DBConnector.Instance;

        // Handles all folder related actions
        private Folder folder = new Folder();

        /// <summary>
        /// Creates a new document.
        /// Adds it to the users list of documents.
        /// </summary>
        /// <param name="owner">The owner of the document</param>
        /// <param name="title">The title of the document.</param>
        /// <returns>The newly created document.</returns>
        public Document NewDocument(User owner, string content, Permission.Permissions perm)
        {
            // NOTE!!!
            Document doc = new Document(owner, content, perm);
            AddDocToList(owner, doc);
            return doc;
        }

        /// <summary>
        /// Saves a document to the database.
        /// And saves the file to the disc.
        /// </summary>
        /// <param name="username">Owner of the document.</param>
        /// <param name="doc">The document to be saved.</param>
        /// <param name="filename">Filename of the document</param>
        public void SaveDocument(User user, Document doc, string filename)
        {
            // The full path to the file.
            string path = "root/" + user.username + "/" + filename;

            // split the filename into an array.
            string[] filePath = path.Split('/');

            string tmpPath = "";

            // Check if the path to the file exists.
            for (int i = 0; i < filePath.Length-1; i++)
            {
                tmpPath += filePath[i] + "/";
                if(!Directory.Exists(tmpPath))
                {
                    try
                    {
                        Directory.CreateDirectory(tmpPath);
                    }
                    catch (IOException e) { }
                    
                }
            }

            // Check if the file exists
            if (!File.Exists(path))
            {
                try
                {
                    // Create the file
                    File.Create(path);
                }
                catch (IOException e) { }
                
            }

            // Split the content so each line is an array index.
            if (doc.content == null) ;
            else
            {
                string[] splitContent = doc.content.Split('\n');

                foreach (string l in splitContent)
                {
                    Console.WriteLine(l);
                }

                // Write content to the file
                try
                {
                    File.WriteAllLines(path, splitContent);
                }
                catch (IOException e)
                {
                }
            }

            doc.lastChanged = DateTime.Now;

            // Insert data to the database.
            dbCon.InsertDocument(user.username, path);
            user.documents.Add(doc);
        }

        /// <summary>
        /// Opens a document based on the document id.
        /// </summary>
        /// <param name="id">Id of the document to open</param>
        /// <returns>The document</returns>
        public Document OpenDocument(int id, User user)
        {
            // Get the path to the file from the database.
            string path = "";
            path = dbCon.GetDocument(id, user.username);

            // Read the file, line by line, into an array.
            try
            {
                string[] lines = File.ReadAllLines(path);

                // Save the content of the file.
                string content = "";
                for (int i = 0; i < lines.Length; i++)
                {
                    content += lines[i] + "\n";
                }

                // Create a new document object.
                Document doc = new Document(user, id, content, path);

                // Add document to the users list of documents
                AddDocToList(user, doc);

                // Return the document.
                return doc;
            }
            catch (IOException e)
            { 
            
            }
            return null;
        }

        /// <summary>
        /// Reads the content of a file
        /// </summary>
        /// <param name="path">Path to the file</param>
        /// <returns>File content as a string</returns>
        public string ReadFile(string path)
        {
            try
            {
                string[] lines = File.ReadAllLines(path);

                // Save the content of the file.
                string content = "";
                for (int i = 0; i < lines.Length; i++)
                {
                    content += lines[i] + "\n";
                }
                return content;
            }
            catch (IOException e)
            { 
            }
            return null;
        }

        /// <summary>
        /// Returns all documents from the database that belong to
        /// the specific user.
        /// </summary>
        /// <param name="user">Owner of the documents</param>
        /// <returns>List of all documents that belong to the user.</returns>
        public List<Document> GetAllUsersDocuments(User user)
        {
            List<int> documentIDList = dbCon.SelectDocumentsFromUser(user);
            List<Document> usersDocuments = new List<Document>();

            foreach (int i in documentIDList) usersDocuments.Add(OpenDocument(i, user));

            return usersDocuments;
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
            string path = doc.path;

            // Delete the file
            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                }
                catch (IOException e) {
                    Console.WriteLine(e.StackTrace);
                }
            }

            // Delete the entry from the database.
            dbCon.DeleteDocumentByID(doc.documentId);
        }

        /// <summary>
        /// Allows the owner of the document to share the
        /// document with other users.
        /// </summary>
        /// <param name="file">File path of file</param>
        /// <param name="perm">Enumerated permition</param>
        /// <param name="users">List of users to share with.</param>
        public void ShareDocument(User currentUser, Document doc, Permission.Permissions perm ,params User[] users)
        {
            Document sharedDocument = new Document(doc.owner, doc.path, perm);
            
            foreach (User i in users)
            {
                if (i.documents.Contains(doc) || i.documents.Contains(sharedDocument)) Console.WriteLine("Document doe already exist");
                else SaveDocument(i, doc, doc.title);
                
                Console.WriteLine(i.documents.Contains(sharedDocument));
            }
        }

        /// <summary>
        /// Synchronizes a users local Documents with Documents owned and shared with him on the server
        /// </summary>
        /// <param name="incDocuments">All of the users Documents</param>
        /// <param name="user">the documents user</param>
        /// <returns>A list of all the newest documents the user either owns, have rights to watch or edit.</returns>
        public List<Document> OfflineSynchronization(List<Document> incDocuments, User user)
        {
            List<Document> newDocumentList = new List<Document>();
            List<Document> usersDocumentOnServer = GetAllUsersDocuments(user);

            newDocumentList = usersDocumentOnServer;
            CopyNewEntities(incDocuments, newDocumentList);


            return newDocumentList;
        }

        public List<Document> OfflineSynchronization(List<Document> incDocuments, List<Document> serverDocuments)
        {
            List<Document> newDocumentList = serverDocuments;

            newDocumentList = CopyNewEntities(incDocuments, newDocumentList);


            return newDocumentList;
        }

        /********************** PRIVATE HELPER METHODS ******************************/

        /// <summary>
        /// Copies and selects newest documents from one list and 
        /// adds them into another list. if two documents have got the
        /// same ID, the newes one is chosen
        /// </summary>
        /// <param name="fromList">List that is copied into another list</param>
        /// <param name="toList">List that gets new documents and possible updated some of it's documents</param>
        /// <returns>A list of all files from list 1 and 2 without dublicates</returns>
        private List<Document> CopyNewEntities(List<Document> fromList, List<Document> toList)
        {
            foreach (Document d in fromList)
            {
                Document tmp = CheckDocumentInList(d, toList);
                if (tmp == null) toList.Add(d);
            }


            return toList;
        }

        /// <summary>
        /// Compares a single document with all documents in a list
        /// </summary>
        /// <param name="d">document to be compared</param>
        /// <param name="toList">list of documents the "d" document will be compared to</param>
        /// <returns>if it finds a document in "toList" that matches the ID of "d", 
        /// it returns the newest of those 2 documents. If "d" does not exist in "toList" it returns null
        /// to let it's caller know that the document does not exist in the "toList"</returns>
        private Document CheckDocumentInList(Document d, List<Document> toList)
        {
            
            foreach (Document i in toList)
            {
                if (d.documentId == i.documentId)
                {
                    Document tmp = FindNewestDocument(i, d);
                    if (toList.Contains(i)) toList.Remove(i);
                    if (toList.Contains(d)) toList.Remove(d);
                    toList.Add(tmp); return tmp;
                }
            }
            return null;
        }

        /// <summary>
        /// Compares two documents and finds the one with the newest DateTime Object
        /// </summary>
        /// <param name="doc1">First Document</param>
        /// <param name="doc2">Second Document</param>
        /// <returns>The document with the newest DateTime object</returns>
        private Document FindNewestDocument(Document doc1, Document doc2)
        {

            if (doc1.lastChanged.CompareTo(doc2.lastChanged) < 0) return doc2;
            else if (doc1.lastChanged.CompareTo(doc2.lastChanged) > 0) return doc1;
            else return doc1;
        }
        /// <summary>
        /// Splits a string at every "/" and returns an array of strings
        /// </summary>
        /// <param name="input">string to be split</param>
        /// <returns>An array of strings, contaning the input after it has been split</returns>
        private string[] splitString(string input)
        {
            string[] tmp = input.Split('/');

            return tmp;
        }

        /// <summary>
        /// Adds a document to the users list of documents.
        /// </summary>
        /// <param name="doc">The document to be added.</param>
        private void AddDocToList(User user, Document doc)
        {
            user.documents.Add(doc);
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
        private Document NewDocObject(User owner, int id, string content, string path)
        {
            Document doc = new Document(owner, id, content, path);

            return doc;
        }
    }
}
