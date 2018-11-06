using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.DAL
{
    internal class DBSqlHelper<T> where T : class, new()
    {
        private const string SELECT = " SELECT  ";
        private const string FROM = "   FROM    ";
        private const string INSERT = "   INSERT    ";
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public static string GetTableSelectSql()
        {
            var Props = typeof(T).GetProperties().Select(m => m.Name);//当前实体所有属性
            var PropName = String.Join(",   ", Props);

            StringBuilder SelectSql = new StringBuilder();
            SelectSql.Append(SELECT);
            SelectSql.Append(PropName);
            SelectSql.Append(FROM);
            SelectSql.Append(typeof(T).Name);
            return SelectSql.ToString();
        }
        public static string GetTableInsertSql()
        {
            var Props = typeof(T).GetProperties().Select(m => m.Name);//当前实体所有属性
            var PropName = String.Join(",   ", Props);

            StringBuilder SelectSql = new StringBuilder();
            SelectSql.Append(SELECT);
            SelectSql.Append(PropName);
            SelectSql.Append(FROM);
            SelectSql.Append(typeof(T).Name);
            return SelectSql.ToString();
        }
    }
}
