﻿using System;
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
        ClientSystemFacade facade = ClientSystemFacade.GetInstance();

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
            Document testDocument = facade.OpenDocument(225, testUser);

            Assert.AreEqual(true, engine.dbCon.CheckForUserDocument(testUser, testDocument));
        }

        [TestMethod]
        public void DeleteUserdocumentTest()
        {
            User testUser = engine.userhandler.GetUser("hvass", "1234");
            Document testDocument = facade.OpenDocument(225, testUser);

            engine.dbCon.DeleteUserDocument(testUser, testDocument);

            Assert.AreEqual(false, engine.dbCon.CheckForUserDocument(testUser, testDocument));
        }

        [TestMethod]
        public void InsertUserdocumentTest()
        {
            User testUser = engine.userhandler.GetUser("hvass", "1234");
            Document testDocument = facade.OpenDocument(225, testUser);

            engine.dbCon.InsertUserDocument(testUser, testDocument.documentId, Permission.Permissions.Edit);

            Assert.AreEqual(true, engine.dbCon.CheckForUserDocument(testUser, testDocument));
        }
    }
}
