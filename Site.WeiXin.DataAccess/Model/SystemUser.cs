using System;
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
        public string Name { get; set; }
    }
}
