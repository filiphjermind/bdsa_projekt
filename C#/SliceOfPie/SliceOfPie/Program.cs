using System;
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
>>>>>>> f5cb75287a160e6830a45b062b436a043741e061

            //engine.dbCon.InsertDocument("carl", "Left there");
            //engine.dbCon.DeleteDocumentByUserName("carl");
            //engine.dbCon.DeleteDocumentByID(10);
            //engine.dbCon.UpdateDocumentByID(1,"carlos","right over there");
            //engine.dbCon.SelectDocumentsFromUser("carlos");
            //engine.dbCon.print(SelectDocumentsFromUser("carlos"));

            //engine.dbCon.InsertUser("God", "Almighty", "Blowback");
            //engine.dbCon.DeleteUserByUsername("K-Master");
            //engine.dbCon.UpdateUserByUsername("Karl", "Dante", "Henry", "password");
            //engine.dbCon.SelectUser("Henry", "password");
            //engine.dbCon.SelectAllUsers();

            Console.WriteLine("should've been run now");

            //User user1 = engine.userhandler.NewUser("Mr T", "mrT", "1234");

            //Document doc = engine.docHandler.NewDocument(user1, "Some other title");

            //engine.docHandler.SaveDocument(user1, doc, "TestFile2.html");

            User user1 = engine.userhandler.GetUser("jetli", "12345");

            Console.WriteLine(user1.name);
            Console.WriteLine(user1.username);
            Console.WriteLine(user1.password);


            Console.ReadKey();
        }
    }
}
