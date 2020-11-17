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
    public partial class main : UserControl
    {
        private static main _instance;
        public static main Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new main();
                return _instance;
            }
        }
        public main()
        {
            InitializeComponent();
        }

        private void bt_GA_Click(object sender, EventArgs e)
        {
            sidebar_uc.controller.load_second_screen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sidebar_uc.controller.load_third_screen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sidebar_uc.controller.load_fourth_screen();
        }
    }
}
