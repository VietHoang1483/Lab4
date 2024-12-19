namespace Lab04_04
{
    partial class Form1
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
            this.chkCheck = new System.Windows.Forms.CheckBox();
            this.dtpDaugiao = new System.Windows.Forms.DateTimePicker();
            this.dtpCuoigiao = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvQLGH = new System.Windows.Forms.DataGridView();
            this.Stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaydat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaygiao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLGH)).BeginInit();
            this.SuspendLayout();
            // 
            // chkCheck
            // 
            this.chkCheck.AutoSize = true;
            this.chkCheck.Location = new System.Drawing.Point(23, 24);
            this.chkCheck.Name = "chkCheck";
            this.chkCheck.Size = new System.Drawing.Size(160, 20);
            this.chkCheck.TabIndex = 0;
            this.chkCheck.Text = "Xem tất cả trong tháng";
            this.chkCheck.UseVisualStyleBackColor = true;
            this.chkCheck.CheckedChanged += new System.EventHandler(this.chkCheck_CheckedChanged);
            // 
            // dtpDaugiao
            // 
            this.dtpDaugiao.CustomFormat = "dd/MM/yyyy";
            this.dtpDaugiao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDaugiao.Location = new System.Drawing.Point(180, 61);
            this.dtpDaugiao.Name = "dtpDaugiao";
            this.dtpDaugiao.Size = new System.Drawing.Size(150, 22);
            this.dtpDaugiao.TabIndex = 1;
            this.dtpDaugiao.ValueChanged += new System.EventHandler(this.dtpDat_ValueChanged);
            // 
            // dtpCuoigiao
            // 
            this.dtpCuoigiao.CustomFormat = "dd/MM/yyyy";
            this.dtpCuoigiao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCuoigiao.Location = new System.Drawing.Point(380, 61);
            this.dtpCuoigiao.Name = "dtpCuoigiao";
            this.dtpCuoigiao.Size = new System.Drawing.Size(150, 22);
            this.dtpCuoigiao.TabIndex = 1;
            this.dtpCuoigiao.ValueChanged += new System.EventHandler(this.dtpGiao_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Thời Gian Giao Hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "~";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpCuoigiao);
            this.groupBox1.Controls.Add(this.dtpDaugiao);
            this.groupBox1.Controls.Add(this.chkCheck);
            this.groupBox1.Location = new System.Drawing.Point(26, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(549, 106);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Đơn Hàng";
            // 
            // dgvQLGH
            // 
            this.dgvQLGH.AllowUserToAddRows = false;
            this.dgvQLGH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQLGH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Stt,
            this.SoHD,
            this.ngaydat,
            this.ngaygiao,
            this.tien});
            this.dgvQLGH.Location = new System.Drawing.Point(30, 155);
            this.dgvQLGH.Name = "dgvQLGH";
            this.dgvQLGH.RowHeadersWidth = 51;
            this.dgvQLGH.RowTemplate.Height = 24;
            this.dgvQLGH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQLGH.Size = new System.Drawing.Size(944, 281);
            this.dgvQLGH.TabIndex = 4;
            this.dgvQLGH.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQLGH_CellContentClick);
            // 
            // Stt
            // 
            this.Stt.HeaderText = "STT";
            this.Stt.MinimumWidth = 6;
            this.Stt.Name = "Stt";
            this.Stt.Width = 125;
            // 
            // SoHD
            // 
            this.SoHD.HeaderText = "Số Hóa Đơn";
            this.SoHD.MinimumWidth = 6;
            this.SoHD.Name = "SoHD";
            this.SoHD.Width = 125;
            // 
            // ngaydat
            // 
            this.ngaydat.HeaderText = "Ngày Đặt Hàng";
            this.ngaydat.MinimumWidth = 6;
            this.ngaydat.Name = "ngaydat";
            this.ngaydat.Width = 150;
            // 
            // ngaygiao
            // 
            this.ngaygiao.HeaderText = "Ngày Giao Hàng";
            this.ngaygiao.MinimumWidth = 6;
            this.ngaygiao.Name = "ngaygiao";
            this.ngaygiao.Width = 150;
            // 
            // tien
            // 
            this.tien.HeaderText = "Thành Tiền";
            this.tien.MinimumWidth = 6;
            this.tien.Name = "tien";
            this.tien.Width = 125;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(514, 456);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(218, 22);
            this.txtTotal.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(446, 459);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tổng tiền";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 494);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.dgvQLGH);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLGH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkCheck;
        private System.Windows.Forms.DateTimePicker dtpDaugiao;
        private System.Windows.Forms.DateTimePicker dtpCuoigiao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvQLGH;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaydat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaygiao;
        private System.Windows.Forms.DataGridViewTextBoxColumn tien;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label3;
    }
}

