using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.BaseModel
{
    public class UserModel
    {
        public string UserOID { get; private set; }
        public string UserName { get; private set; }
        public string UserCode { get; private set; }
        public string UserHead { get; set; }
    }
}