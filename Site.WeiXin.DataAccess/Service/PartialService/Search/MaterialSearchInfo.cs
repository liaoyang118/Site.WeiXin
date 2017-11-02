using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.WeiXin.DataAccess.Service.PartialService.Search
{
    public class MaterialSearchInfo
    {
        public string OrderBy = "CreateTime desc";

        public string MaterialName { get; set; }



        public string ToWhereString()
        {
            List<string> where = new List<string>();
            if (!string.IsNullOrEmpty(MaterialName))
            {
                where.Add(string.Format("MaterialName like N'%{0}%'", MaterialName));
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
