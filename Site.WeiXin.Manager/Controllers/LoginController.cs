using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.WeiXin.DataAccess.Service;
using Site.WeiXin.DataAccess.Model;
using Site.Untity;
using Site.WeiXin.DataAccess.Service.PartialService.Search;
using System.Web.Security;

namespace Site.WeiXin.Manager.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet, AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost, AllowAnonymous]
        public ActionResult Index(string username, string pwd)
        {
            SystemUserSearchInfo search = new SystemUserSearchInfo
            {
                Account = username,
                AccountState = (int)SiteEnum.AccountState.正常
            };
            IList<SystemUser> list = SystemUserService.Select(search.ToWhereString());
            if (list.Count > 0)
            {
                if (list.Count > 1)
                {
                    ModelState.AddModelError("500", "该账号存在多个同名账号，请联系管理员处理！");
                }
                else
                {
                    SystemUser uInfo = list.FirstOrDefault();
                    string md5Str = UntityTool.Md5_32(pwd);
                    if (md5Str == uInfo.Password)
                    {
                        //保存用户app信息
                        GongzhongAccount gzInfo = GongzhongAccountService.SelectObject(uInfo.GongzhongAccountId);
                        if (gzInfo != null)
                        {
                            uInfo.AppID = gzInfo.AppID;
                            uInfo.AppSecret = gzInfo.AppSecret;
                            uInfo.Name = gzInfo.Name;
                        }
                        HttpContextUntity.CurrentUser = uInfo;
                        string remenber = Request["remenber"] ?? string.Empty;

                        #region ticket 方法

                        //创建一个新的票据，将客户ip记入ticket的userdata 
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                        1, username, DateTime.Now, DateTime.Now.AddHours(2), false, uInfo.Id.ToString());
                        //将票据加密 
                        string authTicket = FormsAuthentication.Encrypt(ticket);
                        //将加密后的票据保存为cookie 
                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, authTicket);
                        if (!string.IsNullOrEmpty(remenber))
                        {
                            cookie.Expires = DateTime.Now.AddDays(1);
                        }
                        //使用加入了userdata的新cookie 
                        Response.Cookies.Add(cookie);
                        //取值
                        //((System.Web.Security.FormsIdentity)this.Context.User.Identity).Ticket.UserData
                        #endregion
                        if (uInfo.IsSuperAdmin)
                        {
                            return RedirectToAction("AppList", "System");
                        }
                        return RedirectToAction("index", "home");
                    }
                    else
                    {
                        ModelState.AddModelError("403", "密码错误，请确认！");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("404", "账号不存在，请确认！");
            }

            return View();
        }


        public void LoginOut()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

    }
}