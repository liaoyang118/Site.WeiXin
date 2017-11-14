using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.BT.DataAccess.Access;
using Site.BT.DataAccess.Model;
using Site.BT.DataAccess.Service;
using Site.BT.DataAccess.Service.PartialService.Search;
using Site.BT.Filder;
using Site.BT.Manager.Common;
using Site.Untity;

namespace Site.BT.Controllers
{
    [Identity(IsLogin = false)]
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult BindingAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BindingAccount(string account, string pwd)
        {
            int result = 0;
            BusinessUser bInfo = BusinessUserService.Select(string.Format(" where Account=N'{0}' and Status={1}", account, (int)SiteEnum.AccountState.正常)).FirstOrDefault();
            if (bInfo != null)
            {
                BusinessAccountBinding babInfo = BusinessAccountBindingService.Select(string.Format(" where BusinessUserId={0}", bInfo.Id)).FirstOrDefault();
                if (babInfo == null)
                {
                    BusinessAccountBinding bab = new BusinessAccountBinding();
                    bab.BusinessUserId = bInfo.Id;
                    bab.BussinessUserAccount = account;
                    bab.CreateTime = DateTime.Now;
                    bab.OpenId = HttpContextUntity.CurrentUser.openid;

                    result = BusinessAccountBindingService.Insert(bab);
                }
                else
                {
                    ModelState.AddModelError("exist", "该账号已被绑定");
                }
            }
            else
            {
                ModelState.AddModelError("404", "不存在该账户");
            }

            if (result > 0)
            {
                return RedirectToAction("index", "home");
            }

            return View();
        }
    }
}