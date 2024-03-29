﻿using System;
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
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }

        private void FrmBilling_Load(object sender, EventArgs e)
        {

        }
        private int ID { get; set; }//用来存储餐桌的id
        public void SetText(object sender, EventArgs e)
        {
            FrmEventArgs fea = e as FrmEventArgs;
            DeskInfo dk = fea.obj as DeskInfo;
            labDeskName.Text = dk.DeskName;
            labRoomType.Text = fea.Name;
            labLittleMoney.Text = fea.Money.ToString();
            this.ID = dk.DeskId;//把餐桌的id存起来
        }
        //确定开单
        private void btnOK_Click(object sender, EventArgs e)
        {
            //开单用了三张表
            //先改变餐桌的状态，需要餐桌的id
            DeskInfoBLL dkBll = new DeskInfoBLL();
            bool dkFlag = dkBll.UpdateDeskStateByDeskId(this.ID, 1);

            //添加一个订单
            OrderInfo order = new OrderInfo();
            order.DelFlag = 0;
            order.OrderState = 1;
            order.Remark = txtPersonCount.Text + "," + txtDescription.Text;
            order.SubBy = 1;
            order.SubTime = System.DateTime.Now;
            OrderInfoBLL orderBll = new OrderInfoBLL();
            //插入一条数据，返回该数据的主键Id
            int orderId = orderBll.AddOrderInfo(order);


            //再把订单的id和餐桌的id存到中间表中
            ROrderDeskBLL rodBll = new ROrderDeskBLL();
            ROrderDesk rod = new ROrderDesk();
            rod.DeskId = this.ID;
            rod.OrderId = orderId;
            bool rodFlag = rodBll.AddROrderDesk(rod);

            //判断
            if (dkFlag && rodFlag)
            {
                MessageBox.Show("开单成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("开单失败");
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
