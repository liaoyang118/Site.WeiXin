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
    public class TextMessageHandle : IHandleBase
    {
        public string Handle(string xml)
        {
            try
            {
                TextMessageModel xmlObj = UntityTool.DeSerialize<TextMessageModel>(xml, Encoding.UTF8);
                UserMessage info = new UserMessage();
                info.XmlContent = xml;
                info.ContentValue = xmlObj.Content;
                info.CreateTime = DateTime.Now;
                info.MessageType = xmlObj.MsgType;
                info.MsgId = xmlObj.MsgId;
                info.OpenID = xmlObj.FromUserName;

                GongzhongAccount gzInfo = GongzhongAccountService.Select(string.Format("where AppAccount='{0}'",xmlObj.ToUserName)).FirstOrDefault();
                if (gzInfo != null)
                {
                    info.AppId = gzInfo.AppID;
                }

                UserMessageService.Insert(info);

                //优先处理关键字，如没有关键字则回复默认信息
                IList<KeyWordsReply> list = KeyWordsReplyService.Select(string.Format(" where KeyWords like N'%{0}%' and Statu={1} order by CreateTime", xmlObj.Content, (int)SiteEnum.ArticleState.通过));
                if (list.Count > 0)
                {
                    KeyWordsReply kInfo = list.FirstOrDefault();
                    return string.Format(kInfo.ReplyContent, xmlObj.FromUserName, xmlObj.ToUserName, DateTime.Now.Ticks);
                }
                else
                {
                    //优先执行默认回复，如没有则不处理
                    list = KeyWordsReplyService.Select(string.Format(" where KeyWords like N'%{0}%' and Statu={1} order by CreateTime", "默认", (int)SiteEnum.ArticleState.通过));
                    if (list.Count > 0)
                    {
                        KeyWordsReply kInfo = list.FirstOrDefault();
                        return string.Format(kInfo.ReplyContent, xmlObj.FromUserName, xmlObj.ToUserName, DateTime.Now.Ticks);
                    }
                    else
                    {
                        return WeiXinCommon.Success;
                    }
                }

            }
            catch (Exception ex)
            {
                LogHelp.Error(ex.Message);
                return WeiXinCommon.Success;
            }

        }
    }
}
