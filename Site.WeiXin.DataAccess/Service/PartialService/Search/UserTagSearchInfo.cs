using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.WeiXin.DataAccess.Service.PartialService.Search
{
    public class UserTagSearchInfo
    {
        public string OrderBy = "CreateTime desc";

        public string TagName { get; set; }
        public string AppID { get; set; }


        public string ToWhereString()
        {
            List<string> where = new List<string>();
            if (!string.IsNullOrEmpty(TagName))
            {
                where.Add(string.Format("TagName like N'%{0}%'", TagName));
            }
            if (!string.IsNullOrEmpty(AppID))
            {
                where.Add(string.Format("AppID = N'{0}'", AppID));
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
