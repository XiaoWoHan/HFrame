using HFrame.Common.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.Web.Tests.Controllers
{
    [TestClass]
    public class LogHelperTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            LogHelper.Log();
        }
    }
}
