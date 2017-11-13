using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Site.Untity
{
    public class BaseModel
    {
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public string CreateTime { get; set; }
        public string MsgType { get; set; }
    }

    [XmlRoot(ElementName = "xml")]
    public class TextMessageModel : BaseModel
    {
        public string URL { get; set; }
        public string Content { get; set; }
        public string MsgId { get; set; }
    }

    /// <summary>
    /// SCAN,subscribe,unsubscribe 事件公用结构
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    public class SubscribeEventModel : BaseModel
    {
        public string Event { get; set; }
        public string EventKey { get; set; }
        public string Ticket { get; set; }
    }


    [XmlRoot(ElementName = "xml")]
    public class LocationModel : BaseModel
    {
        //地理位置纬度
        public double Latitude { get; set; }
        //地理位置经度
        public double Longitude { get; set; }

        //地理位置精度
        public double Precision { get; set; }
    }


    [XmlRoot(ElementName = "xml")]
    public class ClickModel : BaseModel
    {
        public string Event { get; set; }
        public string EventKey { get; set; }
    }


    /// <summary>
    /// 获取个人信息的用户对象，微信服务器返回json格式
    /// </summary>
    public class UserInfo
    {
        public int subscribe { get; set; }
        public string openid { get; set; }
        public string nickname { get; set; }
        public int sex { get; set; }
        public string language { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public string headimgurl { get; set; }
        public int subscribe_time { get; set; }
        public string unionid { get; set; }
        public string remark { get; set; }
        public int groupid { get; set; }
        public List<int> tagid_list { get; set; }
    }

    /// <summary>
    /// 网页授权获取的用户信息
    /// </summary>
    public class IdentityUserInfo
    {
        public string openid { get; set; }
        public string nickname { get; set; }
        public int sex { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public string headimgurl { get; set; }
        public string unionid { get; set; }
        public List<string> privilege { get; set; }
    }


}
