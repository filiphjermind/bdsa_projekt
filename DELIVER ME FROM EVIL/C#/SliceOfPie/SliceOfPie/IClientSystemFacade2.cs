using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SliceOfPie
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IClientSystemFacade2" in both code and config file together.
    [ServiceContract]
    public interface IClientSystemFacade2
    {
        [OperationContract]
        void ShareDocuments(string username, string password, string[] users, string document, string permission);

        [OperationContract]
        void ShareFolder(string username, string password, string[] users, string folder, string permission);

        [OperationContract]
        string[] GetInvitations(string username, string password);

        [OperationContract]
        void AcceptInvitations(string username, string password, string[] accepts);
        
        [OperationContract]
        string[][] Synchronize(string username, string password, string[][] files);
    }
}
