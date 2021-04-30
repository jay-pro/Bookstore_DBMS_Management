namespace BuiHaNhi_18110168_QLTiemSach_DMS
{
    partial class Form_Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Menu));
            this.panel_HoaDon = new System.Windows.Forms.Panel();
            this.btnPay = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTong = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.livHoaDon = new System.Windows.Forms.ListView();
            this.panel_Detail = new System.Windows.Forms.Panel();
            this.txtRank = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_Bill = new System.Windows.Forms.Panel();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nuSoluong = new System.Windows.Forms.NumericUpDown();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvMenu = new System.Windows.Forms.DataGridView();
            this.panel_HoaDon.SuspendLayout();
            this.panel_Detail.SuspendLayout();
            this.panel_Bill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuSoluong)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_HoaDon
            // 
            this.panel_HoaDon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_HoaDon.BackgroundImage")));
            this.panel_HoaDon.Controls.Add(this.btnPay);
            this.panel_HoaDon.Controls.Add(this.label6);
            this.panel_HoaDon.Controls.Add(this.txtTong);
            this.panel_HoaDon.Controls.Add(this.btnDelete);
            this.panel_HoaDon.Controls.Add(this.label4);
            this.panel_HoaDon.Controls.Add(this.livHoaDon);
            this.panel_HoaDon.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_HoaDon.Location = new System.Drawing.Point(0, 0);
            this.panel_HoaDon.Name = "panel_HoaDon";
            this.panel_HoaDon.Size = new System.Drawing.Size(321, 548);
            this.panel_HoaDon.TabIndex = 0;
            // 
            // btnPay
            // 
            this.btnPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.Location = new System.Drawing.Point(134, 448);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(181, 41);
            this.btnPay.TabIndex = 21;
            this.btnPay.Text = "Thanh Toán";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(7, 376);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 26);
            this.label6.TabIndex = 20;
            this.label6.Text = "Tổng Tiền";
            // 
            // txtTong
            // 
            this.txtTong.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTong.Location = new System.Drawing.Point(154, 373);
            this.txtTong.Name = "txtTong";
            this.txtTong.Size = new System.Drawing.Size(161, 32);
            this.txtTong.TabIndex = 19;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(17, 448);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(102, 41);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(111, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 29);
            this.label4.TabIndex = 15;
            this.label4.Text = "Receipt";
            // 
            // livHoaDon
            // 
            this.livHoaDon.HideSelection = false;
            this.livHoaDon.Location = new System.Drawing.Point(12, 62);
            this.livHoaDon.Name = "livHoaDon";
            this.livHoaDon.Size = new System.Drawing.Size(303, 299);
            this.livHoaDon.TabIndex = 14;
            this.livHoaDon.UseCompatibleStateImageBehavior = false;
            // 
            // panel_Detail
            // 
            this.panel_Detail.BackColor = System.Drawing.Color.LightCyan;
            this.panel_Detail.Controls.Add(this.txtRank);
            this.panel_Detail.Controls.Add(this.label1);
            this.panel_Detail.Controls.Add(this.btnChange);
            this.panel_Detail.Controls.Add(this.txtHoTen);
            this.panel_Detail.Controls.Add(this.label2);
            this.panel_Detail.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Detail.Location = new System.Drawing.Point(321, 0);
            this.panel_Detail.Name = "panel_Detail";
            this.panel_Detail.Size = new System.Drawing.Size(672, 99);
            this.panel_Detail.TabIndex = 1;
            // 
            // txtRank
            // 
            this.txtRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRank.Location = new System.Drawing.Point(236, 56);
            this.txtRank.Name = "txtRank";
            this.txtRank.Size = new System.Drawing.Size(106, 32);
            this.txtRank.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(18, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 26);
            this.label1.TabIndex = 24;
            this.label1.Text = "Cấp Thành Viên";
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.Color.Aquamarine;
            this.btnChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChange.Location = new System.Drawing.Point(376, 52);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(102, 41);
            this.btnChange.TabIndex = 23;
            this.btnChange.Text = "Sửa";
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Location = new System.Drawing.Point(236, 17);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(225, 32);
            this.txtHoTen.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(18, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 26);
            this.label2.TabIndex = 21;
            this.label2.Text = "Tên Khách Hàng";
            // 
            // panel_Bill
            // 
            this.panel_Bill.BackColor = System.Drawing.Color.Linen;
            this.panel_Bill.Controls.Add(this.btnSelect);
            this.panel_Bill.Controls.Add(this.label3);
            this.panel_Bill.Controls.Add(this.nuSoluong);
            this.panel_Bill.Controls.Add(this.txtTenSP);
            this.panel_Bill.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Bill.Location = new System.Drawing.Point(321, 99);
            this.panel_Bill.Name = "panel_Bill";
            this.panel_Bill.Size = new System.Drawing.Size(672, 101);
            this.panel_Bill.TabIndex = 2;
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.Moccasin;
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Location = new System.Drawing.Point(326, 54);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(207, 41);
            this.btnSelect.TabIndex = 26;
            this.btnSelect.Text = "Chọn Sản Phẩm";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 26);
            this.label3.TabIndex = 25;
            this.label3.Text = "Tên Sản Phẩm";
            // 
            // nuSoluong
            // 
            this.nuSoluong.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuSoluong.Location = new System.Drawing.Point(591, 15);
            this.nuSoluong.Name = "nuSoluong";
            this.nuSoluong.Size = new System.Drawing.Size(59, 34);
            this.nuSoluong.TabIndex = 7;
            // 
            // txtTenSP
            // 
            this.txtTenSP.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtTenSP.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSP.Location = new System.Drawing.Point(200, 17);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.ReadOnly = true;
            this.txtTenSP.Size = new System.Drawing.Size(385, 32);
            this.txtTenSP.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvMenu);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(321, 200);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(672, 348);
            this.panel4.TabIndex = 3;
            // 
            // dgvMenu
            // 
            this.dgvMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMenu.Location = new System.Drawing.Point(0, 0);
            this.dgvMenu.Name = "dgvMenu";
            this.dgvMenu.RowHeadersWidth = 51;
            this.dgvMenu.RowTemplate.Height = 24;
            this.dgvMenu.Size = new System.Drawing.Size(672, 348);
            this.dgvMenu.TabIndex = 0;
            this.dgvMenu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMenu_CellClick);
            // 
            // Form_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 548);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel_Bill);
            this.Controls.Add(this.panel_Detail);
            this.Controls.Add(this.panel_HoaDon);
            this.Name = "Form_Menu";
            this.Text = "Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Menu_FormClosed);
            this.Load += new System.EventHandler(this.Form_Menu_Load);
            this.panel_HoaDon.ResumeLayout(false);
            this.panel_HoaDon.PerformLayout();
            this.panel_Detail.ResumeLayout(false);
            this.panel_Detail.PerformLayout();
            this.panel_Bill.ResumeLayout(false);
            this.panel_Bill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuSoluong)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_HoaDon;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTong;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView livHoaDon;
        private System.Windows.Forms.Panel panel_Detail;
        private System.Windows.Forms.TextBox txtRank;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel_Bill;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nuSoluong;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvMenu;
    }
}