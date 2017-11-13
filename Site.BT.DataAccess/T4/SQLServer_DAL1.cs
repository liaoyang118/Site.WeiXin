

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using DataAccess.Base;
using Site.BT.DataAccess.Model;

namespace Site.BT.DataAccess.Access
{

	[Serializable]
	public partial class BusinessAccountBindingAccess : AccessBase<BusinessAccountBinding>,IDisposable
    {

		Database db;

		DatabaseProviderFactory factory = new DatabaseProviderFactory();//6.0 创建方式

        #region 00 IDisposable 实现
        public BusinessAccountBindingAccess(string configName)
        {
			db = factory.Create(configName);
        }

        public BusinessAccountBindingAccess()
        {
            db = factory.Create("BT");
        }

        //虚拟Idisposable 实现,手动调用的
        public void Dispose()
        {
            //调用方法，释放资源
            Dispose(true);
            //通知GC，已经手动调用，不用调用析构函数了
            System.GC.SuppressFinalize(this);
        }

        //重载方法，满足不同的调用，清理干净资源，提升性能
        /// <summary>
        /// true --手动调用，清理托管资源
        /// false--GC 调用，把非托管资源一起清理掉
        /// </summary>
        /// <param name="isDispose"></param>
        protected virtual void Dispose(bool isDispose)
        {
            if (isDispose)
            {

            }
            //清理非托管资源，此处没有，所以直接ruturn
            return;
        }

        //析构函数，供GC 调用
        ~BusinessAccountBindingAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_BusinessAccountBinding_Insert
		 public override int Insert(BusinessAccountBinding obj)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_BusinessAccountBinding_Insert");
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@OpenId", DbType.String,obj.OpenId);
			db.AddInParameter(dbCmd, "@BusinessUserId", DbType.Int32,obj.BusinessUserId);
			db.AddInParameter(dbCmd, "@BussinessUserAccount", DbType.String,obj.BussinessUserAccount);
			db.AddInParameter(dbCmd, "@CreateTime", DbType.DateTime,obj.CreateTime);
						try
			{ 
				int returnValue = db.ExecuteNonQuery(dbCmd);
				//int Id = (int)dbCmd.Parameters["@Id"].Value;
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		#endregion
		
		#region 02 Proc_BusinessAccountBinding_Delete
		 public override int Delete(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_BusinessAccountBinding_DeleteById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			try
			{ 
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		#endregion

		#region 03 Proc_BusinessAccountBinding_Update
		 public override int Update(BusinessAccountBinding obj)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_BusinessAccountBinding_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@OpenId", DbType.String,obj.OpenId);
			db.AddInParameter(dbCmd, "@BusinessUserId", DbType.Int32,obj.BusinessUserId);
			db.AddInParameter(dbCmd, "@BussinessUserAccount", DbType.String,obj.BussinessUserAccount);
			db.AddInParameter(dbCmd, "@CreateTime", DbType.DateTime,obj.CreateTime);
			
			try
			{ 
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		#endregion

		#region 04 Proc_BusinessAccountBinding_SelectObject
		 public override BusinessAccountBinding SelectObject(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_BusinessAccountBinding_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			BusinessAccountBinding obj=null;
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						obj=Object2Model(reader);
					}
                }
				return obj;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
		}
		#endregion

		#region 05 Proc_BusinessAccountBinding_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 空格 and开始</param>
         /// <returns></returns>
		 public override IList<BusinessAccountBinding> Select(string whereStr)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_BusinessAccountBinding_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
			
			IList<BusinessAccountBinding> list= new List<BusinessAccountBinding>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						BusinessAccountBinding obj= Object2Model(reader);
						list.Add(obj);
					}
                }
				return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
		}
		#endregion

