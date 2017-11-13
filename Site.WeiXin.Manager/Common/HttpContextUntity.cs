﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Site.Untity;
using Site.WeiXin.DataAccess.Model;
using Site.WeiXin.DataAccess.Service;
using Site.WeiXin.DataAccess.Service.PartialService.Search;

namespace Site.WeiXin.Manager.Common
{
    public class HttpContextUntity
    {
        /// <summary>
        /// 当前登录用户
        /// </summary>
        public static SystemUser CurrentUser
        {
            set
            {
                HttpContext.Current.Session["user"] = value;
            }
            get
            {
                if (HttpContext.Current.Session["user"] != null)
                {
                    return (SystemUser)HttpContext.Current.Session["user"];
                }
                else
                {
                    string name = HttpContext.Current.User.Identity.Name;
                    if (!string.IsNullOrEmpty(name))
                    {
                        SystemUserSearchInfo search = new SystemUserSearchInfo
                        {
                            Account = name,
                            AccountState = (int)SiteEnum.AccountState.正常
                        };
                        IList<SystemUser> list = SystemUserService.Select(search.ToWhereString());
                        return list.FirstOrDefault();
                    }
                    return null;
                }
            }
        }
    }
}