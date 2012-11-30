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
<<<<<<< HEAD
            DBConnector dbCon = new DBConnector();
=======
            DBConnector dbCon = DBConnector.Instance;
>>>>>>> 983f8d621b0d3ceabc6ad0b5a8d4a54ba4bf4961

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
