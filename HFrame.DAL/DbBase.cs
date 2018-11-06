using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.DAL
{
    public class DbBase<T> where T : class, new()
    {
        #region 属性
        private static IDbConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HFrameDB;Integrated Security=True;MultipleActiveResultSets=True");
        #endregion

        #region 构造函数
        #endregion
        public static T Get()
        {
            var SelectStr = DBSqlHelper<T>.GetTableSelectSql();
            return connection.Query<T>(SelectStr).FirstOrDefault();
        }
        public bool Add()
        {
            var InsertStr = DBSqlHelper<T>.GetTableInsertSql();
            return connection.Execute(InsertStr)>0;
        }
    }
}
