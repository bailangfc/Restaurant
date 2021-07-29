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
    public partial class FrmMemmberInfo : Form
    {
        public FrmMemmberInfo()
        {
            InitializeComponent();
        }

        public event EventHandler evt;//事件，主要是传值用的

        private void FrmMemmberInfo_Load(object sender, EventArgs e)
        {
            //加载所有会员（未删除的）
            LoadMemmberInfoByDelFlag(0);
        }
        //加载所有会员
        private void LoadMemmberInfoByDelFlag(int p)
        {
            MemmberInfoBLL bll = new MemmberInfoBLL();
            dgvMemmber.AutoGenerateColumns = false;
            dgvMemmber.DataSource = bll.GetAllMemmberInfoByDelFlag(p);
            dgvMemmber.SelectedRows[0].Selected = false;
        }
        //删除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //判断是否有选中的行
            if (dgvMemmber.SelectedRows.Count>0)
            {
                int id = Convert.ToInt32(dgvMemmber.SelectedRows[0].Cells[0].Value);
                MemmberInfoBLL bll = new MemmberInfoBLL();
                if (bll.DeleteMemmberByMemmberId(id))
                {
                    MessageBox.Show("操作成功");
                    LoadMemmberInfoByDelFlag(0);
                }else
                {
                    MessageBox.Show("操作失败");
                }
            }else
            {
                MessageBox.Show("请选中要删除的行");
            }
        }
        //新增会员 1表示是新增
        private void btnAddMemMber_Click(object sender, EventArgs e)
        {
            //FrmChangeMemmber fcm = new FrmChangeMemmber();
            //fcm.ShowDialog();
            ShowFrmChangeMemmber(1);

        } 
        //修改会员 2表示是修改
        private void btnUpdateMember_Click(object sender, EventArgs e)
        {
            //FrmChangeMemmber fcm = new FrmChangeMemmber();
            //fcm.ShowDialog();
            if (dgvMemmber.SelectedRows.Count>0)
            {
                int id = Convert.ToInt32(dgvMemmber.SelectedRows[0].Cells[0].Value);
                //根据id去数据库查询这条数据是否存在
                MemmberInfoBLL bll = new MemmberInfoBLL();
                MemmberInfo mem = bll.GetMemmberInfoByMemmberId(id);
                fea.obj = mem;
                ShowFrmChangeMemmber(2);
            }else
            {
                MessageBox.Show("请选择要修改的数据");
            }

            

        }
        FrmEventArgs fea = new FrmEventArgs();
        private void ShowFrmChangeMemmber(int p)
        {
            FrmChangeMemmber fcm = new FrmChangeMemmber();
            this.evt += new EventHandler(fcm.SetText);//注册事件
            
            fea.Temp = p;//传的是新增或修改的标识
            if (this.evt!=null)//执行事件之前要判断不能为空
            {
                this.evt(this, fea);//执行事件
               
            }
            fcm.FormClosed += new FormClosedEventHandler(FrmMemmberInfo_Load);
            fcm.ShowDialog();
        }

    }
}
