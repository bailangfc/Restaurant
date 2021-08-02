using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using ItcastCater.Model;

namespace ItcastCater.DAL
{
    public class ProductInfoDAL
    {
        /// <summary>
        /// 查询所有没被删除的产品
        /// </summary>
        /// <param name="delflag"></param>
        /// <returns></returns>
        public List<ProductInfo> GetAllProductInfoByDelFlag(int delflag)
        {
            string sql = "select * from productinfo where DelFlag=@DelFlag";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@DelFlag", delflag));
            List<ProductInfo> list = new List<ProductInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    ProductInfo pro = RowToProductInfo(item);
                    list.Add(pro);
                }
            }
            return list;
        }

        private ProductInfo RowToProductInfo(DataRow dr)
        {
            ProductInfo pro = new ProductInfo();
            pro.CatId = Convert.ToInt32(dr["CatId"]);
            pro.DelFlag = Convert.ToInt32(dr["DelFlag"]);
            pro.ProCost = Convert.ToDecimal(dr["ProCost"]);
            pro.ProId = Convert.ToInt32(dr["ProId"]);
            pro.ProName = dr["ProName"].ToString();
            pro.ProNum = dr["ProNum"].ToString();
            pro.ProPrice = Convert.ToDecimal(dr["ProPrice"]);
            pro.ProSpell = dr["ProSpell"].ToString();
            pro.ProStock = Convert.ToDecimal(dr["ProStock"]);
            pro.ProUnit = dr["ProUnit"].ToString();
            pro.Remark = dr["Remark"].ToString();
            pro.SubBy = Convert.ToInt32(dr["SubBy"]);
            pro.SubTime = Convert.ToDateTime(dr["SubTime"]);
            return pro;

        }
    }
}
