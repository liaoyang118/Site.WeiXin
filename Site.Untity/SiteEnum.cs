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
    }
}