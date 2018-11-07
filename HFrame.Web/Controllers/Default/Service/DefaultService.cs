using HFrame.Common.Cache;
using HFrame.Common.Model;
using HFrame.DAL;
using HFrame.Web.Default.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HFrame.Web.Default.Service
{
    public class DefaultService
    {
        public static bool Register(ResultModel result, RegisterModel Model)
        {
            #region 模型表单验证
            ValidationContext context = new ValidationContext(Model, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(Model, context, results, true);
            #endregion
            if (valid)
            {
                return RedisHelper.Current.Add("Member", Model);
            }
            else
            {
                result.ErrorCode = -1;
                result.ErrorMsg = $"注册失败 {results.FirstOrDefault()?.ErrorMessage}";
                return false;
            }
        }
    }
}