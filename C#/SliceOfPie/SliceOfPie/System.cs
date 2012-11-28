using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SliceOfPie
{
    class System
    {
        private DocumentHandler docHandler = new DocumentHandler();

        /// <summary>
        /// Creates a new document by calling the NewDocument method from 
        /// the document handler class.
        /// </summary>
        /// <param name="owner">The owner of the document</param>
        /// <param name="title">Title of the document</param>
        /// <returns>The new document.</returns>
        public Document NewDocument(User owner, string title)
        {
            return docHandler.NewDocument(owner, title);
        }

        /// <summary>
        /// Opens a document stored in the database by calling
        /// the open document method in the documenthandler class.
        /// </summary>
        /// <param name="id">The id of the specific job.</param>
        /// <returns>The newly opened job.</returns>
        public Document OpenDocument(int id)
        {
            return docHandler.OpenDocument(id);
        }

        /// <summary>
        /// Saves a document to the database by calling the
        /// save document in the document handler class.
        /// </summary>
        /// <param name="doc">The document to save</param>
        public void SaveDocument(Document doc)
        {
            docHandler.SaveDocument(doc);
        }

        /// <summary>
        /// Deletes a document from the database by calling
        /// the delete document method from the document handler class.
        /// </summary>
        /// <param name="doc">The document to delete.</param>
        public void DeleteDocument(Document doc)
        {
            docHandler.DeleteDocument(doc);
        }

        /// <summary>
        /// Shares a document with other users by calling the share document
        /// method of the document handler class
        /// </summary>
        /// <param name="users">The users to share the document with.</param>
        public void ShareDocument(params User[] users)
        {
            docHandler.ShareDocument(users);
        }
    }
}
