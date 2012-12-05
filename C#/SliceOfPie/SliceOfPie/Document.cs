using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SliceOfPie
{
    public class Document
    {
        /// <summary>
        /// List of users that have access to edit the document.
        /// </summary>
        public List<User> users;

        /// <summary>
        /// The owner of the document.
        /// </summary>
        public User owner
        {
            get;
            set;
        }

        /// <summary>
        /// The title of the document
        /// </summary>
        public string title
        {
            get;
            set;
        }

        /// <summary>
        /// Unique id of the document
        /// </summary>
        public int documentId
        {
            get;
            set;
        }

        /// <summary>
        /// Content of the document.
        /// </summary>
        public string content
        {
            get;
            set;
        }

        // Primary
        public Document(User owner, int id, string content)
        {
            this.owner = owner;
            this.documentId = id;
            this.content = content;
        }

        public Document(string owner, int id, string file)
        {
            this.documentId = id;
            //this.owner = owner;
            //TODO: file
        }

        public Document(User owner, string title)
        {
            this.owner = owner;
            this.title = title;
            // file
            //this.documentId
            this.users = new List<User>();
            this.content = "";
        }
    }
}
