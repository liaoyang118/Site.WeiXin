using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.WeiXin.DataAccess.Service.PartialService.Search
{
    public class GongzhongAccountSearchInfo
    {
        public string OrderBy = "CreateTime desc";

        public string Name { get; set; }
        


        public string ToWhereString()
        {
            List<string> where = new List<string>();
            if (!string.IsNullOrEmpty(Name))
            {
                where.Add(string.Format("Name like N'%{0}%'", Name));
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
