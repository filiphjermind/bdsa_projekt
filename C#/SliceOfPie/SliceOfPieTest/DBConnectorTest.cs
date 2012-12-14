using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SliceOfPie;
using System.IO;
using System.Collections.Generic;

namespace SliceOfPieTest
{
    /// <summary>
    /// Summary description for DBConnectorTest
    /// </summary>
    [TestClass]
    public class DBConnectorTest
    {
        Engine engine = new Engine();

        public DBConnectorTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        /*[TestMethod]
        public void TestGetUserdocumentsByUser()
        {
            User testUser = engine.userhandler.GetUser("hvass", "1234");

            
        }*/

        [TestMethod]
        public void CheckUserdocumentTest()
        {
            User testUser = engine.userhandler.GetUser("hvass", "1234");
            //Document testDocument = engine.dbCon.GetDocument(
        }

        [TestMethod]
        public void InsertUserdocumentTest()
        {
            User testUser = engine.userhandler.GetUser("hvass", "1234");

            Document testDoc = engine.userhandler.docHandler.NewDocument(testUser, "", Permission.Permissions.Edit);
            testDoc.content = "asd";

            engine.userhandler.docHandler.SaveDocument(testUser, testDoc, "fakeDocument.html");

            string path = "root/hvass/fakeDocument.html";
            //Document doc = engine.userhandler.docHandler.OpenDocument(218, testUser);
            List<int> testList = engine.dbCon.GetUserdocumentsByUser(testUser);
            Document finalDoc = engine.userhandler.docHandler.OpenDocument(engine.dbCon.GetDocument(testUser.username, path), testUser);

            Assert.AreEqual(true, testList.Contains(finalDoc.documentId));
        }
    }
}
