using System;
using HFrame.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var aa = Data_User.Current.GetFirst(m=>m.Name==11.ToString());
            Assert.IsNotNull(aa);
        }
    }
}
