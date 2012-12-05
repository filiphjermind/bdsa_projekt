using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SliceOfPie
{
    public class Engine
    {

        //private static Engine instance;

        // handles the creation of folders.
        public Folder folder;

        // Handles all the database related methods.
        public DBConnector dbCon;

        // Handles user creation / editing etc ..
        public UserHandler userhandler;

        // Handles user authentication
        public UserAuth userAuth;

        // Handles functionality related to documents
        public DocumentHandler docHandler;
<<<<<<< HEAD
=======

        /*public static Engine Instance
        {
            get
            {
                if (instance == null) instance = new Engine();
                return instance;
            }
        }*/
>>>>>>> f5cb75287a160e6830a45b062b436a043741e061

        public Engine()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes the engine class.
        /// </summary>
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
