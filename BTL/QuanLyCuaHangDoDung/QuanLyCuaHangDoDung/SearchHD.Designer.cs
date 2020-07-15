namespace QuanLyCuaHangDoDung
{
    partial class SearchHD
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewHD = new System.Windows.Forms.DataGridView();
            this.dateTimePickerNgay = new System.Windows.Forms.DateTimePicker();
            this.buttonSearchByDate = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.buttonSearchByKH = new System.Windows.Forms.Button();
            this.comboBoxSearchByKH = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewCTHD = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCTHD)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewHD);
            this.groupBox1.Controls.Add(this.dateTimePickerNgay);
            this.groupBox1.Controls.Add(this.buttonSearchByDate);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.buttonSearchByKH);
            this.groupBox1.Controls.Add(this.comboBoxSearchByKH);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 450);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hóa Đơn";
            // 
            // dataGridViewHD
            // 
            this.dataGridViewHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewHD.Location = new System.Drawing.Point(3, 166);
            this.dataGridViewHD.Name = "dataGridViewHD";
            this.dataGridViewHD.Size = new System.Drawing.Size(364, 281);
            this.dataGridViewHD.TabIndex = 25;
            this.dataGridViewHD.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHD_CellClick);
            // 
            // dateTimePickerNgay
            // 
            this.dateTimePickerNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNgay.Location = new System.Drawing.Point(98, 78);
            this.dateTimePickerNgay.Name = "dateTimePickerNgay";
            this.dateTimePickerNgay.Size = new System.Drawing.Size(104, 20);
            this.dateTimePickerNgay.TabIndex = 24;
            // 
            // buttonSearchByDate
            // 
            this.buttonSearchByDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(133)))), ((int)(((byte)(208)))));
            this.buttonSearchByDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonSearchByDate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSearchByDate.Location = new System.Drawing.Point(208, 78);
            this.buttonSearchByDate.Name = "buttonSearchByDate";
            this.buttonSearchByDate.Size = new System.Drawing.Size(138, 23);
            this.buttonSearchByDate.TabIndex = 23;
            this.buttonSearchByDate.Text = "Tìm kiếm theo ngày bán";
            this.buttonSearchByDate.UseVisualStyleBackColor = false;
            this.buttonSearchByDate.Click += new System.EventHandler(this.buttonSearchByDate_Click);
            // 
            // label31
            // 
            this.label31.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(39, 68);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(53, 13);
            this.label31.TabIndex = 21;
            this.label31.Text = "Ngày bán";
            // 
            // buttonSearchByKH
            // 
            this.buttonSearchByKH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(133)))), ((int)(((byte)(208)))));
            this.buttonSearchByKH.FlatAppearance.BorderSize = 0;
            this.buttonSearchByKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchByKH.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSearchByKH.Location = new System.Drawing.Point(208, 49);
            this.buttonSearchByKH.Name = "buttonSearchByKH";
            this.buttonSearchByKH.Size = new System.Drawing.Size(138, 23);
            this.buttonSearchByKH.TabIndex = 20;
            this.buttonSearchByKH.Text = "Tìm kiếm theo khách hàng";
            this.buttonSearchByKH.UseVisualStyleBackColor = false;
            this.buttonSearchByKH.Click += new System.EventHandler(this.buttonSearchByKH_Click);
            // 
            // comboBoxSearchByKH
            // 
            this.comboBoxSearchByKH.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxSearchByKH.FormattingEnabled = true;
            this.comboBoxSearchByKH.Location = new System.Drawing.Point(98, 33);
            this.comboBoxSearchByKH.Name = "comboBoxSearchByKH";
            this.comboBoxSearchByKH.Size = new System.Drawing.Size(104, 21);
            this.comboBoxSearchByKH.TabIndex = 19;
            // 
            // label30
            // 
            this.label30.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(25, 33);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(67, 13);
            this.label30.TabIndex = 18;
            this.label30.Text = "Khách Hàng";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(370, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(15, 450);
            this.panel1.TabIndex = 3;
            // 
            // dataGridViewCTHD
            // 
            this.dataGridViewCTHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCTHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCTHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCTHD.Location = new System.Drawing.Point(385, 0);
            this.dataGridViewCTHD.Name = "dataGridViewCTHD";
            this.dataGridViewCTHD.Size = new System.Drawing.Size(415, 450);
            this.dataGridViewCTHD.TabIndex = 4;
            // 
            // SearchHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewCTHD);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "SearchHD";
            this.Text = "Tìm Kiếm Hóa Đơn";
            this.Load += new System.EventHandler(this.SearchHD_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCTHD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewHD;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgay;
        private System.Windows.Forms.Button buttonSearchByDate;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Button buttonSearchByKH;
        private System.Windows.Forms.ComboBox comboBoxSearchByKH;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewCTHD;
    }
}