using System;
using HFrame.Common.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HFrame.Common.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            for(var i = 0; i <= 100; i++)
            {
                Assert.IsTrue(LogHelper.Log("TestOneLog"));
                Assert.IsTrue(LogHelper.LogError("TestOneLogError"));
                Assert.IsNotNull(LogHelper.GetErrors());
            }
        }
    }
}
