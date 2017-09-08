

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{

	[Serializable]
	public partial class ModulePermission
    {
        
		#region p_id
		private int _p_id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int p_id 
		{ 
			get { return _p_id; } 
			set { _p_id = value; } 
		
		}
		#endregion
		
		#region p_gid
		private string _p_gid;
       
        /// <summary>
        /// 
        /// </summary>        
        public string p_gid 
		{ 
			get { return _p_gid; } 
			set { _p_gid = value; } 
		
		}
		#endregion
		
		#region p_m_gid
		private string _p_m_gid;
       
        /// <summary>
        /// 
        /// </summary>        
        public string p_m_gid 
		{ 
			get { return _p_m_gid; } 
			set { _p_m_gid = value; } 
		
		}
		#endregion
		
		#region p_name
		private string _p_name;
       
        /// <summary>
        /// 
        /// </summary>        
        public string p_name 
		{ 
			get { return _p_name; } 
			set { _p_name = value; } 
		
		}
		#endregion
		
		#region p_path
		private string _p_path;
       
        /// <summary>
        /// 
        /// </summary>        
        public string p_path 
		{ 
			get { return _p_path; } 
			set { _p_path = value; } 
		
		}
		#endregion
		
		#region p_createTime
		private DateTime _p_createTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime p_createTime 
		{ 
			get { return _p_createTime; } 
			set { _p_createTime = value; } 
		
		}
		#endregion
		
		#region p_createUser
		private string _p_createUser;
       
        /// <summary>
        /// 
        /// </summary>        
        public string p_createUser 
		{ 
			get { return _p_createUser; } 
			set { _p_createUser = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class Role
    {
        
		#region r_id
		private int _r_id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int r_id 
		{ 
			get { return _r_id; } 
			set { _r_id = value; } 
		
		}
		#endregion
		
		#region r_gid
		private string _r_gid;
       
        /// <summary>
        /// 
        /// </summary>        
        public string r_gid 
		{ 
			get { return _r_gid; } 
			set { _r_gid = value; } 
		
		}
		#endregion
		
		#region r_name
		private string _r_name;
       
        /// <summary>
        /// 
        /// </summary>        
        public string r_name 
		{ 
			get { return _r_name; } 
			set { _r_name = value; } 
		
		}
		#endregion
		
		#region r_createTime
		private DateTime _r_createTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime r_createTime 
		{ 
			get { return _r_createTime; } 
			set { _r_createTime = value; } 
		
		}
		#endregion
		
		#region r_createUser
		private string _r_createUser;
       
        /// <summary>
        /// 
        /// </summary>        
        public string r_createUser 
		{ 
			get { return _r_createUser; } 
			set { _r_createUser = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class Role_ModualPermission_Mapping
    {
        
		#region r_p_id
		private int _r_p_id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int r_p_id 
		{ 
			get { return _r_p_id; } 
			set { _r_p_id = value; } 
		
		}
		#endregion
		
		#region r_p_gid
		private string _r_p_gid;
       
        /// <summary>
        /// 
        /// </summary>        
        public string r_p_gid 
		{ 
			get { return _r_p_gid; } 
			set { _r_p_gid = value; } 
		
		}
		#endregion
		
		#region r_gid
		private string _r_gid;
       
        /// <summary>
        /// 
        /// </summary>        
        public string r_gid 
		{ 
			get { return _r_gid; } 
			set { _r_gid = value; } 
		
		}
		#endregion
		
		#region p_gid
		private string _p_gid;
       
        /// <summary>
        /// 
        /// </summary>        
        public string p_gid 
		{ 
			get { return _p_gid; } 
			set { _p_gid = value; } 
		
		}
		#endregion
		
		#region r_p_CreateTime
		private DateTime? _r_p_CreateTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime? r_p_CreateTime 
		{ 
			get { return _r_p_CreateTime; } 
			set { _r_p_CreateTime = value; } 
		
		}
		#endregion
		
		#region r_p_CreateUser
		private string _r_p_CreateUser;
       
        /// <summary>
        /// 
        /// </summary>        
        public string r_p_CreateUser 
		{ 
			get { return _r_p_CreateUser; } 
			set { _r_p_CreateUser = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class Site_Cates
    {
        
		#region c_id
		private int _c_id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int c_id 
		{ 
			get { return _c_id; } 
			set { _c_id = value; } 
		
		}
		#endregion
		
		#region c_gid
		private string _c_gid;
       
        /// <summary>
        /// 
        /// </summary>        
        public string c_gid 
		{ 
			get { return _c_gid; } 
			set { _c_gid = value; } 
		
		}
		#endregion
		
		#region c_path
		private string _c_path;
       
        /// <summary>
        /// 
        /// </summary>        
        public string c_path 
		{ 
			get { return _c_path; } 
			set { _c_path = value; } 
		
		}
		#endregion
		
		#region c_isMainCate
		private bool _c_isMainCate;
       
        /// <summary>
        /// 
        /// </summary>        
        public bool c_isMainCate 
		{ 
			get { return _c_isMainCate; } 
			set { _c_isMainCate = value; } 
		
		}
		#endregion
		
		#region c_tableId
		private int _c_tableId;
       
        /// <summary>
        /// 
        /// </summary>        
        public int c_tableId 
		{ 
			get { return _c_tableId; } 
			set { _c_tableId = value; } 
		
		}
		#endregion
		
		#region c_name
		private string _c_name;
       
        /// <summary>
        /// 
        /// </summary>        
        public string c_name 
		{ 
			get { return _c_name; } 
			set { _c_name = value; } 
		
		}
		#endregion
		
		#region c_type
		private string _c_type;
       
        /// <summary>
        /// 
        /// </summary>        
        public string c_type 
		{ 
			get { return _c_type; } 
			set { _c_type = value; } 
		
		}
		#endregion
		
		#region c_createUser
		private string _c_createUser;
       
        /// <summary>
        /// 
        /// </summary>        
        public string c_createUser 
		{ 
			get { return _c_createUser; } 
			set { _c_createUser = value; } 
		
		}
		#endregion
		
		#region c_createTime
		private DateTime _c_createTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime c_createTime 
		{ 
			get { return _c_createTime; } 
			set { _c_createTime = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class Site_CMSBlock
    {
        
		#region b_id
		private int _b_id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int b_id 
		{ 
			get { return _b_id; } 
			set { _b_id = value; } 
		
		}
		#endregion
		
		#region b_gid
		private string _b_gid;
       
        /// <summary>
        /// 
        /// </summary>        
        public string b_gid 
		{ 
			get { return _b_gid; } 
			set { _b_gid = value; } 
		
		}
		#endregion
		
		#region b_p_gid
		private string _b_p_gid;
       
        /// <summary>
        /// 
        /// </summary>        
        public string b_p_gid 
		{ 
			get { return _b_p_gid; } 
			set { _b_p_gid = value; } 
		
		}
		#endregion
		
		#region b_path
		private string _b_path;
       
        /// <summary>
        /// 
        /// </summary>        
        public string b_path 
		{ 
			get { return _b_path; } 
			set { _b_path = value; } 
		
		}
		#endregion
		
		#region b_name
		private string _b_name;
       
        /// <summary>
        /// 
        /// </summary>        
        public string b_name 
		{ 
			get { return _b_name; } 
			set { _b_name = value; } 
		
		}
		#endregion
		
		#region b_img_size
		private string _b_img_size;
       
        /// <summary>
        /// 
        /// </summary>        
        public string b_img_size 
		{ 
			get { return _b_img_size; } 
			set { _b_img_size = value; } 
		
		}
		#endregion
		
		#region b_createUser
		private string _b_createUser;
       
        /// <summary>
        /// 
        /// </summary>        
        public string b_createUser 
		{ 
			get { return _b_createUser; } 
			set { _b_createUser = value; } 
		
		}
		#endregion
		
		#region b_createTime
		private DateTime _b_createTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime b_createTime 
		{ 
			get { return _b_createTime; } 
			set { _b_createTime = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class Site_CMSItem
    {
        
		#region i_id
		private int _i_id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int i_id 
		{ 
			get { return _i_id; } 
			set { _i_id = value; } 
		
		}
		#endregion
		
		#region i_gid
		private string _i_gid;
       
        /// <summary>
        /// 
        /// </summary>        
        public string i_gid 
		{ 
			get { return _i_gid; } 
			set { _i_gid = value; } 
		
		}
		#endregion
		
		#region i_b_gid
		private string _i_b_gid;
       
        /// <summary>
        /// 
        /// </summary>        
        public string i_b_gid 
		{ 
			get { return _i_b_gid; } 
			set { _i_b_gid = value; } 
		
		}
		#endregion
		
		#region i_p_gid
		private string _i_p_gid;
       
        /// <summary>
        /// 
        /// </summary>        
        public string i_p_gid 
		{ 
			get { return _i_p_gid; } 
			set { _i_p_gid = value; } 
		
		}
		#endregion
		
		#region i_title
		private string _i_title;
       
        /// <summary>
        /// 
        /// </summary>        
        public string i_title 
		{ 
			get { return _i_title; } 
			set { _i_title = value; } 
		
		}
		#endregion
		
		#region i_c_gid
		private string _i_c_gid;
       
        /// <summary>
        /// 
        /// </summary>        
        public string i_c_gid 
		{ 
			get { return _i_c_gid; } 
			set { _i_c_gid = value; } 
		
		}
		#endregion
		
		#region i_c_type
		private string _i_c_type;
       
        /// <summary>
        /// 
        /// </summary>        
        public string i_c_type 
		{ 
			get { return _i_c_type; } 
			set { _i_c_type = value; } 
		
		}
		#endregion
		
		#region i_subTitle
		private string _i_subTitle;
       
        /// <summary>
        /// 
        /// </summary>        
        public string i_subTitle 
		{ 
			get { return _i_subTitle; } 
			set { _i_subTitle = value; } 
		
		}
		#endregion
		
		#region i_intro
		private string _i_intro;
       
        /// <summary>
        /// 
        /// </summary>        
        public string i_intro 
		{ 
			get { return _i_intro; } 
			set { _i_intro = value; } 
		
		}
		#endregion
		
		#region i_c_img_src
		private string _i_c_img_src;
       
        /// <summary>
        /// 
        /// </summary>        
        public string i_c_img_src 
		{ 
			get { return _i_c_img_src; } 
			set { _i_c_img_src = value; } 
		
		}
		#endregion
		
		#region i_status
		private int _i_status;
       
        /// <summary>
        /// 
        /// </summary>        
        public int i_status 
		{ 
			get { return _i_status; } 
			set { _i_status = value; } 
		
		}
		#endregion
		
		#region i_createUser
		private string _i_createUser;
       
        /// <summary>
        /// 
        /// </summary>        
        public string i_createUser 
		{ 
			get { return _i_createUser; } 
			set { _i_createUser = value; } 
		
		}
		#endregion
		
		#region i_createTime
		private DateTime _i_createTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime i_createTime 
		{ 
			get { return _i_createTime; } 
			set { _i_createTime = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class Site_CMSPage
    {
        
		#region p_id
		private int _p_id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int p_id 
		{ 
			get { return _p_id; } 
			set { _p_id = value; } 
		
		}
		#endregion
		
		#region p_gid
		private string _p_gid;
       
        /// <summary>
        /// 
        /// </summary>        
        public string p_gid 
		{ 
			get { return _p_gid; } 
			set { _p_gid = value; } 
		
		}
		#endregion
		
		#region p_name
		private string _p_name;
       
        /// <summary>
        /// 
        /// </summary>        
        public string p_name 
		{ 
			get { return _p_name; } 
			set { _p_name = value; } 
		
		}
		#endregion
		
		#region p_path
		private string _p_path;
       
        /// <summary>
        /// 
        /// </summary>        
        public string p_path 
		{ 
			get { return _p_path; } 
			set { _p_path = value; } 
		
		}
		#endregion
		
		#region p_tempPath
		private string _p_tempPath;
       
        /// <summary>
        /// 
        /// </summary>        
        public string p_tempPath 
		{ 
			get { return _p_tempPath; } 
			set { _p_tempPath = value; } 
		
		}
		#endregion
		
		#region p_filePath
		private string _p_filePath;
       
        /// <summary>
        /// 
        /// </summary>        
        public string p_filePath 
		{ 
			get { return _p_filePath; } 
			set { _p_filePath = value; } 
		
		}
		#endregion
		
		#region p_createTime
		private DateTime _p_createTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime p_createTime 
		{ 
			get { return _p_createTime; } 
			set { _p_createTime = value; } 
		
		}
		#endregion
		
		#region p_createUser
		private string _p_createUser;
       
        /// <summary>
        /// 
        /// </summary>        
        public string p_createUser 
		{ 
			get { return _p_createUser; } 
			set { _p_createUser = value; } 
		
		}
		#endregion
		
		#region p_pageDuty
		private string _p_pageDuty;
       
        /// <summary>
        /// 
        /// </summary>        
        public string p_pageDuty 
		{ 
			get { return _p_pageDuty; } 
			set { _p_pageDuty = value; } 
		
		}
		#endregion
		
		#region p_siteName
		private int _p_siteName;
       
        /// <summary>
        /// 
        /// </summary>        
        public int p_siteName 
		{ 
			get { return _p_siteName; } 
			set { _p_siteName = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class Site_Content
    {
        
		#region c_id
		private int _c_id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int c_id 
		{ 
			get { return _c_id; } 
			set { _c_id = value; } 
		
		}
		#endregion
		
		#region c_gid
		private string _c_gid;
       
        /// <summary>
        /// 
        /// </summary>        
        public string c_gid 
		{ 
			get { return _c_gid; } 
			set { _c_gid = value; } 
		
		}
		#endregion
		
		#region c_c_gid
		private string _c_c_gid;
       
        /// <summary>
        /// 
        /// </summary>        
        public string c_c_gid 
		{ 
			get { return _c_c_gid; } 
			set { _c_c_gid = value; } 
		
		}
		#endregion
		
		#region c_title
		private string _c_title;
       
        /// <summary>
        /// 
        /// </summary>        
        public string c_title 
		{ 
			get { return _c_title; } 
			set { _c_title = value; } 
		
		}
		#endregion
		
		#region c_sub_title
		private string _c_sub_title;
       
        /// <summary>
        /// 
        /// </summary>        
        public string c_sub_title 
		{ 
			get { return _c_sub_title; } 
			set { _c_sub_title = value; } 
		
		}
		#endregion
		
		#region c_keywords
		private string _c_keywords;
       
        /// <summary>
        /// 
        /// </summary>        
        public string c_keywords 
		{ 
			get { return _c_keywords; } 
			set { _c_keywords = value; } 
		
		}
		#endregion
		
		#region c_intro
		private string _c_intro;
       
        /// <summary>
        /// 
        /// </summary>        
        public string c_intro 
		{ 
			get { return _c_intro; } 
			set { _c_intro = value; } 
		
		}
		#endregion
		
		#region c_content
		private string _c_content;
       
        /// <summary>
        /// 
        /// </summary>        
        public string c_content 
		{ 
			get { return _c_content; } 
			set { _c_content = value; } 
		
		}
		#endregion
		
		#region c_img_src
		private string _c_img_src;
       
        /// <summary>
        /// 
        /// </summary>        
        public string c_img_src 
		{ 
			get { return _c_img_src; } 
			set { _c_img_src = value; } 
		
		}
		#endregion
		
		#region c_createUserId
		private string _c_createUserId;
       
        /// <summary>
        /// 
        /// </summary>        
        public string c_createUserId 
		{ 
			get { return _c_createUserId; } 
			set { _c_createUserId = value; } 
		
		}
		#endregion
		
		#region c_createUserName
		private string _c_createUserName;
       
        /// <summary>
        /// 
        /// </summary>        
        public string c_createUserName 
		{ 
			get { return _c_createUserName; } 
			set { _c_createUserName = value; } 
		
		}
		#endregion
		
		#region c_createUserNickName
		private string _c_createUserNickName;
       
        /// <summary>
        /// 
        /// </summary>        
        public string c_createUserNickName 
		{ 
			get { return _c_createUserNickName; } 
			set { _c_createUserNickName = value; } 
		
		}
		#endregion
		
		#region c_createTime
		private DateTime? _c_createTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime? c_createTime 
		{ 
			get { return _c_createTime; } 
			set { _c_createTime = value; } 
		
		}
		#endregion
		
		#region c_status
		private int? _c_status;
       
        /// <summary>
        /// 
        /// </summary>        
        public int? c_status 
		{ 
			get { return _c_status; } 
			set { _c_status = value; } 
		
		}
		#endregion
		
		#region c_state
		private bool? _c_state;
       
        /// <summary>
        /// 
        /// </summary>        
        public bool? c_state 
		{ 
			get { return _c_state; } 
			set { _c_state = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class SystemGroup
    {
        
		#region g_id
		private int _g_id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int g_id 
		{ 
			get { return _g_id; } 
			set { _g_id = value; } 
		
		}
		#endregion
		
		#region g_gid
		private string _g_gid;
       
        /// <summary>
        /// 
        /// </summary>        
        public string g_gid 
		{ 
			get { return _g_gid; } 
			set { _g_gid = value; } 
		
		}
		#endregion
		
		#region g_name
		private string _g_name;
       
        /// <summary>
        /// 
        /// </summary>        
        public string g_name 
		{ 
			get { return _g_name; } 
			set { _g_name = value; } 
		
		}
		#endregion
		
		#region g_picCover
		private string _g_picCover;
       
        /// <summary>
        /// 
        /// </summary>        
        public string g_picCover 
		{ 
			get { return _g_picCover; } 
			set { _g_picCover = value; } 
		
		}
		#endregion
		
		#region g_createTime
		private DateTime _g_createTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime g_createTime 
		{ 
			get { return _g_createTime; } 
			set { _g_createTime = value; } 
		
		}
		#endregion
		
		#region g_createUser
		private string _g_createUser;
       
        /// <summary>
        /// 
        /// </summary>        
        public string g_createUser 
		{ 
			get { return _g_createUser; } 
			set { _g_createUser = value; } 
		
		}
		#endregion
		
		#region g_sort
		private int _g_sort;
       
        /// <summary>
        /// 
        /// </summary>        
        public int g_sort 
		{ 
			get { return _g_sort; } 
			set { _g_sort = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class SystemModual
    {
        
		#region m_id
		private int _m_id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int m_id 
		{ 
			get { return _m_id; } 
			set { _m_id = value; } 
		
		}
		#endregion
		
		#region m_gid
		private string _m_gid;
       
        /// <summary>
        /// 
        /// </summary>        
        public string m_gid 
		{ 
			get { return _m_gid; } 
			set { _m_gid = value; } 
		
		}
		#endregion
		
		#region m_g_gid
		private string _m_g_gid;
       
        /// <summary>
        /// 模块对应的模块组 gid
        /// </summary>        
        public string m_g_gid 
		{ 
			get { return _m_g_gid; } 
			set { _m_g_gid = value; } 
		
		}
		#endregion
		
		#region m_path
		private string _m_path;
       
        /// <summary>
        /// 
        /// </summary>        
        public string m_path 
		{ 
			get { return _m_path; } 
			set { _m_path = value; } 
		
		}
		#endregion
		
		#region m_name
		private string _m_name;
       
        /// <summary>
        /// 
        /// </summary>        
        public string m_name 
		{ 
			get { return _m_name; } 
			set { _m_name = value; } 
		
		}
		#endregion
		
		#region m_parent
		private int _m_parent;
       
        /// <summary>
        /// 
        /// </summary>        
        public int m_parent 
		{ 
			get { return _m_parent; } 
			set { _m_parent = value; } 
		
		}
		#endregion
		
		#region m_parent_gid
		private string _m_parent_gid;
       
        /// <summary>
        /// 
        /// </summary>        
        public string m_parent_gid 
		{ 
			get { return _m_parent_gid; } 
			set { _m_parent_gid = value; } 
		
		}
		#endregion
		
		#region m_Controller
		private string _m_Controller;
       
        /// <summary>
        /// 
        /// </summary>        
        public string m_Controller 
		{ 
			get { return _m_Controller; } 
			set { _m_Controller = value; } 
		
		}
		#endregion
		
		#region m_Action
		private string _m_Action;
       
        /// <summary>
        /// 
        /// </summary>        
        public string m_Action 
		{ 
			get { return _m_Action; } 
			set { _m_Action = value; } 
		
		}
		#endregion
		
		#region m_createTime
		private DateTime _m_createTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime m_createTime 
		{ 
			get { return _m_createTime; } 
			set { _m_createTime = value; } 
		
		}
		#endregion
		
		#region m_createUser
		private string _m_createUser;
       
        /// <summary>
        /// 
        /// </summary>        
        public string m_createUser 
		{ 
			get { return _m_createUser; } 
			set { _m_createUser = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class User
    {
        
		#region u_id
		private int _u_id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int u_id 
		{ 
			get { return _u_id; } 
			set { _u_id = value; } 
		
		}
		#endregion
		
		#region u_gid
		private string _u_gid;
       
        /// <summary>
        /// 
        /// </summary>        
        public string u_gid 
		{ 
			get { return _u_gid; } 
			set { _u_gid = value; } 
		
		}
		#endregion
		
		#region u_username
		private string _u_username;
       
        /// <summary>
        /// 
        /// </summary>        
        public string u_username 
		{ 
			get { return _u_username; } 
			set { _u_username = value; } 
		
		}
		#endregion
		
		#region u_password
		private string _u_password;
       
        /// <summary>
        /// 
        /// </summary>        
        public string u_password 
		{ 
			get { return _u_password; } 
			set { _u_password = value; } 
		
		}
		#endregion
		
		#region u_createTime
		private DateTime _u_createTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime u_createTime 
		{ 
			get { return _u_createTime; } 
			set { _u_createTime = value; } 
		
		}
		#endregion
		
		#region u_createUser
		private string _u_createUser;
       
        /// <summary>
        /// 
        /// </summary>        
        public string u_createUser 
		{ 
			get { return _u_createUser; } 
			set { _u_createUser = value; } 
		
		}
		#endregion
		
		#region u_status
		private int _u_status;
       
        /// <summary>
        /// 
        /// </summary>        
        public int u_status 
		{ 
			get { return _u_status; } 
			set { _u_status = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class User_Role_Mapping
    {
        
		#region u_r_id
		private int _u_r_id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int u_r_id 
		{ 
			get { return _u_r_id; } 
			set { _u_r_id = value; } 
		
		}
		#endregion
		
		#region u_r_gid
		private string _u_r_gid;
       
        /// <summary>
        /// 
        /// </summary>        
        public string u_r_gid 
		{ 
			get { return _u_r_gid; } 
			set { _u_r_gid = value; } 
		
		}
		#endregion
		
		#region u_gid
		private string _u_gid;
       
        /// <summary>
        /// 
        /// </summary>        
        public string u_gid 
		{ 
			get { return _u_gid; } 
			set { _u_gid = value; } 
		
		}
		#endregion
		
		#region r_gid
		private string _r_gid;
       
        /// <summary>
        /// 
        /// </summary>        
        public string r_gid 
		{ 
			get { return _r_gid; } 
			set { _r_gid = value; } 
		
		}
		#endregion
		
		#region u_r_CreateTime
		private DateTime? _u_r_CreateTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime? u_r_CreateTime 
		{ 
			get { return _u_r_CreateTime; } 
			set { _u_r_CreateTime = value; } 
		
		}
		#endregion
		
		#region u_r_CreateUser
		private string _u_r_CreateUser;
       
        /// <summary>
        /// 
        /// </summary>        
        public string u_r_CreateUser 
		{ 
			get { return _u_r_CreateUser; } 
			set { _u_r_CreateUser = value; } 
		
		}
		#endregion
		
    }
	
}