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
        public static bool sidebar_slide_state = false;
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
            this.DoubleBuffered = true;
        }


        private void bt_menu_Click(object sender, EventArgs e)
        {
            controller.slide_sidebar();   
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //controller.load_main_screen();
            controller.resize_sidebar();
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

        private void desc_GA_MouseEnter(object sender, EventArgs e)
        {
            controller.slide_desc_bar();
            string txt = "Fitur untuk menentukan Group dan Kata kunci terbaik" +
                "\r\n\r\nPetunjuk:" +
                "\r\n\r\n1.Siapkan Data File CSV Hasil Iklan yang dapat di Download Di Dashboard Google Adwords" +
                "\r\n\r\n2.Untuk menentukan Kata Kunci Terbaik anda cukup mengklik setiap file yang sudah di Upload" +
                "\r\n\r\n3.Kriteria yang digunakan adalah Jumlah klik, tayangan, CTR, Skor Kualitas, Posisi rata - rata, Dan Biaya" +
                "\r\n\r\n4.Keputusan Terbaik dapat dilihat dengan cara Mengklik tombol Decision";
            controller.description_message("Groups Analysis",txt);
        }

        private void desc_GA_MouseLeave(object sender, EventArgs e)
        {
            controller.slide_desc_bar();
            controller.description_message();
        }

        private void desc_KA_MouseEnter(object sender, EventArgs e)
        {
            controller.slide_desc_bar();
            string txt = "Fitur untuk menentukan Kata Kunci yang akan digunakan untuk memulai iklan" +
                "\r\n\r\nPetunjuk:" +
                "\r\n\r\n1.Siapkan Data File CSV Rencana Kata Kunci yang dapat di Download di Dashboard Google Adwords" +
                "\r\n\r\n2.Kriteria yang digunakan adalah Jenis Kata Kunci, Volume Pencarian, Harga CPC, dan Kompetisi" +
                "\r\n\r\n3.Tentukan Kata Kunci yang akan digunakan untuk Iklan disini";
            controller.description_message("Keywords Analysis",txt);
        }

        private void desc_KA_MouseLeave(object sender, EventArgs e)
        {
            controller.slide_desc_bar();
            controller.description_message();
        }
        private void desc_UserManuals_MouseEnter(object sender, EventArgs e)
        {
            controller.slide_desc_bar();
            string txt = "Pedoman Pengguna menggunakan software serta pedoman mendapatkan file csv hasil iklan";
            controller.description_message("User Manuals", txt);
        }

        private void desc_UserManuals_MouseLeave(object sender, EventArgs e)
        {
            controller.slide_desc_bar();
            controller.description_message();
        }

    }
}
