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
    public class OrderInfoDAL
    {

        /// <summary>
        /// 插入一个订单，返回该订单的id对象
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int AddOrderInfo(OrderInfo order)
        {
            string sql = "insert into OrderInfo(SubTime,Remark,OrderState,DelFlag,SubBy) values(@SubTime,@Remark,@OrderState,@DelFlag,@SubBy);select last_insert_rowid();";
            SQLiteParameter[] param =
            {
                new SQLiteParameter("@SubTime",order.SubTime),
                new SQLiteParameter("@Remark",order.Remark),
                new SQLiteParameter("@OrderState",order.OrderState),
                new SQLiteParameter("@DelFlag",order.DelFlag),
                new SQLiteParameter("@SubBy",order.SubBy),
            };
            return Convert.ToInt32( SqliteHelper.ExecuteScalar(sql, param));
        }
    }
}
