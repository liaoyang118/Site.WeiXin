

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.BT.DataAccess.Model
{

	[Serializable]
	public partial class BusinessAccountBinding
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
		
		#region OpenId
		private string _OpenId;
       
        /// <summary>
        /// 
        /// </summary>        
        public string OpenId 
		{ 
			get { return _OpenId; } 
			set { _OpenId = value; } 
		
		}
		#endregion
		
		#region BusinessUserId
		private int _BusinessUserId;
       
        /// <summary>
        /// 
        /// </summary>        
        public int BusinessUserId 
		{ 
			get { return _BusinessUserId; } 
			set { _BusinessUserId = value; } 
		
		}
		#endregion
		
		#region BussinessUserAccount
		private string _BussinessUserAccount;
       
        /// <summary>
        /// 
        /// </summary>        
        public string BussinessUserAccount 
		{ 
			get { return _BussinessUserAccount; } 
			set { _BussinessUserAccount = value; } 
		
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
	[Serializable]
	public partial class BusinessUser
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
		
		#region Status
		private int _Status;
       
        /// <summary>
        /// 
        /// </summary>        
        public int Status 
		{ 
			get { return _Status; } 
			set { _Status = value; } 
		
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