using HFrame.Common.Model;
using HFrame.Web.Default.Model;
using HFrame.Web.Default.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HFrame.Web.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        //public ActionResult Login(RegisterModel Model)
        //{
        //}
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel Model)
        {
            var result = new ResultModel();
            ValidationContext context = new ValidationContext(Model, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var valid=Validator.TryValidateObject(Model, context, results, true);
            if (valid)
            {
                var Status = DefaultService.Register(Model);
                if (Status)
                {
                    result.ErrorMsg = "注册成功";
                    return Json(result);
                }
            }
            result.ErrorCode = -1;
            result.ErrorMsg = $"注册失败 {results.FirstOrDefault()?.ErrorMessage}";
            return Json(result);
        }
    }
}