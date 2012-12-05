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
            Engine engine = new Engine();//Engine.Instance;

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


            Console.ReadKey();
        }
    }
}
