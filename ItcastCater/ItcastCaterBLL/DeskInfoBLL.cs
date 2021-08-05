using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItcastCater.Model;
using ItcastCater.DAL;

namespace ItcastCater.BLL
{
    public class DeskInfoBLL
    {
        DeskInfoDAL dal = new DeskInfoDAL();


        /// <summary>
        /// 根据房间的ID查询该房间下的所有餐桌
        /// </summary>
        /// <param name="roomId">房间的id</param>
        /// <returns>餐桌对象</returns>
        public List<DeskInfo> GetDeskInfoByRoomId(int roomId)
        {
            return dal.GetDeskInfoByRoomId(roomId);
        }

        /// <summary>
        /// 根据房间的Id删除餐桌
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public bool DeleteDeskInfoByRoomId(int roomId)
        {
            return dal.DeleteDeskInfoByRoomId(roomId)>0?true:false;
        }

        /// <summary>
        /// 查询该房间下是否有正在使用的餐桌
        /// </summary>
        /// <param name="roomId">房间的Id</param>
        /// <returns></returns>
        public bool GetDeskInfoStateByRoomId(int roomId)
        {
            bool a = Convert.ToInt32(dal.GetDeskInfoStateByRoomId(roomId)) > 0 ? true : false;
            return a;
        }

       
        /// <summary>
        /// 删除餐桌
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteDeskById(int id)
        {
            return dal.DeleteDeskById(id) > 0 ? true : false;
        }
        /// <summary>
        /// 根据餐桌的ID查询该餐桌是不是空闲的
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool SerachDeskById(int id)
        {
            return  Convert.ToInt32(dal.SerachDeskById(id)) > 0 ? true : false;
        }

        /// <summary>
        /// 添加和修改餐桌
        /// </summary>
        /// <param name="desk">餐桌对象</param>
        /// <param name="temp"></param>
        /// <returns></returns>
        public bool SaveDesk(DeskInfo desk,int temp)
        {
            int r = -1;
            if (temp == 1)
            {
                r = dal.AddDeskInfo(desk);
            }else if (temp == 2)
            {
                r = dal.UpdateDeskInfo(desk);
            }
            return r > 0 ? true : false;
        }


        public List<DeskInfo> GetAllDeskInfoByDelFlag(int delFlag)
        {
            return dal.GetAllDeskInfoByDelFlag(delFlag);
        }


        /// <summary>
        /// 根据用户ID获取信息
        /// </summary>
        /// <param name="deskId"></param>
        /// <returns></returns>
        public DeskInfo GetDeskInfoByDeskId(int deskId)
        {
            return dal.GetDeskInfoByDeskId(deskId);
        }
    }
}
