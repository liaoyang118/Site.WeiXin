using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Site.WeiXin.DataAccess.Access;
using Site.WeiXin.DataAccess.Model;

namespace Site.WeiXin.Service
{
    public class WeiXinService
    {
        #region GloblaToken

        public static int Insert(GloblaToken obj)
        {
            using (var access = new GloblaTokenAccess())
            {
                return access.Insert(obj);
            }
        }




        #endregion
    }
}
