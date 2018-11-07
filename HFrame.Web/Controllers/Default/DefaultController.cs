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
            var Status = DefaultService.Register(result, Model);
            return Json(result);
        }
    }
}