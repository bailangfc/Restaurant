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
    public class DeskInfoDAL
    {
        /// <summary>
        /// 根据餐桌的ID查询该餐桌是不是空闲的
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public object SerachDeskById(int id)
        {
            string sql = "select count(*) from DeskInfo where DelFlag=0 and DeskId=@DeskId and DeskState=0";
            return SqliteHelper.ExecuteScalar(sql, new SQLiteParameter("@DeskId", id));

        }
        /// <summary>
        /// 删除餐桌
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteDeskById(int id)
        {
            string sql = "update DeskInfo set DelFlag=1 where DeskId=@DeskId";
            return SqliteHelper.ExecuteNonQuery(sql, new SQLiteParameter("@DeskId", id));
        }

        public int AddDeskInfo(DeskInfo desk)
        {
            string sql = "insert into DeskInfo(RoomId,DeskName,DeskRemark,DeskRegion,DeskState,DelFlag,SubTime,SubBy) values(@RoomId,@DeskName,@DeskRemark,@DeskRegion,@DeskState,@DelFlag,@SubTime,@SubBy)";
            return AddAndUpdate(desk, sql, 1);
        }


        public int UpdateDeskInfo(DeskInfo desk)
        {
            string sql = "update DeskInfo set RoomId=@RoomId,DeskName=@DeskName,DeskRemark=@DeskRemark,DeskRegion=@DeskRegion where DeskId=@DeskId";
            return AddAndUpdate(desk, sql, 2);
        }

        public int AddAndUpdate(DeskInfo desk,string sql,int temp)
        {
            SQLiteParameter[] param =
            {
                new SQLiteParameter("@RoomId",desk.RoomId),
                new SQLiteParameter("@DeskName",desk.DeskName),
                new SQLiteParameter("@DeskRegion",desk.DeskRegion),
                new SQLiteParameter("@DeskRemark",desk.DeskRemark)
            };
            List<SQLiteParameter> list = new List<SQLiteParameter>();
            list.AddRange(param);
            if (temp == 1)
            {
                list.Add(new SQLiteParameter("@DeskState", desk.DeskState));
                list.Add(new SQLiteParameter("@DelFlag", desk.DelFlag));
                list.Add(new SQLiteParameter("@Subtime", desk.SubTime));
                list.Add(new SQLiteParameter("@SubBy", desk.SubBy));
            }else if (temp == 2)
            {
                list.Add(new SQLiteParameter("@DeskId", desk.DeskId));
            }
            return SqliteHelper.ExecuteNonQuery(sql, list.ToArray());
        }

        //我的错误代码，返回了一个Desk的列表
        //public List<DeskInfo> GetDeskInfoByDeskId(int deskId)
        //{
        //    string sql = "select * from DeskInfo where DeskId=@DeskId and DelFlag=0";
        //    DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@DeskId", deskId));
        //    List<DeskInfo> list = new List<DeskInfo>();
        //    DeskInfo desk = new DeskInfo();
        //    if (dt.Rows.Count > 0)
        //    {
        //        desk = RowToDeskInfo(dt.Rows[0]);
        //    }
        //    list.Add(desk);
        //    return list;
        //}


        /// <summary>
        /// 根据用户ID获取信息
        /// </summary>
        /// <param name="deskId"></param>
        /// <returns></returns>
        public DeskInfo GetDeskInfoByDeskId(int deskId)
        {
            string sql = "select * from DeskInfo where DeskId=@DeskId and DelFlag=0";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@DeskId", deskId));
           
            DeskInfo desk = new DeskInfo();
            if (dt.Rows.Count > 0)
            {
                desk = RowToDeskInfo(dt.Rows[0]);
            }
            return desk;
        }


        /// <summary>
        /// 查询所有未删除的房间
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns>返回一个列表</returns>
        public List<DeskInfo> GetAllDeskInfoByDelFlag(int delFlag)
        {
            string sql = "select * from DeskInfo Where DelFlag=@delFlag";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@delFlag", delFlag));
            List<DeskInfo> list = new List<DeskInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DeskInfo desk = RowToDeskInfo(item);
                    list.Add(desk);
                }
            }
            return list;
        }

        //关系转对象
        private DeskInfo RowToDeskInfo(DataRow dr)
        {
            DeskInfo desk = new DeskInfo();
            //desk.DelFlag = Convert.ToInt32(dr[""]);
            desk.DeskId = Convert.ToInt32(dr["DeskId"]);
            desk.DeskName = dr["DeskName"].ToString();
            desk.DeskRegion = dr["DeskRegion"].ToString();
            desk.DeskRemark = dr["DeskRemark"].ToString();
            //desk.DeskState = Convert.ToInt32(dr[""]);
             desk.DeskStateString = Convert.ToInt32(dr["DeskState"]) == 0 ? "空闲" : "开桌";
            
            desk.RoomId = Convert.ToInt32(dr["RoomId"]);
            desk.SubBy = Convert.ToInt32(dr["SubBy"]);
            desk.SubTime = Convert.ToDateTime(dr["SubTime"]);
            return desk;
        }
    }
}
