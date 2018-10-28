using System;

namespace CommonModel
{
    public class MemberModel
    {
        /// <summary>
        /// 用户标识
        /// </summary>
        public string MemberOID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string MemberName { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string MemberNiName { get; set; }
        /// <summary>
        /// 登陆标识
        /// </summary>
        private string Token { get; set; }
    }
}
