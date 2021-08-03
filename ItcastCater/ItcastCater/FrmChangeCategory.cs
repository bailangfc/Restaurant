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
    public partial class FrmChangeCategory : Form
    {
        public FrmChangeCategory()
        {
            InitializeComponent();
        }
        private int Tp { get; set; }

        //注册事件的方法
        public void SetText(object sender,EventArgs e)
        {
            //清空文本框
            foreach (Control item in this.Controls)
            {
                if(item is TextBox)
                {
                    TextBox tb = item as TextBox;
                    tb.Text = "";
                }
            }

            FrmEventArgs fea = e as FrmEventArgs;
            this.Tp = fea.Temp;
            if (fea.Temp == 2)
            {
                CategoryInfo cat = fea.obj as CategoryInfo;
                txtCName.Text = cat.Catname;
                txtCNum.Text = cat.Catnum;
                txtCRemark.Text = cat.Remark;
                labId.Text = cat.Catid.ToString();
            }


        }
        private void FrmChangeCategory_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //判断是新增还是修改
            if (CheckEmpty())
            {
                CategoryInfoBLL bll = new CategoryInfoBLL();
                CategoryInfo cat = new CategoryInfo();
                cat.Catname = txtCName.Text;
                cat.Catnum = txtCNum.Text;
                cat.Remark = txtCRemark.Text;
                if (this.Tp == 1)
                {
                    cat.Delflag = 0;
                    cat.Subtime = DateTime.Now;
                    cat.Subby = 1;
                }else if (this.Tp == 2)
                {
                    cat.Catid = Convert.ToInt32(labId.Text);
                }
                string msg = bll.SaveCategory(cat, this.Tp) ? "操作成功" : "操作失败";
                MessageBox.Show(msg);
                this.Close();
            }
        }

        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty( txtCName.Text))
            {
                MessageBox.Show("商品名字不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtCNum.Text))
            {
                MessageBox.Show("商品编号不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtCRemark.Text))
            {
                MessageBox.Show("备注不能为空");
                return false;
            }
            return true;
        }
    }
}
