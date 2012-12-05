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
            DocumentHandler docHandler = new DocumentHandler();
            Engine engine = new Engine();

            //dbCon.OpenConnection();
            //dbCon.Insert();

            
            //dbCon.AddDocument("joe", "right behind you");

            Console.WriteLine("should've been run now");


            Console.ReadKey();
        }
    }
}
