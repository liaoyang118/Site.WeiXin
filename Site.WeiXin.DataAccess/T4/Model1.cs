

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.WeiXin.DataAccess.Model
{

	[Serializable]
	public partial class Article
    {
        
		#region Id
		private int _Id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int Id 
		{ 
			get { return _Id; } 
			set { _Id = value; } 
		
		}
		#endregion
		
		#region AuthorName
		private string _AuthorName;
       
        /// <summary>
        /// 
        /// </summary>        
        public string AuthorName 
		{ 
			get { return _AuthorName; } 
			set { _AuthorName = value; } 
		
		}
		#endregion
		
		#region Title
		private string _Title;
       
        /// <summary>
        /// 
        /// </summary>        
        public string Title 
		{ 
			get { return _Title; } 
			set { _Title = value; } 
		
		}
		#endregion
		
		#region ContentSourceUrl
		private string _ContentSourceUrl;
       
        /// <summary>
        /// 
        /// </summary>        
        public string ContentSourceUrl 
		{ 
			get { return _ContentSourceUrl; } 
			set { _ContentSourceUrl = value; } 
		
		}
		#endregion
		
		#region ArticleContent
		private string _ArticleContent;
       
        /// <summary>
        /// 
        /// </summary>        
        public string ArticleContent 
		{ 
			get { return _ArticleContent; } 
			set { _ArticleContent = value; } 
		
		}
		#endregion
		
		#region Intro
		private string _Intro;
       
        /// <summary>
        /// 
        /// </summary>        
        public string Intro 
		{ 
			get { return _Intro; } 
			set { _Intro = value; } 
		
		}
		#endregion
		
		#region ShowCover
		private int _ShowCover;
       
        /// <summary>
        /// 
        /// </summary>        
        public int ShowCover 
		{ 
			get { return _ShowCover; } 
			set { _ShowCover = value; } 
		
		}
		#endregion
		
		#region CreateTime
		private DateTime _CreateTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime CreateTime 
		{ 
			get { return _CreateTime; } 
			set { _CreateTime = value; } 
		
		}
		#endregion
		
		#region CreateUserAccount
		private string _CreateUserAccount;
       
        /// <summary>
        /// 
        /// </summary>        
        public string CreateUserAccount 
		{ 
			get { return _CreateUserAccount; } 
			set { _CreateUserAccount = value; } 
		
		}
		#endregion
		
		#region Statu
		private int _Statu;
       
        /// <summary>
        /// 
        /// </summary>        
        public int Statu 
		{ 
			get { return _Statu; } 
			set { _Statu = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class GloblaToken
    {
        
		#region Id
		private int _Id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int Id 
		{ 
			get { return _Id; } 
			set { _Id = value; } 
		
		}
		#endregion
		
		#region Token
		private string _Token;
       
        /// <summary>
        /// 
        /// </summary>        
        public string Token 
		{ 
			get { return _Token; } 
			set { _Token = value; } 
		
		}
		#endregion
		
		#region AppId
		private string _AppId;
       
        /// <summary>
        /// 
        /// </summary>        
        public string AppId 
		{ 
			get { return _AppId; } 
			set { _AppId = value; } 
		
		}
		#endregion
		
		#region ExpireTime
		private DateTime? _ExpireTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime? ExpireTime 
		{ 
			get { return _ExpireTime; } 
			set { _ExpireTime = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class Material
    {
        
		#region Id
		private int _Id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int Id 
		{ 
			get { return _Id; } 
			set { _Id = value; } 
		
		}
		#endregion
		
		#region MaterialName
		private string _MaterialName;
       
        /// <summary>
        /// 
        /// </summary>        
        public string MaterialName 
		{ 
			get { return _MaterialName; } 
			set { _MaterialName = value; } 
		
		}
		#endregion
		
		#region MaterialType
		private string _MaterialType;
       
        /// <summary>
        /// 图片、语音、视屏、缩略图
        /// </summary>        
        public string MaterialType 
		{ 
			get { return _MaterialType; } 
			set { _MaterialType = value; } 
		
		}
		#endregion
		
		#region Media_id
		private string _Media_id;
       
        /// <summary>
        /// 
        /// </summary>        
        public string Media_id 
		{ 
			get { return _Media_id; } 
			set { _Media_id = value; } 
		
		}
		#endregion
		
		#region Url
		private string _Url;
       
        /// <summary>
        /// 
        /// </summary>        
        public string Url 
		{ 
			get { return _Url; } 
			set { _Url = value; } 
		
		}
		#endregion
		
		#region CreateTime
		private DateTime _CreateTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime CreateTime 
		{ 
			get { return _CreateTime; } 
			set { _CreateTime = value; } 
		
		}
		#endregion
		
		#region CreateUserAccount
		private string _CreateUserAccount;
       
        /// <summary>
        /// 
        /// </summary>        
        public string CreateUserAccount 
		{ 
			get { return _CreateUserAccount; } 
			set { _CreateUserAccount = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class Menu
    {
        
		#region Id
		private int _Id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int Id 
		{ 
			get { return _Id; } 
			set { _Id = value; } 
		
		}
		#endregion
		
		#region ParentId
		private int? _ParentId;
       
        /// <summary>
        /// 
        /// </summary>        
        public int? ParentId 
		{ 
			get { return _ParentId; } 
			set { _ParentId = value; } 
		
		}
		#endregion
		
		#region Name
		private string _Name;
       
        /// <summary>
        /// 
        /// </summary>        
        public string Name 
		{ 
			get { return _Name; } 
			set { _Name = value; } 
		
		}
		#endregion
		
		#region Type
		private string _Type;
       
        /// <summary>
        /// 
        /// </summary>        
        public string Type 
		{ 
			get { return _Type; } 
			set { _Type = value; } 
		
		}
		#endregion
		
		#region Value
		private string _Value;
       
        /// <summary>
        /// 
        /// </summary>        
        public string Value 
		{ 
			get { return _Value; } 
			set { _Value = value; } 
		
		}
		#endregion
		
		#region CreateTime
		private DateTime? _CreateTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime? CreateTime 
		{ 
			get { return _CreateTime; } 
			set { _CreateTime = value; } 
		
		}
		#endregion
		
		#region LevelCode
		private string _LevelCode;
       
        /// <summary>
        /// 
        /// </summary>        
        public string LevelCode 
		{ 
			get { return _LevelCode; } 
			set { _LevelCode = value; } 
		
		}
		#endregion
		
		#region Status
		private int? _Status;
       
        /// <summary>
        /// 
        /// </summary>        
        public int? Status 
		{ 
			get { return _Status; } 
			set { _Status = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class MenuType
    {
        
		#region Id
		private int _Id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int Id 
		{ 
			get { return _Id; } 
			set { _Id = value; } 
		
		}
		#endregion
		
		#region Type
		private string _Type;
       
        /// <summary>
        /// 
        /// </summary>        
        public string Type 
		{ 
			get { return _Type; } 
			set { _Type = value; } 
		
		}
		#endregion
		
		#region Intro
		private string _Intro;
       
        /// <summary>
        /// 
        /// </summary>        
        public string Intro 
		{ 
			get { return _Intro; } 
			set { _Intro = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class SystemUser
    {
        
		#region Id
		private int _Id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int Id 
		{ 
			get { return _Id; } 
			set { _Id = value; } 
		
		}
		#endregion
		
		#region AppId
		private string _AppId;
       
        /// <summary>
        /// 
        /// </summary>        
        public string AppId 
		{ 
			get { return _AppId; } 
			set { _AppId = value; } 
		
		}
		#endregion
		
		#region Account
		private string _Account;
       
        /// <summary>
        /// 
        /// </summary>        
        public string Account 
		{ 
			get { return _Account; } 
			set { _Account = value; } 
		
		}
		#endregion
		
		#region Password
		private string _Password;
       
        /// <summary>
        /// 
        /// </summary>        
        public string Password 
		{ 
			get { return _Password; } 
			set { _Password = value; } 
		
		}
		#endregion
		
		#region CreateTime
		private DateTime? _CreateTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime? CreateTime 
		{ 
			get { return _CreateTime; } 
			set { _CreateTime = value; } 
		
		}
		#endregion
		
		#region CreateUserName
		private string _CreateUserName;
       
        /// <summary>
        /// 
        /// </summary>        
        public string CreateUserName 
		{ 
			get { return _CreateUserName; } 
			set { _CreateUserName = value; } 
		
		}
		#endregion
		
		#region AccountState
		private int? _AccountState;
       
        /// <summary>
        /// 0 正常 1 不可用
        /// </summary>        
        public int? AccountState 
		{ 
			get { return _AccountState; } 
			set { _AccountState = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class User
    {
        
		#region Id
		private int _Id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int Id 
		{ 
			get { return _Id; } 
			set { _Id = value; } 
		
		}
		#endregion
		
		#region OpenID
		private string _OpenID;
       
        /// <summary>
        /// 
        /// </summary>        
        public string OpenID 
		{ 
			get { return _OpenID; } 
			set { _OpenID = value; } 
		
		}
		#endregion
		
		#region NickName
		private string _NickName;
       
        /// <summary>
        /// 
        /// </summary>        
        public string NickName 
		{ 
			get { return _NickName; } 
			set { _NickName = value; } 
		
		}
		#endregion
		
		#region HeadImg
		private string _HeadImg;
       
        /// <summary>
        /// 
        /// </summary>        
        public string HeadImg 
		{ 
			get { return _HeadImg; } 
			set { _HeadImg = value; } 
		
		}
		#endregion
		
		#region Sex
		private int? _Sex;
       
        /// <summary>
        /// 值为1时是男性，值为2时是女性，值为0时是未知
        /// </summary>        
        public int? Sex 
		{ 
			get { return _Sex; } 
			set { _Sex = value; } 
		
		}
		#endregion
		
		#region Country
		private string _Country;
       
        /// <summary>
        /// 
        /// </summary>        
        public string Country 
		{ 
			get { return _Country; } 
			set { _Country = value; } 
		
		}
		#endregion
		
		#region Province
		private string _Province;
       
        /// <summary>
        /// 
        /// </summary>        
        public string Province 
		{ 
			get { return _Province; } 
			set { _Province = value; } 
		
		}
		#endregion
		
		#region City
		private string _City;
       
        /// <summary>
        /// 
        /// </summary>        
        public string City 
		{ 
			get { return _City; } 
			set { _City = value; } 
		
		}
		#endregion
		
		#region Language
		private string _Language;
       
        /// <summary>
        /// 
        /// </summary>        
        public string Language 
		{ 
			get { return _Language; } 
			set { _Language = value; } 
		
		}
		#endregion
		
		#region Subscribe_Time
		private DateTime? _Subscribe_Time;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime? Subscribe_Time 
		{ 
			get { return _Subscribe_Time; } 
			set { _Subscribe_Time = value; } 
		
		}
		#endregion
		
		#region Unionid
		private string _Unionid;
       
        /// <summary>
        /// 
        /// </summary>        
        public string Unionid 
		{ 
			get { return _Unionid; } 
			set { _Unionid = value; } 
		
		}
		#endregion
		
		#region IsSubscribe
		private bool? _IsSubscribe;
       
        /// <summary>
        /// 
        /// </summary>        
        public bool? IsSubscribe 
		{ 
			get { return _IsSubscribe; } 
			set { _IsSubscribe = value; } 
		
		}
		#endregion
		
		#region UnSubscribe_Time
		private DateTime? _UnSubscribe_Time;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime? UnSubscribe_Time 
		{ 
			get { return _UnSubscribe_Time; } 
			set { _UnSubscribe_Time = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class UserMessage
    {
        
		#region Id
		private int _Id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int Id 
		{ 
			get { return _Id; } 
			set { _Id = value; } 
		
		}
		#endregion
		
		#region MessageType
		private string _MessageType;
       
        /// <summary>
        /// 
        /// </summary>        
        public string MessageType 
		{ 
			get { return _MessageType; } 
			set { _MessageType = value; } 
		
		}
		#endregion
		
		#region OpenID
		private string _OpenID;
       
        /// <summary>
        /// 
        /// </summary>        
        public string OpenID 
		{ 
			get { return _OpenID; } 
			set { _OpenID = value; } 
		
		}
		#endregion
		
		#region XmlContent
		private string _XmlContent;
       
        /// <summary>
        /// 整个请求内容
        /// </summary>        
        public string XmlContent 
		{ 
			get { return _XmlContent; } 
			set { _XmlContent = value; } 
		
		}
		#endregion
		
		#region MsgId
		private string _MsgId;
       
        /// <summary>
        /// 
        /// </summary>        
        public string MsgId 
		{ 
			get { return _MsgId; } 
			set { _MsgId = value; } 
		
		}
		#endregion
		
		#region CreateTime
		private DateTime _CreateTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime CreateTime 
		{ 
			get { return _CreateTime; } 
			set { _CreateTime = value; } 
		
		}
		#endregion
		
		#region ContentValue
		private string _ContentValue;
       
        /// <summary>
        /// 
        /// </summary>        
        public string ContentValue 
		{ 
			get { return _ContentValue; } 
			set { _ContentValue = value; } 
		
		}
		#endregion
		
    }
	
}