		#region 06 Proc_BusinessAccountBinding_SelectPage
		 public override IList<BusinessAccountBinding> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_BusinessAccountBinding_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);

			List<BusinessAccountBinding> list= new List<BusinessAccountBinding>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						BusinessAccountBinding obj= Object2Model(reader);
						list.Add(obj);
					}
					reader.NextResult();
					rowCount = (int)dbCmd.Parameters["@rowCount"].Value;
                }
				return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
		}
		#endregion


		#region Object2Model

        public BusinessAccountBinding Object2Model(IDataReader reader)
        {
            BusinessAccountBinding obj = null;
            try
            {
                obj = new BusinessAccountBinding();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.OpenId = reader["OpenId"] == DBNull.Value ? default(string) : (string)reader["OpenId"];
				obj.BusinessUserId = reader["BusinessUserId"] == DBNull.Value ? default(int) : (int)reader["BusinessUserId"];
				obj.BussinessUserAccount = reader["BussinessUserAccount"] == DBNull.Value ? default(string) : (string)reader["BussinessUserAccount"];
				obj.CreateTime = reader["CreateTime"] == DBNull.Value ? default(DateTime) : (DateTime)reader["CreateTime"];
				
            }
            catch(Exception ex)
            {
                obj = null;
            }
            return obj;
        }



        #endregion


    }
	[Serializable]
	public partial class BusinessUserAccess : AccessBase<BusinessUser>,IDisposable
    {

		Database db;

		DatabaseProviderFactory factory = new DatabaseProviderFactory();//6.0 创建方式

        #region 00 IDisposable 实现
        public BusinessUserAccess(string configName)
        {
			db = factory.Create(configName);
        }

        public BusinessUserAccess()
        {
            db = factory.Create("BT");
        }

        //虚拟Idisposable 实现,手动调用的
        public void Dispose()
        {
            //调用方法，释放资源
            Dispose(true);
            //通知GC，已经手动调用，不用调用析构函数了
            System.GC.SuppressFinalize(this);
        }

        //重载方法，满足不同的调用，清理干净资源，提升性能
        /// <summary>
        /// true --手动调用，清理托管资源
        /// false--GC 调用，把非托管资源一起清理掉
        /// </summary>
        /// <param name="isDispose"></param>
        protected virtual void Dispose(bool isDispose)
        {
            if (isDispose)
            {

            }
            //清理非托管资源，此处没有，所以直接ruturn
            return;
        }

        //析构函数，供GC 调用
        ~BusinessUserAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_BusinessUser_Insert
		 public override int Insert(BusinessUser obj)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_BusinessUser_Insert");
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@Account", DbType.String,obj.Account);
			db.AddInParameter(dbCmd, "@Password", DbType.String,obj.Password);
			db.AddInParameter(dbCmd, "@Status", DbType.Int32,obj.Status);
			db.AddInParameter(dbCmd, "@CreateUserAccount", DbType.String,obj.CreateUserAccount);
			db.AddInParameter(dbCmd, "@CreateTime", DbType.DateTime,obj.CreateTime);
						try
			{ 
				int returnValue = db.ExecuteNonQuery(dbCmd);
				//int Id = (int)dbCmd.Parameters["@Id"].Value;
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		#endregion
		
		#region 02 Proc_BusinessUser_Delete
		 public override int Delete(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_BusinessUser_DeleteById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			try
			{ 
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		#endregion

		#region 03 Proc_BusinessUser_Update
		 public override int Update(BusinessUser obj)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_BusinessUser_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@Account", DbType.String,obj.Account);
			db.AddInParameter(dbCmd, "@Password", DbType.String,obj.Password);
			db.AddInParameter(dbCmd, "@Status", DbType.Int32,obj.Status);
			db.AddInParameter(dbCmd, "@CreateUserAccount", DbType.String,obj.CreateUserAccount);
			db.AddInParameter(dbCmd, "@CreateTime", DbType.DateTime,obj.CreateTime);
			
			try
			{ 
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		#endregion

		#region 04 Proc_BusinessUser_SelectObject
		 public override BusinessUser SelectObject(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_BusinessUser_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			BusinessUser obj=null;
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						obj=Object2Model(reader);
					}
                }
				return obj;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
		}
		#endregion

		#region 05 Proc_BusinessUser_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 空格 and开始</param>
         /// <returns></returns>
		 public override IList<BusinessUser> Select(string whereStr)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_BusinessUser_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
			
			IList<BusinessUser> list= new List<BusinessUser>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						BusinessUser obj= Object2Model(reader);
						list.Add(obj);
					}
                }
				return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
		}
		#endregion

		#region 06 Proc_BusinessUser_SelectPage
		 public override IList<BusinessUser> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_BusinessUser_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);

			List<BusinessUser> list= new List<BusinessUser>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						BusinessUser obj= Object2Model(reader);
						list.Add(obj);
					}
					reader.NextResult();
					rowCount = (int)dbCmd.Parameters["@rowCount"].Value;
                }
				return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
		}
		#endregion


		#region Object2Model

        public BusinessUser Object2Model(IDataReader reader)
        {
            BusinessUser obj = null;
            try
            {
                obj = new BusinessUser();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.Account = reader["Account"] == DBNull.Value ? default(string) : (string)reader["Account"];
				obj.Password = reader["Password"] == DBNull.Value ? default(string) : (string)reader["Password"];
				obj.Status = reader["Status"] == DBNull.Value ? default(int) : (int)reader["Status"];
				obj.CreateUserAccount = reader["CreateUserAccount"] == DBNull.Value ? default(string) : (string)reader["CreateUserAccount"];
				obj.CreateTime = reader["CreateTime"] == DBNull.Value ? default(DateTime) : (DateTime)reader["CreateTime"];
				
            }
            catch(Exception ex)
            {
                obj = null;
            }
            return obj;
        }



        #endregion


    }
}
