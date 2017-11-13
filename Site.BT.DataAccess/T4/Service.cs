 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using Site.BT.DataAccess.Model;
using Site.BT.DataAccess.Access;

namespace Site.BT.DataAccess.Service
{

	public partial class BusinessAccountBindingService
    {

        #region 01 BusinessAccountBinding_Insert
		 public static int Insert(BusinessAccountBinding obj)
		 {
			using (var access = new BusinessAccountBindingAccess())
            {
                return access.Insert(obj);
            }
		 }
		#endregion
		
		#region 02 BusinessAccountBinding_Delete
		 public static int Delete(int id)
		 {
			using (var access = new BusinessAccountBindingAccess())
			{
				return access.Delete(id);
			}
		}
		#endregion

		#region 03 BusinessAccountBinding_Update
		 public static int Update(BusinessAccountBinding obj)
		 {
			
			using (var access = new BusinessAccountBindingAccess())
			{
				return access.Update(obj);
			}
		}
		#endregion

		#region 04 BusinessAccountBinding_SelectObject
		 public static BusinessAccountBinding SelectObject(int id)
		 {
			
			using (var access = new BusinessAccountBindingAccess())
			{
				return access.SelectObject(id);
			}
		}
		#endregion

		#region 05 BusinessAccountBinding_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<BusinessAccountBinding> Select(string whereStr)
		 {
			using (var access = new BusinessAccountBindingAccess())
			{
				return access.Select(whereStr);
			}
		}
		#endregion

		#region 06 BusinessAccountBinding_SelectPage
		 public static IList<BusinessAccountBinding> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			using (var access = new BusinessAccountBindingAccess())
			{
				return access.SelectPage(cloumns,order,whereStr,pageIndex,pageSize, out rowCount);
			}
		}
		#endregion

    }
	public partial class BusinessUserService
    {

        #region 01 BusinessUser_Insert
		 public static int Insert(BusinessUser obj)
		 {
			using (var access = new BusinessUserAccess())
            {
                return access.Insert(obj);
            }
		 }
		#endregion
		
		#region 02 BusinessUser_Delete
		 public static int Delete(int id)
		 {
			using (var access = new BusinessUserAccess())
			{
				return access.Delete(id);
			}
		}
		#endregion

		#region 03 BusinessUser_Update
		 public static int Update(BusinessUser obj)
		 {
			
			using (var access = new BusinessUserAccess())
			{
				return access.Update(obj);
			}
		}
		#endregion

		#region 04 BusinessUser_SelectObject
		 public static BusinessUser SelectObject(int id)
		 {
			
			using (var access = new BusinessUserAccess())
			{
				return access.SelectObject(id);
			}
		}
		#endregion

		#region 05 BusinessUser_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<BusinessUser> Select(string whereStr)
		 {
			using (var access = new BusinessUserAccess())
			{
				return access.Select(whereStr);
			}
		}
		#endregion

		#region 06 BusinessUser_SelectPage
		 public static IList<BusinessUser> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			using (var access = new BusinessUserAccess())
			{
				return access.SelectPage(cloumns,order,whereStr,pageIndex,pageSize, out rowCount);
			}
		}
		#endregion

    }
}
