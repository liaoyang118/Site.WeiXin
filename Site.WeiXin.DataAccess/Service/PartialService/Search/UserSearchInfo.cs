using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.WeiXin.DataAccess.Service.PartialService.Search
{
    public class UserSearchInfo
    {
        public string OrderBy = "Subscribe_Time desc";

        public string NickName { get; set; }



        public string ToWhereString()
        {
            List<string> where = new List<string>();
            if (!string.IsNullOrEmpty(NickName))
            {
                where.Add(string.Format("NickName like N'%{0}%'", NickName));
            }

            if (where.Count > 0)
            {
                return string.Format(" where {0}", string.Join(" and ", where.ToList()));
            }
            else
            {
                return string.Empty;
            }
        }


    }
}
