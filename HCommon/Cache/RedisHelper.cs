using HCommon.Helper;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace HCommon.Cache
{
    public class RedisHelper: CacheModel
    {
        #region 构造函数
        public RedisHelper() => ConnectPath = "127.0.0.1:6379";
        public RedisHelper(string Path) => ConnectPath = Path;
        #endregion
        /// <summary>
        /// 连接对象
        /// </summary>
        public static IConnectionMultiplexer Connect => ConnectionMultiplexer.Connect("127.0.0.1:6379");
        /// <summary>
        /// 链接数据
        /// </summary>
        public static IDatabase DataBase => Connect.GetDatabase();

        #region 方法
        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object Get(string key)
        {
            return Get<object>(key);
        }
        /// <summary>
        /// 获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(string key)where T:class,new()
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
        public static void Insert(string key, object data)
        {
            lock (_lockeder)
            {
                var JsonData = JsonHelper.ToJson(data);
                DataBase.StringSet(key, JsonData);
            }
        }
        public static void Insert(string key, object data, int MaxTime)
        {
            lock (_lockeder)
            {
                var timeSpan = TimeSpan.FromSeconds(MaxTime);
                var jsonData = JsonHelper.ToJson(data);
                DataBase.StringSet(key, jsonData, timeSpan);
            }
        }
        public static void Insert(string key, object data, DateTime EndTime)
        {
            lock (_lockeder)
            {
                var timeSpan = EndTime - DateTime.Now;
                var jsonData = JsonHelper.ToJson(data);
                DataBase.StringSet(key, jsonData, timeSpan);
            }
        }
        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            lock (_lockeder)
            {
                DataBase.KeyDelete(key);
            }
        }
        /// <summary>
        /// 判断key是否存在
        /// </summary>
        public static bool Exists(string key)
        {
            return DataBase.KeyExists(key);
        }
        #endregion
    }
}
