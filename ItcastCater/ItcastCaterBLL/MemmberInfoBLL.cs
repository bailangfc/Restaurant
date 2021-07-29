using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItcastCater.DAL;
using ItcastCater.Model;


namespace ItcastCater.BLL
{
    public class MemmberInfoBLL
    {
        MemmberInfoDAL dal = new MemmberInfoDAL();

        /// <summary>
        /// 新增和修改
        /// </summary>
        /// <param name="memmber">会员对象</param>
        /// <param name="temp">标识 1：新增 2：修改</param>
        /// <returns></returns>
        public bool SaveMemmber(MemmberInfo memmber, int temp)
        {
            int r = -1;
            if (temp == 1)//新增
            {
                r = dal.AddMemmberInfo(memmber);
            }
            else if (temp == 2)
            {
                r = dal.UpdateMemmberInfo(memmber);
            }
            return r > 0 ? true : false;
        }


        /// <summary>
        /// 根据会员的Id查询该会员的信息
        /// </summary>
        /// <param name="memmberId">会员Id</param>
        /// <returns>会员对象</returns>
        public MemmberInfo GetMemmberInfoByMemmberId(int memmberId)
        {
            return dal.GetMemmberInfoByMemmberId(memmberId);
        }



        /// <summary>
        /// 根据会员id删除该会员
        /// </summary>
        /// <param name="memmberId">会员id</param>
        /// <returns>受影响的行数</returns>
        public bool DeleteMemmberByMemmberId(int memmberId)
        {
            return dal.DeleteMemmberByMemmberId(memmberId) > 0 ? true : false;
        }



        public List<MemmberInfo> GetAllMemmberInfoByDelFlag(int delFlag)
        {
            return dal.GetAllMemmberInfoByDelFlag(delFlag);
        }
    }
}
