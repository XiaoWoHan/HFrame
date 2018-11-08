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
            Assert.IsNull(Data_User.Current.GetFirst(m=>m.Name=="11"||m.OID.Equals("3asd4352fadsf")&&m.IsDeleted!=false&&m.IsLocked==true&&true));
        }
    }
}
