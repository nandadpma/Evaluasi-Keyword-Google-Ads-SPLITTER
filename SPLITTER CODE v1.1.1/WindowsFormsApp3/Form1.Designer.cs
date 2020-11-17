namespace WindowsFormsApp3
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.desc_panel = new System.Windows.Forms.Panel();
            this.desc_message = new System.Windows.Forms.TextBox();
            this.desc_box = new System.Windows.Forms.GroupBox();
            this.desc_button = new System.Windows.Forms.Button();
            this.panel_side = new System.Windows.Forms.Panel();
            this.panel_top = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.desc_panel.SuspendLayout();
            this.panel_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.desc_panel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(97, 221);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1253, 443);
            this.panel1.TabIndex = 2;
            // 
            // desc_panel
            // 
            this.desc_panel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.desc_panel.Controls.Add(this.desc_message);
            this.desc_panel.Controls.Add(this.desc_box);
            this.desc_panel.Controls.Add(this.desc_button);
            this.desc_panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.desc_panel.Location = new System.Drawing.Point(1233, 0);
            this.desc_panel.Name = "desc_panel";
            this.desc_panel.Size = new System.Drawing.Size(20, 443);
            this.desc_panel.TabIndex = 0;
            // 
            // desc_message
            // 
            this.desc_message.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.desc_message.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.desc_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc_message.Location = new System.Drawing.Point(47, 27);
            this.desc_message.Multiline = true;
            this.desc_message.Name = "desc_message";
            this.desc_message.Size = new System.Drawing.Size(246, 386);
            this.desc_message.TabIndex = 11;
            // 
            // desc_box
            // 
            this.desc_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc_box.Location = new System.Drawing.Point(31, 6);
            this.desc_box.Name = "desc_box";
            this.desc_box.Size = new System.Drawing.Size(277, 425);
            this.desc_box.TabIndex = 10;
            this.desc_box.TabStop = false;
            this.desc_box.Text = "Description";
            // 
            // desc_button
            // 
            this.desc_button.BackColor = System.Drawing.Color.Transparent;
            this.desc_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.desc_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc_button.Image = global::Splitter.Properties.Resources.DescriptionOFF;
            this.desc_button.Location = new System.Drawing.Point(0, 0);
            this.desc_button.Name = "desc_button";
            this.desc_button.Size = new System.Drawing.Size(20, 115);
            this.desc_button.TabIndex = 9;
            this.desc_button.UseVisualStyleBackColor = false;
            this.desc_button.Click += new System.EventHandler(this.Desc_button_Click);
            // 
            // panel_side
            // 
            this.panel_side.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel_side.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel_side.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_side.Location = new System.Drawing.Point(0, 0);
            this.panel_side.Name = "panel_side";
            this.panel_side.Size = new System.Drawing.Size(97, 664);
            this.panel_side.TabIndex = 0;
            // 
            // panel_top
            // 
            this.panel_top.BackgroundImage = global::Splitter.Properties.Resources.top3;
            this.panel_top.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_top.Controls.Add(this.button1);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(97, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(1253, 221);
            this.panel_top.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = global::Splitter.Properties.Resources.splitter10;
            this.button1.Location = new System.Drawing.Point(571, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 87);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 664);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_top);
            this.Controls.Add(this.panel_side);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPLITTER";
            this.panel1.ResumeLayout(false);
            this.desc_panel.ResumeLayout(false);
            this.desc_panel.PerformLayout();
            this.panel_top.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel_side;
        private System.Windows.Forms.Panel panel_top;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Panel desc_panel;
        private System.Windows.Forms.Button desc_button;
        public System.Windows.Forms.TextBox desc_message;
        public System.Windows.Forms.GroupBox desc_box;
    }
}

