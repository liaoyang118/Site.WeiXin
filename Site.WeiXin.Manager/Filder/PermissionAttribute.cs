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
        /// <summary>
        /// 超级管理员验证
        /// </summary>
        public bool AllowSuperAdmin { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string httpMethod = filterContext.RequestContext.HttpContext.Request.HttpMethod.ToLower();

            ViewDataDictionary dic = new ViewDataDictionary();
            dic.Add(new KeyValuePair<string, object>("title", "无法访问"));
            dic.Add(new KeyValuePair<string, object>("words", "该账号无此访问权限"));

            //验证超级管理员

            if (!HttpContextUntity.CurrentUser.IsAdmin)
            {

                if (httpMethod == "post")
                {
                    filterContext.Result = new JsonResult() { Data = UntityTool.JsonResult(false, "无此操作权限") };
                    return;
                }
                else
                {
                    //无权限访问
                    filterContext.Result = new ViewResult()
                    {
                        ViewName = "~/Views/Common/Common.cshtml",
                        ViewData = dic
                    };
                    return;
                }
            }
            else
            {
                if (!AllowSuperAdmin)
                {
                    if (HttpContextUntity.CurrentUser.IsSuperAdmin)
                    {
                        if (httpMethod == "post")
                        {
                            filterContext.Result = new JsonResult() { Data = UntityTool.JsonResult(false, "无此操作权限") };
                            return;
                        }
                        else
                        {
                            //无权限访问
                            filterContext.Result = new ViewResult()
                            {
                                ViewName = "~/Views/Common/Common.cshtml",
                                ViewData = dic
                            };

                            return;
                        }
                    }
                }
            }


        }
    }
}