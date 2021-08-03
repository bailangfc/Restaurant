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
        //CategoryInfo cg = new CategoryInfo();
        //增加商品类别
        public int AddCategoryInfo(CategoryInfo cat)
        {
            string sql = "insert into CategoryInfo(CatName,CatNum,Remark,DelFlag,SubTime,SubBy) values(@CatName,@CatNum,@Remark,@DelFlag,@SubTime,@SubBy)";
            return AddAndUpdate(sql, cat, 1);
        }

        //修改商品类别
        public int UpdateCategoryInfo(CategoryInfo cat)
        {
            string sql = "update CategoryInfo set CatName=@CatName, CatNum=@CatNum, Remark=@Remark where CatId=@CatId";
            return AddAndUpdate(sql, cat, 2);
        }
        //增加和修改合并
        public int AddAndUpdate(string sql,CategoryInfo cat,int temp)
        {
            List<SQLiteParameter> list = new List<SQLiteParameter>();
            SQLiteParameter[] param =
            {
                new SQLiteParameter("@CatName",cat.Catname),
                new SQLiteParameter("@CatNum",cat.Catnum),
                new SQLiteParameter("@Remark",cat.Remark)
            };
            list.AddRange(param);
            if (temp == 1)
            {
                list.Add(new SQLiteParameter("@DelFlag", cat.Delflag));
                list.Add(new SQLiteParameter("@SubTime", cat.Subtime));
                list.Add(new SQLiteParameter("@SubBy", cat.Subby));
            }
            else if (temp == 2)
            {
                list.Add(new SQLiteParameter("@CatId", cat.Catid));
            }
            return SqliteHelper.ExecuteNonQuery(sql, list.ToArray());
        }

        //删除商品类别
        public int DeleteCategoryInfoByCatId(int catId)
        {
            string sql = "update CategoryInfo set DelFlag=1 where CatId=@CatId";
            return SqliteHelper.ExecuteNonQuery(sql, new SQLiteParameter("@CatId", catId));
        }



        /// <summary>
        /// 根据id查对象
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>

        public CategoryInfo GetCategoryInfoByCatId(int id)
        {
            string sql = "select * from CategoryInfo where CatId=@CatId";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@CatId", id));
            CategoryInfo cat = null;
            if (dt.Rows.Count > 0)
            {
                cat = RowToCategoryInfo(dt.Rows[0]);
            }
            return cat;
        }


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
