using System;
using System.Collections.Generic;
using System.Configuration;
using Site.Service.UploadService.UploadService;
using Site.Common;

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

        public static DateTime TimespanToDatetime(long timeStamp)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            DateTime dt = startTime.AddSeconds(timeStamp);
            return dt;
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
                    a_url += string.Format("<li><a href=\"{0}\" class=\"{2}\" >{1}</a></li>\r\n", GetListUrl(i, urlBase), i, i == pageIndex ? "cur" : "");
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

        #region 图片上传 WCF服务

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="imgDatas">二进制数据</param>
        /// <param name="configName">文件保存路径配置名称 WeiXinUpload </param>
        /// <param name="sizeConfig">缩略尺寸设置：尺寸设置 360*200（大）、200*200（小） 不使用水印图片</param>
        /// <param name="imgExt">扩展名</param>
        /// <param name="thumbModel">"s",整图缩放;"c",裁剪; 默认为裁剪</param>
        /// <returns>原图地址(0)和缩略图地址(1)</returns>
        public static List<string> UploadImg(byte[] imgDatas, string configName, List<string> sizeConfig, string imgExt, string thumbModel = "c")
        {
            IUploadService channel = Entity.CreateChannel<IUploadService>(Site.Common.SiteEnum.SiteService.UploadService);
            var result = channel.UploadImg(imgDatas, configName, sizeConfig, imgExt, thumbModel);
            (channel as IDisposable).Dispose();
            return result;
        }

        #endregion
    }
}
