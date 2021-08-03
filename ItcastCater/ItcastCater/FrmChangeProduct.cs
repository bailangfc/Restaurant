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
    public partial class FrmChangeProduct : Form
    {
        public FrmChangeProduct()
        {
            InitializeComponent();
        }

        public void LoadCategoryType()
        {
            CategoryInfoBLL bll = new CategoryInfoBLL();
            List<CategoryInfo> list = bll.GetAllCategoryInfoByDelFlag(0);
            list.Insert(0, new CategoryInfo() { Catid = -1, Catname = "请选择" });
            cmbCategory.DataSource = list;
            cmbCategory.DisplayMember = "Catname";
            cmbCategory.ValueMember = "Catid";

        }



        private int Tp { get; set; }
        public void SetText(object sender,EventArgs e)
        {
            //清空文本框的值
            foreach (Control item in this.Controls)
            {
                if(item is TextBox)
                {
                    TextBox tb = item as TextBox;
                    tb.Text = "";
                }
            }

            FrmEventArgs feas = e as FrmEventArgs;
            this.Tp = feas.Temp;
            LoadCategoryType();
            if (feas.Temp == 2)
            {
                ProductInfo pro = feas.obj as ProductInfo;
                txtName.Text = pro.ProName;
                txtNum.Text = pro.ProNum;
                txtCost.Text = pro.ProCost.ToString();
                txtPrice.Text = pro.ProPrice.ToString();
                txtSpell.Text = pro.ProSpell;
                txtUnit.Text = pro.ProUnit;
                txtStock.Text = pro.ProStock.ToString();
                txtRemark.Text = pro.Remark;
                labId.Text = pro.ProId.ToString();
                cmbCategory.SelectedValue = pro.CatId;

            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CheckEmpty())
            {
                ProductInfo pro = new ProductInfo();
                pro.CatId = Convert.ToInt32(cmbCategory.SelectedValue);
                pro.ProCost = Convert.ToDecimal(txtCost.Text);
                pro.ProName = txtName.Text;
                pro.ProNum = txtNum.Text;
                pro.ProPrice = Convert.ToDecimal(txtPrice.Text);
                pro.ProSpell = txtSpell.Text;
                pro.ProStock = Convert.ToDecimal(txtStock.Text);
                pro.ProUnit = txtUnit.Text;
                pro.Remark = txtRemark.Text;

                if (this.Tp == 1)
                {
                    pro.DelFlag = 0;
                    pro.SubBy = 1;
                    pro.SubTime = System.DateTime.Now;
                }else if (this.Tp == 2)
                {
                    pro.ProId = Convert.ToInt32(labId.Text);
                }

                ProductInfoBLL bll = new ProductInfoBLL();
                string msg = bll.SaveProduct(pro, this.Tp) ? "操作成功" : "操作失败";
                MessageBox.Show(msg);
                this.Close();
            }

        }

        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(txtCost.Text))
            {
                MessageBox.Show("商品成本不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("商品名称不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtNum.Text))
            {
                MessageBox.Show("商品编号不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("商品价格不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtRemark.Text))
            {
                MessageBox.Show("商品备注不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtSpell.Text))
            {
                MessageBox.Show("商品拼音不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtStock.Text))
            {
                MessageBox.Show("商品库存不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtUnit.Text))
            {
                MessageBox.Show("商品单位不能为空");
                return false;
            }
            return true;
        }
    }
}
