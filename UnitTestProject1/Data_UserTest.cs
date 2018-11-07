using System;
using HFrame.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class Data_UserTest
    {
        [TestMethod]
        public void TestAdd()
        {
            for (var i = 1; i <= 30; i++)
            {
                var User = new Data_User
                {
                    OID = Guid.NewGuid().ToString(),
                    IsDeleted = false,
                    IsLocked = false,
                    Name = "1231111Name",
                    Telephone = "32s4da65a1s2d3",
                    Password = "aa4ssdafadstrafg2345d",
                    UserName = "123441",
                    CreateTime = DateTime.Now
                };
                Assert.IsTrue(User.Add());
            }
        }
        [TestMethod]
        public void TestGet()
        {
            Assert.IsNotNull(Data_User.Current.Get());
        }
    }
}
