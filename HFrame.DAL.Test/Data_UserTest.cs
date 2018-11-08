using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.DAL.Test
{
    [TestClass]
    public class Data_UserTest
    {
        [TestMethod]
        public void TestDelete()
        {
            var aaa = Data_User.Current.GetFirst();
            aaa.Name = "123123";
            Assert.IsTrue(aaa.Update());
        }
    }
}
