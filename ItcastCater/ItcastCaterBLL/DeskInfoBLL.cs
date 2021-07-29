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
