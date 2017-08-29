using Site.Log;
using Site.Untity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Site.WeiXin.Interface.Controllers
{

    public class HomeController : Controller
    {
        //验证请求是否合法,用于配置Url地址时验证
        public ActionResult Index(string signature, string timestamp, string nonce, string echostr)
        {

            LogHelp.Info(string.Format("{0},{1},{2},{3}", signature, timestamp, nonce, echostr));

            bool isCheck = CheckSignature(signature, timestamp, nonce);
            if (isCheck)
            {
                return Content(echostr);
            }
            else
            {
                return Content("");
            }

        }


        private bool CheckSignature(string signature, string timestamp, string nonce)
        {
            string token = UntityConfig.GetConfigValue("token");
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