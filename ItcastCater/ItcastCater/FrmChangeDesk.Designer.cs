﻿namespace ItcastCater
{
    partial class FrmChangeDesk
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labId = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtDeskRegion = new System.Windows.Forms.TextBox();
            this.txtDeskRemark = new System.Windows.Forms.TextBox();
            this.txtDeskName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdRoom = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labId
            // 
            this.labId.AutoSize = true;
            this.labId.Location = new System.Drawing.Point(38, 203);
            this.labId.Name = "labId";
            this.labId.Size = new System.Drawing.Size(0, 12);
            this.labId.TabIndex = 35;
            this.labId.Visible = false;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(120, 198);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(95, 28);
            this.btnOk.TabIndex = 34;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtDeskRegion
            // 
            this.txtDeskRegion.Location = new System.Drawing.Point(95, 144);
            this.txtDeskRegion.Name = "txtDeskRegion";
            this.txtDeskRegion.Size = new System.Drawing.Size(120, 21);
            this.txtDeskRegion.TabIndex = 31;
            // 
            // txtDeskRemark
            // 
            this.txtDeskRemark.Location = new System.Drawing.Point(95, 105);
            this.txtDeskRemark.Name = "txtDeskRemark";
            this.txtDeskRemark.Size = new System.Drawing.Size(120, 21);
            this.txtDeskRemark.TabIndex = 32;
            // 
            // txtDeskName
            // 
            this.txtDeskName.Location = new System.Drawing.Point(95, 70);
            this.txtDeskName.Name = "txtDeskName";
            this.txtDeskName.Size = new System.Drawing.Size(120, 21);
            this.txtDeskName.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "餐桌描述";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 29;
            this.label3.Text = "餐桌备注";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "餐桌编号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 27;
            this.label1.Text = "房间";
            // 
            // cmdRoom
            // 
            this.cmdRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdRoom.FormattingEnabled = true;
            this.cmdRoom.Location = new System.Drawing.Point(95, 27);
            this.cmdRoom.Name = "cmdRoom";
            this.cmdRoom.Size = new System.Drawing.Size(120, 20);
            this.cmdRoom.TabIndex = 26;
            // 
            // FrmChangeDesk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(282, 288);
            this.Controls.Add(this.labId);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtDeskRegion);
            this.Controls.Add(this.txtDeskRemark);
            this.Controls.Add(this.txtDeskName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdRoom);
            this.Name = "FrmChangeDesk";
            this.Text = "FrmChangeDesk";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labId;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtDeskRegion;
        private System.Windows.Forms.TextBox txtDeskRemark;
        private System.Windows.Forms.TextBox txtDeskName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmdRoom;
    }
}