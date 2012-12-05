using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SliceOfPie
{
    class Program
    {
        static void Main(string[] args)
        {
            DBConnector dbCon = DBConnector.Instance;

            //dbCon.OpenConnection();
            //dbCon.Insert();

            
            //dbCon.AddDocument("joe", "right behind you");

            Console.WriteLine("should've been run now");

            //System system = new System();
            //system.NewUser("chuck norris", "chuckn", "1234");

            //User user = new User("Chuck Norris", "Chuck", "pass");

            //DocumentHandler docHandler = new DocumentHandler();



            //docHandler.SaveDocument("Chuck", docHandler.NewDocument(user, "TEST"), "someFile");

            User Chuck = new User("Chuck Norris", "Chuck", "1234");

            DocumentHandler docHandler = new DocumentHandler();

            Console.WriteLine(docHandler.OpenDocument(13, Chuck));

            Console.ReadKey();
        }
    }
}
