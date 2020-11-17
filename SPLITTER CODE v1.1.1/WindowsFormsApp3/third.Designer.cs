namespace WindowsFormsApp3
{
    partial class third
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.pb_tutorials = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_tutorials)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(5, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(238, 47);
            this.button1.TabIndex = 1;
            this.button1.Text = "Pilih Menu Keyword Planner";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.Choose_keywordPlanner_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.UserManuals_MouseLeave);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(5, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(238, 47);
            this.button2.TabIndex = 2;
            this.button2.Text = "Kata Kunci Baru";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            this.button2.MouseEnter += new System.EventHandler(this.NewKeyword_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.UserManuals_MouseLeave);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(5, 111);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(238, 47);
            this.button3.TabIndex = 3;
            this.button3.Text = "Masukkan Kata Kunci Iklan";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            this.button3.MouseEnter += new System.EventHandler(this.Input_keyword_MouseEnter);
            this.button3.MouseLeave += new System.EventHandler(this.UserManuals_MouseLeave);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(5, 164);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(238, 47);
            this.button4.TabIndex = 4;
            this.button4.Text = "Tampilan Group Iklan";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            this.button4.MouseEnter += new System.EventHandler(this.Show_Groupsads_MouseEnter);
            this.button4.MouseLeave += new System.EventHandler(this.UserManuals_MouseLeave);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(5, 270);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(238, 47);
            this.button5.TabIndex = 5;
            this.button5.Text = "Export Data Group Iklan";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button6_Click);
            this.button5.MouseEnter += new System.EventHandler(this.Export_Groupsads_MouseEnter);
            this.button5.MouseLeave += new System.EventHandler(this.UserManuals_MouseLeave);
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(5, 217);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(238, 47);
            this.button6.TabIndex = 6;
            this.button6.Text = "Analisis Group Iklan";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button5_Click);
            this.button6.MouseEnter += new System.EventHandler(this.Analysis_Groupsads_MouseEnter);
            this.button6.MouseLeave += new System.EventHandler(this.UserManuals_MouseLeave);
            // 
            // pb_tutorials
            // 
            this.pb_tutorials.Location = new System.Drawing.Point(328, 2);
            this.pb_tutorials.Name = "pb_tutorials";
            this.pb_tutorials.Size = new System.Drawing.Size(774, 437);
            this.pb_tutorials.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_tutorials.TabIndex = 7;
            this.pb_tutorials.TabStop = false;
            // 
            // third
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::Splitter.Properties.Resources.rotate_splitterbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pb_tutorials);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "third";
            this.Size = new System.Drawing.Size(1253, 443);
            ((System.ComponentModel.ISupportInitialize)(this.pb_tutorials)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.PictureBox pb_tutorials;
    }
}
