using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using SliceOfPie;

namespace SliceOfPieTest
{
    [TestClass]
    public class ClientFacadeTest
    {
        ClientSystemFacade facade = ClientSystemFacade.GetInstance();

        [TestMethod]
        public void RootDirTest()
        {
            bool exists = Directory.Exists("root");

            Assert.AreEqual(true, exists);
        }

        [TestMethod]
        public void NewUserTest()
        {
            // Create new user.
            User user = facade.NewUser("Sample User", "sampleuser", "sample123");

            // Check if user exists in the database.
            Assert.AreEqual(user.username, facade.GetUser("sampleuser", "sample123").username);
        }

        [TestMethod]
        public void AuthenticateTest()
        { 
            // Get a user from the database.
            User user = facade.GetUser("sampleuser", "sample123");

            // Authenticate user.
            User user2 = facade.Authenticate("sampleuser", "sample123");

            Assert.AreEqual(user.username, user2.username);
        }

        [TestMethod]
        public void AuthenticateNegativeTest()
        {
            User user = facade.GetUser("sampleuser", "sample123");

            // Authenticating with wrong password.
            User user2 = facade.Authenticate("sampleuser", "test123456");

            Assert.AreEqual(null, user2);
        }

        [TestMethod]
        public void UserRootDirTest()
        {
            User user = facade.GetUser("sampleuser", "sample123");

            bool exists = Directory.Exists("root/" + user.username);

            Assert.AreEqual(true, exists);
        }

        [TestMethod]
        public void SaveDocToFileTest()
        {
            User user = facade.GetUser("sampleuser", "sample123");

            Document doc = facade.NewDocument(user, "some content", "testDocument.html", Permission.Permissions.Edit);
            doc.path = "testDocument.html";
            doc.content = "here is some\nSample content";

            Console.WriteLine(doc.path);

            facade.SaveDocument(user, doc, "testDocument.html");

            string pathToFile = "root/" + user.username + "/" + doc.path;

            bool exists = File.Exists(pathToFile);

            Assert.AreEqual(true, exists);
        }

        [TestMethod]
        public void DeleteDocumentFromDiscTest()
        {
            User user = facade.GetUser("sampleuser", "sample123");

            string pathToFile = "root/" + user.username + "/testDocument.html";

            facade.DeleteDocument(user, pathToFile);

            bool exists = File.Exists(pathToFile);

            Assert.AreEqual(false, exists);
        }
    }
}
