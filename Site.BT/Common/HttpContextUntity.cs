using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Site.Untity;
using Site.BT.DataAccess.Model;
using Site.BT.DataAccess.Service;
using Site.BT.DataAccess.Service.PartialService.Search;

namespace Site.BT.Manager.Common
{
    public class HttpContextUntity
    {
        /// <summary>
        /// 当前网页授权微信用户
        /// </summary>
        public static IdentityUserInfo CurrentUser
        {
            set
            {
                HttpContext.Current.Session["user"] = value;
            }
            get
            {
                if (HttpContext.Current.Session["user"] != null)
                {
                    return (IdentityUserInfo)HttpContext.Current.Session["user"];
                }
                return null;
            }
        }

    }
}