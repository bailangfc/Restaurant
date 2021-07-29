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
    public partial class FrmChangeDesk : Form
    {
        public FrmChangeDesk()
        {
            InitializeComponent();
        }

        private void LoadRoomType()
        {
            RoomInfoBLL bll = new RoomInfoBLL();
            List<RoomInfo> list = bll.GetAllRoomInfoByDelflag(0);
            //list.Insert(0, new RoomInfo(){ RoomId = -1, RoomName = "请选择" });
            list.Insert(0, new RoomInfo() { RoomId = -1, RoomName = "请选择" });
            cmdRoom.DataSource = list;
            cmdRoom.DisplayMember = "RoomName";
            cmdRoom.ValueMember = "RoomId";
        }
        private int Tp { get; set; }
        public void SetDeskText(object sender,EventArgs e)
        {

            //获取传过来的值
            //清空所有文本框
            FrmEventArgs feas = e as FrmEventArgs;
            this.Tp = feas.Temp;
            LoadRoomType();
            if (feas.Temp == 1)
            {
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        TextBox tb = item as TextBox;
                        tb.Text = "";
                    }
                }
            }
            
            else if(this.Tp==2)
            {
                DeskInfo desk = feas.obj as DeskInfo;
                labId.Text = desk.DeskId.ToString();
                txtDeskName.Text = desk.DeskName;
                txtDeskRegion.Text = desk.DeskRegion;
                txtDeskRemark.Text = desk.DeskRemark;
                cmdRoom.SelectedValue = desk.RoomId;
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CheckEmpty())
            {
                DeskInfo desk = new DeskInfo();
                //desk.RoomId = Convert.ToInt32(cmdRoom.Text);
                desk.DeskName = txtDeskName.Text;
                desk.DeskRegion = txtDeskRegion.Text;
                desk.DeskRemark = txtDeskRemark.Text;
                if (this.Tp == 1)
                {
                    desk.DelFlag = 0;
                    desk.DeskState = 0;
                    desk.SubTime = System.DateTime.Now;
                    desk.SubBy = 1;
                    desk.RoomId = Convert.ToInt32(cmdRoom.SelectedIndex);
                }else if (this.Tp == 2)
                {
                    desk.DeskId = Convert.ToInt32(labId.Text);
                    //desk.RoomId = Convert.ToInt32(cmdRoom.SelectedIndex);
                }
                DeskInfoBLL bll = new DeskInfoBLL();
                string msg = bll.SaveDesk(desk, this.Tp) ? "操作成功": "操作失败";
                MessageBox.Show(msg);
                this.Close();
            }
        }

        private bool CheckEmpty()
        {
          
            if (string.IsNullOrEmpty(txtDeskName.Text))
            {
                MessageBox.Show("餐桌名字不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtDeskRegion.Text))
            {
                MessageBox.Show("餐桌名字不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtDeskRemark.Text))
            {
                MessageBox.Show("餐桌备注不能为空");
                return false;
            }
            return true;
        }
    }
}
