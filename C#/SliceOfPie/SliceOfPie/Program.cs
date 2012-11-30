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
            DBConnector dbCon = new DBConnector();

            //dbCon.OpenConnection();
            //dbCon.Insert();

            
            //dbCon.AddDocument("joe", "right behind you");

            Console.WriteLine("should've been run now");

            //System system = new System();
            //system.NewUser("chuck norris", "chuckn", "1234");

            Console.ReadKey();
        }
    }
}
