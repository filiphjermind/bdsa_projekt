﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SliceOfPie
{
    public class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD

            Engine engine = new Engine();
=======
            Engine engine = new Engine();//Engine.Instance;
            DBConnector DBCon = DBConnector.Instance;
>>>>>>> 62c0e5c429c26ca08ad288f09bcd0108faaf8782

            User user = engine.userhandler.GetUser("mrT", "1234");
            Document document1 = engine.docHandler.OpenDocument(15, user);
            
            
            //DBCon.InsertUserDocument(user, document1, Permission.Permissions.Edit);

            //Console.WriteLine(DBCon.CheckPermission(user, document1));

            //User user1 = engine.userhandler.NewUser("Mr T", "mrT", "1234");

            //Document doc = engine.docHandler.NewDocument(user1, "Some other title");

            //engine.docHandler.SaveDocument(user1, doc, "TestFile2.html");

            //User user = engine.userhandler.NewUser("Test user", "testuser", "test123");

            Console.WriteLine("should've been run now");
            Console.ReadKey();
        }
    }
}
