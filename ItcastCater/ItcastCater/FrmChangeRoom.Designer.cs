﻿namespace ItcastCater
{
    partial class FrmChangeRoom
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
            this.txtIsDeflaut = new System.Windows.Forms.TextBox();
            this.txtRPerNum = new System.Windows.Forms.TextBox();
            this.txtRMinMoney = new System.Windows.Forms.TextBox();
            this.txtRType = new System.Windows.Forms.TextBox();
            this.txtRName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labId
            // 
            this.labId.AutoSize = true;
            this.labId.Location = new System.Drawing.Point(70, 258);
            this.labId.Name = "labId";
            this.labId.Size = new System.Drawing.Size(0, 12);
            this.labId.TabIndex = 39;
            this.labId.Visible = false;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(173, 258);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 38;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtIsDeflaut
            // 
            this.txtIsDeflaut.Location = new System.Drawing.Point(148, 211);
            this.txtIsDeflaut.Name = "txtIsDeflaut";
            this.txtIsDeflaut.Size = new System.Drawing.Size(100, 21);
            this.txtIsDeflaut.TabIndex = 35;
            // 
            // txtRPerNum
            // 
            this.txtRPerNum.Location = new System.Drawing.Point(148, 168);
            this.txtRPerNum.Name = "txtRPerNum";
            this.txtRPerNum.Size = new System.Drawing.Size(100, 21);
            this.txtRPerNum.TabIndex = 34;
            // 
            // txtRMinMoney
            // 
            this.txtRMinMoney.Location = new System.Drawing.Point(148, 124);
            this.txtRMinMoney.Name = "txtRMinMoney";
            this.txtRMinMoney.Size = new System.Drawing.Size(100, 21);
            this.txtRMinMoney.TabIndex = 37;
            // 
            // txtRType
            // 
            this.txtRType.Location = new System.Drawing.Point(148, 86);
            this.txtRType.Name = "txtRType";
            this.txtRType.Size = new System.Drawing.Size(100, 21);
            this.txtRType.TabIndex = 36;
            // 
            // txtRName
            // 
            this.txtRName.Location = new System.Drawing.Point(148, 42);
            this.txtRName.Name = "txtRName";
            this.txtRName.Size = new System.Drawing.Size(100, 21);
            this.txtRName.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 29;
            this.label5.Text = "默认编号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "房间人数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 30;
            this.label3.Text = "最低消费";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 32;
            this.label2.Text = "房间类型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "房间名字";
            // 
            // FrmChangeRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(298, 316);
            this.Controls.Add(this.labId);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtIsDeflaut);
            this.Controls.Add(this.txtRPerNum);
            this.Controls.Add(this.txtRMinMoney);
            this.Controls.Add(this.txtRType);
            this.Controls.Add(this.txtRName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmChangeRoom";
            this.Text = "FrmChangeRoom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labId;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtIsDeflaut;
        private System.Windows.Forms.TextBox txtRPerNum;
        private System.Windows.Forms.TextBox txtRMinMoney;
        private System.Windows.Forms.TextBox txtRType;
        private System.Windows.Forms.TextBox txtRName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}