using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Base
{
    /// <summary>
    /// 所有id属性 默认为表中的主键
    /// </summary>
    /// <typeparam name="T">操作对象</typeparam>
    public abstract class AccessBase<T> where T : class
    {
        public abstract int Insert(T obj);

        public abstract int Delete(int id);

        public abstract int Update(T obj);

        public abstract T SelectObject(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereStr">格式： where a<1 and b>2 </param>
        /// <returns></returns>
        public abstract IList<T> Select(string whereStr);

        /// <summary>
        /// 分页查询，注意需要数据库有该存储过程 Proc_SelectPageBase
        /// </summary>
        /// <param name="cloumns">格式：*、name,age,num</param>
        /// <param name="order">格式:ID DESC、ID ASC、name,age desc</param>
        /// <param name="whereStr">格式： where a<1 and b>2 </param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public abstract IList<T> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount);


    }
}
