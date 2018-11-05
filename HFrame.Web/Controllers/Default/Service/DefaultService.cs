using HFrame.Common.Cache;
using HFrame.Common.Model;
using HFrame.Web.Default.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HFrame.Web.Default.Service
{
    public class DefaultService
    {
        public static bool Register(RegisterModel Model)
        {
            return RedisHelper.Current.Add("Member",Model);
        }
    }
}