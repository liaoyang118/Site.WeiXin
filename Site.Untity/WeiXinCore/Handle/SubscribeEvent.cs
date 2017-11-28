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
    public class SubscribeEvent : IHandleBase
    {
        public string Handle(string xml)
        {
            try
            {
                SubscribeEventModel xmlObj = UntityTool.DeSerialize<SubscribeEventModel>(xml, Encoding.UTF8);

                //记录关注者信息
                User info = new User();
                info.OpenID = xmlObj.FromUserName;
                info.Subscribe_Time = DateTime.Now;
                info.IsSubscribe = true;
                info.UnSubscribe_Time = DateTime.Now;


                //获取用户信息
                UserInfo wInfo;
                bool isSuccess = WeiXinCommon.GetUserInfo(xmlObj.FromUserName, out wInfo);
                if (isSuccess)
                {
                    info.City = wInfo.city;
                    info.Country = wInfo.country;
                    info.HeadImg = wInfo.headimgurl;
                    info.IsSubscribe = wInfo.subscribe == 1 ? true : false;
                    info.Language = wInfo.language;
                    info.NickName = wInfo.nickname;
                    info.Province = wInfo.province;
                    info.Sex = wInfo.sex;
                    info.Unionid = wInfo.unionid ?? string.Empty;
                }
                UserService.Insert(info);

                //优先执行关注回复，如没有则不处理
                IList<KeyWordsReply> list = KeyWordsReplyService.Select(string.Format(" where KeyWords like N'%{0}%' and Statu={1} order by CreateTime", "关注", (int)SiteEnum.ArticleState.通过));
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
            catch (Exception ex)
            {
                LogHelp.Error(ex.Message);
                return WeiXinCommon.Success;
            }

        }
    }
}
