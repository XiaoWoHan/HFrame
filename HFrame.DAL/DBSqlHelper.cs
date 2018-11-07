using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.DAL
{
    public class DBSqlHelper<T>: DBTablePropertie<T> where T : class, new()
    {
        #region 属性
        #region SQL字段封装
        private const string SELECT = " SELECT  ";
        private const string FROM = "   FROM    ";
        private const string INSERT = "   INSERT    INTO    ";
        private const string VALUES = "   VALUES    ";
        #endregion
        #endregion

        #region 构造函数
        public DBSqlHelper()
        {

        }
        #endregion

        #region 查询操作
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public string GetTableSelectSql()
        {
            StringBuilder SelectSql = new StringBuilder();
            SelectSql.Append(SELECT);
            SelectSql.Append(base.Columns);
            SelectSql.Append(FROM);
            SelectSql.Append(base.TableName);
            return SelectSql.ToString();
        }
        #endregion

        #region 插入操作
        private static object _InsertSqlLocker = new object();
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <returns></returns>
        public string GetTableInsertSql()
        {
            lock (_InsertSqlLocker)
            {
                StringBuilder InsertSql = new StringBuilder();
                InsertSql.Append(INSERT);
                InsertSql.Append(base.TableName);
                InsertSql.Append($" (   {base.Columns}  )    ");
                InsertSql.Append(VALUES);
                InsertSql.Append($" (   {base.Values}    )   ");
                return InsertSql.ToString();
            }
        }
        #endregion
    }
}
