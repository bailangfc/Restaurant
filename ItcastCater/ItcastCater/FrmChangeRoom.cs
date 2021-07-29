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
    public partial class FrmChangeRoom : Form
    {
        public FrmChangeRoom()
        {
            InitializeComponent();
        }
        private int Tp { get; set; }
        public void SetText(object sender, EventArgs e)
        {
            //第一：清空所有文本框
            foreach (Control ctr in this.Controls)
            {
                if (ctr is TextBox)
                {
                    TextBox tb = ctr as TextBox;
                    tb.Text = "";
                }
            }
            //获取传过来的值
            FrmEventArgs fea = e as FrmEventArgs;
            this.Tp = fea.Temp;//标识存起来
            if (fea.Temp == 2)
            {
                RoomInfo room = fea.obj as RoomInfo;//里式转换
                labId.Text = room.RoomId.ToString();
                txtIsDeflaut.Text = room.IsDefault.ToString();
                txtRMinMoney.Text = room.RoomMinimunConsume.ToString();
                txtRName.Text = room.RoomName;
                txtRPerNum.Text = room.RoomMaxConsumer.ToString();
                txtRType.Text = room.RoomType.ToString();

            }
            //要为每个文本框赋值
            //Id存起来
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //判断每个文本框不能为空
            if (CheckEmpty())
            {
                RoomInfo room = new RoomInfo();
                room.IsDefault = Convert.ToInt32(txtIsDeflaut.Text);
                room.RoomMaxConsumer = Convert.ToInt32(txtRPerNum.Text);
                room.RoomMinimunConsume = Convert.ToDecimal(txtRMinMoney.Text);
                room.RoomName = txtRName.Text;
                room.RoomType = Convert.ToInt32(txtRType.Text);
                if (this.Tp == 1)//新增
                {
                    room.DelFlag = 0;
                    room.SubBy = 1;
                    room.SubTime = DateTime.Now;
                }
                else if (this.Tp == 2)//修改
                {
                    room.RoomId = Convert.ToInt32(labId.Text);
                }
                RoomInfoBLL bll = new RoomInfoBLL();
                string msg = bll.SaveRoom(room, this.Tp) ? "操作成功" : "操作失败";
                MessageBox.Show(msg);
                this.Close();

            }

        }

        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(txtIsDeflaut.Text))
            {
                MessageBox.Show("默认编号不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtRMinMoney.Text))
            {
                MessageBox.Show("最低消费不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtRName.Text))
            {
                MessageBox.Show("房间的编号不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtRPerNum.Text))
            {
                MessageBox.Show("容纳的人数不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtRType.Text))
            {
                MessageBox.Show("类型不能为空");
                return false;
            }
            return true;
        }
    }
}
