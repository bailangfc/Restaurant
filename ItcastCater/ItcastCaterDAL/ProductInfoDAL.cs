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
        ProductInfo pro = new ProductInfo();

        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="proNum"></param>
        /// <returns></returns>
        public List<ProductInfo> GetProductByProNum(string proNum)
        {
            string sql = "select * from ProductInfo where DelFlag=0 and ProNum like @ProNum";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@ProNum","%"+ proNum+"%"));
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



        /// <summary>
        /// 根据商品类别的id查询产品
        /// </summary>
        /// <param name="catId"></param>
        /// <returns></returns>
        public List<ProductInfo> GetProductInfoByCatId(int catId)
        {
            string sql = "select * from ProductInfo where DelFlag=0 and CatId=@CatId";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@CatId", catId));
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

        /// <summary>
        /// 根据产品的Id来查询产品信息
        /// </summary>
        /// <param name="proId"></param>
        /// <returns></returns>
        public ProductInfo GetProductInfoByProId(int proId)
        {
            string sql = "select * from ProductInfo where DelFlag=0 and ProId=@ProId";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@ProId",proId));
            ProductInfo pro = null;
            if (dt.Rows.Count > 0)
            {
                pro = RowToProductInfo(dt.Rows[0]);
            }
            return pro;
        }


        //新增
        public int AddProductInfo(ProductInfo pro)
        {
            string sql = "insert into ProductInfo(CatId,ProName,ProCost,ProSpell,ProPrice,ProUnit,Remark,DelFlag,SubTime,ProStock,ProNum,SubBy) values(@CatId,@ProName,@ProCost,@ProSpell,@ProPrice,@ProUnit,@Remark,@DelFlag,@SubTime,@ProStock,@ProNum,@SubBy)";
            return AddAndUpdateProductInfo(pro, sql, 1);
        }
        //修改
        public int UpdateProductInfo(ProductInfo pro)
        {
            string sql = "update ProductInfo set CatId=@CatId,ProName=@ProName,ProCost=@ProCost,ProSpell=@ProSpell,ProPrice=@ProPrice,ProUnit=@ProUnit,Remark=@Remark,ProStock=@ProStock,ProNum=@ProNum where ProId=@ProId";
            return AddAndUpdateProductInfo(pro, sql, 2);
        }

        public int AddAndUpdateProductInfo(ProductInfo pro,string sql, int temp)
        {
            List<SQLiteParameter> list = new List<SQLiteParameter>();
            SQLiteParameter[] param =
            {
                new SQLiteParameter("@CatId",pro.CatId),
                new SQLiteParameter("@ProName",pro.ProName),
                new SQLiteParameter("@ProCost",pro.ProCost),
                new SQLiteParameter("@ProSpell",pro.ProSpell),
                new SQLiteParameter("@ProPrice",pro.ProPrice),
                new SQLiteParameter("@ProUnit",pro.ProUnit),
                new SQLiteParameter("@Remark",pro.Remark),
                new SQLiteParameter("@ProStock",pro.ProStock),
                new SQLiteParameter("@ProNum",pro.ProNum)
            };

            list.AddRange(param);
            if (temp == 1)
            {
                list.Add(new SQLiteParameter("@DelFlag", pro.DelFlag));
                list.Add(new SQLiteParameter("@SubTime", pro.SubTime));
                list.Add(new SQLiteParameter("@SubBy", pro.SubBy));
            }else if (temp == 2)
            {
                list.Add(new SQLiteParameter("@ProId", pro.ProId));
            }
            return SqliteHelper.ExecuteNonQuery(sql, list.ToArray());
        }
        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="id">产品id</param>
        /// <returns></returns>
        public int DeleteProductInfoByProId(int id)
        {
            string sql = "update ProductInfo set delFlag=1 where proId=@ProId";
            return SqliteHelper.ExecuteNonQuery(sql, new SQLiteParameter("@ProId", id));
        }





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
