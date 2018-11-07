using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.DAL
{
    public class DBTablePropertie<T> where T : class, new()
    {
        #region 属性

        #region 实体类属性
        /// <summary>
        /// 实体类名称（表名称）
        /// </summary>
        protected internal string TableName => typeof(T).Name;
        /// <summary>
        /// 实体类所有公共属性
        /// </summary>
        protected internal PropertyInfo[] PropInfo => typeof(T).GetProperties();
        /// <summary>
        /// 字段名集合
        /// </summary>
        protected internal List<string> ColumnsList => PropInfo.Select(m => m.Name).ToList();
        /// <summary>
        /// 所有字段名（以【,】分割）
        /// </summary>
        protected internal string Columns => String.Join(",   ", ColumnsList);
        /// <summary>
        /// 实体类所有公共属性
        /// </summary>
        protected internal List<object> ValueList => ColumnsList.Select(m=> GetPropertyValue(m)).ToList();
        /// <summary>
        /// 所有字段名（以【,】分割）
        /// </summary>
        protected internal string Values => String.Join(" ,", ValueList.Select(m => FormatValue(m)));
        #endregion

        #endregion

        /// <summary>
        /// 根据属性名称获取属性值
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns></returns>
        private object GetPropertyValue(string propertyName)=> typeof(T).GetProperty(propertyName).GetValue(this);
        /// <summary>
        /// 获取当前字段插入语句格式
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public object FormatValue(object value)
        {
            if (value == null)
            {
                return "NULL";
            }
            else
            {
                if (value is DateTime)
                {
                    var date = Convert.ToDateTime(value);
                    if (date < Convert.ToDateTime("1900-1-1"))
                    {
                        date = Convert.ToDateTime("1900-1-1");
                    }
                    return "('" + date.ToString("yyyy-MM-dd HH:mm:ss") + "') ";
                }
                else if (value is Enum)
                {
                    return Convert.ToInt64(value);
                }
                else if (value is byte[])
                {
                    string bytesString = "0x" + BitConverter.ToString((byte[])value).Replace("-", "");
                    return bytesString;
                }
                else if (value is Boolean)
                {
                    return Convert.ToBoolean(value) ? "1" : "0";
                }
                else if (value is String || value is object)
                {
                    return "N'" + ToSqlFilter(value.ToString()) + "'";
                }
                else
                {
                    return value;
                }
            }
        }
        public string ToSqlFilter(string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                value = value.Replace("'", "''");
            }
            return value;
        }
    }
}
