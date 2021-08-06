using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItcastCater.Model;
using ItcastCater.DAL;

namespace ItcastCater.BLL
{
    public class ROrderDeskBLL
    {
        ROrderDeskDAL dal = new ROrderDeskDAL();
        /// <summary>
        /// 往中间表插入数据
        /// </summary>
        /// <param name="rod">中间表对象</param>
        /// <returns></returns>
        public bool AddROrderDesk(ROrderDesk rod)
        {
            return dal.AddROrderDesk(rod) > 0 ? true : false;
        }
    }
}
