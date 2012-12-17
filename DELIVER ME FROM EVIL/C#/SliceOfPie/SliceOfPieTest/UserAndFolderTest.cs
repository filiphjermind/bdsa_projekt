using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SliceOfPie;
using System.IO;

namespace SliceOfPieTest
{
    [TestClass]
    public class UserAndFolderTest
    {
        private Engine engine = new Engine();

        /// <summary>
        /// Create new user.
        /// Check that it works to create a new user object.
        /// </summary>
        [TestMethod]
        public void CreateNewUserTest()
        {
            User user = engine.userhandler.NewUser("Test user", "testuser", "test123");
            Assert.AreEqual("Test user", user.name);
        }

        /// <summary>
        /// Test if the newly created user has been added to the database.
        /// </summary>
        [TestMethod]
        public void GetUserTest()
        {
            User user = engine.userhandler.GetUser("testuser", "test123");

            Assert.AreEqual("Test user", user.name);
        }

        /// <summary>
        /// Test if a users root folder is created when a user
        /// is created.
        /// </summary>
        [TestMethod]
        public void GetUserRootFolderTest()
        {
            User user = engine.userhandler.GetUser("testuser", "test123");
            bool exists = Directory.Exists("root/" + user.username);

            Assert.AreEqual(true, exists);
        }

        /// <summary>
        /// Test to make sure it's possible to create a new folder.
        /// </summary>
        [TestMethod]
        public void CreateNewFolderTest()
        {
            User user = engine.userhandler.GetUser("testuser", "test123");
            engine.folder.CreateNewFolder(user, "sampleFolder");

            bool exists = Directory.Exists("root/" + user.username + "/sampleFolder");

            Assert.AreEqual(true, exists);
        }

        /// <summary>
        /// Test to make sure it's possible to delete a folder.
        /// </summary>
        [TestMethod]
        public void DeleteFolderTest()
        {
            User user = engine.userhandler.GetUser("testuser", "test123");
            engine.folder.DeleteFolder(user, "sampleFolder");

            bool exists = Directory.Exists("root/" + user.username + "/sampleFolder");

            Assert.AreEqual(false, exists);
        }

        ///<summary>
        ///Check that it's possible to delete a user from the database.
        ///</summary>
        [TestMethod]
        public void DeleteUserTest()
        {
            User user1 = engine.userhandler.GetUser("testuser", "test123");
            engine.userhandler.DeleteUser(user1);
            User user = engine.userhandler.GetUser("testuser", "test123");
            Assert.AreEqual(null, user.username);
        }

        /// <summary>
        /// Check to make sure that a users root folder is removed
        /// after a user has been deleted from the system.
        /// </summary>
        [TestMethod]
        public void DeleteUserRootFolder()
        {
            bool exists = Directory.Exists("root/testuser");
            Assert.AreEqual(false, exists);
        }

    }
}
