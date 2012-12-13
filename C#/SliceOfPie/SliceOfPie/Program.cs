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
            ClientSystemFacade facade = ClientSystemFacade.GetInstance();
            Engine engine = new Engine();//Engine.Instance;
            DBConnector DBCon = DBConnector.Instance;

            //User user = engine.userhandler.GetUser("mrT", "1234");

            User user = facade.Authenticate("mrT", "1234");

            List<Document> docs = engine.userhandler.docHandler.GetAllUsersDocuments(user);

            Document doc1 = engine.userhandler.docHandler.OpenDocument(71, user);
            Document doc2 = engine.userhandler.docHandler.OpenDocument(105, user);

            engine.userhandler.docHandler.SaveDocument(user, engine.userhandler.docHandler.MergeDocuments(doc1, doc2), "hello.html");


            //Console.WriteLine(user.ToString());

            //User ownerUser = engine.userhandler.GetUser("mrT", "1234");
            //User toUser = engine.userhandler.GetUser("bergar", "1234");

            //engine.userhandler.docHandler.ShareDocument(ownerUser, sharedDocument, Permission.Permissions.Edit, toUser);

            //User user = engine.userhandler.GetUser("mrT", "1234");
            //List<Document> docs = engine.userhandler.docHandler.GetAllUsersDocuments(user);

            //Console.WriteLine(docs.Count);

            //foreach (Document doc in docs)
            //{
            //    Console.WriteLine(doc.documentId + " " + doc.owner.username);
            //}
            //Document document1 = engine.userhandler.docHandler.OpenDocument(15, user);
            //Document doc1 = new Document(user);
            //doc1.content = "This is \n a tst";
            //engine.userhandler.docHandler.SaveDocument(user, doc1, "sometestfilelololol.html");
            //Console.WriteLine(document1.content);
            
            
            //DBCon.InsertUserDocument(user, document1, Permission.Permissions.Edit);

            //Console.WriteLine(DBCon.CheckPermission(user, document1));

            //User user1 = engine.userhandler.NewUser("Mr T", "mrT", "1234");

            //Document doc = engine.docHandler.NewDocument(user1, "Some other title");

            //engine.docHandler.SaveDocument(user1, doc, "TestFile2.html");

            Console.WriteLine("should've been run now");
            Console.ReadKey();
        }
    }
}
