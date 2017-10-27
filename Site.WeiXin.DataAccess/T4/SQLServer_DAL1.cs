

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using DataAccess.Base;
using Site.WeiXin.DataAccess.Model;

namespace Site.WeiXin.DataAccess.Access
{

	[Serializable]
	public partial class ArticleAccess : AccessBase<Article>,IDisposable
    {

		Database db;

		DatabaseProviderFactory factory = new DatabaseProviderFactory();//6.0 创建方式

        #region 00 IDisposable 实现
        public ArticleAccess(string configName)
        {
			db = factory.Create(configName);
        }

        public ArticleAccess()
        {
            db = factory.Create("wxmanager");
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
        ~ArticleAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_Article_Insert
		 public override int Insert(Article obj)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Article_Insert");
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@AuthorName", DbType.String,obj.AuthorName);
			db.AddInParameter(dbCmd, "@Title", DbType.String,obj.Title);
			db.AddInParameter(dbCmd, "@ContentSourceUrl", DbType.String,obj.ContentSourceUrl);
			db.AddInParameter(dbCmd, "@MediaId", DbType.String,obj.MediaId);
			db.AddInParameter(dbCmd, "@ArticleContent", DbType.String,obj.ArticleContent);
			db.AddInParameter(dbCmd, "@Intro", DbType.String,obj.Intro);
			db.AddInParameter(dbCmd, "@ShowCover", DbType.Int32,obj.ShowCover);
			db.AddInParameter(dbCmd, "@CreateTime", DbType.DateTime,obj.CreateTime);
			db.AddInParameter(dbCmd, "@CreateUserAccount", DbType.String,obj.CreateUserAccount);
			db.AddInParameter(dbCmd, "@Statu", DbType.Int32,obj.Statu);
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
		
		#region 02 Proc_Article_Delete
		 public override int Delete(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Article_DeleteById");
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

		#region 03 Proc_Article_Update
		 public override int Update(Article obj)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Article_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@AuthorName", DbType.String,obj.AuthorName);
			db.AddInParameter(dbCmd, "@Title", DbType.String,obj.Title);
			db.AddInParameter(dbCmd, "@ContentSourceUrl", DbType.String,obj.ContentSourceUrl);
			db.AddInParameter(dbCmd, "@MediaId", DbType.String,obj.MediaId);
			db.AddInParameter(dbCmd, "@ArticleContent", DbType.String,obj.ArticleContent);
			db.AddInParameter(dbCmd, "@Intro", DbType.String,obj.Intro);
			db.AddInParameter(dbCmd, "@ShowCover", DbType.Int32,obj.ShowCover);
			db.AddInParameter(dbCmd, "@CreateTime", DbType.DateTime,obj.CreateTime);
			db.AddInParameter(dbCmd, "@CreateUserAccount", DbType.String,obj.CreateUserAccount);
			db.AddInParameter(dbCmd, "@Statu", DbType.Int32,obj.Statu);
			
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

		#region 04 Proc_Article_SelectObject
		 public override Article SelectObject(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Article_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			Article obj=null;
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

		#region 05 Proc_Article_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 空格 and开始</param>
         /// <returns></returns>
		 public override IList<Article> Select(string whereStr)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Article_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
			
			IList<Article> list= new List<Article>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						Article obj= Object2Model(reader);
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

		#region 06 Proc_Article_SelectPage
		 public override IList<Article> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Article_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);

			List<Article> list= new List<Article>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						Article obj= Object2Model(reader);
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

        public Article Object2Model(IDataReader reader)
        {
            Article obj = null;
            try
            {
                obj = new Article();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.AuthorName = reader["AuthorName"] == DBNull.Value ? default(string) : (string)reader["AuthorName"];
				obj.Title = reader["Title"] == DBNull.Value ? default(string) : (string)reader["Title"];
				obj.ContentSourceUrl = reader["ContentSourceUrl"] == DBNull.Value ? default(string) : (string)reader["ContentSourceUrl"];
				obj.MediaId = reader["MediaId"] == DBNull.Value ? default(string) : (string)reader["MediaId"];
				obj.ArticleContent = reader["ArticleContent"] == DBNull.Value ? default(string) : (string)reader["ArticleContent"];
				obj.Intro = reader["Intro"] == DBNull.Value ? default(string) : (string)reader["Intro"];
				obj.ShowCover = reader["ShowCover"] == DBNull.Value ? default(int) : (int)reader["ShowCover"];
				obj.CreateTime = reader["CreateTime"] == DBNull.Value ? default(DateTime) : (DateTime)reader["CreateTime"];
				obj.CreateUserAccount = reader["CreateUserAccount"] == DBNull.Value ? default(string) : (string)reader["CreateUserAccount"];
				obj.Statu = reader["Statu"] == DBNull.Value ? default(int) : (int)reader["Statu"];
				
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
	public partial class GloblaTokenAccess : AccessBase<GloblaToken>,IDisposable
    {

		Database db;

		DatabaseProviderFactory factory = new DatabaseProviderFactory();//6.0 创建方式

        #region 00 IDisposable 实现
        public GloblaTokenAccess(string configName)
        {
			db = factory.Create(configName);
        }

        public GloblaTokenAccess()
        {
            db = factory.Create("wxmanager");
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
        ~GloblaTokenAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_GloblaToken_Insert
		 public override int Insert(GloblaToken obj)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_GloblaToken_Insert");
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@Token", DbType.String,obj.Token);
			db.AddInParameter(dbCmd, "@AppId", DbType.String,obj.AppId);
			db.AddInParameter(dbCmd, "@ExpireTime", DbType.DateTime,obj.ExpireTime);
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
		
		#region 02 Proc_GloblaToken_Delete
		 public override int Delete(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_GloblaToken_DeleteById");
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

		#region 03 Proc_GloblaToken_Update
		 public override int Update(GloblaToken obj)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_GloblaToken_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@Token", DbType.String,obj.Token);
			db.AddInParameter(dbCmd, "@AppId", DbType.String,obj.AppId);
			db.AddInParameter(dbCmd, "@ExpireTime", DbType.DateTime,obj.ExpireTime);
			
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

		#region 04 Proc_GloblaToken_SelectObject
		 public override GloblaToken SelectObject(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_GloblaToken_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			GloblaToken obj=null;
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

		#region 05 Proc_GloblaToken_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 空格 and开始</param>
         /// <returns></returns>
		 public override IList<GloblaToken> Select(string whereStr)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_GloblaToken_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
			
			IList<GloblaToken> list= new List<GloblaToken>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						GloblaToken obj= Object2Model(reader);
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

		#region 06 Proc_GloblaToken_SelectPage
		 public override IList<GloblaToken> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_GloblaToken_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);

			List<GloblaToken> list= new List<GloblaToken>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						GloblaToken obj= Object2Model(reader);
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

        public GloblaToken Object2Model(IDataReader reader)
        {
            GloblaToken obj = null;
            try
            {
                obj = new GloblaToken();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.Token = reader["Token"] == DBNull.Value ? default(string) : (string)reader["Token"];
				obj.AppId = reader["AppId"] == DBNull.Value ? default(string) : (string)reader["AppId"];
				obj.ExpireTime = reader["ExpireTime"] == DBNull.Value ? default(DateTime) : (DateTime)reader["ExpireTime"];
				
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
	public partial class MaterialAccess : AccessBase<Material>,IDisposable
    {

		Database db;

		DatabaseProviderFactory factory = new DatabaseProviderFactory();//6.0 创建方式

        #region 00 IDisposable 实现
        public MaterialAccess(string configName)
        {
			db = factory.Create(configName);
        }

        public MaterialAccess()
        {
            db = factory.Create("wxmanager");
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
        ~MaterialAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_Material_Insert
		 public override int Insert(Material obj)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Material_Insert");
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@MaterialName", DbType.String,obj.MaterialName);
			db.AddInParameter(dbCmd, "@MaterialType", DbType.String,obj.MaterialType);
			db.AddInParameter(dbCmd, "@Media_id", DbType.String,obj.Media_id);
			db.AddInParameter(dbCmd, "@Url", DbType.String,obj.Url);
			db.AddInParameter(dbCmd, "@CreateTime", DbType.DateTime,obj.CreateTime);
			db.AddInParameter(dbCmd, "@CreateUserAccount", DbType.String,obj.CreateUserAccount);
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
		
		#region 02 Proc_Material_Delete
		 public override int Delete(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Material_DeleteById");
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

		#region 03 Proc_Material_Update
		 public override int Update(Material obj)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Material_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@MaterialName", DbType.String,obj.MaterialName);
			db.AddInParameter(dbCmd, "@MaterialType", DbType.String,obj.MaterialType);
			db.AddInParameter(dbCmd, "@Media_id", DbType.String,obj.Media_id);
			db.AddInParameter(dbCmd, "@Url", DbType.String,obj.Url);
			db.AddInParameter(dbCmd, "@CreateTime", DbType.DateTime,obj.CreateTime);
			db.AddInParameter(dbCmd, "@CreateUserAccount", DbType.String,obj.CreateUserAccount);
			
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

		#region 04 Proc_Material_SelectObject
		 public override Material SelectObject(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Material_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			Material obj=null;
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

		#region 05 Proc_Material_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 空格 and开始</param>
         /// <returns></returns>
		 public override IList<Material> Select(string whereStr)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Material_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
			
			IList<Material> list= new List<Material>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						Material obj= Object2Model(reader);
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

		#region 06 Proc_Material_SelectPage
		 public override IList<Material> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Material_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);

			List<Material> list= new List<Material>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						Material obj= Object2Model(reader);
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

        public Material Object2Model(IDataReader reader)
        {
            Material obj = null;
            try
            {
                obj = new Material();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.MaterialName = reader["MaterialName"] == DBNull.Value ? default(string) : (string)reader["MaterialName"];
				obj.MaterialType = reader["MaterialType"] == DBNull.Value ? default(string) : (string)reader["MaterialType"];
				obj.Media_id = reader["Media_id"] == DBNull.Value ? default(string) : (string)reader["Media_id"];
				obj.Url = reader["Url"] == DBNull.Value ? default(string) : (string)reader["Url"];
				obj.CreateTime = reader["CreateTime"] == DBNull.Value ? default(DateTime) : (DateTime)reader["CreateTime"];
				obj.CreateUserAccount = reader["CreateUserAccount"] == DBNull.Value ? default(string) : (string)reader["CreateUserAccount"];
				
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
	public partial class MenuAccess : AccessBase<Menu>,IDisposable
    {

		Database db;

		DatabaseProviderFactory factory = new DatabaseProviderFactory();//6.0 创建方式

        #region 00 IDisposable 实现
        public MenuAccess(string configName)
        {
			db = factory.Create(configName);
        }

        public MenuAccess()
        {
            db = factory.Create("wxmanager");
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
        ~MenuAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_Menu_Insert
		 public override int Insert(Menu obj)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Menu_Insert");
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@ParentId", DbType.Int32,obj.ParentId);
			db.AddInParameter(dbCmd, "@Name", DbType.String,obj.Name);
			db.AddInParameter(dbCmd, "@Type", DbType.String,obj.Type);
			db.AddInParameter(dbCmd, "@Value", DbType.String,obj.Value);
			db.AddInParameter(dbCmd, "@CreateTime", DbType.DateTime,obj.CreateTime);
			db.AddInParameter(dbCmd, "@LevelCode", DbType.String,obj.LevelCode);
			db.AddInParameter(dbCmd, "@Status", DbType.Int32,obj.Status);
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
		
		#region 02 Proc_Menu_Delete
		 public override int Delete(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Menu_DeleteById");
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

		#region 03 Proc_Menu_Update
		 public override int Update(Menu obj)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Menu_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@ParentId", DbType.Int32,obj.ParentId);
			db.AddInParameter(dbCmd, "@Name", DbType.String,obj.Name);
			db.AddInParameter(dbCmd, "@Type", DbType.String,obj.Type);
			db.AddInParameter(dbCmd, "@Value", DbType.String,obj.Value);
			db.AddInParameter(dbCmd, "@CreateTime", DbType.DateTime,obj.CreateTime);
			db.AddInParameter(dbCmd, "@LevelCode", DbType.String,obj.LevelCode);
			db.AddInParameter(dbCmd, "@Status", DbType.Int32,obj.Status);
			
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

		#region 04 Proc_Menu_SelectObject
		 public override Menu SelectObject(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Menu_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			Menu obj=null;
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

		#region 05 Proc_Menu_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 空格 and开始</param>
         /// <returns></returns>
		 public override IList<Menu> Select(string whereStr)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Menu_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
			
			IList<Menu> list= new List<Menu>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						Menu obj= Object2Model(reader);
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

		#region 06 Proc_Menu_SelectPage
		 public override IList<Menu> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Menu_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);

			List<Menu> list= new List<Menu>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						Menu obj= Object2Model(reader);
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

        public Menu Object2Model(IDataReader reader)
        {
            Menu obj = null;
            try
            {
                obj = new Menu();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.ParentId = reader["ParentId"] == DBNull.Value ? default(int) : (int)reader["ParentId"];
				obj.Name = reader["Name"] == DBNull.Value ? default(string) : (string)reader["Name"];
				obj.Type = reader["Type"] == DBNull.Value ? default(string) : (string)reader["Type"];
				obj.Value = reader["Value"] == DBNull.Value ? default(string) : (string)reader["Value"];
				obj.CreateTime = reader["CreateTime"] == DBNull.Value ? default(DateTime) : (DateTime)reader["CreateTime"];
				obj.LevelCode = reader["LevelCode"] == DBNull.Value ? default(string) : (string)reader["LevelCode"];
				obj.Status = reader["Status"] == DBNull.Value ? default(int) : (int)reader["Status"];
				
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
	public partial class MenuTypeAccess : AccessBase<MenuType>,IDisposable
    {

		Database db;

		DatabaseProviderFactory factory = new DatabaseProviderFactory();//6.0 创建方式

        #region 00 IDisposable 实现
        public MenuTypeAccess(string configName)
        {
			db = factory.Create(configName);
        }

        public MenuTypeAccess()
        {
            db = factory.Create("wxmanager");
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
        ~MenuTypeAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_MenuType_Insert
		 public override int Insert(MenuType obj)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_MenuType_Insert");
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@Type", DbType.String,obj.Type);
			db.AddInParameter(dbCmd, "@Intro", DbType.String,obj.Intro);
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
		
		#region 02 Proc_MenuType_Delete
		 public override int Delete(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_MenuType_DeleteById");
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

		#region 03 Proc_MenuType_Update
		 public override int Update(MenuType obj)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_MenuType_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@Type", DbType.String,obj.Type);
			db.AddInParameter(dbCmd, "@Intro", DbType.String,obj.Intro);
			
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

		#region 04 Proc_MenuType_SelectObject
		 public override MenuType SelectObject(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_MenuType_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			MenuType obj=null;
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

		#region 05 Proc_MenuType_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 空格 and开始</param>
         /// <returns></returns>
		 public override IList<MenuType> Select(string whereStr)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_MenuType_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
			
			IList<MenuType> list= new List<MenuType>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						MenuType obj= Object2Model(reader);
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

		#region 06 Proc_MenuType_SelectPage
		 public override IList<MenuType> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_MenuType_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);

			List<MenuType> list= new List<MenuType>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						MenuType obj= Object2Model(reader);
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

        public MenuType Object2Model(IDataReader reader)
        {
            MenuType obj = null;
            try
            {
                obj = new MenuType();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.Type = reader["Type"] == DBNull.Value ? default(string) : (string)reader["Type"];
				obj.Intro = reader["Intro"] == DBNull.Value ? default(string) : (string)reader["Intro"];
				
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
	public partial class SystemUserAccess : AccessBase<SystemUser>,IDisposable
    {

		Database db;

		DatabaseProviderFactory factory = new DatabaseProviderFactory();//6.0 创建方式

        #region 00 IDisposable 实现
        public SystemUserAccess(string configName)
        {
			db = factory.Create(configName);
        }

        public SystemUserAccess()
        {
            db = factory.Create("wxmanager");
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
        ~SystemUserAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_SystemUser_Insert
		 public override int Insert(SystemUser obj)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_SystemUser_Insert");
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@AppId", DbType.String,obj.AppId);
			db.AddInParameter(dbCmd, "@Account", DbType.String,obj.Account);
			db.AddInParameter(dbCmd, "@Password", DbType.String,obj.Password);
			db.AddInParameter(dbCmd, "@CreateTime", DbType.DateTime,obj.CreateTime);
			db.AddInParameter(dbCmd, "@CreateUserName", DbType.String,obj.CreateUserName);
			db.AddInParameter(dbCmd, "@AccountState", DbType.Int32,obj.AccountState);
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
		
		#region 02 Proc_SystemUser_Delete
		 public override int Delete(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_SystemUser_DeleteById");
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

		#region 03 Proc_SystemUser_Update
		 public override int Update(SystemUser obj)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_SystemUser_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@AppId", DbType.String,obj.AppId);
			db.AddInParameter(dbCmd, "@Account", DbType.String,obj.Account);
			db.AddInParameter(dbCmd, "@Password", DbType.String,obj.Password);
			db.AddInParameter(dbCmd, "@CreateTime", DbType.DateTime,obj.CreateTime);
			db.AddInParameter(dbCmd, "@CreateUserName", DbType.String,obj.CreateUserName);
			db.AddInParameter(dbCmd, "@AccountState", DbType.Int32,obj.AccountState);
			
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

		#region 04 Proc_SystemUser_SelectObject
		 public override SystemUser SelectObject(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_SystemUser_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			SystemUser obj=null;
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

		#region 05 Proc_SystemUser_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 空格 and开始</param>
         /// <returns></returns>
		 public override IList<SystemUser> Select(string whereStr)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_SystemUser_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
			
			IList<SystemUser> list= new List<SystemUser>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						SystemUser obj= Object2Model(reader);
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

		#region 06 Proc_SystemUser_SelectPage
		 public override IList<SystemUser> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_SystemUser_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);

			List<SystemUser> list= new List<SystemUser>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						SystemUser obj= Object2Model(reader);
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

        public SystemUser Object2Model(IDataReader reader)
        {
            SystemUser obj = null;
            try
            {
                obj = new SystemUser();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.AppId = reader["AppId"] == DBNull.Value ? default(string) : (string)reader["AppId"];
				obj.Account = reader["Account"] == DBNull.Value ? default(string) : (string)reader["Account"];
				obj.Password = reader["Password"] == DBNull.Value ? default(string) : (string)reader["Password"];
				obj.CreateTime = reader["CreateTime"] == DBNull.Value ? default(DateTime) : (DateTime)reader["CreateTime"];
				obj.CreateUserName = reader["CreateUserName"] == DBNull.Value ? default(string) : (string)reader["CreateUserName"];
				obj.AccountState = reader["AccountState"] == DBNull.Value ? default(int) : (int)reader["AccountState"];
				
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
	public partial class UserAccess : AccessBase<User>,IDisposable
    {

		Database db;

		DatabaseProviderFactory factory = new DatabaseProviderFactory();//6.0 创建方式

        #region 00 IDisposable 实现
        public UserAccess(string configName)
        {
			db = factory.Create(configName);
        }

        public UserAccess()
        {
            db = factory.Create("wxmanager");
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
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@OpenID", DbType.String,obj.OpenID);
			db.AddInParameter(dbCmd, "@NickName", DbType.String,obj.NickName);
			db.AddInParameter(dbCmd, "@HeadImg", DbType.String,obj.HeadImg);
			db.AddInParameter(dbCmd, "@Sex", DbType.Int32,obj.Sex);
			db.AddInParameter(dbCmd, "@Country", DbType.String,obj.Country);
			db.AddInParameter(dbCmd, "@Province", DbType.String,obj.Province);
			db.AddInParameter(dbCmd, "@City", DbType.String,obj.City);
			db.AddInParameter(dbCmd, "@Language", DbType.String,obj.Language);
			db.AddInParameter(dbCmd, "@Subscribe_Time", DbType.DateTime,obj.Subscribe_Time);
			db.AddInParameter(dbCmd, "@Unionid", DbType.String,obj.Unionid);
			db.AddInParameter(dbCmd, "@IsSubscribe", DbType.Boolean,obj.IsSubscribe);
			db.AddInParameter(dbCmd, "@UnSubscribe_Time", DbType.DateTime,obj.UnSubscribe_Time);
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
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_User_DeleteById");
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

		#region 03 Proc_User_Update
		 public override int Update(User obj)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_User_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@OpenID", DbType.String,obj.OpenID);
			db.AddInParameter(dbCmd, "@NickName", DbType.String,obj.NickName);
			db.AddInParameter(dbCmd, "@HeadImg", DbType.String,obj.HeadImg);
			db.AddInParameter(dbCmd, "@Sex", DbType.Int32,obj.Sex);
			db.AddInParameter(dbCmd, "@Country", DbType.String,obj.Country);
			db.AddInParameter(dbCmd, "@Province", DbType.String,obj.Province);
			db.AddInParameter(dbCmd, "@City", DbType.String,obj.City);
			db.AddInParameter(dbCmd, "@Language", DbType.String,obj.Language);
			db.AddInParameter(dbCmd, "@Subscribe_Time", DbType.DateTime,obj.Subscribe_Time);
			db.AddInParameter(dbCmd, "@Unionid", DbType.String,obj.Unionid);
			db.AddInParameter(dbCmd, "@IsSubscribe", DbType.Boolean,obj.IsSubscribe);
			db.AddInParameter(dbCmd, "@UnSubscribe_Time", DbType.DateTime,obj.UnSubscribe_Time);
			
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
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_User_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
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
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 空格 and开始</param>
         /// <returns></returns>
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
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.OpenID = reader["OpenID"] == DBNull.Value ? default(string) : (string)reader["OpenID"];
				obj.NickName = reader["NickName"] == DBNull.Value ? default(string) : (string)reader["NickName"];
				obj.HeadImg = reader["HeadImg"] == DBNull.Value ? default(string) : (string)reader["HeadImg"];
				obj.Sex = reader["Sex"] == DBNull.Value ? default(int) : (int)reader["Sex"];
				obj.Country = reader["Country"] == DBNull.Value ? default(string) : (string)reader["Country"];
				obj.Province = reader["Province"] == DBNull.Value ? default(string) : (string)reader["Province"];
				obj.City = reader["City"] == DBNull.Value ? default(string) : (string)reader["City"];
				obj.Language = reader["Language"] == DBNull.Value ? default(string) : (string)reader["Language"];
				obj.Subscribe_Time = reader["Subscribe_Time"] == DBNull.Value ? default(DateTime) : (DateTime)reader["Subscribe_Time"];
				obj.Unionid = reader["Unionid"] == DBNull.Value ? default(string) : (string)reader["Unionid"];
				obj.IsSubscribe = reader["IsSubscribe"] == DBNull.Value ? default(bool) : (bool)reader["IsSubscribe"];
				obj.UnSubscribe_Time = reader["UnSubscribe_Time"] == DBNull.Value ? default(DateTime) : (DateTime)reader["UnSubscribe_Time"];
				
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
	public partial class UserMessageAccess : AccessBase<UserMessage>,IDisposable
    {

		Database db;

		DatabaseProviderFactory factory = new DatabaseProviderFactory();//6.0 创建方式

        #region 00 IDisposable 实现
        public UserMessageAccess(string configName)
        {
			db = factory.Create(configName);
        }

        public UserMessageAccess()
        {
            db = factory.Create("wxmanager");
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
        ~UserMessageAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_UserMessage_Insert
		 public override int Insert(UserMessage obj)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_UserMessage_Insert");
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@MessageType", DbType.String,obj.MessageType);
			db.AddInParameter(dbCmd, "@OpenID", DbType.String,obj.OpenID);
			db.AddInParameter(dbCmd, "@XmlContent", DbType.String,obj.XmlContent);
			db.AddInParameter(dbCmd, "@MsgId", DbType.String,obj.MsgId);
			db.AddInParameter(dbCmd, "@CreateTime", DbType.DateTime,obj.CreateTime);
			db.AddInParameter(dbCmd, "@ContentValue", DbType.String,obj.ContentValue);
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
		
		#region 02 Proc_UserMessage_Delete
		 public override int Delete(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_UserMessage_DeleteById");
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

		#region 03 Proc_UserMessage_Update
		 public override int Update(UserMessage obj)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_UserMessage_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@MessageType", DbType.String,obj.MessageType);
			db.AddInParameter(dbCmd, "@OpenID", DbType.String,obj.OpenID);
			db.AddInParameter(dbCmd, "@XmlContent", DbType.String,obj.XmlContent);
			db.AddInParameter(dbCmd, "@MsgId", DbType.String,obj.MsgId);
			db.AddInParameter(dbCmd, "@CreateTime", DbType.DateTime,obj.CreateTime);
			db.AddInParameter(dbCmd, "@ContentValue", DbType.String,obj.ContentValue);
			
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

		#region 04 Proc_UserMessage_SelectObject
		 public override UserMessage SelectObject(int id)
		 {
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_UserMessage_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			UserMessage obj=null;
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

		#region 05 Proc_UserMessage_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 空格 and开始</param>
         /// <returns></returns>
		 public override IList<UserMessage> Select(string whereStr)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_UserMessage_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
			
			IList<UserMessage> list= new List<UserMessage>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						UserMessage obj= Object2Model(reader);
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

		#region 06 Proc_UserMessage_SelectPage
		 public override IList<UserMessage> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_UserMessage_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);

			List<UserMessage> list= new List<UserMessage>();
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						UserMessage obj= Object2Model(reader);
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

        public UserMessage Object2Model(IDataReader reader)
        {
            UserMessage obj = null;
            try
            {
                obj = new UserMessage();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.MessageType = reader["MessageType"] == DBNull.Value ? default(string) : (string)reader["MessageType"];
				obj.OpenID = reader["OpenID"] == DBNull.Value ? default(string) : (string)reader["OpenID"];
				obj.XmlContent = reader["XmlContent"] == DBNull.Value ? default(string) : (string)reader["XmlContent"];
				obj.MsgId = reader["MsgId"] == DBNull.Value ? default(string) : (string)reader["MsgId"];
				obj.CreateTime = reader["CreateTime"] == DBNull.Value ? default(DateTime) : (DateTime)reader["CreateTime"];
				obj.ContentValue = reader["ContentValue"] == DBNull.Value ? default(string) : (string)reader["ContentValue"];
				
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
