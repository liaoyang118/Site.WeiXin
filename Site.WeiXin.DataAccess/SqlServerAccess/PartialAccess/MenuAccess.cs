using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Site.WeiXin.DataAccess.Model;

namespace Site.WeiXin.DataAccess.Access
{
    public partial class MenuAccess
    {
        /// <summary>
        /// 递归查询菜单
        /// </summary>
        /// <returns></returns>
        public IList<Menu> SelectMenuList()
        {
            DbCommand dbCmd = db.GetStoredProcCommand("Proc_Menu_SelectMenuList");

            IList<Menu> list = new List<Menu>();
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        //属性赋值
                        Menu obj = Object2Model(reader);
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

        /// <summary>
        /// 删除父菜单和其子菜单
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public int DeleteByParentId(int id,int parentId)
        {

            DbCommand dbCmd = db.GetStoredProcCommand("Proc_Menu_DeleteByParentId");
            db.AddInParameter(dbCmd, "@Id", DbType.Int32, id);
            db.AddInParameter(dbCmd, "@ParentId", DbType.Int32, parentId);

            try
            {
                int returnValue = db.ExecuteNonQuery(dbCmd);
                return returnValue;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
