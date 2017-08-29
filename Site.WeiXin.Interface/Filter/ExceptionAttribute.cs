using Site.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.WeiXin.Interface.Filter
{
    public class ExceptionAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            LogHelp.Error(string.Format("出错了：{0},InnerException:{1}", filterContext.Exception.Message, filterContext.Exception.InnerException));
        }
    }
}