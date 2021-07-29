using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItcastCater.Model;
using ItcastCater.DAL;

namespace ItcastCater.BLL
{
    public class RoomInfoBLL
    {
        RoomInfoDAL dal = new RoomInfoDAL();




        /// <summary>
        /// 新增或是修改
        /// </summary>
        /// <param name="room">房间对象</param>
        /// <param name="temp">1：表示新增，2：表示修改</param>
        /// <returns></returns>
        public bool SaveRoom(RoomInfo room,int temp)
        {
            int r = -1;
            if (temp==1)
            {
                r = dal.AddRoomInfo(room);
            }else if (temp == 2)
            {
                r = dal.UpdateRoomInfo(room);
            }
            return r > 0 ? true : false;
        }



        /// <summary>
        /// 查询所有未删除的房间
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns>房间对象集合</returns>
        public List<RoomInfo> GetAllRoomInfoByDelflag(int delFlag)
        {
            return dal.GetAllRoomInfoByDelflag(delFlag);
        }

        /// <summary>
        /// 根据房间Id查询该房间信息
        /// </summary>
        /// <param name="roomId">房间Id</param>
        /// <returns>房间对象</returns>
        public RoomInfo GetRoomInfoByRoomId(int roomId)
        {
            return dal.GetRoomInfoByRoomId(roomId);
        }
    }
}
