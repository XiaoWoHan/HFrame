using HCommon.Helper;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace HCommon.Cache
{
    public class RedisHelper : CacheModel
    {
        #region 属性
        /// <summary>
        /// 连接对象
        /// </summary>
        public IConnectionMultiplexer Connect => ConnectionMultiplexer.Connect("127.0.0.1:6379");
        /// <summary>
        /// 链接数据
        /// </summary>
        public IDatabase DataBase => Connect.GetDatabase();
        #endregion

        #region 构造函数
        public RedisHelper() { }
        public RedisHelper(string Path) : base(Path) { }
        #endregion

        #region 方法
        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override object Get(string key)
        {
            return Get<object>(key);
        }
        /// <summary>
        /// 获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public override T Get<T>(string key)
        {
            var value = default(T);///默认返回值
            var cacheValue = DataBase.StringGet(key);
            if (!cacheValue.IsNull&& cacheValue.HasValue)
            {
                value = JsonHelper.ParseJson<T>(cacheValue.ToString());
            }
            return value;
        }
        /// <summary>
        /// 插入对象
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        public override bool Insert(string key, object data)
        {
            lock (_lockeder)
            {
                var JsonData = JsonHelper.ToJson(data);
                return DataBase.StringSet(key, JsonData);
            }
        }
        public override bool Insert(string key, object data, int MaxTime)
        {
            lock (_lockeder)
            {
                var timeSpan = TimeSpan.FromSeconds(MaxTime);
                var jsonData = JsonHelper.ToJson(data);
                return DataBase.StringSet(key, jsonData, timeSpan);
            }
        }
        public override bool Insert(string key, object data, DateTime EndTime)
        {
            lock (_lockeder)
            {
                var timeSpan = EndTime - DateTime.Now;
                var jsonData = JsonHelper.ToJson(data);
                return DataBase.StringSet(key, jsonData, timeSpan);
            }
        }
        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="key"></param>
        public override bool Remove(string key)
        {
            lock (_lockeder)
            {
                return DataBase.KeyDelete(key);
            }
        }
        /// <summary>
        /// 判断key是否存在
        /// </summary>
        public override bool Exists(string key)
        {
            return DataBase.KeyExists(key);
        }
        #endregion
    }
}
