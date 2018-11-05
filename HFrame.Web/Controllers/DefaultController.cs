using System;
using System.Collections.Generic;
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
        public ActionResult Login()
        {

            return Json();
        }
        public ActionResult Register()
        {
            return View();
        }
    }
}