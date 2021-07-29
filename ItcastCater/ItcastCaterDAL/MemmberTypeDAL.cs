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
    public class MemmberTypeDAL
    {
        /// <summary>
        /// 查询所有没有被删除的会员类型
        /// </summary>
        /// <returns>会员类型集合</returns>
        public List<MemmberType> GetAllMemmberTypeByDelFlag()
        {
            string sql = "select MemType,MemTpName from MemmberType where DelFlag=0";
            DataTable dt = SqliteHelper.ExecuteTable(sql);
            List<MemmberType> list = new List<MemmberType>();
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow item in dt.Rows)
                {
                    MemmberType memtp = RowToMemmberType(item);
                    list.Add(memtp);
                }
            }
            return list;
        }
        //关系转对象
        private MemmberType RowToMemmberType(DataRow item)
        {
            MemmberType mem = new MemmberType();
            mem.MemTpName = item["MemTpName"].ToString();
            mem.MemType = Convert.ToInt32(item["MemType"]);
            return mem;
        }
    }
}
