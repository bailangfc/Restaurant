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
    public partial class FrmChangeMemmber : Form
    {
        public FrmChangeMemmber()
        {
            InitializeComponent();
        }

        public void LoadMemmberType()
        {
            MemmberTypeBLL bll = new MemmberTypeBLL();
            List<MemmberType> list = bll.GetAllMemmberTypeByDelFlag();
            list.Insert(0, new MemmberType() { MemType = -1, MemTpName = "请选择" });
            cmbMemType.DataSource = list;
            cmbMemType.DisplayMember = "MemTpName";
            cmbMemType.ValueMember = "MemType";
        }
        private int Tp { get; set; }//存标识

        //传值用
        public void SetText(object sender, EventArgs e)
        {
            LoadMemmberType();
            FrmEventArgs fea = e as FrmEventArgs;
            this.Tp = fea.Temp;
            //if (fea.Temp==1)
            //{
                foreach(Control item in this.Controls)
                {
                    if(item is TextBox)
                    {
                        TextBox tb = item as TextBox;//把控件转成文本框
                        tb.Text = "";
                    }
                }
            //}else if(fea.Temp==2)//修改
            if(fea.Temp==2)
            {
                MemmberInfo mem = fea.obj as MemmberInfo;
                txtBirs.Text = mem.MemBirthdaty.ToString();
                txtMemDiscount.Text = mem.MemDiscount.ToString();
                txtMemIntegral.Text = mem.MemIntegral.ToString();
                txtmemMoney.Text = mem.MemMoney.ToString();
                txtMemName.Text = mem.MemName;
                txtMemNum.Text = mem.MemNum;
                txtAddress.Text = mem.MemAddress;
                txtMemPhone.Text = mem.MemMobilePhone;
                cmbMemType.SelectedIndex = mem.MemType;
                rdoMan.Checked = mem.MemGender == "男" ? true : false;
                rdoWomen.Checked = mem.MemGender == "女" ? true : false;
                labId.Text = mem.MemmberId.ToString();
            }else if (fea.Temp == 1)
            {
                txtMemIntegral.Text = "0";
            }
        }
        private void FrmChangeMemmber_Load(object sender, EventArgs e)
        {

        }

        //确定按钮，新增和修改 
        private void btnOk_Click(object sender, EventArgs e)
        {
            MemmberInfo mem = new MemmberInfo();
            if (IsCheck())
            {
                mem.MemAddress = txtAddress.Text;
                mem.MemBirthdaty = Convert.ToDateTime(txtBirs.Text);
                mem.MemDiscount = Convert.ToDecimal(txtMemDiscount.Text);
                mem.MemEndServerTime = dtEndServerTime.Value;
                mem.MemGender = CheckGender();
                mem.MemIntegral = Convert.ToInt32(txtMemIntegral.Text);
                mem.MemMobilePhone = txtMemPhone.Text;
                mem.MemMoney = Convert.ToDecimal(txtmemMoney.Text);
                mem.MemName = txtMemName.Text;
                mem.MemNum = txtMemNum.Text;
                mem.MemType = Convert.ToInt32(cmbMemType.SelectedIndex);
            }
            MemmberInfoBLL bll = new MemmberInfoBLL();
            //新增还是修改
            if (this.Tp == 1)//新增
            {
                mem.DelFlag = 0;
                mem.SubTime = System.DateTime.Now;
                //if (bll.SaveMemmber(mem,this.Tp))
                //{
                //    MessageBox.Show("新增成功");
                //    this.Close();
                //}
                //else
                //{
                //    MessageBox.Show("新增失败");
                //}

            }else if (this.Tp == 2)//修改
            {
                mem.MemmberId = Convert.ToInt32(labId.Text);
                //if (bll.SaveMemmber(mem, this.Tp))
                //{
                //    MessageBox.Show("修改成功");
                //    this.Close();
                //}
                //else
                //{
                //    MessageBox.Show("修改失败");
                //}
            }
            string st = bll.SaveMemmber(mem, this.Tp) ? "操作成功" : "操作失败";
            MessageBox.Show(st);
            this.Close();
          
        }
        //检查男女
        public string CheckGender()
        {
            string str = "";
            if (rdoMan.Checked)
            {
                str = "男";
            }
            else if (rdoWomen.Checked)
            {
                str = "女";
            }
            return str;
        }
        //检查每个文本框是否为空
        public bool IsCheck()
        {
            if (string.IsNullOrEmpty(txtBirs.Text))
            {
                MessageBox.Show("生日不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtMemDiscount.Text))
            {
                MessageBox.Show("折扣不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtMemIntegral.Text))
            {
                MessageBox.Show("积分不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtmemMoney.Text))
            {
                MessageBox.Show("余额不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtMemName.Text))
            {
                MessageBox.Show("名字不能为空");
                return false;

            }
            if (string.IsNullOrEmpty(txtMemNum.Text))
            {
                MessageBox.Show("编号不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtMemPhone.Text))
            {
                MessageBox.Show("电话不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(dtEndServerTime.Text))
            {
                MessageBox.Show("有效期不能为空");
                return false;
            }
            return true;
        }

    }
}
