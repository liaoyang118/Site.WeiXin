using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.WeiXin.DataAccess.Service.PartialService.Search
{
    public class ArticleSearchInfo
    {
        public string OrderBy = "CreateTime desc";

        public string Title { get; set; }
        public int? Statu { get; set; }



        public string ToWhereString()
        {
            List<string> where = new List<string>();
            if (!string.IsNullOrEmpty(Title))
            {
                where.Add(string.Format("Title like N'%{0}%'", Title));
            }

            if (Statu != null)
            {
                where.Add(string.Format("Statu = {0}", Statu));
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
