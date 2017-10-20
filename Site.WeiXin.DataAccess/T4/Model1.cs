

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.WeiXin.DataAccess.Model
{

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
		private bool? _Sex;
       
        /// <summary>
        /// 
        /// </summary>        
        public bool? Sex 
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
		
		#region Subscribe_time
		private DateTime? _Subscribe_time;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime? Subscribe_time 
		{ 
			get { return _Subscribe_time; } 
			set { _Subscribe_time = value; } 
		
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
		
		#region Content
		private string _Content;
       
        /// <summary>
        /// 整个请求内容
        /// </summary>        
        public string Content 
		{ 
			get { return _Content; } 
			set { _Content = value; } 
		
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
		
    }
	
}