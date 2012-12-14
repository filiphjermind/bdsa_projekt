using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ServiceModel;
using System.Threading;

namespace SliceOfPie
{
    public class Engine
    {
        // Absolute path to the root directory of the logged in user.
        public readonly string rootDirectory;

        // handles the creation of folders.
        public Folder folder;

        // Handles all the database related methods.
        public DBConnector dbCon;

        // Handles user creation / editing etc ..
        public UserHandler userhandler;

        // Handles user authentication
        public UserAuth userAuth;

        // Handles functionality related to documents
        //public DocumentHandler docHandler;

        /*public static Engine Instance
        {
            get
            {
                if (instance == null) instance = new Engine();
                return instance;
            }
        }*/


        public Engine()
        {
            rootDirectory = Path.GetFullPath("root"); //folder.SetRootDirectory();
            Console.WriteLine(rootDirectory);
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

            ClientSystemFacade2.GetInstance();



            //Thread hostThread = new Thread(() => OpenHost());
            //hostThread.Start();

            //docHandler = new DocumentHandler();


            // Check if root directory exists
            /*if (!Directory.Exists("root"))
            {
                Directory.CreateDirectory("root");
            }*/
        }

        private void OpenHost()
        {
            using (ServiceHost host = new ServiceHost(typeof(ClientSystemFacade2)))
            {
                host.Open();
                Console.ReadLine();
            }
        }

    }
}
