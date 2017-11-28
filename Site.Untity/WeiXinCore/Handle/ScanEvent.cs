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
    public class ScanEvent : IHandleBase
    {
        public string Handle(string xml)
        {
            try
            {
                SubscribeEventModel xmlObj = UntityTool.DeSerialize<SubscribeEventModel>(xml, Encoding.UTF8);
                
                string eventKey = xmlObj.EventKey;
                string ticket = xmlObj.Ticket;


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
