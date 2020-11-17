using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class sidebar_uc : UserControl
    {
        //static Form1 main_form = new Form1();
        public static controller controller = new controller();
        private static sidebar_uc _instance;
        public static sidebar_uc Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new sidebar_uc();
                return _instance;
            }
        }

        //static bool slide_status = false;
        
        public sidebar_uc()
        {
            InitializeComponent();
        }


        private void bt_menu_Click(object sender, EventArgs e)
        {
            controller.slide_sidebar();   
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller.load_main_screen();
            //this.Size = new Size(106, 718);
            //slide_status = false;
            //main_form = new Form1();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controller.load_second_screen();
            //this.Size = new Size(106, 718);
            //slide_status = false;
            //main_form = new Form1();
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            controller.load_third_screen();
            //this.Size = new Size(106, 718);
            //slide_status = false;
            //main_form = new Form1();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            controller.load_fourth_screen();
        }
    }
}
