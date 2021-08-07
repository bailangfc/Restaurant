using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItcastCater.Model;
using ItcastCater.DAL;

namespace ItcastCater.BLL
{
    public class OrderInfoBLL
    {
        OrderInfoDAL dal = new OrderInfoDAL();

        /// <summary>
        /// 根据餐桌的id查询正在使用的订单id
        /// </summary>
        /// <param name="deskId">餐桌id</param>
        /// <returns>订单的id</returns>
        public int GetOrderIdByDeskId(int deskId)
        {
            return Convert.ToInt32( dal.GetOrderIdByDeskId(deskId));
        }


        /// <summary>
        /// 插入一个订单，返回该订单的id对象
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int AddOrderInfo(OrderInfo order)
        {
            return dal.AddOrderInfo(order);
        }
    }
}
