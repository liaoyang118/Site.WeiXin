

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace DataAccess.Model
{

	[Serializable]
	public partial class ModulePermissionAccess : AccessBase<ModulePermission>
    {

		Database db;

        #region 00 IDisposable 实现
        public ModulePermissionAccess(string configName)
        {
            db = DatabaseFactory.CreateDatabase(configName);
        }

        public ModulePermissionAccess()
        {
            db = DatabaseFactory.CreateDatabase("MySite");
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
        ~ModulePermissionAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_ModulePermission_Insert
		 public override int Insert(ModulePermission obj)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ModulePermission_Insert");
			db.AddOutParameter(dbCmd, "@p_id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@p_gid", DbType.String,obj.p_gid);
			db.AddInParameter(dbCmd, "@p_m_gid", DbType.String,obj.p_m_gid);
			db.AddInParameter(dbCmd, "@p_name", DbType.String,obj.p_name);
			db.AddInParameter(dbCmd, "@p_path", DbType.String,obj.p_path);
			db.AddInParameter(dbCmd, "@p_createTime", DbType.DateTime,obj.p_createTime);
			db.AddInParameter(dbCmd, "@p_createUser", DbType.String,obj.p_createUser);
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
		
		#region 02 Proc_ModulePermission_Delete
		 public override int Delete(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ModulePermission_DeleteByp_id");
			db.AddInParameter(dbCmd, "@p_id", DbType.Int32,id);
			
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

		#region 03 Proc_ModulePermission_Update
		 public override int Update(ModulePermission obj)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ModulePermission_DeleteByp_id");
			db.AddInParameter(dbCmd, "@p_id", DbType.Int32,obj.p_id);
			db.AddInParameter(dbCmd, "@p_gid", DbType.String,obj.p_gid);
			db.AddInParameter(dbCmd, "@p_m_gid", DbType.String,obj.p_m_gid);
			db.AddInParameter(dbCmd, "@p_name", DbType.String,obj.p_name);
			db.AddInParameter(dbCmd, "@p_path", DbType.String,obj.p_path);
			db.AddInParameter(dbCmd, "@p_createTime", DbType.DateTime,obj.p_createTime);
			db.AddInParameter(dbCmd, "@p_createUser", DbType.String,obj.p_createUser);
			
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

		#region 04 Proc_ModulePermission_SelectObject
		 public override ModulePermission SelectObject(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ModulePermission_SelectByp_id");
			db.AddInParameter(dbCmd, "@p_id", DbType.Int32,id);
			
			ModulePermission obj=null;
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

		#region 05 Proc_ModulePermission_Select
		 public override IList<ModulePermission> Select(string whereStr)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ModulePermission_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
			
			IList<ModulePermission> list= new List<ModulePermission>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						ModulePermission obj= Object2Model(reader);
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

		#region 06 Proc_ModulePermission_SelectPage
		 public override IList<ModulePermission> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ModulePermission_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);

			List<ModulePermission> list= new List<ModulePermission>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						ModulePermission obj= Object2Model(reader);
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

        public ModulePermission Object2Model(IDataReader reader)
        {
            ModulePermission obj = null;
            try
            {
                obj = new ModulePermission();
				obj.p_id = reader["p_id"] == null ? default(int) : (int)reader["p_id"];
				obj.p_gid = reader["p_gid"] == null ? default(string) : (string)reader["p_gid"];
				obj.p_m_gid = reader["p_m_gid"] == null ? default(string) : (string)reader["p_m_gid"];
				obj.p_name = reader["p_name"] == null ? default(string) : (string)reader["p_name"];
				obj.p_path = reader["p_path"] == null ? default(string) : (string)reader["p_path"];
				obj.p_createTime = reader["p_createTime"] == null ? default(DateTime) : (DateTime)reader["p_createTime"];
				obj.p_createUser = reader["p_createUser"] == null ? default(string) : (string)reader["p_createUser"];
				
            }
            catch
            {
                obj = null;
            }
            return obj;
        }



        #endregion


    }
	[Serializable]
	public partial class RoleAccess : AccessBase<Role>
    {

		Database db;

        #region 00 IDisposable 实现
        public RoleAccess(string configName)
        {
            db = DatabaseFactory.CreateDatabase(configName);
        }

        public RoleAccess()
        {
            db = DatabaseFactory.CreateDatabase("MySite");
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
        ~RoleAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_Role_Insert
		 public override int Insert(Role obj)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Role_Insert");
			db.AddOutParameter(dbCmd, "@r_id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@r_gid", DbType.String,obj.r_gid);
			db.AddInParameter(dbCmd, "@r_name", DbType.String,obj.r_name);
			db.AddInParameter(dbCmd, "@r_createTime", DbType.DateTime,obj.r_createTime);
			db.AddInParameter(dbCmd, "@r_createUser", DbType.String,obj.r_createUser);
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
		
		#region 02 Proc_Role_Delete
		 public override int Delete(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Role_DeleteByr_id");
			db.AddInParameter(dbCmd, "@r_id", DbType.Int32,id);
			
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

		#region 03 Proc_Role_Update
		 public override int Update(Role obj)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Role_DeleteByr_id");
			db.AddInParameter(dbCmd, "@r_id", DbType.Int32,obj.r_id);
			db.AddInParameter(dbCmd, "@r_gid", DbType.String,obj.r_gid);
			db.AddInParameter(dbCmd, "@r_name", DbType.String,obj.r_name);
			db.AddInParameter(dbCmd, "@r_createTime", DbType.DateTime,obj.r_createTime);
			db.AddInParameter(dbCmd, "@r_createUser", DbType.String,obj.r_createUser);
			
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

		#region 04 Proc_Role_SelectObject
		 public override Role SelectObject(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Role_SelectByr_id");
			db.AddInParameter(dbCmd, "@r_id", DbType.Int32,id);
			
			Role obj=null;
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

		#region 05 Proc_Role_Select
		 public override IList<Role> Select(string whereStr)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Role_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
			
			IList<Role> list= new List<Role>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						Role obj= Object2Model(reader);
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

		#region 06 Proc_Role_SelectPage
		 public override IList<Role> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Role_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);

			List<Role> list= new List<Role>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						Role obj= Object2Model(reader);
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

        public Role Object2Model(IDataReader reader)
        {
            Role obj = null;
            try
            {
                obj = new Role();
				obj.r_id = reader["r_id"] == null ? default(int) : (int)reader["r_id"];
				obj.r_gid = reader["r_gid"] == null ? default(string) : (string)reader["r_gid"];
				obj.r_name = reader["r_name"] == null ? default(string) : (string)reader["r_name"];
				obj.r_createTime = reader["r_createTime"] == null ? default(DateTime) : (DateTime)reader["r_createTime"];
				obj.r_createUser = reader["r_createUser"] == null ? default(string) : (string)reader["r_createUser"];
				
            }
            catch
            {
                obj = null;
            }
            return obj;
        }



        #endregion


    }
	[Serializable]
	public partial class Role_ModualPermission_MappingAccess : AccessBase<Role_ModualPermission_Mapping>
    {

		Database db;

        #region 00 IDisposable 实现
        public Role_ModualPermission_MappingAccess(string configName)
        {
            db = DatabaseFactory.CreateDatabase(configName);
        }

        public Role_ModualPermission_MappingAccess()
        {
            db = DatabaseFactory.CreateDatabase("MySite");
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
        ~Role_ModualPermission_MappingAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_Role_ModualPermission_Mapping_Insert
		 public override int Insert(Role_ModualPermission_Mapping obj)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Role_ModualPermission_Mapping_Insert");
			db.AddOutParameter(dbCmd, "@r_p_id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@r_p_gid", DbType.String,obj.r_p_gid);
			db.AddInParameter(dbCmd, "@r_gid", DbType.String,obj.r_gid);
			db.AddInParameter(dbCmd, "@p_gid", DbType.String,obj.p_gid);
			db.AddInParameter(dbCmd, "@r_p_CreateTime", DbType.DateTime,obj.r_p_CreateTime);
			db.AddInParameter(dbCmd, "@r_p_CreateUser", DbType.String,obj.r_p_CreateUser);
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
		
		#region 02 Proc_Role_ModualPermission_Mapping_Delete
		 public override int Delete(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Role_ModualPermission_Mapping_DeleteByr_p_id");
			db.AddInParameter(dbCmd, "@r_p_id", DbType.Int32,id);
			
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

		#region 03 Proc_Role_ModualPermission_Mapping_Update
		 public override int Update(Role_ModualPermission_Mapping obj)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Role_ModualPermission_Mapping_DeleteByr_p_id");
			db.AddInParameter(dbCmd, "@r_p_id", DbType.Int32,obj.r_p_id);
			db.AddInParameter(dbCmd, "@r_p_gid", DbType.String,obj.r_p_gid);
			db.AddInParameter(dbCmd, "@r_gid", DbType.String,obj.r_gid);
			db.AddInParameter(dbCmd, "@p_gid", DbType.String,obj.p_gid);
			db.AddInParameter(dbCmd, "@r_p_CreateTime", DbType.DateTime,obj.r_p_CreateTime);
			db.AddInParameter(dbCmd, "@r_p_CreateUser", DbType.String,obj.r_p_CreateUser);
			
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

		#region 04 Proc_Role_ModualPermission_Mapping_SelectObject
		 public override Role_ModualPermission_Mapping SelectObject(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Role_ModualPermission_Mapping_SelectByr_p_id");
			db.AddInParameter(dbCmd, "@r_p_id", DbType.Int32,id);
			
			Role_ModualPermission_Mapping obj=null;
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

		#region 05 Proc_Role_ModualPermission_Mapping_Select
		 public override IList<Role_ModualPermission_Mapping> Select(string whereStr)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Role_ModualPermission_Mapping_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
			
			IList<Role_ModualPermission_Mapping> list= new List<Role_ModualPermission_Mapping>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						Role_ModualPermission_Mapping obj= Object2Model(reader);
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

		#region 06 Proc_Role_ModualPermission_Mapping_SelectPage
		 public override IList<Role_ModualPermission_Mapping> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Role_ModualPermission_Mapping_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);

			List<Role_ModualPermission_Mapping> list= new List<Role_ModualPermission_Mapping>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						Role_ModualPermission_Mapping obj= Object2Model(reader);
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

        public Role_ModualPermission_Mapping Object2Model(IDataReader reader)
        {
            Role_ModualPermission_Mapping obj = null;
            try
            {
                obj = new Role_ModualPermission_Mapping();
				obj.r_p_id = reader["r_p_id"] == null ? default(int) : (int)reader["r_p_id"];
				obj.r_p_gid = reader["r_p_gid"] == null ? default(string) : (string)reader["r_p_gid"];
				obj.r_gid = reader["r_gid"] == null ? default(string) : (string)reader["r_gid"];
				obj.p_gid = reader["p_gid"] == null ? default(string) : (string)reader["p_gid"];
				obj.r_p_CreateTime = reader["r_p_CreateTime"] == null ? default(DateTime) : (DateTime)reader["r_p_CreateTime"];
				obj.r_p_CreateUser = reader["r_p_CreateUser"] == null ? default(string) : (string)reader["r_p_CreateUser"];
				
            }
            catch
            {
                obj = null;
            }
            return obj;
        }



        #endregion


    }
	[Serializable]
	public partial class Site_CatesAccess : AccessBase<Site_Cates>
    {

		Database db;

        #region 00 IDisposable 实现
        public Site_CatesAccess(string configName)
        {
            db = DatabaseFactory.CreateDatabase(configName);
        }

        public Site_CatesAccess()
        {
            db = DatabaseFactory.CreateDatabase("MySite");
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
        ~Site_CatesAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_Site_Cates_Insert
		 public override int Insert(Site_Cates obj)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Site_Cates_Insert");
			db.AddOutParameter(dbCmd, "@c_id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@c_gid", DbType.String,obj.c_gid);
			db.AddInParameter(dbCmd, "@c_path", DbType.String,obj.c_path);
			db.AddInParameter(dbCmd, "@c_isMainCate", DbType.Boolean,obj.c_isMainCate);
			db.AddInParameter(dbCmd, "@c_tableId", DbType.Int32,obj.c_tableId);
			db.AddInParameter(dbCmd, "@c_name", DbType.String,obj.c_name);
			db.AddInParameter(dbCmd, "@c_type", DbType.String,obj.c_type);
			db.AddInParameter(dbCmd, "@c_createUser", DbType.String,obj.c_createUser);
			db.AddInParameter(dbCmd, "@c_createTime", DbType.DateTime,obj.c_createTime);
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
		
		#region 02 Proc_Site_Cates_Delete
		 public override int Delete(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Site_Cates_DeleteByc_id");
			db.AddInParameter(dbCmd, "@c_id", DbType.Int32,id);
			
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

		#region 03 Proc_Site_Cates_Update
		 public override int Update(Site_Cates obj)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Site_Cates_DeleteByc_id");
			db.AddInParameter(dbCmd, "@c_id", DbType.Int32,obj.c_id);
			db.AddInParameter(dbCmd, "@c_gid", DbType.String,obj.c_gid);
			db.AddInParameter(dbCmd, "@c_path", DbType.String,obj.c_path);
			db.AddInParameter(dbCmd, "@c_isMainCate", DbType.Boolean,obj.c_isMainCate);
			db.AddInParameter(dbCmd, "@c_tableId", DbType.Int32,obj.c_tableId);
			db.AddInParameter(dbCmd, "@c_name", DbType.String,obj.c_name);
			db.AddInParameter(dbCmd, "@c_type", DbType.String,obj.c_type);
			db.AddInParameter(dbCmd, "@c_createUser", DbType.String,obj.c_createUser);
			db.AddInParameter(dbCmd, "@c_createTime", DbType.DateTime,obj.c_createTime);
			
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

		#region 04 Proc_Site_Cates_SelectObject
		 public override Site_Cates SelectObject(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Site_Cates_SelectByc_id");
			db.AddInParameter(dbCmd, "@c_id", DbType.Int32,id);
			
			Site_Cates obj=null;
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

		#region 05 Proc_Site_Cates_Select
		 public override IList<Site_Cates> Select(string whereStr)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Site_Cates_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
			
			IList<Site_Cates> list= new List<Site_Cates>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						Site_Cates obj= Object2Model(reader);
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

		#region 06 Proc_Site_Cates_SelectPage
		 public override IList<Site_Cates> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Site_Cates_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);

			List<Site_Cates> list= new List<Site_Cates>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						Site_Cates obj= Object2Model(reader);
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

        public Site_Cates Object2Model(IDataReader reader)
        {
            Site_Cates obj = null;
            try
            {
                obj = new Site_Cates();
				obj.c_id = reader["c_id"] == null ? default(int) : (int)reader["c_id"];
				obj.c_gid = reader["c_gid"] == null ? default(string) : (string)reader["c_gid"];
				obj.c_path = reader["c_path"] == null ? default(string) : (string)reader["c_path"];
				obj.c_isMainCate = reader["c_isMainCate"] == null ? default(bool) : (bool)reader["c_isMainCate"];
				obj.c_tableId = reader["c_tableId"] == null ? default(int) : (int)reader["c_tableId"];
				obj.c_name = reader["c_name"] == null ? default(string) : (string)reader["c_name"];
				obj.c_type = reader["c_type"] == null ? default(string) : (string)reader["c_type"];
				obj.c_createUser = reader["c_createUser"] == null ? default(string) : (string)reader["c_createUser"];
				obj.c_createTime = reader["c_createTime"] == null ? default(DateTime) : (DateTime)reader["c_createTime"];
				
            }
            catch
            {
                obj = null;
            }
            return obj;
        }



        #endregion


    }
	[Serializable]
	public partial class Site_CMSBlockAccess : AccessBase<Site_CMSBlock>
    {

		Database db;

        #region 00 IDisposable 实现
        public Site_CMSBlockAccess(string configName)
        {
            db = DatabaseFactory.CreateDatabase(configName);
        }

        public Site_CMSBlockAccess()
        {
            db = DatabaseFactory.CreateDatabase("MySite");
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
        ~Site_CMSBlockAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_Site_CMSBlock_Insert
		 public override int Insert(Site_CMSBlock obj)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Site_CMSBlock_Insert");
			db.AddOutParameter(dbCmd, "@b_id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@b_gid", DbType.String,obj.b_gid);
			db.AddInParameter(dbCmd, "@b_p_gid", DbType.String,obj.b_p_gid);
			db.AddInParameter(dbCmd, "@b_path", DbType.String,obj.b_path);
			db.AddInParameter(dbCmd, "@b_name", DbType.String,obj.b_name);
			db.AddInParameter(dbCmd, "@b_createUser", DbType.String,obj.b_createUser);
			db.AddInParameter(dbCmd, "@b_createTime", DbType.DateTime,obj.b_createTime);
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
		
		#region 02 Proc_Site_CMSBlock_Delete
		 public override int Delete(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Site_CMSBlock_DeleteByb_id");
			db.AddInParameter(dbCmd, "@b_id", DbType.Int32,id);
			
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

		#region 03 Proc_Site_CMSBlock_Update
		 public override int Update(Site_CMSBlock obj)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Site_CMSBlock_DeleteByb_id");
			db.AddInParameter(dbCmd, "@b_id", DbType.Int32,obj.b_id);
			db.AddInParameter(dbCmd, "@b_gid", DbType.String,obj.b_gid);
			db.AddInParameter(dbCmd, "@b_p_gid", DbType.String,obj.b_p_gid);
			db.AddInParameter(dbCmd, "@b_path", DbType.String,obj.b_path);
			db.AddInParameter(dbCmd, "@b_name", DbType.String,obj.b_name);
			db.AddInParameter(dbCmd, "@b_createUser", DbType.String,obj.b_createUser);
			db.AddInParameter(dbCmd, "@b_createTime", DbType.DateTime,obj.b_createTime);
			
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

		#region 04 Proc_Site_CMSBlock_SelectObject
		 public override Site_CMSBlock SelectObject(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Site_CMSBlock_SelectByb_id");
			db.AddInParameter(dbCmd, "@b_id", DbType.Int32,id);
			
			Site_CMSBlock obj=null;
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

		#region 05 Proc_Site_CMSBlock_Select
		 public override IList<Site_CMSBlock> Select(string whereStr)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Site_CMSBlock_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
			
			IList<Site_CMSBlock> list= new List<Site_CMSBlock>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						Site_CMSBlock obj= Object2Model(reader);
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

		#region 06 Proc_Site_CMSBlock_SelectPage
		 public override IList<Site_CMSBlock> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Site_CMSBlock_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);

			List<Site_CMSBlock> list= new List<Site_CMSBlock>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						Site_CMSBlock obj= Object2Model(reader);
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

        public Site_CMSBlock Object2Model(IDataReader reader)
        {
            Site_CMSBlock obj = null;
            try
            {
                obj = new Site_CMSBlock();
				obj.b_id = reader["b_id"] == null ? default(int) : (int)reader["b_id"];
				obj.b_gid = reader["b_gid"] == null ? default(string) : (string)reader["b_gid"];
				obj.b_p_gid = reader["b_p_gid"] == null ? default(string) : (string)reader["b_p_gid"];
				obj.b_path = reader["b_path"] == null ? default(string) : (string)reader["b_path"];
				obj.b_name = reader["b_name"] == null ? default(string) : (string)reader["b_name"];
				obj.b_createUser = reader["b_createUser"] == null ? default(string) : (string)reader["b_createUser"];
				obj.b_createTime = reader["b_createTime"] == null ? default(DateTime) : (DateTime)reader["b_createTime"];
				
            }
            catch
            {
                obj = null;
            }
            return obj;
        }



        #endregion


    }
	[Serializable]
	public partial class Site_CMSItemAccess : AccessBase<Site_CMSItem>
    {

		Database db;

        #region 00 IDisposable 实现
        public Site_CMSItemAccess(string configName)
        {
            db = DatabaseFactory.CreateDatabase(configName);
        }

        public Site_CMSItemAccess()
        {
            db = DatabaseFactory.CreateDatabase("MySite");
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
        ~Site_CMSItemAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_Site_CMSItem_Insert
		 public override int Insert(Site_CMSItem obj)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Site_CMSItem_Insert");
			db.AddOutParameter(dbCmd, "@i_id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@i_gid", DbType.String,obj.i_gid);
			db.AddInParameter(dbCmd, "@i_b_gid", DbType.String,obj.i_b_gid);
			db.AddInParameter(dbCmd, "@i_title", DbType.String,obj.i_title);
			db.AddInParameter(dbCmd, "@i_c_gid", DbType.String,obj.i_c_gid);
			db.AddInParameter(dbCmd, "@i_c_type", DbType.String,obj.i_c_type);
			db.AddInParameter(dbCmd, "@i_subTitle", DbType.String,obj.i_subTitle);
			db.AddInParameter(dbCmd, "@i_content", DbType.String,obj.i_content);
			db.AddInParameter(dbCmd, "@i_status", DbType.Int32,obj.i_status);
			db.AddInParameter(dbCmd, "@i_createUser", DbType.String,obj.i_createUser);
			db.AddInParameter(dbCmd, "@i_createTime", DbType.DateTime,obj.i_createTime);
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
		
		#region 02 Proc_Site_CMSItem_Delete
		 public override int Delete(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Site_CMSItem_DeleteByi_id");
			db.AddInParameter(dbCmd, "@i_id", DbType.Int32,id);
			
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

		#region 03 Proc_Site_CMSItem_Update
		 public override int Update(Site_CMSItem obj)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Site_CMSItem_DeleteByi_id");
			db.AddInParameter(dbCmd, "@i_id", DbType.Int32,obj.i_id);
			db.AddInParameter(dbCmd, "@i_gid", DbType.String,obj.i_gid);
			db.AddInParameter(dbCmd, "@i_b_gid", DbType.String,obj.i_b_gid);
			db.AddInParameter(dbCmd, "@i_title", DbType.String,obj.i_title);
			db.AddInParameter(dbCmd, "@i_c_gid", DbType.String,obj.i_c_gid);
			db.AddInParameter(dbCmd, "@i_c_type", DbType.String,obj.i_c_type);
			db.AddInParameter(dbCmd, "@i_subTitle", DbType.String,obj.i_subTitle);
			db.AddInParameter(dbCmd, "@i_content", DbType.String,obj.i_content);
			db.AddInParameter(dbCmd, "@i_status", DbType.Int32,obj.i_status);
			db.AddInParameter(dbCmd, "@i_createUser", DbType.String,obj.i_createUser);
			db.AddInParameter(dbCmd, "@i_createTime", DbType.DateTime,obj.i_createTime);
			
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

		#region 04 Proc_Site_CMSItem_SelectObject
		 public override Site_CMSItem SelectObject(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Site_CMSItem_SelectByi_id");
			db.AddInParameter(dbCmd, "@i_id", DbType.Int32,id);
			
			Site_CMSItem obj=null;
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

		#region 05 Proc_Site_CMSItem_Select
		 public override IList<Site_CMSItem> Select(string whereStr)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Site_CMSItem_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
			
			IList<Site_CMSItem> list= new List<Site_CMSItem>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						Site_CMSItem obj= Object2Model(reader);
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

		#region 06 Proc_Site_CMSItem_SelectPage
		 public override IList<Site_CMSItem> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Site_CMSItem_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);

			List<Site_CMSItem> list= new List<Site_CMSItem>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						Site_CMSItem obj= Object2Model(reader);
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

        public Site_CMSItem Object2Model(IDataReader reader)
        {
            Site_CMSItem obj = null;
            try
            {
                obj = new Site_CMSItem();
				obj.i_id = reader["i_id"] == null ? default(int) : (int)reader["i_id"];
				obj.i_gid = reader["i_gid"] == null ? default(string) : (string)reader["i_gid"];
				obj.i_b_gid = reader["i_b_gid"] == null ? default(string) : (string)reader["i_b_gid"];
				obj.i_title = reader["i_title"] == null ? default(string) : (string)reader["i_title"];
				obj.i_c_gid = reader["i_c_gid"] == null ? default(string) : (string)reader["i_c_gid"];
				obj.i_c_type = reader["i_c_type"] == null ? default(string) : (string)reader["i_c_type"];
				obj.i_subTitle = reader["i_subTitle"] == null ? default(string) : (string)reader["i_subTitle"];
				obj.i_content = reader["i_content"] == null ? default(string) : (string)reader["i_content"];
				obj.i_status = reader["i_status"] == null ? default(int) : (int)reader["i_status"];
				obj.i_createUser = reader["i_createUser"] == null ? default(string) : (string)reader["i_createUser"];
				obj.i_createTime = reader["i_createTime"] == null ? default(DateTime) : (DateTime)reader["i_createTime"];
				
            }
            catch
            {
                obj = null;
            }
            return obj;
        }



        #endregion


    }
	[Serializable]
	public partial class Site_CMSPageAccess : AccessBase<Site_CMSPage>
    {

		Database db;

        #region 00 IDisposable 实现
        public Site_CMSPageAccess(string configName)
        {
            db = DatabaseFactory.CreateDatabase(configName);
        }

        public Site_CMSPageAccess()
        {
            db = DatabaseFactory.CreateDatabase("MySite");
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
        ~Site_CMSPageAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_Site_CMSPage_Insert
		 public override int Insert(Site_CMSPage obj)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Site_CMSPage_Insert");
			db.AddOutParameter(dbCmd, "@p_id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@p_gid", DbType.String,obj.p_gid);
			db.AddInParameter(dbCmd, "@p_name", DbType.String,obj.p_name);
			db.AddInParameter(dbCmd, "@p_path", DbType.String,obj.p_path);
			db.AddInParameter(dbCmd, "@p_tempPath", DbType.String,obj.p_tempPath);
			db.AddInParameter(dbCmd, "@p_filePath", DbType.String,obj.p_filePath);
			db.AddInParameter(dbCmd, "@p_createTime", DbType.DateTime,obj.p_createTime);
			db.AddInParameter(dbCmd, "@p_createUser", DbType.String,obj.p_createUser);
			db.AddInParameter(dbCmd, "@p_pageDuty", DbType.String,obj.p_pageDuty);
			db.AddInParameter(dbCmd, "@p_siteName", DbType.Int32,obj.p_siteName);
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
		
		#region 02 Proc_Site_CMSPage_Delete
		 public override int Delete(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Site_CMSPage_DeleteByp_id");
			db.AddInParameter(dbCmd, "@p_id", DbType.Int32,id);
			
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

		#region 03 Proc_Site_CMSPage_Update
		 public override int Update(Site_CMSPage obj)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Site_CMSPage_DeleteByp_id");
			db.AddInParameter(dbCmd, "@p_id", DbType.Int32,obj.p_id);
			db.AddInParameter(dbCmd, "@p_gid", DbType.String,obj.p_gid);
			db.AddInParameter(dbCmd, "@p_name", DbType.String,obj.p_name);
			db.AddInParameter(dbCmd, "@p_path", DbType.String,obj.p_path);
			db.AddInParameter(dbCmd, "@p_tempPath", DbType.String,obj.p_tempPath);
			db.AddInParameter(dbCmd, "@p_filePath", DbType.String,obj.p_filePath);
			db.AddInParameter(dbCmd, "@p_createTime", DbType.DateTime,obj.p_createTime);
			db.AddInParameter(dbCmd, "@p_createUser", DbType.String,obj.p_createUser);
			db.AddInParameter(dbCmd, "@p_pageDuty", DbType.String,obj.p_pageDuty);
			db.AddInParameter(dbCmd, "@p_siteName", DbType.Int32,obj.p_siteName);
			
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

		#region 04 Proc_Site_CMSPage_SelectObject
		 public override Site_CMSPage SelectObject(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Site_CMSPage_SelectByp_id");
			db.AddInParameter(dbCmd, "@p_id", DbType.Int32,id);
			
			Site_CMSPage obj=null;
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

		#region 05 Proc_Site_CMSPage_Select
		 public override IList<Site_CMSPage> Select(string whereStr)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Site_CMSPage_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
			
			IList<Site_CMSPage> list= new List<Site_CMSPage>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						Site_CMSPage obj= Object2Model(reader);
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

		#region 06 Proc_Site_CMSPage_SelectPage
		 public override IList<Site_CMSPage> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Site_CMSPage_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);

			List<Site_CMSPage> list= new List<Site_CMSPage>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						Site_CMSPage obj= Object2Model(reader);
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

        public Site_CMSPage Object2Model(IDataReader reader)
        {
            Site_CMSPage obj = null;
            try
            {
                obj = new Site_CMSPage();
				obj.p_id = reader["p_id"] == null ? default(int) : (int)reader["p_id"];
				obj.p_gid = reader["p_gid"] == null ? default(string) : (string)reader["p_gid"];
				obj.p_name = reader["p_name"] == null ? default(string) : (string)reader["p_name"];
				obj.p_path = reader["p_path"] == null ? default(string) : (string)reader["p_path"];
				obj.p_tempPath = reader["p_tempPath"] == null ? default(string) : (string)reader["p_tempPath"];
				obj.p_filePath = reader["p_filePath"] == null ? default(string) : (string)reader["p_filePath"];
				obj.p_createTime = reader["p_createTime"] == null ? default(DateTime) : (DateTime)reader["p_createTime"];
				obj.p_createUser = reader["p_createUser"] == null ? default(string) : (string)reader["p_createUser"];
				obj.p_pageDuty = reader["p_pageDuty"] == null ? default(string) : (string)reader["p_pageDuty"];
				obj.p_siteName = reader["p_siteName"] == null ? default(int) : (int)reader["p_siteName"];
				
            }
            catch
            {
                obj = null;
            }
            return obj;
        }



        #endregion


    }
	[Serializable]
	public partial class SystemGroupAccess : AccessBase<SystemGroup>
    {

		Database db;

        #region 00 IDisposable 实现
        public SystemGroupAccess(string configName)
        {
            db = DatabaseFactory.CreateDatabase(configName);
        }

        public SystemGroupAccess()
        {
            db = DatabaseFactory.CreateDatabase("MySite");
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
        ~SystemGroupAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_SystemGroup_Insert
		 public override int Insert(SystemGroup obj)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_SystemGroup_Insert");
			db.AddOutParameter(dbCmd, "@g_id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@g_gid", DbType.String,obj.g_gid);
			db.AddInParameter(dbCmd, "@g_name", DbType.String,obj.g_name);
			db.AddInParameter(dbCmd, "@g_picCover", DbType.String,obj.g_picCover);
			db.AddInParameter(dbCmd, "@g_createTime", DbType.DateTime,obj.g_createTime);
			db.AddInParameter(dbCmd, "@g_createUser", DbType.String,obj.g_createUser);
			db.AddInParameter(dbCmd, "@g_sort", DbType.Int32,obj.g_sort);
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
		
		#region 02 Proc_SystemGroup_Delete
		 public override int Delete(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_SystemGroup_DeleteByg_id");
			db.AddInParameter(dbCmd, "@g_id", DbType.Int32,id);
			
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

		#region 03 Proc_SystemGroup_Update
		 public override int Update(SystemGroup obj)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_SystemGroup_DeleteByg_id");
			db.AddInParameter(dbCmd, "@g_id", DbType.Int32,obj.g_id);
			db.AddInParameter(dbCmd, "@g_gid", DbType.String,obj.g_gid);
			db.AddInParameter(dbCmd, "@g_name", DbType.String,obj.g_name);
			db.AddInParameter(dbCmd, "@g_picCover", DbType.String,obj.g_picCover);
			db.AddInParameter(dbCmd, "@g_createTime", DbType.DateTime,obj.g_createTime);
			db.AddInParameter(dbCmd, "@g_createUser", DbType.String,obj.g_createUser);
			db.AddInParameter(dbCmd, "@g_sort", DbType.Int32,obj.g_sort);
			
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

		#region 04 Proc_SystemGroup_SelectObject
		 public override SystemGroup SelectObject(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_SystemGroup_SelectByg_id");
			db.AddInParameter(dbCmd, "@g_id", DbType.Int32,id);
			
			SystemGroup obj=null;
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

		#region 05 Proc_SystemGroup_Select
		 public override IList<SystemGroup> Select(string whereStr)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_SystemGroup_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
			
			IList<SystemGroup> list= new List<SystemGroup>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						SystemGroup obj= Object2Model(reader);
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

		#region 06 Proc_SystemGroup_SelectPage
		 public override IList<SystemGroup> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_SystemGroup_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);

			List<SystemGroup> list= new List<SystemGroup>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						SystemGroup obj= Object2Model(reader);
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

        public SystemGroup Object2Model(IDataReader reader)
        {
            SystemGroup obj = null;
            try
            {
                obj = new SystemGroup();
				obj.g_id = reader["g_id"] == null ? default(int) : (int)reader["g_id"];
				obj.g_gid = reader["g_gid"] == null ? default(string) : (string)reader["g_gid"];
				obj.g_name = reader["g_name"] == null ? default(string) : (string)reader["g_name"];
				obj.g_picCover = reader["g_picCover"] == null ? default(string) : (string)reader["g_picCover"];
				obj.g_createTime = reader["g_createTime"] == null ? default(DateTime) : (DateTime)reader["g_createTime"];
				obj.g_createUser = reader["g_createUser"] == null ? default(string) : (string)reader["g_createUser"];
				obj.g_sort = reader["g_sort"] == null ? default(int) : (int)reader["g_sort"];
				
            }
            catch
            {
                obj = null;
            }
            return obj;
        }



        #endregion


    }
	[Serializable]
	public partial class SystemModualAccess : AccessBase<SystemModual>
    {

		Database db;

        #region 00 IDisposable 实现
        public SystemModualAccess(string configName)
        {
            db = DatabaseFactory.CreateDatabase(configName);
        }

        public SystemModualAccess()
        {
            db = DatabaseFactory.CreateDatabase("MySite");
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
        ~SystemModualAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_SystemModual_Insert
		 public override int Insert(SystemModual obj)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_SystemModual_Insert");
			db.AddOutParameter(dbCmd, "@m_id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@m_gid", DbType.String,obj.m_gid);
			db.AddInParameter(dbCmd, "@m_g_gid", DbType.String,obj.m_g_gid);
			db.AddInParameter(dbCmd, "@m_path", DbType.String,obj.m_path);
			db.AddInParameter(dbCmd, "@m_name", DbType.String,obj.m_name);
			db.AddInParameter(dbCmd, "@m_parent", DbType.Int32,obj.m_parent);
			db.AddInParameter(dbCmd, "@m_parent_gid", DbType.String,obj.m_parent_gid);
			db.AddInParameter(dbCmd, "@m_Controller", DbType.String,obj.m_Controller);
			db.AddInParameter(dbCmd, "@m_Action", DbType.String,obj.m_Action);
			db.AddInParameter(dbCmd, "@m_createTime", DbType.DateTime,obj.m_createTime);
			db.AddInParameter(dbCmd, "@m_createUser", DbType.String,obj.m_createUser);
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
		
		#region 02 Proc_SystemModual_Delete
		 public override int Delete(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_SystemModual_DeleteBym_id");
			db.AddInParameter(dbCmd, "@m_id", DbType.Int32,id);
			
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

		#region 03 Proc_SystemModual_Update
		 public override int Update(SystemModual obj)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_SystemModual_DeleteBym_id");
			db.AddInParameter(dbCmd, "@m_id", DbType.Int32,obj.m_id);
			db.AddInParameter(dbCmd, "@m_gid", DbType.String,obj.m_gid);
			db.AddInParameter(dbCmd, "@m_g_gid", DbType.String,obj.m_g_gid);
			db.AddInParameter(dbCmd, "@m_path", DbType.String,obj.m_path);
			db.AddInParameter(dbCmd, "@m_name", DbType.String,obj.m_name);
			db.AddInParameter(dbCmd, "@m_parent", DbType.Int32,obj.m_parent);
			db.AddInParameter(dbCmd, "@m_parent_gid", DbType.String,obj.m_parent_gid);
			db.AddInParameter(dbCmd, "@m_Controller", DbType.String,obj.m_Controller);
			db.AddInParameter(dbCmd, "@m_Action", DbType.String,obj.m_Action);
			db.AddInParameter(dbCmd, "@m_createTime", DbType.DateTime,obj.m_createTime);
			db.AddInParameter(dbCmd, "@m_createUser", DbType.String,obj.m_createUser);
			
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

		#region 04 Proc_SystemModual_SelectObject
		 public override SystemModual SelectObject(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_SystemModual_SelectBym_id");
			db.AddInParameter(dbCmd, "@m_id", DbType.Int32,id);
			
			SystemModual obj=null;
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

		#region 05 Proc_SystemModual_Select
		 public override IList<SystemModual> Select(string whereStr)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_SystemModual_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
			
			IList<SystemModual> list= new List<SystemModual>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						SystemModual obj= Object2Model(reader);
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

		#region 06 Proc_SystemModual_SelectPage
		 public override IList<SystemModual> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_SystemModual_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);

			List<SystemModual> list= new List<SystemModual>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						SystemModual obj= Object2Model(reader);
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

        public SystemModual Object2Model(IDataReader reader)
        {
            SystemModual obj = null;
            try
            {
                obj = new SystemModual();
				obj.m_id = reader["m_id"] == null ? default(int) : (int)reader["m_id"];
				obj.m_gid = reader["m_gid"] == null ? default(string) : (string)reader["m_gid"];
				obj.m_g_gid = reader["m_g_gid"] == null ? default(string) : (string)reader["m_g_gid"];
				obj.m_path = reader["m_path"] == null ? default(string) : (string)reader["m_path"];
				obj.m_name = reader["m_name"] == null ? default(string) : (string)reader["m_name"];
				obj.m_parent = reader["m_parent"] == null ? default(int) : (int)reader["m_parent"];
				obj.m_parent_gid = reader["m_parent_gid"] == null ? default(string) : (string)reader["m_parent_gid"];
				obj.m_Controller = reader["m_Controller"] == null ? default(string) : (string)reader["m_Controller"];
				obj.m_Action = reader["m_Action"] == null ? default(string) : (string)reader["m_Action"];
				obj.m_createTime = reader["m_createTime"] == null ? default(DateTime) : (DateTime)reader["m_createTime"];
				obj.m_createUser = reader["m_createUser"] == null ? default(string) : (string)reader["m_createUser"];
				
            }
            catch
            {
                obj = null;
            }
            return obj;
        }



        #endregion


    }
	[Serializable]
	public partial class UserAccess : AccessBase<User>
    {

		Database db;

        #region 00 IDisposable 实现
        public UserAccess(string configName)
        {
            db = DatabaseFactory.CreateDatabase(configName);
        }

        public UserAccess()
        {
            db = DatabaseFactory.CreateDatabase("MySite");
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
        ~UserAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_User_Insert
		 public override int Insert(User obj)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_User_Insert");
			db.AddOutParameter(dbCmd, "@u_id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@u_gid", DbType.String,obj.u_gid);
			db.AddInParameter(dbCmd, "@u_username", DbType.String,obj.u_username);
			db.AddInParameter(dbCmd, "@u_password", DbType.String,obj.u_password);
			db.AddInParameter(dbCmd, "@u_createTime", DbType.DateTime,obj.u_createTime);
			db.AddInParameter(dbCmd, "@u_createUser", DbType.String,obj.u_createUser);
			db.AddInParameter(dbCmd, "@u_status", DbType.Int32,obj.u_status);
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
		
		#region 02 Proc_User_Delete
		 public override int Delete(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_User_DeleteByu_id");
			db.AddInParameter(dbCmd, "@u_id", DbType.Int32,id);
			
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

		#region 03 Proc_User_Update
		 public override int Update(User obj)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_User_DeleteByu_id");
			db.AddInParameter(dbCmd, "@u_id", DbType.Int32,obj.u_id);
			db.AddInParameter(dbCmd, "@u_gid", DbType.String,obj.u_gid);
			db.AddInParameter(dbCmd, "@u_username", DbType.String,obj.u_username);
			db.AddInParameter(dbCmd, "@u_password", DbType.String,obj.u_password);
			db.AddInParameter(dbCmd, "@u_createTime", DbType.DateTime,obj.u_createTime);
			db.AddInParameter(dbCmd, "@u_createUser", DbType.String,obj.u_createUser);
			db.AddInParameter(dbCmd, "@u_status", DbType.Int32,obj.u_status);
			
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

		#region 04 Proc_User_SelectObject
		 public override User SelectObject(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_User_SelectByu_id");
			db.AddInParameter(dbCmd, "@u_id", DbType.Int32,id);
			
			User obj=null;
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

		#region 05 Proc_User_Select
		 public override IList<User> Select(string whereStr)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_User_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
			
			IList<User> list= new List<User>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						User obj= Object2Model(reader);
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

		#region 06 Proc_User_SelectPage
		 public override IList<User> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_User_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);

			List<User> list= new List<User>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						User obj= Object2Model(reader);
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

        public User Object2Model(IDataReader reader)
        {
            User obj = null;
            try
            {
                obj = new User();
				obj.u_id = reader["u_id"] == null ? default(int) : (int)reader["u_id"];
				obj.u_gid = reader["u_gid"] == null ? default(string) : (string)reader["u_gid"];
				obj.u_username = reader["u_username"] == null ? default(string) : (string)reader["u_username"];
				obj.u_password = reader["u_password"] == null ? default(string) : (string)reader["u_password"];
				obj.u_createTime = reader["u_createTime"] == null ? default(DateTime) : (DateTime)reader["u_createTime"];
				obj.u_createUser = reader["u_createUser"] == null ? default(string) : (string)reader["u_createUser"];
				obj.u_status = reader["u_status"] == null ? default(int) : (int)reader["u_status"];
				
            }
            catch
            {
                obj = null;
            }
            return obj;
        }



        #endregion


    }
	[Serializable]
	public partial class User_Role_MappingAccess : AccessBase<User_Role_Mapping>
    {

		Database db;

        #region 00 IDisposable 实现
        public User_Role_MappingAccess(string configName)
        {
            db = DatabaseFactory.CreateDatabase(configName);
        }

        public User_Role_MappingAccess()
        {
            db = DatabaseFactory.CreateDatabase("MySite");
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
        ~User_Role_MappingAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_User_Role_Mapping_Insert
		 public override int Insert(User_Role_Mapping obj)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_User_Role_Mapping_Insert");
			db.AddOutParameter(dbCmd, "@u_r_id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@u_r_gid", DbType.String,obj.u_r_gid);
			db.AddInParameter(dbCmd, "@u_gid", DbType.String,obj.u_gid);
			db.AddInParameter(dbCmd, "@r_gid", DbType.String,obj.r_gid);
			db.AddInParameter(dbCmd, "@u_r_CreateTime", DbType.DateTime,obj.u_r_CreateTime);
			db.AddInParameter(dbCmd, "@u_r_CreateUser", DbType.String,obj.u_r_CreateUser);
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
		
		#region 02 Proc_User_Role_Mapping_Delete
		 public override int Delete(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_User_Role_Mapping_DeleteByu_r_id");
			db.AddInParameter(dbCmd, "@u_r_id", DbType.Int32,id);
			
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

		#region 03 Proc_User_Role_Mapping_Update
		 public override int Update(User_Role_Mapping obj)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_User_Role_Mapping_DeleteByu_r_id");
			db.AddInParameter(dbCmd, "@u_r_id", DbType.Int32,obj.u_r_id);
			db.AddInParameter(dbCmd, "@u_r_gid", DbType.String,obj.u_r_gid);
			db.AddInParameter(dbCmd, "@u_gid", DbType.String,obj.u_gid);
			db.AddInParameter(dbCmd, "@r_gid", DbType.String,obj.r_gid);
			db.AddInParameter(dbCmd, "@u_r_CreateTime", DbType.DateTime,obj.u_r_CreateTime);
			db.AddInParameter(dbCmd, "@u_r_CreateUser", DbType.String,obj.u_r_CreateUser);
			
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

		#region 04 Proc_User_Role_Mapping_SelectObject
		 public override User_Role_Mapping SelectObject(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_User_Role_Mapping_SelectByu_r_id");
			db.AddInParameter(dbCmd, "@u_r_id", DbType.Int32,id);
			
			User_Role_Mapping obj=null;
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

		#region 05 Proc_User_Role_Mapping_Select
		 public override IList<User_Role_Mapping> Select(string whereStr)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_User_Role_Mapping_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
			
			IList<User_Role_Mapping> list= new List<User_Role_Mapping>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						User_Role_Mapping obj= Object2Model(reader);
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

		#region 06 Proc_User_Role_Mapping_SelectPage
		 public override IList<User_Role_Mapping> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_User_Role_Mapping_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);

			List<User_Role_Mapping> list= new List<User_Role_Mapping>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						User_Role_Mapping obj= Object2Model(reader);
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

        public User_Role_Mapping Object2Model(IDataReader reader)
        {
            User_Role_Mapping obj = null;
            try
            {
                obj = new User_Role_Mapping();
				obj.u_r_id = reader["u_r_id"] == null ? default(int) : (int)reader["u_r_id"];
				obj.u_r_gid = reader["u_r_gid"] == null ? default(string) : (string)reader["u_r_gid"];
				obj.u_gid = reader["u_gid"] == null ? default(string) : (string)reader["u_gid"];
				obj.r_gid = reader["r_gid"] == null ? default(string) : (string)reader["r_gid"];
				obj.u_r_CreateTime = reader["u_r_CreateTime"] == null ? default(DateTime) : (DateTime)reader["u_r_CreateTime"];
				obj.u_r_CreateUser = reader["u_r_CreateUser"] == null ? default(string) : (string)reader["u_r_CreateUser"];
				
            }
            catch
            {
                obj = null;
            }
            return obj;
        }



        #endregion


    }
}
