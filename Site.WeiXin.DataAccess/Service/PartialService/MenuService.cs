using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Site.WeiXin.DataAccess.Access;
using Site.WeiXin.DataAccess.Model;

namespace Site.WeiXin.DataAccess.Service
{
    public partial class MenuService
    {
        /// <summary>
        /// 递归查询菜单
        /// </summary>
        /// <returns></returns>
        public static IList<Menu> SelectMenuList(string appId)
        {
            using (var access = new MenuAccess())
            {
                return access.SelectMenuList(appId);
            }
        }

        /// <summary>
        /// 删除父菜单和其子菜单
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public static int DeleteByParentId(int id, int parentId)
        {
            using (var access = new MenuAccess())
            {
                return access.DeleteByParentId(id, parentId);
            }
        }
    }
}
