using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Untity;

namespace Site.WeiXin.Manager.Filder
{
    /// <summary>
    /// 管理员权限验证
    /// </summary>
    public class PermissionAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool isAdmin = HttpContextUntity.CurrentUser.IsAdmin;
            if (!isAdmin)
            {
                string httpMethod = filterContext.RequestContext.HttpContext.Request.HttpMethod.ToLower();
                if (httpMethod == "post")
                {
                    filterContext.Result = new JsonResult() { Data = UntityTool.JsonResult(false, "无此操作权限") };
                    return;
                }
                else
                {
                    //无权限访问
                    filterContext.Result = new RedirectResult("/Common/NotPermission");
                    return;
                }
            }
        }
    }
}