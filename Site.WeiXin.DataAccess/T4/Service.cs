 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using Site.WeiXin.DataAccess.Model;
using Site.WeiXin.DataAccess.Access;

namespace Site.WeiXin.DataAccess.Service
{

	public partial class GloblaTokenService
    {

        #region 01 GloblaToken_Insert
		 public static int Insert(GloblaToken obj)
		 {
			using (var access = new GloblaTokenAccess())
            {
                return access.Insert(obj);
            }
		 }
		#endregion
		
		#region 02 GloblaToken_Delete
		 public static int Delete(int id)
		 {
			using (var access = new GloblaTokenAccess())
			{
				return access.Delete(id);
			}
		}
		#endregion

		#region 03 GloblaToken_Update
		 public static int Update(GloblaToken obj)
		 {
			
			using (var access = new GloblaTokenAccess())
			{
				return access.Update(obj);
			}
		}
		#endregion

		#region 04 GloblaToken_SelectObject
		 public static GloblaToken SelectObject(int id)
		 {
			
			using (var access = new GloblaTokenAccess())
			{
				return access.SelectObject(id);
			}
		}
		#endregion

		#region 05 GloblaToken_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以空格 and 开始</param>
         /// <returns></returns>
		 public static IList<GloblaToken> Select(string whereStr)
		 {
			using (var access = new GloblaTokenAccess())
			{
				return access.Select(whereStr);
			}
		}
		#endregion

