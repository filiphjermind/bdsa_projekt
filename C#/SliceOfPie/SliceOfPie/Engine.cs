using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SliceOfPie
{
    class Engine
    {
        // handles the creation of folders.
        private Folder folder;

        // Handles all the database related methods.
        private DBConnector dbCon;

        // Handles user creation / editing etc ..
        private UserHandler userhandler;

        // Handles user authentication
        private UserAuth userAuth;

        // Handles functionality related to documents
        private DocumentHandler docHandler;

        public Engine()
        {
            Initialize();
        }

        private void Initialize()
        { 
            // Initializes all other classes.
            dbCon = DBConnector.Instance;
            folder = new Folder();
            userhandler = new UserHandler();
            docHandler = new DocumentHandler();
            userAuth = new UserAuth();

            // Check if root directory exists
            if (!Directory.Exists("root"))
            {
                Directory.CreateDirectory("root");
            }
        }

    }
}
