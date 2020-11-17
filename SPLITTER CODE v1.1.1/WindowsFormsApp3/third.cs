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
        public static controller controller = new controller();
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
            this.DoubleBuffered = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            pb_tutorials.Image = Splitter.Properties.Resources.tutorial_find_keyword1;
            /*
            controller.slide_desc_bar();
            string txt = "Untuk Dapat Memperoleh Data Dari Suatu Keyword Mula-Mula User Harus Memilih Menu Keyword Planner Pada Google Adwords";
            controller.description_message("Pilih Menu Keyword Planner", txt);
            */
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            pb_tutorials.Image = Splitter.Properties.Resources.tutorial_find_keyword2;
            /*
            controller.slide_desc_bar();
            string txt = "Setelah Memilih Menu Keyword Planner, User Memasukkan Kata Kunci Yang Ingin Diperoleh Datanya";
            controller.description_message("Kata Kunci Baru", txt);
            */
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            pb_tutorials.Image = Splitter.Properties.Resources.tutorial_find_keyword3;
            /*
            controller.slide_desc_bar();
            string txt = "User Diminta Untuk Memasukkan Keyword Yang Ingin Diperoleh Data Statistiknya Dari Google Adwords";
            controller.description_message("Input Ads Keywords", txt);
            */
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            pb_tutorials.Image = Splitter.Properties.Resources.keyword_analyze_1;
            /*
            controller.slide_desc_bar();
            string txt = "Ditampilkan Berbagai Group Iklan";
            controller.description_message("Show GroupAds", txt);
            */
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            pb_tutorials.Image = Splitter.Properties.Resources.tutorial_find_keyword4;
            /*
            controller.slide_desc_bar();
            string txt = "Ditampilkan Data Statisik Dari Suatu Group Iklan";
            controller.description_message("Analysis Group Ads", txt);
            */
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            pb_tutorials.Image = Splitter.Properties.Resources.keyword_analyze_2;
            /*
            controller.slide_desc_bar();
            string txt = "Setelah Ditampilkan Data Statistik Dari Suatu Group Iklan, Pengguna Data Mengunduh Berkas Tersebut";
            controller.description_message("Export Group Ads", txt);
            */
        }

        private void UserManuals_MouseEnter(object sender, EventArgs e)
        {
            controller.slide_desc_bar();
            string txt = "Ditampilkan Hasil Perhitungan Dari Proses FAHP Untuk Menentukan Group Iklan Terbaik" +
                "\r\n\r\nPetunjuk:" +
                "\r\n\r\n1. Ditampilkan Hasil Perhitungan Synthesis Of Prioriry Dan Logical Consistancy Dari Semua Kriteria";
            controller.description_message("User Manuals", txt);
        }

        private void Choose_keywordPlanner_MouseEnter(object sender, EventArgs e)
        {
            controller.slide_desc_bar();
            string txt = "Untuk Dapat Memperoleh Data Dari Suatu Keyword Mula-Mula User Harus Memilih Menu Keyword Planner Pada Google Adwords";
            controller.description_message("Pilih Menu Keyword Planner", txt);
        }

        private void NewKeyword_MouseEnter(object sender, EventArgs e)
        {
            controller.slide_desc_bar();
            string txt = "Setelah Memilih Menu Keyword Planner, User Memasukkan Kata Kunci Yang Ingin Diperoleh Datanya";
            controller.description_message("Kata Kunci Baru", txt);
        }

        private void Input_keyword_MouseEnter(object sender, EventArgs e)
        {
            controller.slide_desc_bar();
            string txt = "User Diminta Untuk Memasukkan Keyword Yang Ingin Diperoleh Data Statistiknya Dari Google Adwords";
            controller.description_message("Input Ads Keywords", txt);
        }

        private void Show_Groupsads_MouseEnter(object sender, EventArgs e)
        {
            controller.slide_desc_bar();
            string txt = "Ditampilkan Berbagai Group Iklan";
            controller.description_message("Show GroupAds", txt);
        }

        private void Export_Groupsads_MouseEnter(object sender, EventArgs e)
        {
            controller.slide_desc_bar();
            string txt = "Setelah Ditampilkan Data Statistik Dari Suatu Group Iklan, Pengguna Data Mengunduh Berkas Tersebut";
            controller.description_message("Export Group Ads", txt);
        }

        private void Analysis_Groupsads_MouseEnter(object sender, EventArgs e)
        {
            controller.slide_desc_bar();
            string txt = "Ditampilkan Data Statisik Dari Suatu Group Iklan";
            controller.description_message("Analysis Group Ads", txt);
        }

        private void UserManuals_MouseLeave(object sender, EventArgs e)
        {
            controller.slide_desc_bar();
            //controller.description_message();
        }

    }
}
