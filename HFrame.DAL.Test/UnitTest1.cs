using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HFrame.DAL.Test
{
    [TestClass]
    public class Data_UserTest
    {
        [TestMethod]
        public void GetWhereTest()
        {
            var a=Data_User.Current.GetFirst(m => m.Name == 11.ToString());
            Assert.IsTrue(a!=null);
        }
    }
}
