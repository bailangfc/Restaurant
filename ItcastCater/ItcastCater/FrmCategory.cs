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
            //显示商品类别
            LoadCategoryInfoByDelFlag(0);
            //显示产品
            LoadProductInfoByDelFlag(0);
            //加载商品类别
            LoadCategory();
        }

         private void LoadCategory()
        {
            CategoryInfoBLL bll = new CategoryInfoBLL();
            List<CategoryInfo> list = bll.GetAllCategoryInfoByDelFlag(0);
            list.Insert(0,new CategoryInfo() { Catid=-1,Catname="请选择"});
            cmbCategory.DataSource = list;
            cmbCategory.DisplayMember = "Catname";
            cmbCategory.ValueMember = "Catid";
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
        #region 商品类别的增删改
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
        
        //删除商品类别
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
        #endregion

        #region 产品的增删改
        public event EventHandler evtPro;
        FrmEventArgs feas = new FrmEventArgs();
        private void btnAddPro_Click(object sender, EventArgs e)
        {
            ShowFrmChangeProduct(1);
        }

        private void btnUpdatePro_Click(object sender, EventArgs e)
        {
            if (dgvProductInfo.SelectedRows.Count > 0)
            {
                //获取要修改的产品的Id
                //根据id查询该行数据是否真的存在--要获取该行数据
                //把对象传到另一个窗体中---对象
                int id = Convert.ToInt32(dgvProductInfo.SelectedRows[0].Cells[0].Value);
                ProductInfoBLL bll = new ProductInfoBLL();
                ProductInfo pro = bll.GetProductInfoByProId(id);
                pro.ProId = id;
                feas.obj = pro;
                ShowFrmChangeProduct(2);
            }
            else
            {
                MessageBox.Show("请选择要操作的行");
            }
            
        }

        public void ShowFrmChangeProduct(int p)
        {
            FrmChangeProduct fcp = new FrmChangeProduct();
            this.evtPro += new EventHandler(fcp.SetText);
            feas.Temp = p;
            if (true)
            {
                this.evtPro(this, feas);
            }
            fcp.FormClosed += new FormClosedEventHandler(fcp_FromClosed);
            fcp.ShowDialog();
        }

        private void fcp_FromClosed(object sender, FormClosedEventArgs e)
        {
            LoadProductInfoByDelFlag(0);
        }
        //删除产品
        private void btnDeletePro_Click(object sender, EventArgs e)
        {
            if (dgvProductInfo.SelectedRows.Count > 0)
            {
                ProductInfoBLL bll = new ProductInfoBLL();
                int id = Convert.ToInt32(dgvProductInfo.SelectedRows[0].Cells[0].Value);
                //if (bll.DeleteProductInfo(id))
                //{
                //    MessageBox.Show("删除成功");
                //    LoadProductInfoByDelFlag(0);
                //}
                //else
                //{
                //    MessageBox.Show("删除失败");
                //}
                string msg = bll.DeleteProductInfo(id) ? "操作成功" : "操作失败";
                MessageBox.Show(msg);
                LoadProductInfoByDelFlag(0);

            }else
            {
                MessageBox.Show("请选择要操作的行");
            }
        }
        #endregion

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex == 0)
            {
                LoadProductInfoByDelFlag(0);
            }
            else
            {
                int id =Convert.ToInt32( cmbCategory.SelectedValue);
                ProductInfoBLL bll = new ProductInfoBLL();
                List<ProductInfo> list = bll.GetProductInfoByCatId(id);
                if (list.Count > 0)
                {
                    dgvProductInfo.AutoGenerateColumns = false;
                    dgvProductInfo.DataSource = list;
                    dgvProductInfo.SelectedRows[0].Selected = false;
                }
               
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //搜索
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                ProductInfoBLL bll = new ProductInfoBLL();
                dgvProductInfo.AutoGenerateColumns = false;
                dgvProductInfo.DataSource = bll.GetProductByProNum(txtSearch.Text);
                dgvProductInfo.SelectedRows[0].Selected = false;
            }
            else
            {
                LoadProductInfoByDelFlag(0);
            }
        }
    }
}
