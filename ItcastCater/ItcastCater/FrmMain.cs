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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();//注释
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //加载房间
            LoadRoomInfoByDelFlag(0);
            //加载餐桌
            TabPage tp = tcin.TabPages[0];
            LoadDeskByTabPage(tp);
        }
        //加载房间
        private void LoadRoomInfoByDelFlag(int p)
        {
            RoomInfoBLL bll = new RoomInfoBLL();
            List<RoomInfo> listRoom = bll.GetAllRoomInfoByDelflag(0);
            for (int i = listRoom.Count - 1; i >= 0; i--)
            {
                TabPage tp = new TabPage();
                tp.Tag = listRoom[i];//存房间的对象
                tp.Text = listRoom[i].RoomName;//显示房间的名字
                ListView lv = new ListView();
                lv.LargeImageList = imageList1;//给listview控件绑定图片集合
                lv.BackColor = Color.White;//设置背景颜色
                lv.Dock = DockStyle.Fill;//让listview控件在父容器中填充
                lv.MultiSelect = false;//只能选中一个
                lv.View = View.LargeIcon;

                tp.Controls.Add(lv);
                tcin.TabPages.Add(tp);
            }
        }

        //加载餐桌
        private void LoadDeskByTabPage(TabPage tp)
        {
            //获取房间的Id
            RoomInfo room = tp.Tag as RoomInfo;
            //int id = room.RoomId;
            DeskInfoBLL bll = new DeskInfoBLL();
            List<DeskInfo> listDesk = bll.GetDeskInfoByRoomId(Convert.ToInt32(room.RoomId));
            ListView lv = tp.Controls[0] as ListView;
            for (int i = 0; i < listDesk.Count; i++)
            {
                //判断餐桌状态显示对象的图片
                lv.Items.Add(listDesk[i].DeskName,Convert.ToInt32( listDesk[i].DeskState));
                lv.Items[i].Tag = listDesk[i];//餐桌对象
            }


        }


        private void bthMemmber_Click(object sender, EventArgs e)
        {
            FrmMemmberInfo fm = new FrmMemmberInfo();
            fm.ShowDialog();
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            FrmRoom fm = new FrmRoom();
            fm.ShowDialog();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            FrmCategory frc = new FrmCategory();
            frc.ShowDialog();
        }
    }
}
