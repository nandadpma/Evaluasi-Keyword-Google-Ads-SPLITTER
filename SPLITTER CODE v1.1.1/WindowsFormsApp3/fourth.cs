using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp3
{
    public partial class fourth : UserControl
    {
        public static controller controller = new controller();
        private static fourth _instance;
        public static fourth Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new fourth();
                return _instance;
            }
        }
        public fourth()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }
        AHP run_AHP;
        string csv_fname;
        Dataset csv;
        String dirName;
        static bool keyword_detail = false;

        private void bt_loadkeywordFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog chooseTrainfile = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Text Files",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "csv",
                Filter = "csv files (*.csv)|*.csv",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true,
                Multiselect = false
            };
            DialogResult all_csv_file = chooseTrainfile.ShowDialog();
            if (all_csv_file == DialogResult.OK)
            {
                this.dgv_keyword_analysis.Rows.Clear();
                this.csv_fname = chooseTrainfile.FileName;
                this.dirName = (Path.GetDirectoryName(chooseTrainfile.FileName));
                this.csv = new Dataset(csv_fname,true);
                run_AHP = new AHP(this.csv);
                //this.fahp.run_FAHP(this.all_csv);
                /*
                for (int i = 0; i < 5; i++)
                {
                    dgv_keyword_analysis.Rows.Add(run_AHP.data_keyword.keyword[i], run_AHP.data_keyword.status_keyword[i], run_AHP.data_keyword.fitur[i,0], "$"+ run_AHP.data_keyword.fitur[i, 1], run_AHP.data_keyword.fitur[i, 2], run_AHP.rating_keyword[i]);
                    dgv_keyword_analysis.Update();
                }
                */
                show_keyword(false);
                keyword_detail = true;
            }
        }

        public void show_keyword(bool show_more) {
            dgv_keyword_analysis.Rows.Clear();
            if (show_more == true) {
                for (int i = 0; i < run_AHP.data_keyword.keyword.GetLength(0); i++)
                {
                    dgv_keyword_analysis.Rows.Add(run_AHP.data_keyword.keyword[i], run_AHP.data_keyword.status_keyword[i], run_AHP.data_keyword.fitur[i, 0], "$" + run_AHP.data_keyword.fitur[i, 1], run_AHP.data_keyword.fitur[i, 2], run_AHP.rating_keyword[i]);
                    dgv_keyword_analysis.Update();
                }
            }
            else{
                for (int i = 0; i < 5; i++)
                {
                    dgv_keyword_analysis.Rows.Add(run_AHP.data_keyword.keyword[i], run_AHP.data_keyword.status_keyword[i], run_AHP.data_keyword.fitur[i, 0], "$" + run_AHP.data_keyword.fitur[i, 1], run_AHP.data_keyword.fitur[i, 2], run_AHP.rating_keyword[i]);
                    dgv_keyword_analysis.Update();
                }
            }
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

        private void Button1_Click(object sender, EventArgs e)
        {
            if (keyword_detail == true)
            {
                show_keyword(keyword_detail);
                keyword_detail = false;
            }
            else {
                show_keyword(keyword_detail);
                keyword_detail = true;
            }
        }
    }
}
