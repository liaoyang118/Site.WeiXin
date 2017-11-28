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
    public class ViewEvent : IHandleBase
    {
        public string Handle(string xml)
        {
            try
            {
                ClickModel xmlObj = UntityTool.DeSerialize<ClickModel>(xml, Encoding.UTF8);

                string url = xmlObj.EventKey;


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
