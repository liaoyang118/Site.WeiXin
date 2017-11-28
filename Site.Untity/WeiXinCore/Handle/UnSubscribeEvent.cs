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
    public class UnSubscribeEvent : IHandleBase
    {
        public string Handle(string xml)
        {
            try
            {
                SubscribeEventModel xmlObj = UntityTool.DeSerialize<SubscribeEventModel>(xml, Encoding.UTF8);

                //取消关注
                User info = UserService.Select(string.Format(" and OpenID={0}", xmlObj.FromUserName)).FirstOrDefault();
                if (info != null)
                {
                    info.IsSubscribe = false;
                    info.UnSubscribe_Time = DateTime.Now;
                    UserService.Update(info);
                }
                else
                {
                    //记录关注者信息
                    info = new User();
                    info.OpenID = xmlObj.FromUserName;
                    info.UnSubscribe_Time = DateTime.Now;
                    info.IsSubscribe = false;
                    UserService.Insert(info);
                }

                return WeiXinCommon.Success;
            }
            catch (Exception ex)
            {
                LogHelp.Error(ex.Message);
                return WeiXinCommon.Success;
            }

        }
    }
}
