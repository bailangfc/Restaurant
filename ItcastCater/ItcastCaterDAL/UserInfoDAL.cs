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
    public class UserInfoDAL
    {
        //去数据库中查询数据
        public UserInfo GetUserPwdByLoginName(string loginName)
        {
            string sql = "select * from UserInfo where LoginUserName=@LoginUserName and DelFlag=0";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@LoginUserName", loginName));
            //dt是否有行
            UserInfo user = null;
            if (dt.Rows.Count >0)
            {
                 user = RowToUserInfo(dt.Rows[0]);
            }
            return user;
        }
        //关系转对象
        private UserInfo RowToUserInfo(DataRow dr)
        {
            UserInfo user = new UserInfo();
            user.LastLoginIp = dr["LastLoginIp"].ToString();
            user.LastLoginTime = Convert.ToDateTime(dr["LastLoginTime"]);
            user.LoginUserName = dr["LoginUserName"].ToString();
            user.Pwd = dr["Pwd"].ToString();
            user.SubTime = Convert.ToDateTime(dr["SubTime"]);
            user.UserId = Convert.ToInt32(dr["UserId"]);
            user.UserName = dr["UserName"].ToString();
            return user;
        }
    }
}
