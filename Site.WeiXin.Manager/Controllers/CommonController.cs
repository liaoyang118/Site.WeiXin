using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.WeiXin.Manager.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        public ActionResult NotPermission()
        {
            ViewBag.title = "无法访问";
            ViewBag.words = "暂无权限访问";
            return View("~/Views/Common/Test.cshtml");
        }
    }
}