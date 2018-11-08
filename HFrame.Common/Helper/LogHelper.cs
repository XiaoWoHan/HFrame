using HFrame.Common.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace HFrame.Common.Helper
{
    public class LogHelper
    {
        private const string LOG = "HFrame.Redis.Log";
        private static readonly string ERROR = "HFrame.Redis.Log.Error."+DateTime.Now.ToString("yyyy-MM-dd");
        public static bool Log(string Comment)
        {
            var Logs = RedisHelper.Current.Get<List<string>>(LOG)??new List<string>();
            Logs.Add(Comment);
            return RedisHelper.Current.AddOrUpdate(LOG, Logs);
        }
        public static bool LogError(string ErrorComment)
        {
            var Errors = RedisHelper.Current.Get<List<string>>(ERROR)??new List<string>();
            Errors.Add(ErrorComment);
            return RedisHelper.Current.AddOrUpdate(ERROR, Errors);
        }
        public static List<String> GetErrors()
        {
            return RedisHelper.Current.Get<List<string>>(ERROR);
        }
    }
}
