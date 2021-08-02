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
    }
}
