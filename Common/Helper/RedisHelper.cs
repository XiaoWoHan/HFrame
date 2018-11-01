using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Helper
{
    public class RedisHelper
    {
        private static string RedisPath;
        #region 属性
        public RedisHelper()
        {
            System.Configuration.ConfigurationSettings.AppSettings["RedisPath"];
        }
        public RedisHelper(string RedisPath)
        {
            this.RedisPath = RedisPath;
        }
        #endregion
    }
}
