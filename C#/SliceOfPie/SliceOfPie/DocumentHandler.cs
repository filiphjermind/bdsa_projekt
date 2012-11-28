using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SliceOfPie
{
    class DocumentHandler
    {
        /// <summary>
        /// Creates a new document.
        /// </summary>
        /// <param name="owner">The owner of the document</param>
        /// <param name="title">The title of the document.</param>
        /// <returns>The newly created document.</returns>
        public Document NewDocument(User owner, string title)
        {
            Document doc = new Document(owner, title);
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
        /// Saves a document to the database.
        /// </summary>
        /// <param name="doc">The document to save</param>
        public void SaveDocument(Document doc)
        { 
        
        }

        /// <summary>
        /// Opens a document based on the document id.
        /// </summary>
        /// <param name="id">Id of the document to open</param>
        /// <returns>The document</returns>
        public Document OpenDocument(int id)
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
    }
}