		#region 06 GloblaToken_SelectPage
		 public static IList<GloblaToken> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			using (var access = new GloblaTokenAccess())
			{
				return access.SelectPage(cloumns,order,whereStr,pageIndex,pageSize, out rowCount);
			}
		}
		#endregion

    }
	public partial class MenuService
    {

        #region 01 Menu_Insert
		 public static int Insert(Menu obj)
		 {
			using (var access = new MenuAccess())
            {
                return access.Insert(obj);
            }
		 }
		#endregion
		
		#region 02 Menu_Delete
		 public static int Delete(int id)
		 {
			using (var access = new MenuAccess())
			{
				return access.Delete(id);
			}
		}
		#endregion

		#region 03 Menu_Update
		 public static int Update(Menu obj)
		 {
			
			using (var access = new MenuAccess())
			{
				return access.Update(obj);
			}
		}
		#endregion

		#region 04 Menu_SelectObject
		 public static Menu SelectObject(int id)
		 {
			
			using (var access = new MenuAccess())
			{
				return access.SelectObject(id);
			}
		}
		#endregion

		#region 05 Menu_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以空格 and 开始</param>
         /// <returns></returns>
		 public static IList<Menu> Select(string whereStr)
		 {
			using (var access = new MenuAccess())
			{
				return access.Select(whereStr);
			}
		}
		#endregion

		#region 06 Menu_SelectPage
		 public static IList<Menu> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			using (var access = new MenuAccess())
			{
				return access.SelectPage(cloumns,order,whereStr,pageIndex,pageSize, out rowCount);
			}
		}
		#endregion

    }
	public partial class MenuTypeService
    {

        #region 01 MenuType_Insert
		 public static int Insert(MenuType obj)
		 {
			using (var access = new MenuTypeAccess())
            {
                return access.Insert(obj);
            }
		 }
		#endregion
		
		#region 02 MenuType_Delete
		 public static int Delete(int id)
		 {
			using (var access = new MenuTypeAccess())
			{
				return access.Delete(id);
			}
		}
		#endregion

		#region 03 MenuType_Update
		 public static int Update(MenuType obj)
		 {
			
			using (var access = new MenuTypeAccess())
			{
				return access.Update(obj);
			}
		}
		#endregion

		#region 04 MenuType_SelectObject
		 public static MenuType SelectObject(int id)
		 {
			
			using (var access = new MenuTypeAccess())
			{
				return access.SelectObject(id);
			}
		}
		#endregion

		#region 05 MenuType_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以空格 and 开始</param>
         /// <returns></returns>
		 public static IList<MenuType> Select(string whereStr)
		 {
			using (var access = new MenuTypeAccess())
			{
				return access.Select(whereStr);
			}
		}
		#endregion

		#region 06 MenuType_SelectPage
		 public static IList<MenuType> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			using (var access = new MenuTypeAccess())
			{
				return access.SelectPage(cloumns,order,whereStr,pageIndex,pageSize, out rowCount);
			}
		}
		#endregion

    }
	public partial class SystemUserService
    {

        #region 01 SystemUser_Insert
		 public static int Insert(SystemUser obj)
		 {
			using (var access = new SystemUserAccess())
            {
                return access.Insert(obj);
            }
		 }
		#endregion
		
		#region 02 SystemUser_Delete
		 public static int Delete(int id)
		 {
			using (var access = new SystemUserAccess())
			{
				return access.Delete(id);
			}
		}
		#endregion

		#region 03 SystemUser_Update
		 public static int Update(SystemUser obj)
		 {
			
			using (var access = new SystemUserAccess())
			{
				return access.Update(obj);
			}
		}
		#endregion

		#region 04 SystemUser_SelectObject
		 public static SystemUser SelectObject(int id)
		 {
			
			using (var access = new SystemUserAccess())
			{
				return access.SelectObject(id);
			}
		}
		#endregion

		#region 05 SystemUser_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以空格 and 开始</param>
         /// <returns></returns>
		 public static IList<SystemUser> Select(string whereStr)
		 {
			using (var access = new SystemUserAccess())
			{
				return access.Select(whereStr);
			}
		}
		#endregion

		#region 06 SystemUser_SelectPage
		 public static IList<SystemUser> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			using (var access = new SystemUserAccess())
			{
				return access.SelectPage(cloumns,order,whereStr,pageIndex,pageSize, out rowCount);
			}
		}
		#endregion

    }
	public partial class UserService
    {

        #region 01 User_Insert
		 public static int Insert(User obj)
		 {
			using (var access = new UserAccess())
            {
                return access.Insert(obj);
            }
		 }
		#endregion
		
		#region 02 User_Delete
		 public static int Delete(int id)
		 {
			using (var access = new UserAccess())
			{
				return access.Delete(id);
			}
		}
		#endregion

		#region 03 User_Update
		 public static int Update(User obj)
		 {
			
			using (var access = new UserAccess())
			{
				return access.Update(obj);
			}
		}
		#endregion

		#region 04 User_SelectObject
		 public static User SelectObject(int id)
		 {
			
			using (var access = new UserAccess())
			{
				return access.SelectObject(id);
			}
		}
		#endregion

		#region 05 User_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以空格 and 开始</param>
         /// <returns></returns>
		 public static IList<User> Select(string whereStr)
		 {
			using (var access = new UserAccess())
			{
				return access.Select(whereStr);
			}
		}
		#endregion

		#region 06 User_SelectPage
		 public static IList<User> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			using (var access = new UserAccess())
			{
				return access.SelectPage(cloumns,order,whereStr,pageIndex,pageSize, out rowCount);
			}
		}
		#endregion

    }
	public partial class UserMessageService
    {

        #region 01 UserMessage_Insert
		 public static int Insert(UserMessage obj)
		 {
			using (var access = new UserMessageAccess())
            {
                return access.Insert(obj);
            }
		 }
		#endregion
		
		#region 02 UserMessage_Delete
		 public static int Delete(int id)
		 {
			using (var access = new UserMessageAccess())
			{
				return access.Delete(id);
			}
		}
		#endregion

		#region 03 UserMessage_Update
		 public static int Update(UserMessage obj)
		 {
			
			using (var access = new UserMessageAccess())
			{
				return access.Update(obj);
			}
		}
		#endregion

		#region 04 UserMessage_SelectObject
		 public static UserMessage SelectObject(int id)
		 {
			
			using (var access = new UserMessageAccess())
			{
				return access.SelectObject(id);
			}
		}
		#endregion

		#region 05 UserMessage_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以空格 and 开始</param>
         /// <returns></returns>
		 public static IList<UserMessage> Select(string whereStr)
		 {
			using (var access = new UserMessageAccess())
			{
				return access.Select(whereStr);
			}
		}
		#endregion

		#region 06 UserMessage_SelectPage
		 public static IList<UserMessage> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			using (var access = new UserMessageAccess())
			{
				return access.SelectPage(cloumns,order,whereStr,pageIndex,pageSize, out rowCount);
			}
		}
		#endregion

    }
}
