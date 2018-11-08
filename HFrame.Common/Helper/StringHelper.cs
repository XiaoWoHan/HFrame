using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HFrame.Common.Helper
{
    /// <summary>
    /// 字符串帮助类
    /// </summary>
    public static class StringHelper
    {
        #region 字符串长度
        /// <summary>
        /// 获得字符串的长度,一个汉字的长度为1
        /// </summary>
        public static int GetStringLength(this string s)
        {
            if (!string.IsNullOrEmpty(s))
                return Encoding.Default.GetBytes(s).Length;

            return 0;
        }
        /// <summary>
        /// 获取字符串长度
        /// </summary>
        /// <param name="s"></param>
        /// <param name="IsBytes">true:汉字为2，false:汉字为1</param>
        /// <returns></returns>
        public static int GetStringLength(this string s,bool IsBytes = false)
        {
            if (!String.IsNullOrEmpty(s) && IsBytes)
                return System.Text.Encoding.Default.GetBytes(s).Length;
            else if (!String.IsNullOrEmpty(s) && !IsBytes)
                return GetStringLength(s);
            else return 0;
        }
        #endregion

        #region 分割字符串

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <param name="splitStr">分隔字符串</param>
        /// <returns></returns>
        public static string[] SplitString(string sourceStr, string splitStr)
        {
            if (string.IsNullOrEmpty(sourceStr) || string.IsNullOrEmpty(splitStr))
                return new string[0] { };

            if (sourceStr.IndexOf(splitStr) == -1)
                return new string[] { sourceStr };

            if (splitStr.Length == 1)
                return sourceStr.Split(splitStr[0]);
            else
                return Regex.Split(sourceStr, Regex.Escape(splitStr), RegexOptions.IgnoreCase);

        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <returns></returns>
        public static string[] SplitString(string sourceStr)
        {
            return SplitString(sourceStr, ",");
        }

        #endregion

        public static bool IsContainsIn(this string thisValue, params string[] inValues)
        {
            return inValues.Any(it => thisValue.Contains(it));
        }
    }
}
