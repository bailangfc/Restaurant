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
        //新增和修改商品类别
        public bool SaveCategory(CategoryInfo cat,int temp)
        {
            int r = -1;
            if (temp==1)
            {
                r = dal.AddCategoryInfo(cat);
            }
            else if (temp == 2)
            {
                r = dal.UpdateCategoryInfo(cat);
            }

            return r > 0 ? true : false;
        }



        /// <summary>
        /// 根据id查对象
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>

        public CategoryInfo GetCategoryInfoByCatId(int id)
        {
            return dal.GetCategoryInfoByCatId(id);
        }

        //删除商品类别
        public bool DeleteCategoryInfoByCatId(int catId)
        {
            return dal.DeleteCategoryInfoByCatId(catId) > 0 ? true : false;
        }

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
