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
    public class SubscribeEvent : HandleBase
    {
        public override string Handle(string xml)
        {
            try
            {
                SubscribeEventModel xmlObj = DeSerialize<SubscribeEventModel>(xml, Encoding.UTF8);

                //记录关注者信息
                User info = new User();
                info.OpenID = xmlObj.FromUserName;
                info.Subscribe_Time = DateTime.Now;
                info.IsSubscribe = true;

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
                    info.Unionid = wInfo.unionid;
                }
                UserService.Insert(info);

                //默认先回复文字
                return string.Format(WeiXinCommon.TextFormat, xmlObj.FromUserName, xmlObj.ToUserName, DateTime.Now.Ticks, "回复测试");
            }
            catch (Exception ex)
            {
                LogHelp.Error(ex.Message);
                return WeiXinCommon.Success;
            }

        }
    }
}
