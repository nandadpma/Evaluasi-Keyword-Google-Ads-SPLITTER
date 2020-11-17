using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public static bool desc_status = false;
        public static bool automatically_show_desc_status = false;
        private static Form1 _instance;
        public static Form1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Form1();
                return _instance;
            }
        }
        public static controller controller = new controller();
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            /*
            if (!panel_side.Controls.Contains(sidebar_uc.Instance))
            {
                panel_side.Controls.Add(sidebar_uc.Instance);
                sidebar_uc.Instance.Dock = DockStyle.Fill;
                sidebar_uc.Instance.BringToFront();
                Console.WriteLine("menambahkan sidebar");
            }
            else
            {
                sidebar_uc.Instance.BringToFront();
                Console.WriteLine("menampilkan sidebar");
            }


            if (!panel1.Controls.Contains(main.Instance))
            {
                panel1.Controls.Add(main.Instance);
                main.Instance.Dock = DockStyle.Fill;
                main.Instance.BringToFront();
                Console.WriteLine("menambahkan main menu");
            }
            else
            {
                main.Instance.BringToFront();
                Console.WriteLine("menampilkan main menu");
            }
            Console.WriteLine("Done");
            */
            /*
            if (!panel_side.Controls.Contains(sidebar_uc.Instance))
            {
                panel_side.Controls.Add(sidebar_uc.Instance);
                sidebar_uc.Instance.Dock = DockStyle.Fill;
                sidebar_uc.Instance.BringToFront();
                Console.WriteLine("menambahkan");
            }
            else
            {
                sidebar_uc.Instance.BringToFront();
                Console.WriteLine("menampilkan yang sudah ada");
            }


            if (!panel1.Controls.Contains(main.Instance))
            {
                panel1.Controls.Add(main.Instance);
                main.Instance.Dock = DockStyle.Fill;
                main.Instance.BringToFront();
                Console.WriteLine("menambahkan");
            }
            else
            {
                main.Instance.BringToFront();
                Console.WriteLine("menampilkan yang sudah ada");
            }
            if (!panel1.Controls.Contains(second.Instance))
            {
                panel1.Controls.Add(second.Instance);
                second.Instance.Dock = DockStyle.Fill;
                second.Instance.SendToBack();
                Console.WriteLine("menambahkan");
            }
            else
            {
                second.Instance.SendToBack();
                Console.WriteLine("menampilkan yang sudah ada");
            }
            if (!panel1.Controls.Contains(third.Instance))
            {
                panel1.Controls.Add(third.Instance);
                third.Instance.Dock = DockStyle.Fill;
                third.Instance.SendToBack();
                Console.WriteLine("menambahkan");
            }
            else
            {
                third.Instance.SendToBack();
                Console.WriteLine("menampilkan yang sudah ada");
            }
            */
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            controller.load_main_screen();
        }

        private void Desc_button_Click(object sender, EventArgs e)
        {
            if (automatically_show_desc_status == false) {
                automatically_show_desc_status = true;
                desc_button.Image = Splitter.Properties.Resources.DescriptionON;
            }
            else if (automatically_show_desc_status == true)
            {
                automatically_show_desc_status = false;
                desc_button.Image = Splitter.Properties.Resources.DescriptionOFF;
            }
            //controller.slide_desc_bar();
        }
    }
}
