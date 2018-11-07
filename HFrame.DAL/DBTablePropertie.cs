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
        protected internal List<object> ColumnsValueList => ColumnsList.Select(m=> GetPropertyValue(m)).ToList();
        /// <summary>
        /// 所有字段名（以【,】分割）
        /// </summary>
        protected internal string Values
        {
            get
            {
                List<String> ValueStr = new List<String>();

                foreach (var item in ColumnsValueList)
                {
                    if(item is String)
                    {
                        ValueStr.Add($"   '{item}' ");
                        continue;
                    }
                    if(item is Int32)
                    {
                        ValueStr.Add($"    {item}   ");
                        continue;
                    }
                    if (item is DateTime)
                    {
                        ValueStr.Add($"    '{item}'   ");
                        continue;
                    }
                    if (item is Single)
                    {
                        ValueStr.Add($"    {item}   ");
                        continue;
                    }
                    if (item is Double)
                    {
                        ValueStr.Add($"    {item}   ");
                        continue;
                    }
                    if (item is Decimal)
                    {
                        ValueStr.Add($"    {item}   ");
                        continue;
                    }
                    if (item is Decimal)
                    {
                        ValueStr.Add($"    {item}   ");
                        continue;
                    }
                    if (item is Boolean)
                    {
                        ValueStr.Add($"    {(Convert.ToBoolean(item) ? 1 : 0)}   ");
                        continue;
                    }
                    ValueStr.Add($"    {item}   ");
                }
                return String.Join("    ,   ",ValueStr);
            }
        }
        #endregion

        #endregion

        /// <summary>
        /// 根据属性名称获取属性值
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns></returns>
        private object GetPropertyValue(string propertyName)=> typeof(T).GetProperty(propertyName).GetValue(this);
    }
}
