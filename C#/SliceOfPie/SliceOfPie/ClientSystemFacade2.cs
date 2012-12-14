using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SliceOfPie
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ClientSystemFacade2" in both code and config file together.
    public class ClientSystemFacade2 : IClientSystemFacade2
    {
        private static ClientSystemFacade2 instance;

        public static ClientSystemFacade2 GetInstance()
        {
            Console.WriteLine("ClientSystemFacade2 - GetInstance()");
            if (instance == null)
            {
                instance = new ClientSystemFacade2();
            }
            return instance;
        }

        public void ShareDocuments(string username, string password, string[] users, string[] documents, string permission)
        {
            Console.WriteLine("ClientSystemFacade2 - ShareDocuments");
        }

        public void ShareFolder(string username, string password, string[] users, string folder, string permission)
        {
            Console.WriteLine("ClientSystemFacade2 - ShareFolder");
        }

        public string[] GetInvitations(string username, string password)
        {
            Console.WriteLine("ClientSystemFacade2 - GetInvitations");
            return null;
        }

        public void AcceptInvitations(string username, string password, string[] accepts)
        {
            Console.WriteLine("ClientSystemFacade2 - GetInvitations");
        }
        public User Authenticate(string username, string password)
        {
            User user = UserAuth.GetInstance().Authenticate(username, password);
            Console.WriteLine(user);
            return user;
        }
    }
}
