using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Site.WeiXin.DataAccess.Access;
using Site.WeiXin.DataAccess.Model;

namespace Site.WeiXin.DataAccess.Service
{
    public partial class UserMessageService
    {
        public static IList<UserMessage> SelectPageExcuteSql(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
        {
            using (var access = new UserMessageAccess())
            {
                return access.SelectPageExcuteSql(cloumns, order, whereStr, pageIndex, pageSize, out rowCount);
            }
        }
    }
}
