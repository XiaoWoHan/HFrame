using System;
using System.ComponentModel.DataAnnotations;

namespace CommonModel
{
    public class MemberModel
    {
        /// <summary>
        /// 用户标识
        /// </summary>
        [Required(ErrorMessage = "用户标识不可为空")]
        [StringLength(16,ErrorMessage ="用户标识错误")]
        public string MemberOID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "用户名不可为空")]
        [StringLength(35,MinimumLength = 6, ErrorMessage = "用户名错误")]
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
