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
    public partial class UserGroupAccess
    {
        #region 01 Proc_ExcuteSqlSelectPage
        /// <summary>
        /// 联表查询，主表别名固定为t1
        /// </summary>
        /// <param name="cloumns">查询列，列名必须和实体中属性一致</param>
        /// <param name="order">主表的排序字段</param>
        /// <param name="whereStr">联表语句</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public IList<UserGroup> SelectPageExcuteSql(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
        {
            DbCommand dbCmd = db.GetStoredProcCommand("Proc_UserGroup_SelectPage");
            db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32, 4);
            db.AddInParameter(dbCmd, "@cloumns", DbType.String, cloumns);
            db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32, pageIndex);
            db.AddInParameter(dbCmd, "@pageSize", DbType.Int32, pageSize);
            db.AddInParameter(dbCmd, "@orderBy", DbType.String, order);
            db.AddInParameter(dbCmd, "@where", DbType.String, whereStr);

            List<UserGroup> list = new List<UserGroup>();
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        //属性赋值
                        UserGroup obj = Object2Model(reader);
                        //获取联表属性
                        obj.TagName = reader["TagName"] == DBNull.Value ? default(string) : (string)reader["TagName"];

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
    }
}
