using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.DAL
{
    internal class DBSqlHelper<T> where T : class, new()
    {
        #region 属性
        #region 实体类属性
        /// <summary>
        /// 实体类名称（表名称）
        /// </summary>
        private readonly static string TableName = typeof(T).Name;
        /// <summary>
        /// 实体类所有公共属性
        /// </summary>
        private readonly static PropertyInfo[] PropInfo = typeof(T).GetProperties();
        /// <summary>
        /// 字段名集合
        /// </summary>
        private readonly static List<string> ColumnsList = PropInfo.Select(m => m.Name).ToList();
        /// <summary>
        /// 所有字段名（以【,】分割）
        /// </summary>
        private readonly static string Columns = String.Join(",   ", ColumnsList);
        /// <summary>
        /// 实体类所有公共属性
        /// </summary>
        private readonly static List<string> ColumnsValueList = PropInfo.Select(m => m.GetValue(typeof(T)).ToString()).ToList();
        /// <summary>
        /// 所有字段名（以【,】分割）
        /// </summary>
        private readonly static string Values = String.Join(",   ", ColumnsValueList);
        #endregion

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
        public static string GetTableSelectSql()
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
        public static string GetTableInsertSql()
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
