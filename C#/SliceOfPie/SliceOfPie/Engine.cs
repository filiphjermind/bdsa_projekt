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
        private Folder folder = new Folder();

        // Handles all the database related methods.
        private DBConnector dbCon = DBConnector.Instance;

        public Engine()
        {
            Initialize();
        }

        private void Initialize()
        { 
            // Check if root directory exists
            if (!Directory.Exists("root"))
            {
                Directory.CreateDirectory("root");
            }

        }

    }
}
