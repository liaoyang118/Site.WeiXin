using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Site.Untity
{
    public class UntityTool
    {
        public static string GetConfigValue(string key)
        {
            string result = string.Empty;
            try
            {
                result = ConfigurationManager.AppSettings[key].ToString();
            }
            catch
            {

            }

            return result;
        }

        public static string Md5_32(string str)
        {
            byte[] b = System.Text.Encoding.Default.GetBytes(str);

            b = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b);
            string ret = "";
            for (int i = 0; i < b.Length; i++)
            {
                ret += b[i].ToString("x").PadLeft(2, '0');
            }
            return ret;
        }


        public static object JsonResult(bool success, string message)
        {
            return new
            {
                success = success,
                message = new { text = message }
            };
        }


        public static int GetTimeStamp()
        {
            //TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            //return Convert.ToInt64(ts.TotalSeconds * 1000);

            int intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            intResult = (int)(DateTime.Now - startTime).TotalSeconds;
            return intResult;
        }

        /// <summary>
        /// 生成分类列表分页Dome
        /// </summary>
        /// <returns></returns>
        public static string CreateListPage(int pageSize, int pageIndex, int rowCount, string urlBase)
        {
            /*
             <ul class="pagination pull-right">
                                <li><a href="#">Prev</a></li>
                                <li><a href="#">1</a></li>
                                <li><a href="#">2</a></li>
                                <li><a href="#">3</a></li>
                                <li><a href="#">4</a></li>
                                <li><a href="#">Next</a></li>
              </ul>

            */
            string result = string.Empty;

            string pageHtml = "<ul class=\"pagination pull-right\">{0}</ul>";
            string a_url = string.Empty;
            int totalPage = (int)Math.Ceiling(rowCount * 1.00 / pageSize * 1.00);
            if (totalPage > 1)
            {
                if (pageIndex != 1)
                {
                    a_url += string.Format("<li><a href=\"{0}\">首页</a></li>\r\n", GetListUrl(1, urlBase));
                    a_url += string.Format("<li><a href=\"{0}\">上一页</a></li>\r\n", GetListUrl(pageIndex - 1, urlBase));
                }

                for (int i = 1; i <= totalPage; i++)
                {
                    a_url += string.Format("<li><a href=\"{0}\" class=\"{2}\" >{1}</a></li>\r\n", "", i, i == pageIndex ? "cur" : "");
                }

                if (pageIndex != totalPage)
                {
                    a_url += string.Format("<li><a href=\"{0}\">下一页</a></li>\r\n", GetListUrl(pageIndex + 1, urlBase));
                    a_url += string.Format("<li><a href=\"{0}\">尾页</a></li>\r\n", GetListUrl(totalPage, urlBase));
                }

                result = string.Format(pageHtml, a_url);
            }

            return result;
        }

        private static string GetListUrl(int current, string url)
        {
            string result = string.Empty;
            if (url.Contains("?"))
            {
                result = url + "&page=" + current;
            }
            else
            {
                result = url + "?page=" + current;
            }

            return result;
        }
    }
}
