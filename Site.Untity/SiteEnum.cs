using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Site.Untity
{
    public class SiteEnum
    {
        /// <summary>
        /// 系统用户状态
        /// </summary>
        public enum AccountState
        {
            正常 = 0,
            不可用 = 1
        }

        /// <summary>
        /// 菜单状态
        /// </summary>
        public enum MenuState
        {
            正常 = 0,
            不可用 = 1
        }

        /// <summary>
        /// Access_token 返回码
        /// </summary>
        public enum Access_tokenStatus
        {
            系统繁忙 = -1,
            请求成功 = 0,
            AppSecret错误 = 40001,
            grant_type错误 = 40002,
            IP黑名单 = 40164
        }
    }
}