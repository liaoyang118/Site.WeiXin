using Site.Log;
using Site.Untity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Site.WeiXin.DataAccess.Model;
using Site.WeiXin.DataAccess.Service;
using System.Text;

namespace Site.WeiXin.Interface.Controllers
{

    public class HomeController : Controller
    {
        //验证请求是否合法,用于配置Url地址时验证
        public ActionResult Index()
        {
            if (Request.HttpMethod == "POST")
            {
                if (CheckSignature())
                {
                    if (Request.InputStream.Length > 0)
                    {
                        byte[] bytes = new byte[Request.InputStream.Length];
                        int result = Request.InputStream.Read(bytes, 0, bytes.Length);

                        if (result > 0)
                        {
                            string requestStr = Encoding.UTF8.GetString(bytes);
                            LogHelp.Info("接收消息:" + requestStr);

                            string msg = WeiXinCommon.HandelRequest(requestStr);

                            LogHelp.Info("返回消息:" + msg);
                            return Content(msg);
                        }
                    }
                }
                else
                {
                    return Content("消息并非来自微信");
                }
            }
            else
            {
                //验证URL是否合法
                if (CheckSignature())
                {
                    string echostr = Request["echostr"] ?? string.Empty;
                    return Content(echostr);
                }
                else
                {
                    return Content(WeiXinCommon.Success);
                }
            }
            return Content(WeiXinCommon.Success);
        }

        //验证参数
        private bool CheckSignature()
        {
            string signature = Request["signature"] ?? string.Empty;
            string timestamp = Request["timestamp"] ?? string.Empty;
            string nonce = Request["nonce"] ?? string.Empty;
            LogHelp.Info(string.Format("{0},{1},{2}", signature, timestamp, nonce));

            string token = Untity.UntityTool.GetConfigValue("token");
            string[] ArrTmp = { token, timestamp, nonce };
            Array.Sort(ArrTmp);
            string tmpStr = string.Join("", ArrTmp);
            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            tmpStr = tmpStr.ToLower();
            if (tmpStr == signature)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}