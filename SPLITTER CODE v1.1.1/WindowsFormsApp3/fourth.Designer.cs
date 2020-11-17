namespace WindowsFormsApp3
{
    partial class fourth
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
            this.bt_loadkeywordFile = new System.Windows.Forms.Button();
            this.dgv_keyword_analysis = new System.Windows.Forms.DataGridView();
            this.keyword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status_keyword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.competition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ahp_score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_keyword_analysis)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_loadkeywordFile
            // 
            this.bt_loadkeywordFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_loadkeywordFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_loadkeywordFile.Location = new System.Drawing.Point(12, 395);
            this.bt_loadkeywordFile.Name = "bt_loadkeywordFile";
            this.bt_loadkeywordFile.Size = new System.Drawing.Size(228, 36);
            this.bt_loadkeywordFile.TabIndex = 4;
            this.bt_loadkeywordFile.Text = "Load Keyword Collection";
            this.bt_loadkeywordFile.UseVisualStyleBackColor = true;
            this.bt_loadkeywordFile.Click += new System.EventHandler(this.bt_loadkeywordFile_Click);
            this.bt_loadkeywordFile.MouseEnter += new System.EventHandler(this.desc_KA_MouseEnter);
            this.bt_loadkeywordFile.MouseLeave += new System.EventHandler(this.desc_KA_MouseLeave);
            // 
            // dgv_keyword_analysis
            // 
            this.dgv_keyword_analysis.AllowUserToAddRows = false;
            this.dgv_keyword_analysis.AllowUserToDeleteRows = false;
            this.dgv_keyword_analysis.AllowUserToOrderColumns = true;
            this.dgv_keyword_analysis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_keyword_analysis.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_keyword_analysis.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_keyword_analysis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_keyword_analysis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_keyword_analysis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.keyword,
            this.status_keyword,
            this.volume,
            this.cpc,
            this.competition,
            this.ahp_score});
            this.dgv_keyword_analysis.Location = new System.Drawing.Point(12, 13);
            this.dgv_keyword_analysis.Name = "dgv_keyword_analysis";
            this.dgv_keyword_analysis.ReadOnly = true;
            this.dgv_keyword_analysis.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_keyword_analysis.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_keyword_analysis.Size = new System.Drawing.Size(904, 376);
            this.dgv_keyword_analysis.TabIndex = 3;
            this.dgv_keyword_analysis.MouseEnter += new System.EventHandler(this.desc_KA_MouseEnter);
            this.dgv_keyword_analysis.MouseLeave += new System.EventHandler(this.desc_KA_MouseLeave);
            // 
            // keyword
            // 
            this.keyword.HeaderText = "Keyword";
            this.keyword.Name = "keyword";
            this.keyword.ReadOnly = true;
            // 
            // status_keyword
            // 
            this.status_keyword.HeaderText = "Keyword Status";
            this.status_keyword.Name = "status_keyword";
            this.status_keyword.ReadOnly = true;
            // 
            // volume
            // 
            this.volume.HeaderText = "Volume Pencarian";
            this.volume.Name = "volume";
            this.volume.ReadOnly = true;
            // 
            // cpc
            // 
            this.cpc.HeaderText = "Harga CPC";
            this.cpc.Name = "cpc";
            this.cpc.ReadOnly = true;
            // 
            // competition
            // 
            this.competition.HeaderText = "Competition";
            this.competition.Name = "competition";
            this.competition.ReadOnly = true;
            // 
            // ahp_score
            // 
            this.ahp_score.HeaderText = "AHP Score";
            this.ahp_score.Name = "ahp_score";
            this.ahp_score.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(246, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "Show More Keywords";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // fourth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::Splitter.Properties.Resources.rotate_splitterbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bt_loadkeywordFile);
            this.Controls.Add(this.dgv_keyword_analysis);
            this.Name = "fourth";
            this.Size = new System.Drawing.Size(1253, 443);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_keyword_analysis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_loadkeywordFile;
        private System.Windows.Forms.DataGridView dgv_keyword_analysis;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyword;
        private System.Windows.Forms.DataGridViewTextBoxColumn status_keyword;
        private System.Windows.Forms.DataGridViewTextBoxColumn volume;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpc;
        private System.Windows.Forms.DataGridViewTextBoxColumn competition;
        private System.Windows.Forms.DataGridViewTextBoxColumn ahp_score;
        private System.Windows.Forms.Button button1;
    }
}
