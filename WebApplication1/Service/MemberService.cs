using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace WebApplication1.Service
{
    public class MemberService
    {
        public static bool Login(string UserName,string Password)
        {
            if (String.IsNullOrEmpty(UserName))
            {
                return false;
            }
            if (String.IsNullOrEmpty(Password))
            {
                return false;
            }
            XmlDocument UserXml = new XmlDocument();
            
        }
    }
}