using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SliceOfPie;

namespace SliceOfPieTest
{
    [TestClass]
    public class UnitTest1
    {
        private Engine engine; 
        

        [TestMethod]
        public void CreateNewUserTest()
        {
            engine = new Engine();

            //User user = engine.userhandler.NewUser("Jet Li", "jetli", "12345");

            User user2 = engine.userhandler.GetUser("jetli", "12345");

            Assert.AreEqual("Jet Li", user2.name);
        }
    }
}
