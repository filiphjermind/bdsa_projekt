using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SliceOfPie
{
    public class Document
    {

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

        public Permission.Permissions permission
        {
            get;
            set;
        }

        public DateTime lastChanged
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
            this.lastChanged = DateTime.Now;
        }

        public Document(User owner, string file, Permission.Permissions perm)
        {
            this.owner = owner;
            this.permission = permission;
            this.lastChanged = DateTime.Now;
            // TODO file
        }

        public Document(User owner)
        {
            this.owner = owner;
            // file
            //this.documentId
            this.content = "";
            this.lastChanged = DateTime.Now;
        }
    }
}
