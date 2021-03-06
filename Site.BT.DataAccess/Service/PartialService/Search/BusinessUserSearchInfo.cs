﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.BT.DataAccess.Service.PartialService.Search
{
    public class BusinessUserSearchInfo
    {
        public string OrderBy = "CreateTime desc";

        public string Account { get; set; }
        public int? AccountState { get; set; }



        public string ToWhereString()
        {
            List<string> where = new List<string>();
            if (!string.IsNullOrEmpty(Account))
            {
                where.Add(string.Format("Account = N'{0}'", Account));
            }

            if (AccountState != null)
            {
                where.Add(string.Format("Status = {0}", AccountState));
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
