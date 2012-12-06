using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SliceOfPie;

namespace SliceOfPieTest
{
    [TestClass]
    public class UnitTest1
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
            User user2 = engine.userhandler.NewUser("123123 user", "sadfsadf", "asdffsdasdf");
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

        [TestMethod]
        public void DeleteUserTest()
        {
            User user1 = engine.userhandler.NewUser("Test user", "testuser", "test123");
            //User user2 = engine.userhandler.GetUser("testuser", "test123");
            //engine.userhandler.DeleteUser("testuser");
            //Assert.AreEqual(null, "testuser");
        }

    }
}
