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
    public class MemmberInfoDAL
    {
        //增加会员
        public int AddMemmberInfo(MemmberInfo memmber)
        {
            string sql = "insert into MemmberInfo(MemName,MemMobilePhone,MemAddress,MemType,MemNum,MemGender,MemDiscount,MemMoney,DelFlag,SubTime,MemIntegral,MemEndServerTime,MemBirthdaty)values(@MemName,@MemMobilePhone,@MemAddress,@MemType,@MemNum,@MemGender,@MemDiscount,@MemMoney,@DelFlag,@SubTime,@MemIntegral,@MemEndServerTime,@MemBirthdaty)";
            return AddAndUpdate(memmber, sql, 1);
        }

        //修改会员
        public int UpdateMemmberInfo(MemmberInfo memmber)
        {
            string sql = "update MemmberInfo set MemName=@MemName,MemMobilePhone=@MemMobilePhone,MemAddress=@MemAddress,MemType=@MemType,MemNum=@MemNum,MemGender=@MemGender,MemDiscount=@MemDiscount,MemMoney=@MemMoney,MemIntegral=@MemIntegral,MemEndServerTime=@MemEndServerTime,MemBirthdaty=@MemBirthdaty where MemmberId=@MemmberId";
            return AddAndUpdate(memmber, sql, 2);
        }

        //新增和修改的公共方法
        private int AddAndUpdate(MemmberInfo memmber,string sql,int temp)
        {
            SQLiteParameter[] param =
            {
                new SQLiteParameter("@MemName",memmber.MemName),
                new SQLiteParameter("@MemMobilePhone",memmber.MemMobilePhone),
                new SQLiteParameter("@MemAddress",memmber.MemAddress),
                new SQLiteParameter("@MemType",memmber.MemType),
                new SQLiteParameter("@MemNum",memmber.MemNum),
                new SQLiteParameter("@MemGender",memmber.MemGender),
                new SQLiteParameter("@MemDiscount",memmber.MemDiscount),
                new SQLiteParameter("@MemMoney",memmber.MemMoney),
                new SQLiteParameter("@MemIntegral",memmber.MemIntegral),
                new SQLiteParameter("@MemEndServerTime",memmber.MemEndServerTime),
                new SQLiteParameter("@MemBirthdaty",memmber.MemBirthdaty)
            };
            List<SQLiteParameter> list = new List<SQLiteParameter>();
            list.AddRange(param);
            if (temp == 1)
            {
                list.Add(new SQLiteParameter("@SubTime", memmber.SubTime));
                list.Add(new SQLiteParameter("@DelFlag", memmber.DelFlag));
            }else if (temp == 2)
            {
                list.Add(new SQLiteParameter("@MemmberId", memmber.MemmberId));
            }

            return SqliteHelper.ExecuteNonQuery(sql, list.ToArray());
        }


        /// <summary>
        /// 根据会员的Id查询该会员的信息
        /// </summary>
        /// <param name="memmberId">会员Id</param>
        /// <returns>会员对象</returns>
        public MemmberInfo GetMemmberInfoByMemmberId(int memmberId)
        {
            string sql = "select  * from MemmberInfo where MemmberId=@MemmberId ";
            DataTable dt= SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@MemmberId", memmberId));
            MemmberInfo mem = null;
            if (dt.Rows.Count > 0)
            {
                mem = RowToMemmberInfo(dt.Rows[0]);
            }
            return mem;
        }

        /// <summary>
        /// 根据会员id删除该会员
        /// </summary>
        /// <param name="memmberId">会员id</param>
        /// <returns>受影响的行数</returns>
        public int DeleteMemmberByMemmberId(int memmberId)
        {
            string sql = "update MemmberInfo set DelFlag=1 where MemmberId=@MemmberId";
            return SqliteHelper.ExecuteNonQuery(sql, new SQLiteParameter("@MemmberId",memmberId));
        }

        /// <summary>
        /// 查询所有没删除的会员
        /// </summary>
        /// <param name="delFlag">删除表示</param>
        /// <returns>会员对象集合</returns>
        public List<MemmberInfo>GetAllMemmberInfoByDelFlag(int delFlag)
        {
            string sql = "select * from MemmberInfo where DelFlag=@DelFlag";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@DelFlag",delFlag));
            List<MemmberInfo> list = new List<MemmberInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow item in dt.Rows)
                {
                    MemmberInfo mem = RowToMemmberInfo(item);
                    list.Add(mem);
                }
            }
            return list;
        }
        //关系转对象
        private MemmberInfo RowToMemmberInfo(DataRow dr)
        {
            MemmberInfo mem = new MemmberInfo();
            mem.MemAddress = dr["MemAddress"].ToString();
            mem.MemBirthdaty = Convert.ToDateTime(dr["MemBirthdaty"]);
            mem.MemDiscount = Convert.ToDecimal(dr["MemDiscount"]);
            mem.MemEndServerTime = Convert.ToDateTime(dr["MemEndServerTime"]);
            mem.MemGender = dr["MemGender"].ToString();
            mem.MemIntegral = Convert.ToInt32(dr["MemIntegral"]);
            mem.MemmberId = Convert.ToInt32(dr["MemmberId"]);
            mem.MemMobilePhone = dr["MemMobilePhone"].ToString();
            mem.MemMoney = Convert.ToDecimal(dr["MemMoney"]);
            mem.MemName = dr["MemName"].ToString();
            mem.MemNum = dr["MemNum"].ToString();
            mem.MemType = Convert.ToInt32(dr["MemType"]);
            mem.SubTime = Convert.ToDateTime(dr["SubTime"]);
            return mem;

        }
    }
}
