﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.WeiXin.DataAccess.Model
{
    public partial class SystemUser
    {
        public string AppID { get; set; }
        public string AppSecret { get; set; }
        /// <summary>
        /// 所属公众号名称
        /// </summary>
        public string Name { get; set; }
    }
}
