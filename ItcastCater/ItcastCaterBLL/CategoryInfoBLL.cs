using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItcastCater.Model;
using ItcastCater.DAL;

namespace ItcastCater.BLL
{
    public class CategoryInfoBLL
    {
        CategoryInfoDAL dal = new CategoryInfoDAL();
        /// <summary>
        /// 查询所有没删除的商品
        /// </summary>
        /// <param name="delflag"></param>
        /// <returns></returns>
        public List<CategoryInfo> GetAllCategoryInfoByDelFlag(int delflag)
        {
            return dal.GetAllCategoryInfoByDelFlag(delflag);
        }
    }
}
