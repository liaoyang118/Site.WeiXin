using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.WeiXin.DataAccess.Service.PartialService.Search
{
    public class SystemUserSearchInfo
    {
        public string OrderBy = "CreateTime desc";

        public string Account { get; set; }

        public int? AccountState { get; set; }


        public string ToWhereString()
        {
            List<string> where = new List<string>();
            if (!string.IsNullOrEmpty(Account))
            {
                where.Add(string.Format("Account='{0}'", Account));
            }
            if (AccountState != null)
            {
                where.Add(string.Format("AccountState={0}", AccountState));
            }
            return string.Format(" where {0}", string.Join(" and ", where.ToList()));
        }


    }
}
