using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Site.Log;
using Site.WeiXin.DataAccess.Model;
using Site.WeiXin.DataAccess.Service;

namespace Site.Untity.WeiXinCore.Handle
{
    public class TextMessageHandle : HandleBase
    {
        public override string Handle(string xml)
        {
            try
            {
                TextMessageModel xmlObj = DeSerialize<TextMessageModel>(xml, Encoding.UTF8);
                UserMessage info = new UserMessage();
                info.Content = xml;
                info.CreateTime = DateTime.Now;
                info.MessageType = xmlObj.MsgType;
                info.MsgId = xmlObj.MsgId;
                info.OpenID = xmlObj.FromUserName;
                UserMessageService.Insert(info);

                //默认先回复文字

                return @"<xml>"
                       + "<ToUserName><![CDATA[" + xmlObj.FromUserName + @"]]></ToUserName>"
                       + "<FromUserName><![CDATA[" + xmlObj.ToUserName + @"]]></FromUserName >"
                       + "<CreateTime>" + UntityTool.GetTimeStamp().ToString() + "</CreateTime>"
                       + "<MsgType><![CDATA[text]]></MsgType>"
                       + "<Content><![CDATA[回复你好]]></Content>"
                       + "</xml>";
            }
            catch (Exception ex)
            {
                LogHelp.Error(ex.Message);
                return "";
            }

        }
    }
}
