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
        public ActionResult Index()
        {
            return View("test");
        }


        [HttpPost, AllowAnonymous]
        public ActionResult Do(string name, string pwd)
        {
            SystemUserSearchInfo search = new SystemUserSearchInfo();
            search.Account = name;
            search.AccountState = (int)SiteEnum.AccountState.正常;
            IList<SystemUser> list = SystemUserService.Select(search.ToWhereString());
            if (list.Count > 0)
            {
                if (list.Count > 1)
                {
                    return Json(UntityTool.JsonResult(false, "该账号存在多个同名账号，请联系管理员处理！"));
                }
                else
                {
                    SystemUser uInfo = list.FirstOrDefault();
                    string md5Str = UntityTool.Md5_32(pwd);
                    if (md5Str == uInfo.Password)
                    {
                        //创建一个新的票据，将客户ip记入ticket的userdata 
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                        1, name, DateTime.Now, DateTime.Now.AddMinutes(30),
                        false, uInfo.Id.ToString());
                        //将票据加密 
                        string authTicket = FormsAuthentication.Encrypt(ticket);
                        //将加密后的票据保存为cookie 
                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, authTicket);
                        //使用加入了userdata的新cookie 
                        Response.Cookies.Add(cookie);

                        //取值
                        //((System.Web.Security.FormsIdentity)this.Context.User.Identity).Ticket.UserData 


                        return Json(UntityTool.JsonResult(true, "登录成功"));
                    }
                    else
                    {
                        return Json(UntityTool.JsonResult(false, "账号不存在，请确认！"));
                    }
                }
            }
            else
            {
                return Json(UntityTool.JsonResult(false, "账号不存在，请确认！"));
            }

        }

    }
}