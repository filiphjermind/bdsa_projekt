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
            Engine engine = new Engine();//Engine.Instance;
            DBConnector DBCon = DBConnector.Instance;

            User user1 = engine.userhandler.GetUser("jetli", "12345");
            Document document1 = engine.docHandler.OpenDocument(29, user1);
            DBCon.InsertUserDocument(user1, document1, Permission.Permissions.Edit);

            Console.WriteLine("should've been run now");

            //User user1 = engine.userhandler.NewUser("Mr T", "mrT", "1234");

            //Document doc = engine.docHandler.NewDocument(user1, "Some other title");

            //engine.docHandler.SaveDocument(user1, doc, "TestFile2.html");

            

            Console.WriteLine(user1.name);
            Console.WriteLine(user1.username);
            Console.WriteLine(user1.password);


            Console.ReadKey();
        }
    }
}
