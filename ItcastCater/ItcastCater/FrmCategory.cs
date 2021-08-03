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
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            LoadCategoryInfoByDelFlag(0);
            LoadProductInfoByDelFlag(0);
        }
        //加载商品类别
        private void LoadCategoryInfoByDelFlag(int p)
        {
            CategoryInfoBLL bll = new CategoryInfoBLL();
            dgvCategoryInfo.AutoGenerateColumns = false;//禁止自动生成列
            dgvCategoryInfo.DataSource = bll.GetAllCategoryInfoByDelFlag(p);
            dgvCategoryInfo.SelectedRows[0].Selected = false;//让第一行不被选中
        }

        private void LoadProductInfoByDelFlag(int p)
        {
            ProductInfoBLL bll = new ProductInfoBLL();
            dgvProductInfo.AutoGenerateColumns = false;
            dgvProductInfo.DataSource = bll.GetAllProductInfoByDelFlag(p);
            dgvProductInfo.SelectedRows[0].Selected = false;
        }

        public event EventHandler evtCategory;

        //增加商品类别1
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            ShowFrmChangeCategory(1);
        }
        //修改商品类别2---修改
        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            
            if (dgvCategoryInfo.SelectedRows.Count > 0)
            {
                //获取选中的id
                int id =Convert.ToInt32( dgvCategoryInfo.SelectedRows[0].Cells[0].Value);
                //根据id查询数据
                CategoryInfoBLL bll = new CategoryInfoBLL();
                CategoryInfo cat = bll.GetCategoryInfoByCatId(id);
                cat.Catid = id;
                fea.obj = cat;

                //传对象
                ShowFrmChangeCategory(2);
            }
            else
            {
                MessageBox.Show("请选择要操作的行");
            }
        }
        FrmEventArgs fea = new FrmEventArgs();
        private void ShowFrmChangeCategory(int p)
        {
            FrmChangeCategory fcc = new FrmChangeCategory();
            this.evtCategory += new EventHandler(fcc.SetText);
            fea.Temp = p;
            if (true)
            {
                this.evtCategory(this, fea);
            }
            fcc.FormClosed += new FormClosedEventHandler(fcc_FormClosed);
            fcc.ShowDialog();
        }
        //刷新
        private void fcc_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadCategoryInfoByDelFlag(0);
        }
        
        //删除会员
        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (dgvCategoryInfo.SelectedRows.Count > 0)
            {
                CategoryInfoBLL bll = new CategoryInfoBLL();
                int id = Convert.ToInt32(dgvCategoryInfo.SelectedRows[0].Cells[0].Value);
                if (bll.DeleteCategoryInfoByCatId(id))
                {
                    MessageBox.Show("删除成功");
                    LoadCategoryInfoByDelFlag(0);
                }
                else
                {
                    MessageBox.Show("删除失败");
                }

            }else
            {
                MessageBox.Show("请选择要处理的行");
            }
        }
    }
}
