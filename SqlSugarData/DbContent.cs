using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugarData
{
    public class DbContent
    {
        public DbContent()
        {

        }
        /// <summary>
        /// 创建连接
        /// </summary>
        /// <param name="DbConnStr">连接字符串</param>
        public DbContent(string DbConnStr)
        {
            ConnentStr = DbConnStr;
        }
        #region 连接属性

        /// <summary>
        /// 连接字符串
        /// </summary>
        private string ConnentStr => ConfigurationManager.ConnectionStrings[1].ConnectionString;

        #endregion

        public SqlSugarClient Db
        {
            get => new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ConnentStr,//数据库连接字符串
                DbType = DbType.SqlServer,         //必填, 数据库类型
            });
        }
    }
}
