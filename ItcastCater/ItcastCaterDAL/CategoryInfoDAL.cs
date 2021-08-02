using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItcastCater.Model;
using System.Data;
using System.Data.SQLite;

namespace ItcastCater.DAL
{
    public class CategoryInfoDAL
    {
        /// <summary>
        /// 查询所有没删除的商品
        /// </summary>
        /// <param name="delflag"></param>
        /// <returns></returns>
        public List<CategoryInfo>GetAllCategoryInfoByDelFlag(int delflag)
        {
            string sql = "select * from categoryinfo where DelFlag=@DelFlag";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@DelFlag", delflag));
            List<CategoryInfo> list = new List<CategoryInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    CategoryInfo ct = RowToCategoryInfo(item);
                    list.Add(ct);
                }
            }
            return list;
        }

        private CategoryInfo RowToCategoryInfo(DataRow dr)
        {
            CategoryInfo ct = new CategoryInfo();
            ct.Catid = Convert.ToInt32(dr["CatId"]);
            ct.Catname = dr["Catname"].ToString();
            ct.Catnum = dr["Catnum"].ToString();
            ct.Delflag= Convert.ToInt32(dr["Delflag"]);
            ct.Remark = dr["Remark"].ToString();
            ct.Subby = Convert.ToInt32(dr["Subby"]);
            ct.Subtime = Convert.ToDateTime(dr["Subtime"]);
            return ct;
        }
    }
}
