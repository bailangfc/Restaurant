﻿namespace ItcastCater
{
    partial class FrmRoom
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
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpdateRoom = new System.Windows.Forms.Button();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnAddDesk = new System.Windows.Forms.Button();
            this.dgvDeskInfo = new System.Windows.Forms.DataGridView();
            this.btnUpdateDesk = new System.Windows.Forms.Button();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvRoomInfo = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeskInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "IsDefault";
            this.Column5.HeaderText = "默认编号";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "RoomMaxConsumer";
            this.Column4.HeaderText = "房间人数";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Location = new System.Drawing.Point(517, 53);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(90, 23);
            this.btnAddRoom.TabIndex = 27;
            this.btnAddRoom.Text = "增加房间";
            this.btnAddRoom.UseVisualStyleBackColor = true;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "RoomMinimunConsume";
            this.Column3.HeaderText = "房间最低消费";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "RoomId";
            this.Column1.HeaderText = "房间的id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // btnUpdateRoom
            // 
            this.btnUpdateRoom.Location = new System.Drawing.Point(517, 105);
            this.btnUpdateRoom.Name = "btnUpdateRoom";
            this.btnUpdateRoom.Size = new System.Drawing.Size(90, 23);
            this.btnUpdateRoom.TabIndex = 25;
            this.btnUpdateRoom.Text = "修改房间";
            this.btnUpdateRoom.UseVisualStyleBackColor = true;
            this.btnUpdateRoom.Click += new System.EventHandler(this.btnUpdateRoom_Click);
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "RoomName";
            this.Column2.HeaderText = "房间的名字";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(519, 332);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 29;
            this.btnDelete.Text = "删除餐桌";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(519, 152);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 23);
            this.button3.TabIndex = 26;
            this.button3.Text = "删除房间";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnAddDesk
            // 
            this.btnAddDesk.Location = new System.Drawing.Point(519, 241);
            this.btnAddDesk.Name = "btnAddDesk";
            this.btnAddDesk.Size = new System.Drawing.Size(75, 23);
            this.btnAddDesk.TabIndex = 30;
            this.btnAddDesk.Text = "添加餐桌";
            this.btnAddDesk.UseVisualStyleBackColor = true;
            this.btnAddDesk.Click += new System.EventHandler(this.btnAddDesk_Click);
            // 
            // dgvDeskInfo
            // 
            this.dgvDeskInfo.AllowUserToAddRows = false;
            this.dgvDeskInfo.AllowUserToDeleteRows = false;
            this.dgvDeskInfo.BackgroundColor = System.Drawing.Color.MediumSeaGreen;
            this.dgvDeskInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeskInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column12,
            this.Column11});
            this.dgvDeskInfo.Location = new System.Drawing.Point(26, 230);
            this.dgvDeskInfo.Name = "dgvDeskInfo";
            this.dgvDeskInfo.ReadOnly = true;
            this.dgvDeskInfo.RowHeadersVisible = false;
            this.dgvDeskInfo.RowTemplate.Height = 23;
            this.dgvDeskInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeskInfo.Size = new System.Drawing.Size(472, 165);
            this.dgvDeskInfo.TabIndex = 28;
            // 
            // btnUpdateDesk
            // 
            this.btnUpdateDesk.Location = new System.Drawing.Point(519, 287);
            this.btnUpdateDesk.Name = "btnUpdateDesk";
            this.btnUpdateDesk.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateDesk.TabIndex = 31;
            this.btnUpdateDesk.Text = "修改餐桌";
            this.btnUpdateDesk.UseVisualStyleBackColor = true;
            this.btnUpdateDesk.Click += new System.EventHandler(this.btnUpdateDesk_Click);
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "RoomType";
            this.Column6.HeaderText = "房间类型";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // dgvRoomInfo
            // 
            this.dgvRoomInfo.AllowUserToAddRows = false;
            this.dgvRoomInfo.AllowUserToDeleteRows = false;
            this.dgvRoomInfo.BackgroundColor = System.Drawing.Color.MediumAquamarine;
            this.dgvRoomInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoomInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvRoomInfo.Location = new System.Drawing.Point(26, 24);
            this.dgvRoomInfo.Name = "dgvRoomInfo";
            this.dgvRoomInfo.ReadOnly = true;
            this.dgvRoomInfo.RowHeadersVisible = false;
            this.dgvRoomInfo.RowTemplate.Height = 23;
            this.dgvRoomInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoomInfo.Size = new System.Drawing.Size(472, 186);
            this.dgvRoomInfo.TabIndex = 24;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "DeskId";
            this.dataGridViewTextBoxColumn1.HeaderText = "餐桌id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "DeskName";
            this.Column7.HeaderText = "餐桌编号";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "DeskRegion";
            this.Column8.HeaderText = "餐桌描述";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "DeskStateString";
            this.Column9.HeaderText = "餐桌状态";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "DeskRemark";
            this.Column12.HeaderText = "餐桌备注";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 130;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "RoomId";
            this.Column11.HeaderText = "房间类型";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Visible = false;
            // 
            // FrmRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 433);
            this.Controls.Add(this.btnAddRoom);
            this.Controls.Add(this.btnUpdateRoom);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnAddDesk);
            this.Controls.Add(this.dgvDeskInfo);
            this.Controls.Add(this.btnUpdateDesk);
            this.Controls.Add(this.dgvRoomInfo);
            this.Name = "FrmRoom";
            this.Text = "FrmRoom";
            this.Load += new System.EventHandler(this.FrmRoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeskInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button btnUpdateRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnAddDesk;
        private System.Windows.Forms.DataGridView dgvDeskInfo;
        private System.Windows.Forms.Button btnUpdateDesk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridView dgvRoomInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
    }
}