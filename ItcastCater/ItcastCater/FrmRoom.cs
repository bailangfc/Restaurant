using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ItcastCater.BLL;
using ItcastCater.Model;

namespace ItcastCater
{
    public partial class FrmRoom : Form
    {
        public FrmRoom()
        {
            InitializeComponent();
        }


        #region "加载没有被删除的房间和餐桌"
        private void FrmRoom_Load(object sender, EventArgs e)
        {
            //加载没有被删除的房间
            //加载没有被删除的餐桌
            LoadDeskInfoByDelFlag(0);
            LoadRoomInfoByDelFlag(0);
        }

        private void LoadDeskInfoByDelFlag(int p)
        {
            DeskInfoBLL bll = new DeskInfoBLL();
            dgvDeskInfo.AutoGenerateColumns = false;
            dgvDeskInfo.DataSource = bll.GetAllDeskInfoByDelFlag(0);
            dgvDeskInfo.SelectedRows[0].Selected = false;
        }

        private void LoadRoomInfoByDelFlag(int p)
        {
            RoomInfoBLL bll = new RoomInfoBLL();
            dgvRoomInfo.AutoGenerateColumns = false;
            dgvRoomInfo.DataSource = bll.GetAllRoomInfoByDelflag(0);
            dgvRoomInfo.SelectedRows[0].Selected = false;
        }
        #endregion


        #region "房间的增加和修改"
        public event EventHandler evt;
        //增加房间
        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            ShowFrmChangeRoom(1);
        }

        //修改房间
        private void btnUpdateRoom_Click(object sender, EventArgs e)
        {
            if (dgvRoomInfo.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvRoomInfo.SelectedRows[0].Cells[0].Value);
                //根据Id查询数据库这个Id对应的所有值
                RoomInfoBLL bll = new RoomInfoBLL();
                RoomInfo room = bll.GetRoomInfoByRoomId(id);
                if (room != null)
                {
                    fea.obj = room;
                    room.RoomId = id;
                    ShowFrmChangeRoom(2);
                }
                
            }else
            {
                MessageBox.Show("请选择要操作的行");
            }
           
        }
        FrmEventArgs fea = new FrmEventArgs();
        //显示新增或修改房间的窗体，1---新增，2---修改
        private void ShowFrmChangeRoom(int p)
        {
            FrmChangeRoom fcm = new FrmChangeRoom();
            //注册事件
            this.evt += new EventHandler(fcm.SetText);
            
            fea.Temp = p;
            if (evt != null)
            {
                this.evt(this, fea);
            }
            fcm.FormClosed += new FormClosedEventHandler(fcm_FormClosed);

            fcm.ShowDialog();
        }
        //设置房间窗体关闭后的内容
        private void fcm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadRoomInfoByDelFlag(0);
        }
        #endregion


        #region "餐桌的增加和修改"
        public event EventHandler evt2;
        //增加餐桌
        private void btnAddDesk_Click(object sender, EventArgs e)
        {
            ShowFrmChangeDesk(1);
        }


        //修改餐桌
        private void btnUpdateDesk_Click(object sender, EventArgs e)
        {
            if (dgvDeskInfo.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvDeskInfo.SelectedRows[0].Cells[0].Value);
                DeskInfo desk = new DeskInfo();
                DeskInfoBLL bll = new DeskInfoBLL();
                desk = bll.GetDeskInfoByDeskId(id);
                if (desk != null)
                {
                    feas.obj = desk;
                    desk.DeskId = id;
                    ShowFrmChangeDesk(2);
                }

            }else
            {
                MessageBox.Show("请选择要修改的数据");
            }
        }
        
        FrmEventArgs feas = new FrmEventArgs();
        private void ShowFrmChangeDesk(int p)
        {
            FrmChangeDesk fcd = new FrmChangeDesk();
            this.evt2 += new EventHandler(fcd.SetDeskText);
            feas.Temp = p;
            if (evt2 != null)
            {
                this.evt2(this, feas);
            }
            fcd.FormClosed += new FormClosedEventHandler(fcd_Closed);
            fcd.ShowDialog();
        }

        private void fcd_Closed(object sender, FormClosedEventArgs e)
        {
            LoadDeskInfoByDelFlag(0);
        }

        #endregion
        //删除餐桌
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //先判断是否有选中的行
            if (dgvDeskInfo.SelectedRows.Count > 0)
            {
                //获取Id
                int id = Convert.ToInt32(dgvDeskInfo.SelectedRows[0].Cells[0].Value);
                //餐桌的状态-- 1使用，0空闲
                DeskInfoBLL bll = new DeskInfoBLL();
                if (bll.SerachDeskById(id))
                {
                    if ( bll.DeleteDeskById(id))
                    {
                        MessageBox.Show("操作成功");
                        LoadDeskInfoByDelFlag(0);
                    }
                    else
                    {
                        MessageBox.Show("操作失败");
                    }
                    
                }
                else
                {
                    MessageBox.Show("餐桌正在使用，不能删除");
                }
            }
            else
            {
                MessageBox.Show("请选中行");//测试本地提交，在vs端拉取
                //多测试几次
               //测试本地提交，在vs端拉取+2
               //测试vs提交，在本地端拉取+3
            }

        }
        //房间的删除
        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvRoomInfo.SelectedRows.Count > 0)
            {
                //房间下是否有餐桌
                
                if (DialogResult.OK == MessageBox.Show("确定删除吗？", "删除", MessageBoxButtons.OKCancel))
                {
                    DeskInfoBLL bll = new DeskInfoBLL();
                    int roomId = Convert.ToInt32(dgvRoomInfo.SelectedRows[0].Cells[0].Value);
                    if (bll.GetDeskInfoStateByRoomId(roomId))
                    {
                        MessageBox.Show("房间下有正在使用的餐桌，不能删除");
                    }
                    else
                    {
                        RoomInfoBLL rbll = new RoomInfoBLL();
                        //先把餐桌删除，再删除房间
                        if (bll.DeleteDeskInfoByRoomId(roomId)&&rbll.DeleteRoomInfoByRoomId(roomId))
                        {
                            MessageBox.Show("操作成功");
                            LoadRoomInfoByDelFlag(0);
                            LoadDeskInfoByDelFlag(0);
                        }else
                        {
                            MessageBox.Show("操作失败");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要操作的行");
            }
        }
    }
}
