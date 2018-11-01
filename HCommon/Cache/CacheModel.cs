using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCommon.Cache
{
    public abstract class CacheModel
    {
        #region 属性
        /// <summary>
        /// 锁
        /// </summary>
        protected readonly object _lockeder = new object();
        /// <summary>
        /// 链接字符串
        /// </summary>
        protected string ConnectPath { get; set; }
        #endregion

        #region 构造函数
        public CacheModel() => ConnectPath = "127.0.0.1:6379";
        public CacheModel(string Path) => ConnectPath = Path;
        #endregion

        #region 方法
        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public abstract object Get(string key);
        /// <summary>
        /// 获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public abstract T Get<T>(string key) where T : class, new();
        /// <summary>
        /// 插入对象
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        public abstract bool Insert(string key, object data);
        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="key"></param>
        public abstract bool Remove(string key);
        /// <summary>
        /// 判断key是否存在
        /// </summary>
        public abstract bool Exists(string key);
        #endregion
    }
}
