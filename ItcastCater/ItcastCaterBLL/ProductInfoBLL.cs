using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItcastCater.DAL;
using ItcastCater.Model;

namespace ItcastCater.BLL
{
    public class ProductInfoBLL
    {
        ProductInfoDAL dal = new ProductInfoDAL();

        //新增和修改
        public bool SaveProduct(ProductInfo pro,int temp)
        {
            int r = -1;
            if (temp == 1)
            {
                r = dal.AddProductInfo(pro);
            }else if (temp == 2)
            {
                r = dal.UpdateProductInfo(pro);
            }
            return r > 0 ? true : false;
        }

        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteProductInfo(int id)
        {
            return dal.DeleteProductInfoByProId(id)>0 ? true : false;
        }


        /// <summary>
        /// 根据产品的Id来查询产品信息
        /// </summary>
        /// <param name="proId"></param>
        /// <returns></returns>
        public ProductInfo GetProductInfoByProId(int proId)
        {
            return dal.GetProductInfoByProId(proId);
        }




        /// <summary>
        /// 查询所有没被删除的产品
        /// </summary>
        /// <param name="delflag"></param>
        /// <returns></returns>
        public List<ProductInfo> GetAllProductInfoByDelFlag(int delflag)
        {
            return dal.GetAllProductInfoByDelFlag(delflag);
        }
    }
}
