﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItcastCater
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

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
    }
}