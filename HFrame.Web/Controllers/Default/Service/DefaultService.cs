using HFrame.Common.Cache;
using HFrame.Common.Model;
using HFrame.DAL;
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
            Data_User U = new Data_User
            {
                Name = "张三",
                Password = "123",
                UserName = "123",
                Telephone = "123",
                CreateTime = DateTime.Now,
                IsLocked = false,
                IsDeleted = false
            };
            U.Add();
            return RedisHelper.Current.Add("Member",Model);
        }
    }
}