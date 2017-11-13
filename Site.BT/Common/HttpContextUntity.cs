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
        /// 当前登录用户
        /// </summary>
        public static BusinessUser CurrentUser
        {
            set
            {
                HttpContext.Current.Session["user"] = value;
            }
            get
            {
                if (HttpContext.Current.Session["user"] != null)
                {
                    return (BusinessUser)HttpContext.Current.Session["user"];
                }
                else
                {
                    string name = HttpContext.Current.User.Identity.Name;
                    if (!string.IsNullOrEmpty(name))
                    {
                        BusinessUserSearchInfo search = new BusinessUserSearchInfo
                        {
                            Account = name,
                            AccountState = (int)SiteEnum.AccountState.正常
                        };
                        IList<BusinessUser> list = BusinessUserService.Select(search.ToWhereString());
                        return list.FirstOrDefault();
                    }
                    return null;
                }
            }
        }
    }
}