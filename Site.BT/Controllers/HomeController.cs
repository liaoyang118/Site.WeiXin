﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.BT.Filder;
using Site.BT.Manager.Common;

namespace Site.BT.Controllers
{
    [Identity(IsLogin = true)]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.name = HttpContextUntity.CurrentUser.nickname;
            return View();
        }
    }
}