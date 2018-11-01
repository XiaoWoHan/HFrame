using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCommon.Cache
{
    class CacheHelper : CacheModel
    {
        private static ConcurrentDictionary<string, object> _cachemodel = new ConcurrentDictionary<string, object>();

        #region 方法
        public override bool Exists(string key)
        {
            return _cachemodel.ContainsKey(key);
        }

        public override object Get(string key)
        {
            return Get<object>(key);
        }

        public override T Get<T>(string key)
        {
            if (_cachemodel != null && Exists(key))
            {
                return _cachemodel["key"] as T;
            }
            return null;
        }

        public override bool Insert(string key, object data)
        {
            throw new NotImplementedException();
        }

        public override bool Remove(string key)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
