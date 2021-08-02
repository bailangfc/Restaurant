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
