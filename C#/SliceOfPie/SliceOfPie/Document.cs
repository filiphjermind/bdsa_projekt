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

        public Permission permission
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

        public Document(User owner, string file, Permission perm)
        {
            this.owner = owner;
            this.permission = permission;
            // TODO file
        }

        public Document(User owner)
        {
            this.owner = owner;
            // file
            //this.documentId
            this.content = "";
        }
    }
}
