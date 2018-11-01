using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCommon.Cache
{
    public class CacheModel
    {
        /// <summary>
        /// 链接字符串
        /// </summary>
        protected static string ConnectPath { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        private static int _outTime = 600;
        protected static int OutTime { get => _outTime; set => _outTime = value; }
        /// <summary>
        /// 锁
        /// </summary>
        protected static readonly object _lockeder = new object();
    }
}
