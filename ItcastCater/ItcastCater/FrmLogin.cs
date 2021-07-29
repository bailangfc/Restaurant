using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ItcastCater.Model;
using ItcastCater.BLL;


namespace ItcastCater
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
        //登录
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //首先获取账号和密码
            //判断账号和密码不能为空
            string name = txtName.Text.Trim();
            string pwd = txtPwd.Text;
            string msg = "";
            if (CheckEmpty(name, pwd))
            {
                UserInfoBLL bll = new UserInfoBLL();
                if (bll.GetUserPwdByLoginName(name, pwd, out msg))
                {
                    //登录成功
                    msgDiv1.MsgDivShow(msg, 1,Bind);
                }
                else
                {
                    msgDiv1.MsgDivShow(msg, 1);
                }
            }
        }
        //判断账号和密码不能为空
        private bool CheckEmpty(string name, string pwd)
        {
            //out传的值必须赋初值；
          
            if (string.IsNullOrEmpty(name))
            {
                msgDiv1.MsgDivShow("账户不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(pwd))
            {
                msgDiv1.MsgDivShow("密码不能为空", 1);
                return false;
            }
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Bind()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
