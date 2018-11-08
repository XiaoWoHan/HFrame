using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.DAL
{
    /// <summary>
    /// SQL语句帮助类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DBSqlHelper<T>: DBTablePropertie<T> where T : class, new()
    {
        #region 属性
        #region SQL字段封装
        private const string SELECT = " SELECT  ";
        private const string FROM = "   FROM    ";
        private const string WHERE = "  WHERE   ";

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
        private static object _selectLocker = new object();
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public string GetTableSelectSql()
        {
            lock (_selectLocker)
            {
                StringBuilder SelectSql = new StringBuilder();
                SelectSql.Append(SELECT);
                SelectSql.Append(base.Columns);
                SelectSql.Append(FROM);
                SelectSql.Append(base.TableName);
                return SelectSql.ToString();
            }
        }

        private static object _whereSelectLocker = new object();
        public string GetTableWhereSelectSql(Expression<Func<T, bool>> expression)
        {
            lock (_whereSelectLocker)
            {
                StringBuilder SelectSql = new StringBuilder();
                SelectSql.Append(SELECT);
                SelectSql.Append(base.Columns);
                SelectSql.Append(FROM);
                SelectSql.Append(base.TableName);
                SelectSql.Append(WHERE);
                SelectSql.Append(GetTableWhereSql(expression));
                return SelectSql.ToString();
            }
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

        #region 查询条件
        private static object _WhereSqlLocker = new object();
        public string GetTableWhereSql(Expression<Func<T, bool>> expression)
        {
            lock (_WhereSqlLocker)
            {
                return DealExpress(expression);
            }
        }
        public static string DealExpress(Expression exp)
        {
            if (exp is LambdaExpression)
            {
                LambdaExpression l_exp = exp as LambdaExpression;
                return DealExpress(l_exp.Body);
            }
            if (exp is BinaryExpression)
            {
                return DealBinaryExpression(exp as BinaryExpression);
            }
            if (exp is MemberExpression)
            {
                return DealMemberExpression(exp as MemberExpression);
            }
            if (exp is ConstantExpression)
            {
                return DealConstantExpression(exp as ConstantExpression);
            }
            if (exp is UnaryExpression)
            {
                return DealUnaryExpression(exp as UnaryExpression);
            }
            return "";
        }
        public static string DealUnaryExpression(UnaryExpression exp)
        {
            return DealExpress(exp.Operand);
        }
        public static string DealConstantExpression(ConstantExpression exp)
        {
            object vaule = exp.Value;
            string v_str = string.Empty;
            if (vaule == null)
            {
                return "NULL";
            }
            if (vaule is string)
            {
                v_str = string.Format("'{0}'", vaule.ToString());
            }
            else if (vaule is DateTime)
            {
                DateTime time = (DateTime)vaule;
                v_str = string.Format("'{0}'", time.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                v_str = vaule.ToString();
            }
            return v_str;
        }
        public static string DealBinaryExpression(BinaryExpression exp)
        {

            string left = DealExpress(exp.Left);
            string oper = GetOperStr(exp.NodeType);
            string right = DealExpress(exp.Right);
            if (right == "NULL")
            {
                if (oper == "=")
                {
                    oper = " is ";
                }
                else
                {
                    oper = " is not ";
                }
            }
            return left + oper + right;
        }
        public static string DealMemberExpression(MemberExpression exp)
        {
            return exp.Member.Name;
        }
        public static string GetOperStr(ExpressionType e_type)
        {
            switch (e_type)
            {
                case ExpressionType.OrElse: return " OR ";
                case ExpressionType.Or: return "|";
                case ExpressionType.AndAlso: return " AND ";
                case ExpressionType.And: return "&";
                case ExpressionType.GreaterThan: return ">";
                case ExpressionType.GreaterThanOrEqual: return ">=";
                case ExpressionType.LessThan: return "<";
                case ExpressionType.LessThanOrEqual: return "<=";
                case ExpressionType.NotEqual: return "<>";
                case ExpressionType.Add: return "+";
                case ExpressionType.Subtract: return "-";
                case ExpressionType.Multiply: return "*";
                case ExpressionType.Divide: return "/";
                case ExpressionType.Modulo: return "%";
                case ExpressionType.Equal: return "=";
            }
            return "";
        }
        #endregion
    }
}
