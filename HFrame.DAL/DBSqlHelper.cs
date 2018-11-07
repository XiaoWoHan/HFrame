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

        public DBSqlHelper()
        {

        }
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public string GetTableSelectSql()
        {
            StringBuilder SelectSql = new StringBuilder();
            SelectSql.Append(SELECT);
            SelectSql.Append(Columns);
            SelectSql.Append(FROM);
            SelectSql.Append(TableName);
            return SelectSql.ToString();
        }
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <returns></returns>
        public string GetTableInsertSql()
        {
            StringBuilder InsertSql = new StringBuilder();
            InsertSql.Append(INSERT);
            InsertSql.Append(TableName);
            InsertSql.Append($" (   {Columns}  )    ");
            InsertSql.Append(VALUES);
            InsertSql.Append($" (   {Values}    )   ");
            return InsertSql.ToString();
        }
    }
}
