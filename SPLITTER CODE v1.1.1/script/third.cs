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
    public partial class third : UserControl
    {
        private static third _instance;
        public static third Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new third();
                return _instance;
            }
        }
        public third()
        {
            InitializeComponent();
        }
    }
}
