using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Site.Untity
{

    public class HttpTool
    {
        static HttpClient client = new HttpClient();

        public static string Get(string url)
        {
            string content = string.Empty;
            HttpResponseMessage result = client.GetAsync(url).Result;
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                content = result.Content.ReadAsStringAsync().Result;
            }
            return content;
        }

        /// <summary>
        /// post提交
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static string Post(string url, Dictionary<string, string> dic)
        {
            string content = string.Empty;
            HttpContent requestContent = new FormUrlEncodedContent(dic);
            HttpResponseMessage result = client.PostAsync(url, requestContent).Result;
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                content = result.Content.ReadAsStringAsync().Result;
            }
            return content;
        }

        /// <summary>
        /// 表单提交
        /// </summary>
        /// <param name="url"></param>
        /// <param name=""></param>
        /// <param name="bytes"></param>
        /// <param name="fileName"></param>
        /// <param name="ext"></param>
        /// <returns></returns>
        public static string Post(string url, string fileName, string ext, byte[] bytes)
        {
            string content = string.Empty;
            MultipartFormDataContent requestContent = new MultipartFormDataContent();
            requestContent.Add(CreateFileContent(bytes, fileName + string.Format("{0}", ext.StartsWith(".") ? ext : "." + ext), "application/octet-stream"));
            
            HttpResponseMessage result = client.PostAsync(url, requestContent).Result;
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                content = result.Content.ReadAsStringAsync().Result;
            }
            return content;
        }

        private static ByteArrayContent CreateFileContent(byte[] bytes, string fileName, string contentType)
        {
            var fileContent = new ByteArrayContent(bytes);
            //fileContent.Headers.Clear();
            //fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            //{
            //    Name = "\"media\"",//微信端上传文件固定是media,普通post为file
            //    FileName = "\"" + fileName + "\""
            //};
            //fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);


            StreamContent sc = new StreamContent(new MemoryStream(bytes));
            sc.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "\"media\"",//微信端上传文件固定是media,普通post为file
                FileName = "\"" + fileName + "\""
            };
            sc.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            return fileContent;
        }

        /// <summary>
        /// post body字符参数提交
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string Post(string url, string param)
        {
            string content = string.Empty;
            HttpContent requestContent = new StringContent(param);
            HttpResponseMessage result = client.PostAsync(url, requestContent).Result;
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                content = result.Content.ReadAsStringAsync().Result;
            }
            return content;
        }

    }
}
