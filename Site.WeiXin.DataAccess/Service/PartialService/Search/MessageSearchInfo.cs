using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.WeiXin.DataAccess.Service.PartialService.Search
{
    public class MessageSearchInfo
    {
        public string OrderBy = "CreateTime desc";

        public string ContentValue { get; set; }



        public string ToWhereString()
        {
            List<string> where = new List<string>();
            if (!string.IsNullOrEmpty(ContentValue))
            {
                where.Add(string.Format("ContentValue like N'%{0}%'", ContentValue));
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
