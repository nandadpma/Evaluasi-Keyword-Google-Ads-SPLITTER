namespace WindowsFormsApp3
{
    partial class second
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_jenis_iklan = new System.Windows.Forms.DataGridView();
            this.jenis_iklan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BNP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loadData = new System.Windows.Forms.Button();
            this.dgv_rating_keyword = new System.Windows.Forms.DataGridView();
            this.keyword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.klick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tyg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.biaya = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ahp_score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_manuals = new System.Windows.Forms.DataGridView();
            this.gb_ManualisasiFAHP = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.bt_showhide_manuals = new System.Windows.Forms.Button();
            this.lb_bestAds = new System.Windows.Forms.Label();
            this.labelBestAds = new System.Windows.Forms.Label();
            this.bt_DetailsAds = new System.Windows.Forms.Button();
            this.bt_kDetails = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_jenis_iklan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rating_keyword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_manuals)).BeginInit();
            this.gb_ManualisasiFAHP.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_jenis_iklan
            // 
            this.dgv_jenis_iklan.AllowUserToAddRows = false;
            this.dgv_jenis_iklan.AllowUserToDeleteRows = false;
            this.dgv_jenis_iklan.AllowUserToOrderColumns = true;
            this.dgv_jenis_iklan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_jenis_iklan.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_jenis_iklan.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_jenis_iklan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_jenis_iklan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_jenis_iklan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.jenis_iklan,
            this.BNP});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_jenis_iklan.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_jenis_iklan.Location = new System.Drawing.Point(17, 58);
            this.dgv_jenis_iklan.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_jenis_iklan.Name = "dgv_jenis_iklan";
            this.dgv_jenis_iklan.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_jenis_iklan.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_jenis_iklan.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_jenis_iklan.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_jenis_iklan.Size = new System.Drawing.Size(221, 163);
            this.dgv_jenis_iklan.TabIndex = 0;
            this.dgv_jenis_iklan.Visible = false;
            this.dgv_jenis_iklan.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_jenis_iklan_CellContentDoubleClick);
            this.dgv_jenis_iklan.MouseEnter += new System.EventHandler(this.desc_GA_SelectGroup_MouseEnter);
            this.dgv_jenis_iklan.MouseLeave += new System.EventHandler(this.desc_GA_MouseLeave);
            // 
            // jenis_iklan
            // 
            this.jenis_iklan.HeaderText = "Jenis Iklan";
            this.jenis_iklan.Name = "jenis_iklan";
            this.jenis_iklan.ReadOnly = true;
            // 
            // BNP
            // 
            this.BNP.HeaderText = "BNP";
            this.BNP.Name = "BNP";
            this.BNP.ReadOnly = true;
            // 
            // loadData
            // 
            this.loadData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadData.Location = new System.Drawing.Point(9, 13);
            this.loadData.Name = "loadData";
            this.loadData.Size = new System.Drawing.Size(229, 37);
            this.loadData.TabIndex = 1;
            this.loadData.Text = "Load All Data";
            this.loadData.UseVisualStyleBackColor = true;
            this.loadData.Click += new System.EventHandler(this.loadData_Click);
            this.loadData.MouseEnter += new System.EventHandler(this.desc_GA_LoadFile_MouseEnter);
            this.loadData.MouseLeave += new System.EventHandler(this.desc_GA_MouseLeave);
            // 
            // dgv_rating_keyword
            // 
            this.dgv_rating_keyword.AllowUserToAddRows = false;
            this.dgv_rating_keyword.AllowUserToDeleteRows = false;
            this.dgv_rating_keyword.AllowUserToOrderColumns = true;
            this.dgv_rating_keyword.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_rating_keyword.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_rating_keyword.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_rating_keyword.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_rating_keyword.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_rating_keyword.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.keyword,
            this.klick,
            this.tyg,
            this.CTR,
            this.SK,
            this.pos,
            this.biaya,
            this.ahp_score});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_rating_keyword.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_rating_keyword.Location = new System.Drawing.Point(252, 13);
            this.dgv_rating_keyword.Name = "dgv_rating_keyword";
            this.dgv_rating_keyword.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_rating_keyword.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_rating_keyword.RowHeadersVisible = false;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_rating_keyword.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_rating_keyword.Size = new System.Drawing.Size(696, 412);
            this.dgv_rating_keyword.TabIndex = 2;
            this.dgv_rating_keyword.MouseEnter += new System.EventHandler(this.desc_GA_GroupResult_MouseEnter);
            this.dgv_rating_keyword.MouseLeave += new System.EventHandler(this.desc_GA_MouseLeave);
            // 
            // keyword
            // 
            this.keyword.HeaderText = "Keyword";
            this.keyword.Name = "keyword";
            this.keyword.ReadOnly = true;
            // 
            // klick
            // 
            this.klick.HeaderText = "Klik";
            this.klick.Name = "klick";
            this.klick.ReadOnly = true;
            // 
            // tyg
            // 
            this.tyg.HeaderText = "Jumlah Tayang";
            this.tyg.Name = "tyg";
            this.tyg.ReadOnly = true;
            // 
            // CTR
            // 
            this.CTR.HeaderText = "CTR";
            this.CTR.Name = "CTR";
            this.CTR.ReadOnly = true;
            // 
            // SK
            // 
            this.SK.HeaderText = "Score Kualitas";
            this.SK.Name = "SK";
            this.SK.ReadOnly = true;
            // 
            // pos
            // 
            this.pos.HeaderText = "Posisi Rata-rata";
            this.pos.Name = "pos";
            this.pos.ReadOnly = true;
            // 
            // biaya
            // 
            this.biaya.HeaderText = "Biaya Iklan";
            this.biaya.Name = "biaya";
            this.biaya.ReadOnly = true;
            // 
            // ahp_score
            // 
            this.ahp_score.HeaderText = "AHP Score";
            this.ahp_score.Name = "ahp_score";
            this.ahp_score.ReadOnly = true;
            // 
            // dgv_manuals
            // 
            this.dgv_manuals.AllowUserToAddRows = false;
            this.dgv_manuals.AllowUserToDeleteRows = false;
            this.dgv_manuals.AllowUserToOrderColumns = true;
            this.dgv_manuals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_manuals.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_manuals.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_manuals.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_manuals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_manuals.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgv_manuals.Location = new System.Drawing.Point(602, 13);
            this.dgv_manuals.Name = "dgv_manuals";
            this.dgv_manuals.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_manuals.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_manuals.RowHeadersVisible = false;
            this.dgv_manuals.Size = new System.Drawing.Size(622, 412);
            this.dgv_manuals.TabIndex = 7;
            this.dgv_manuals.Visible = false;
            // 
            // gb_ManualisasiFAHP
            // 
            this.gb_ManualisasiFAHP.Controls.Add(this.comboBox2);
            this.gb_ManualisasiFAHP.Controls.Add(this.comboBox1);
            this.gb_ManualisasiFAHP.Controls.Add(this.bt_showhide_manuals);
            this.gb_ManualisasiFAHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_ManualisasiFAHP.Location = new System.Drawing.Point(17, 269);
            this.gb_ManualisasiFAHP.Name = "gb_ManualisasiFAHP";
            this.gb_ManualisasiFAHP.Size = new System.Drawing.Size(221, 156);
            this.gb_ManualisasiFAHP.TabIndex = 8;
            this.gb_ManualisasiFAHP.TabStop = false;
            this.gb_ManualisasiFAHP.Text = "Manualisasi Proses FAHP";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Klik",
            "Tayangan",
            "CTR",
            "Skor Kualitas",
            "Posisi Rata-rata",
            "Biaya",
            "Kriteria"});
            this.comboBox2.Location = new System.Drawing.Point(6, 126);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(209, 28);
            this.comboBox2.TabIndex = 9;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.ComboBox2_SelectedIndexChanged);
            this.comboBox2.MouseEnter += new System.EventHandler(this.manualisasi_FAHP_MouseEnter);
            this.comboBox2.MouseLeave += new System.EventHandler(this.desc_GA_MouseLeave);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Synthesis of Priority",
            "Logical Consistancy"});
            this.comboBox1.Location = new System.Drawing.Point(6, 87);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(209, 28);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            this.comboBox1.MouseEnter += new System.EventHandler(this.manualisasi_FAHP_MouseEnter);
            this.comboBox1.MouseLeave += new System.EventHandler(this.desc_GA_MouseLeave);
            // 
            // bt_showhide_manuals
            // 
            this.bt_showhide_manuals.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_showhide_manuals.Location = new System.Drawing.Point(6, 33);
            this.bt_showhide_manuals.Name = "bt_showhide_manuals";
            this.bt_showhide_manuals.Size = new System.Drawing.Size(209, 37);
            this.bt_showhide_manuals.TabIndex = 7;
            this.bt_showhide_manuals.Text = "Show Manualisasi FAHP";
            this.bt_showhide_manuals.UseVisualStyleBackColor = true;
            this.bt_showhide_manuals.Click += new System.EventHandler(this.Bt_showhide_manuals_Click);
            this.bt_showhide_manuals.MouseEnter += new System.EventHandler(this.manualisasi_FAHP_MouseEnter);
            this.bt_showhide_manuals.MouseLeave += new System.EventHandler(this.desc_GA_MouseLeave);
            // 
            // lb_bestAds
            // 
            this.lb_bestAds.AutoSize = true;
            this.lb_bestAds.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_bestAds.Location = new System.Drawing.Point(20, 100);
            this.lb_bestAds.Name = "lb_bestAds";
            this.lb_bestAds.Size = new System.Drawing.Size(0, 24);
            this.lb_bestAds.TabIndex = 9;
            // 
            // labelBestAds
            // 
            this.labelBestAds.AutoSize = true;
            this.labelBestAds.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBestAds.Location = new System.Drawing.Point(20, 58);
            this.labelBestAds.Name = "labelBestAds";
            this.labelBestAds.Size = new System.Drawing.Size(0, 24);
            this.labelBestAds.TabIndex = 10;
            // 
            // bt_DetailsAds
            // 
            this.bt_DetailsAds.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_DetailsAds.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_DetailsAds.Location = new System.Drawing.Point(17, 226);
            this.bt_DetailsAds.Name = "bt_DetailsAds";
            this.bt_DetailsAds.Size = new System.Drawing.Size(102, 37);
            this.bt_DetailsAds.TabIndex = 11;
            this.bt_DetailsAds.Text = "Show Details";
            this.bt_DetailsAds.UseVisualStyleBackColor = true;
            this.bt_DetailsAds.Visible = false;
            this.bt_DetailsAds.Click += new System.EventHandler(this.Bt_DetailsAds_Click);
            // 
            // bt_kDetails
            // 
            this.bt_kDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_kDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_kDetails.Location = new System.Drawing.Point(125, 226);
            this.bt_kDetails.Name = "bt_kDetails";
            this.bt_kDetails.Size = new System.Drawing.Size(113, 37);
            this.bt_kDetails.TabIndex = 12;
            this.bt_kDetails.Text = "KW Details";
            this.bt_kDetails.UseVisualStyleBackColor = true;
            this.bt_kDetails.Visible = false;
            this.bt_kDetails.Click += new System.EventHandler(this.Bt_kDetails_Click);
            // 
            // second
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::Splitter.Properties.Resources.rotate_splitterbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.bt_kDetails);
            this.Controls.Add(this.bt_DetailsAds);
            this.Controls.Add(this.labelBestAds);
            this.Controls.Add(this.lb_bestAds);
            this.Controls.Add(this.gb_ManualisasiFAHP);
            this.Controls.Add(this.dgv_manuals);
            this.Controls.Add(this.dgv_rating_keyword);
            this.Controls.Add(this.loadData);
            this.Controls.Add(this.dgv_jenis_iklan);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "second";
            this.Size = new System.Drawing.Size(1253, 443);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_jenis_iklan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rating_keyword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_manuals)).EndInit();
            this.gb_ManualisasiFAHP.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_jenis_iklan;
        private System.Windows.Forms.DataGridViewTextBoxColumn jenis_iklan;
        private System.Windows.Forms.DataGridViewTextBoxColumn BNP;
        private System.Windows.Forms.Button loadData;
        private System.Windows.Forms.DataGridView dgv_rating_keyword;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyword;
        private System.Windows.Forms.DataGridViewTextBoxColumn klick;
        private System.Windows.Forms.DataGridViewTextBoxColumn tyg;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTR;
        private System.Windows.Forms.DataGridViewTextBoxColumn SK;
        private System.Windows.Forms.DataGridViewTextBoxColumn pos;
        private System.Windows.Forms.DataGridViewTextBoxColumn biaya;
        private System.Windows.Forms.DataGridViewTextBoxColumn ahp_score;
        private System.Windows.Forms.DataGridView dgv_manuals;
        private System.Windows.Forms.GroupBox gb_ManualisasiFAHP;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button bt_showhide_manuals;
        private System.Windows.Forms.Label lb_bestAds;
        private System.Windows.Forms.Label labelBestAds;
        private System.Windows.Forms.Button bt_DetailsAds;
        private System.Windows.Forms.Button bt_kDetails;
    }
}
