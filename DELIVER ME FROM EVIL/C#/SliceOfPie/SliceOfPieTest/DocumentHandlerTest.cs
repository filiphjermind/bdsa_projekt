﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SliceOfPie;
using System.IO;
using System.Collections.Generic;

namespace SliceOfPieTest
{
    [TestClass]
    public class DocumentHandlerTest
    {
        private Engine engine = new Engine();

        [TestMethod]
        public void OfflineSynchronizationTest()
        {
            //creation of documents and user for testing
            User user1 = engine.userhandler.GetUser("mrT","1234");
            Document document1 = new Document(user1, "tmp", "There.html", Permission.Permissions.Edit);
            Document document2 = new Document(user1, "tmp", "There.html", Permission.Permissions.Edit);
            Document document3 = new Document(user1, "tmp", "There.html", Permission.Permissions.Edit);

            Document document4 = new Document(user1, "tmp", "There.html", Permission.Permissions.Edit);
            Document document5 = new Document(user1, "tmp", "There.html", Permission.Permissions.Edit);
            Document document6 = new Document(user1, "tmp", "There.html", Permission.Permissions.Edit);

            document2.lastChanged = new DateTime(2012, 12, 5);
            document3.lastChanged = new DateTime(2012, 12, 5);
            document4.lastChanged = new DateTime(2012, 12, 2);
            document5.lastChanged = new DateTime(2012, 12, 7);

            List<Document> userLocalDocuments = new List<Document>();
            List<Document> userServerDocuments = new List<Document>();

            userLocalDocuments.Add(document1); //not on server
            userLocalDocuments.Add(document2); //most recent version
            userLocalDocuments.Add(document3); //oldest version

            userServerDocuments.Add(document4); //oldest version
            userServerDocuments.Add(document5); //most recent version
            userServerDocuments.Add(document6); //not local

            List<Document> testSet = engine.userhandler.docHandler.OfflineSynchronization(userLocalDocuments, userServerDocuments);
            Assert.AreEqual(4,testSet.Count);
            Assert.AreEqual(true, testSet.Contains(document1));
            Assert.AreEqual(true, testSet.Contains(document2));
            Assert.AreEqual(true, testSet.Contains(document5));
            Assert.AreEqual(true, testSet.Contains(document6));
        }

        [TestMethod]
        public void ShareDocumentTest()
        {
            User ownerUser = engine.userhandler.GetUser("mrT", "1234");
            User toUser = engine.userhandler.GetUser("bergar", "1234");

            Document testDoc = engine.userhandler.docHandler.OpenDocument(81, ownerUser);
            //testDoc.content = "here is some content";
            engine.userhandler.docHandler.ShareDocument(ownerUser, testDoc, Permission.Permissions.Edit,"", toUser);

            Assert.AreEqual(true ,toUser.documents.Contains(testDoc));
        }
    }
}
