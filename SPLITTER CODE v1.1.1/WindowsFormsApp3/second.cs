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
    public partial class second : UserControl
    {
        public static controller controller = new controller();
        private static second _instance;
        public static second Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new second();
                return _instance;
            }
        }
        string[] all_csv_fname;
        //List<double[,]> all_csv_file = new List<double[,]>();
        Dataset[] all_csv;
        Dataset selected_ads;
        public static String dirName;
        FAHP fahp = new FAHP();
        static bool showhide_manuals = false;
        static bool ads_detail = false;
        static bool keyword_detail = false;
        static string selected_file = null;
        public static string best_group_ads = null;
        public static double best_group_BNP;
        public second()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            dgv_jenis_iklan.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv_jenis_iklan.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv_rating_keyword.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv_rating_keyword.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv_rating_keyword.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv_rating_keyword.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv_rating_keyword.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv_rating_keyword.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv_rating_keyword.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv_rating_keyword.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            
        }

        private void dgv_jenis_iklan_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = this.dgv_jenis_iklan.CurrentCell.RowIndex;
            //int columnindex = this.dgv_jenis_iklan.CurrentCell.ColumnIndex;
            int columnindex = 0;
            selected_file = dgv_jenis_iklan.Rows[rowindex].Cells[columnindex].Value.ToString();
            string filename = dirName + "\\" + dgv_jenis_iklan.Rows[rowindex].Cells[columnindex].Value.ToString();
            this.selected_ads = new Dataset(filename);
            AHP ahp = new AHP(this.selected_ads, this.fahp);
            keyword_detail = false;
            if (keyword_detail == false) {
                this.dgv_rating_keyword.Rows.Clear();
                for (int i = 0; i < 5; i++)
                {
                    dgv_rating_keyword.Rows.Add(ahp.keyword[i], ahp.fitur[i, 0], ahp.fitur[i, 1], ahp.fitur[i, 2],
                        ahp.fitur[i, 3], ahp.fitur[i, 4], ahp.fitur[i, 5], ahp.rating_keyword[i]);
                    dgv_rating_keyword.Update();
                }
            }
            else{
                this.dgv_rating_keyword.Rows.Clear();
                for (int i = 0; i < ahp.data_iklan.keyword.GetLength(0); i++)
                {
                    dgv_rating_keyword.Rows.Add(ahp.keyword[i], ahp.fitur[i, 0], ahp.fitur[i, 1], ahp.fitur[i, 2],
                        ahp.fitur[i, 3], ahp.fitur[i, 4], ahp.fitur[i, 5], ahp.rating_keyword[i]);
                    dgv_rating_keyword.Update();
                }
            }
            

        }

        private void loadData_Click(object sender, EventArgs e)
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
                Multiselect = true
            };
            DialogResult all_csv_file = chooseTrainfile.ShowDialog();
            if (all_csv_file == DialogResult.OK)
            {
                this.dgv_jenis_iklan.Rows.Clear();
                //this.all_csv_fname = chooseTrainfile.SafeFileNames;
                this.all_csv_fname = chooseTrainfile.FileNames;
                dirName = (Path.GetDirectoryName(chooseTrainfile.FileName));
                this.all_csv = new Dataset[this.all_csv_fname.GetLength(0)];
                int n_file = 0;
                foreach (string csv_fname in all_csv_fname)
                {
                    this.all_csv[n_file] = new Dataset(csv_fname);
                    n_file++;
                }
                this.fahp.run_FAHP(this.all_csv);
                labelBestAds.Text = "Group Iklan Terbaik : ";
                lb_bestAds.Text = best_group_ads;
                selected_file = best_group_ads;
                //dgv_jenis_iklan.Rows.Add(best_group_ads, best_group_BNP);
                //dgv_jenis_iklan.Update();
                
                for (int i = 0; i < this.fahp.all_data.GetLength(0); i++)
                {
                    dgv_jenis_iklan.Rows.Add(this.fahp.all_data[i].filename, Math.Round(this.fahp.BNP[i], 2, MidpointRounding.AwayFromZero).ToString());
                    dgv_jenis_iklan.Update();
                }
                
                show_group_ads(best_group_ads);
                keyword_detail = true;
                bt_DetailsAds.Visible = true;
                bt_kDetails.Visible = true;
            }
        }

        public void show_group_ads(string sads) {
            //this.selected_ads = new Dataset(second.dirName + "\\" + best_group_ads);
            this.selected_ads = new Dataset(second.dirName + "\\" + sads);
            AHP ahp = new AHP(this.selected_ads, this.fahp);
            if (keyword_detail == false)
            {
                this.dgv_rating_keyword.Rows.Clear();
                for (int i = 0; i < 5; i++)
                {
                    dgv_rating_keyword.Rows.Add(ahp.keyword[i], ahp.fitur[i, 0], ahp.fitur[i, 1], ahp.fitur[i, 2],
                        ahp.fitur[i, 3], ahp.fitur[i, 4], Math.Round(ahp.fitur[i, 5], 2, MidpointRounding.AwayFromZero).ToString(), Math.Round(ahp.rating_keyword[i], 2, MidpointRounding.AwayFromZero).ToString());
                    dgv_rating_keyword.Update();
                }
            }
            else
            {
                this.dgv_rating_keyword.Rows.Clear();
                for (int i = 0; i < ahp.data_iklan.keyword.GetLength(0); i++)
                {
                    dgv_rating_keyword.Rows.Add(ahp.keyword[i], ahp.fitur[i, 0], ahp.fitur[i, 1], ahp.fitur[i, 2],
                        ahp.fitur[i, 3], ahp.fitur[i, 4], Math.Round(ahp.fitur[i, 5], 2, MidpointRounding.AwayFromZero).ToString(), Math.Round(ahp.rating_keyword[i], 2, MidpointRounding.AwayFromZero).ToString());
                    dgv_rating_keyword.Update();
                }
            }
        }

        private void Bt_showhide_manuals_Click(object sender, EventArgs e)
        {
            if (showhide_manuals == false)
            {
                bt_showhide_manuals.Text = "Hide Manualisasi FAHP";
                //dgv_rating_keyword.Visible = false;
                //dgv_rating_keyword.Size = new Size(534,412);
                showhide_manuals = true;
                dgv_manuals.Visible = true;
            }
            else if (showhide_manuals == true){
                bt_showhide_manuals.Text = "Show Manualisasi FAHP";
                //dgv_rating_keyword.Size = new Size(696, 412);
                //dgv_rating_keyword.Visible = true;
                showhide_manuals = false;
                dgv_manuals.Visible = false;
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Synthesis of Priority")
            {
                Console.WriteLine("Synthesis of Priority");
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Klik");
                comboBox2.Items.Add("Tayangan");
                comboBox2.Items.Add("CTR");
                comboBox2.Items.Add("Skor Kualitas");
                comboBox2.Items.Add("Posisi Rata-rata");
                comboBox2.Items.Add("Biaya Kata Kunci");
                comboBox2.Items.Add("Semua Kriteria");
            }
            else if (comboBox1.SelectedItem.ToString() == "Logical Consistancy") {
                Console.WriteLine("Logical Consistancy");
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Klik");
                comboBox2.Items.Add("Tayangan");
                comboBox2.Items.Add("CTR");
                comboBox2.Items.Add("Skor Kualitas");
                comboBox2.Items.Add("Posisi Rata-rata");
                comboBox2.Items.Add("Biaya Kata Kunci");
                comboBox2.Items.Add("Semua Kriteria");
                comboBox2.Items.Add("Consistancy Ratio");
            }
        }

        //public double

        public List<string> CR_Manuals(string header, double[,] value)
        {
            string[] LC_header = new string[] { "Ti", "SoP", "Si" };
            double[] x = new double[value.GetLength(0)];
            double[] a = new double[value.GetLength(0)];
            double sum = 0;
            for (int i = 0; i < value.GetLength(0); i++)
            {
                double hasil_kali = 1;
                for (int j = 0; j < value.GetLength(1); j++)
                {
                    hasil_kali = hasil_kali * value[i, j];
                }
                a[i] = Math.Pow(hasil_kali, (1 / Convert.ToDouble(value.GetLength(1))));
                sum = sum + Math.Pow(hasil_kali, (1 / Convert.ToDouble(value.GetLength(1))));
            }
            for (int i = 0; i < x.GetLength(0); i++)
            {
                x[i] = a[i] / sum;
            }
            List<string> manuals_on_table = new List<string>();
            double[] sum_of_columns = new double[value.GetLength(1)];
            manuals_on_table.Add(header);
            sum_of_columns = new double[value.GetLength(1)];
            for (int j = 0; j < value.GetLength(1); j++)
            {
                double sum_of_column = 0;
                for (int k = 0; k < value.GetLength(0); k++)
                {
                    sum_of_column += value[k, j];
                }
                sum_of_columns[j] = sum_of_column;
            }
            double sum_of_Si = 0;
            for (int j = 0; j < x.GetLength(0); j++)
            {
                sum_of_Si += x[j] * sum_of_columns[j];
            }
            manuals_on_table.Add(Math.Round(sum_of_Si, 2, MidpointRounding.AwayFromZero).ToString());
            manuals_on_table.Add(value.GetLength(0).ToString());
            manuals_on_table.Add((value.GetLength(0) - 1).ToString());
            //double Ci = (sum_of_Si - value.GetLength(0)) / (value.GetLength(0) - 1);
            manuals_on_table.Add(Math.Round(((sum_of_Si - value.GetLength(0)) / (value.GetLength(0) - 1)), 2, MidpointRounding.AwayFromZero).ToString());
            manuals_on_table.Add(fahp.bil_random[value.GetLength(0)-1].ToString());
            //double CR = ((sum_of_Si - value.GetLength(0)) / (value.GetLength(0) - 1)) * (fahp.bil_random[value.GetLength(0)]);
            manuals_on_table.Add(Math.Round((((sum_of_Si - value.GetLength(0)) / (value.GetLength(0) - 1)) / (fahp.bil_random[value.GetLength(0) - 1])), 2, MidpointRounding.AwayFromZero).ToString());
            /*
            manuals_on_table.Add(sum_of_Si.ToString());
            manuals_on_table.Add(value.GetLength(0).ToString());
            manuals_on_table.Add((value.GetLength(0) - 1).ToString());
            //double Ci = (sum_of_Si - value.GetLength(0)) / (value.GetLength(0) - 1);
            manuals_on_table.Add(((sum_of_Si - value.GetLength(0)) / (value.GetLength(0) - 1)).ToString());
            manuals_on_table.Add(fahp.bil_random[value.GetLength(0)-1].ToString());
            //double CR = ((sum_of_Si - value.GetLength(0)) / (value.GetLength(0) - 1)) * (fahp.bil_random[value.GetLength(0)]);
            manuals_on_table.Add((((sum_of_Si - value.GetLength(0)) / (value.GetLength(0) - 1)) / (fahp.bil_random[value.GetLength(0)-1])).ToString());
            
            */
            return manuals_on_table;
        }

        public void show_CR_manuals(string header, double[,] value) {

        }

        public void show_Logical_Consistancy(string[] header, double[,] value)
        {
            string[] LC_header = new string[] {"Ti", "SoP", "Si"};
            double [] x = new double[value.GetLength(0)];
            double [] a = new double[value.GetLength(0)];
            double sum = 0;
            for (int i = 0; i < value.GetLength(0); i++)
            {
                double hasil_kali = 1;
                for (int j = 0; j < value.GetLength(1); j++)
                {
                    hasil_kali = hasil_kali * value[i, j];
                }
                a[i] = Math.Pow(hasil_kali, (1 / Convert.ToDouble(value.GetLength(1))));
                sum = sum + Math.Pow(hasil_kali, (1 / Convert.ToDouble(value.GetLength(1))));
            }
            for (int i = 0; i < x.GetLength(0); i++)
            {
                x[i] = a[i]/sum;
            }
            //Math.Round(, 2, MidpointRounding.AwayFromZero)
            List<string>[] manuals_on_table = new List<string>[value.GetLength(0)+3];
            double[] sum_of_columns = new double[value.GetLength(1)];
            for (int i = 0; i < manuals_on_table.GetLength(0); i++) {
                manuals_on_table[i] = new List<string>();
                if (i < value.GetLength(0))
                {
                    manuals_on_table[i].Add(header[i]);
                    for (int j = 0; j < value.GetLength(1); j++) {
                        manuals_on_table[i].Add(Math.Round(value[i, j], 2, MidpointRounding.AwayFromZero).ToString());
                        //manuals_on_table[i].Add(value[i, j].ToString());
                    }
                }
                else if(i == value.GetLength(0))
                {
                    sum_of_columns = new double[value.GetLength(1)];
                    manuals_on_table[i].Add(LC_header[i - value.GetLength(0)]);
                    for (int j = 0; j < value.GetLength(1); j++) {
                        double sum_of_column = 0;
                        for (int k = 0; k < value.GetLength(0); k++)
                        {
                            sum_of_column += value[k,j];
                        }
                        sum_of_columns[j] = sum_of_column;
                        manuals_on_table[i].Add(Math.Round(sum_of_column, 2, MidpointRounding.AwayFromZero).ToString());
                        //manuals_on_table[i].Add(sum_of_column.ToString());
                    }
                }
                else if (i == value.GetLength(0)+1)
                {
                    manuals_on_table[i].Add(LC_header[i - value.GetLength(0)]);
                    for (int j = 0; j < x.GetLength(0); j++)
                    {
                        manuals_on_table[i].Add(Math.Round(x[j], 2, MidpointRounding.AwayFromZero).ToString());
                        //manuals_on_table[i].Add(x[j].ToString());
                    }
                }
                else if (i == value.GetLength(0)+2)
                {
                    manuals_on_table[i].Add(LC_header[i - value.GetLength(0)]);
                    double sum_of_Si = 0;
                    for (int j = 0; j < x.GetLength(0); j++)
                    {
                        sum_of_Si += x[j] * sum_of_columns[j];
                        manuals_on_table[i].Add(Math.Round((x[j] * sum_of_columns[j]), 2, MidpointRounding.AwayFromZero).ToString());
                        //manuals_on_table[i].Add((x[j] * sum_of_columns[j]).ToString());
                    }
                    manuals_on_table[i].Add(Math.Round(sum_of_Si, 2, MidpointRounding.AwayFromZero).ToString());
                    //manuals_on_table[i].Add(sum_of_Si.ToString());
                }
            }
            for (int i = 0; i < manuals_on_table.GetLength(0); i++) {
                dgv_manuals.Rows.Add(manuals_on_table[i].ToArray());
            }

        }

        public void show_Synthesis_of_Priority(string[] header, double[,] value)
        {
            List<string>[] manuals_on_table = new List<string>[value.GetLength(0)];
            double sum = 0;
            for (int i = 0; i < manuals_on_table.GetLength(0); i++)
            {
                manuals_on_table[i] = new List<string>();
                manuals_on_table[i].Add(header[i]);
                double hasil_kali = 1;
                for (int j = 0; j < value.GetLength(1); j++)
                {
                    manuals_on_table[i].Add(Math.Round(value[i, j], 2, MidpointRounding.AwayFromZero).ToString());
                    hasil_kali = hasil_kali * value[i, j];
                }
                manuals_on_table[i].Add(Math.Round(hasil_kali, 2, MidpointRounding.AwayFromZero).ToString());
                double Ai = Math.Pow(hasil_kali, (1 / Convert.ToDouble(value.GetLength(1))));
                manuals_on_table[i].Add(Math.Round(Ai, 2, MidpointRounding.AwayFromZero).ToString());
                sum = sum + Math.Pow(hasil_kali, (1 / Convert.ToDouble(value.GetLength(1))));
            }
            Console.WriteLine("SUM : "+sum.ToString());
            for (int i = 0; i < manuals_on_table.GetLength(0); i++)
            {
                double Xi = (Convert.ToDouble(manuals_on_table[i].LastOrDefault()) / sum);
                manuals_on_table[i].Add(Math.Round(Xi, 2, MidpointRounding.AwayFromZero).ToString());
                dgv_manuals.Rows.Add(manuals_on_table[i].ToArray());
            }
        }
        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Synthesis of Priority")
            {
                if (comboBox2.SelectedItem.ToString() == "Klik") {
                    dgv_manuals.Rows.Clear();
                    dgv_manuals.Columns.Clear();
                    dgv_manuals.Columns.Add("","");
                    dgv_manuals.Columns.Add("Banyak", "Banyak");
                    dgv_manuals.Columns.Add("Sedang", "Sedang");
                    dgv_manuals.Columns.Add("Sedikit", "Sedikit");
                    dgv_manuals.Columns.Add("Hasil Kali", "Hasil kali");
                    dgv_manuals.Columns.Add("Ai", "Ai");
                    dgv_manuals.Columns.Add("Xi", "Xi");
                    //string[] a = new string[]{"a","b"};
                    dgv_manuals.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv_manuals.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv_manuals.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    show_Synthesis_of_Priority(new string[] { "Banyak", "Sedang", "Sedikit" }, fahp.skalaPenilaian_Klik);
                    //dgv_manuals.row
                }
                else if (comboBox2.SelectedItem.ToString() == "Tayangan")
                {
                    dgv_manuals.Rows.Clear();
                    dgv_manuals.Columns.Clear();
                    dgv_manuals.Columns.Add("", "");
                    dgv_manuals.Columns.Add("Banyak", "Banyak");
                    dgv_manuals.Columns.Add("Sedang", "Sedang");
                    dgv_manuals.Columns.Add("Sedikit", "Sedikit");
                    dgv_manuals.Columns.Add("Hasil Kali", "Hasil kali");
                    dgv_manuals.Columns.Add("Ai", "Ai");
                    dgv_manuals.Columns.Add("Xi", "Xi");
                    dgv_manuals.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv_manuals.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv_manuals.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    show_Synthesis_of_Priority(new string[] { "Banyak", "Sedang", "Sedikit" }, fahp.skalaPenilaian_tyg);
                }
                else if (comboBox2.SelectedItem.ToString() == "CTR")
                {
                    dgv_manuals.Rows.Clear();
                    dgv_manuals.Columns.Clear();
                    dgv_manuals.Columns.Add("", "");
                    dgv_manuals.Columns.Add("DiatasRata", "Di atas Rata-rata");
                    dgv_manuals.Columns.Add("Ratarata", "Rata-rata");
                    dgv_manuals.Columns.Add("DibawahRata", "Di Bawah Rata-rata");
                    dgv_manuals.Columns.Add("Hasil Kali", "Hasil kali");
                    dgv_manuals.Columns.Add("Ai", "Ai");
                    dgv_manuals.Columns.Add("Xi", "Xi");
                    dgv_manuals.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv_manuals.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv_manuals.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    show_Synthesis_of_Priority(new string[] { "Di Atas Rata-rata", "Rata-rata", "Di Bawah Rata-rata" }, fahp.skalaPenilaian_CTR);
                }
                else if (comboBox2.SelectedItem.ToString() == "Skor Kualitas")
                {
                    dgv_manuals.Rows.Clear();
                    dgv_manuals.Columns.Clear();
                    dgv_manuals.Columns.Add("", "");
                    dgv_manuals.Columns.Add("Tinggi", "Tinggi");
                    dgv_manuals.Columns.Add("Sedang", "Sedang");
                    dgv_manuals.Columns.Add("Rendah", "Rendah");
                    dgv_manuals.Columns.Add("Hasil Kali", "Hasil kali");
                    dgv_manuals.Columns.Add("Ai", "Ai");
                    dgv_manuals.Columns.Add("Xi", "Xi");
                    dgv_manuals.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv_manuals.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv_manuals.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    show_Synthesis_of_Priority(new string[] { "Tinggi", "Sedang", "Rendah" }, fahp.skalaPenilaian_SK);
                }
                else if (comboBox2.SelectedItem.ToString() == "Posisi Rata-rata")
                {
                    dgv_manuals.Rows.Clear();
                    dgv_manuals.Columns.Clear();
                    dgv_manuals.Columns.Add("", "");
                    dgv_manuals.Columns.Add("Tertinggi", "Tertinggi");
                    dgv_manuals.Columns.Add("Teratas", "Teratas");
                    dgv_manuals.Columns.Add("Terendah", "Terendah");
                    dgv_manuals.Columns.Add("Hasil Kali", "Hasil kali");
                    dgv_manuals.Columns.Add("Ai", "Ai");
                    dgv_manuals.Columns.Add("Xi", "Xi");
                    dgv_manuals.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv_manuals.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv_manuals.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    show_Synthesis_of_Priority(new string[] { "Tertinggi", "Teratas", "Terendah" }, fahp.skalaPenilaian_pos);
                }
                else if (comboBox2.SelectedItem.ToString() == "Biaya Kata Kunci")
                {
                    dgv_manuals.Rows.Clear();
                    dgv_manuals.Columns.Clear();
                    dgv_manuals.Columns.Add("", "");
                    dgv_manuals.Columns.Add("Murah", "Murah");
                    dgv_manuals.Columns.Add("Sedang", "Sedang");
                    dgv_manuals.Columns.Add("Mahal", "Mahal");
                    dgv_manuals.Columns.Add("Sangat Mahal", "Sangat Mahal");
                    dgv_manuals.Columns.Add("Hasil Kali", "Hasil kali");
                    dgv_manuals.Columns.Add("Ai", "Ai");
                    dgv_manuals.Columns.Add("Xi", "Xi");
                    dgv_manuals.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv_manuals.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv_manuals.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv_manuals.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    show_Synthesis_of_Priority(new string[] { "Murah", "Sedang", "Mahal", "Sangat Mahal" }, fahp.skalaPenilaian_biaya);
                }
                else if (comboBox2.SelectedItem.ToString() == "Semua Kriteria")
                {
                    dgv_manuals.Rows.Clear();
                    dgv_manuals.Columns.Clear();
                    dgv_manuals.Columns.Add("", "");
                    dgv_manuals.Columns.Add("Klik", "Klik");
                    dgv_manuals.Columns.Add("Tayangan", "Tayangan");
                    dgv_manuals.Columns.Add("CTR", "CTR");
                    dgv_manuals.Columns.Add("Skor Kualitas", "Skor Kualitas");
                    dgv_manuals.Columns.Add("Rata-rata Posisi", "Rata-rata Posisi");
                    dgv_manuals.Columns.Add("Biaya", "Biaya");
                    dgv_manuals.Columns.Add("Hasil Kali", "Hasil kali");
                    dgv_manuals.Columns.Add("Ai", "Ai");
                    dgv_manuals.Columns.Add("Xi", "Xi");
                    dgv_manuals.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv_manuals.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv_manuals.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    show_Synthesis_of_Priority(new string[] { "Klik", "Tayangan", "CTR", "Skor Kualitas", "Rata-rata Posisi", "Biaya" }, fahp.skalaPBK);
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Logical Consistancy")
            {
                if (comboBox2.SelectedItem.ToString() == "Klik")
                {
                    dgv_manuals.Rows.Clear();
                    dgv_manuals.Columns.Clear();
                    dgv_manuals.Columns.Add("", "");
                    dgv_manuals.Columns.Add("Banyak", "Banyak");
                    dgv_manuals.Columns.Add("Sedang", "Sedang");
                    dgv_manuals.Columns.Add("Sedikit", "Sedikit");
                    dgv_manuals.Columns.Add("lcKlik", "LC(Jumlah Klik)");
                    dgv_manuals.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv_manuals.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    show_Logical_Consistancy(new string[] { "Banyak", "Sedang", "Sedikit" }, fahp.skalaPenilaian_Klik);
                }
                else if (comboBox2.SelectedItem.ToString() == "Tayangan")
                {
                    dgv_manuals.Rows.Clear();
                    dgv_manuals.Columns.Clear();
                    dgv_manuals.Columns.Add("", "");
                    dgv_manuals.Columns.Add("Banyak", "Banyak");
                    dgv_manuals.Columns.Add("Sedang", "Sedang");
                    dgv_manuals.Columns.Add("Sedikit", "Sedikit");
                    dgv_manuals.Columns.Add("lcTyg", "LC(Jumlah Tayangan)");
                    dgv_manuals.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv_manuals.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    show_Logical_Consistancy(new string[] { "Banyak", "Sedang", "Sedikit" }, fahp.skalaPenilaian_tyg);
                }
                else if (comboBox2.SelectedItem.ToString() == "CTR")
                {
                    dgv_manuals.Rows.Clear();
                    dgv_manuals.Columns.Clear();
                    dgv_manuals.Columns.Add("", "");
                    dgv_manuals.Columns.Add("DiatasRata", "Di atas Rata-rata");
                    dgv_manuals.Columns.Add("Ratarata", "Rata-rata");
                    dgv_manuals.Columns.Add("DibawahRata", "Di Bawah Rata-rata");
                    dgv_manuals.Columns.Add("lcCTR", "LC(CTR)");
                    dgv_manuals.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv_manuals.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    show_Logical_Consistancy(new string[] { "Di Atas Rata-rata", "Rata-rata", "Di Bawah Rata-rata" }, fahp.skalaPenilaian_CTR);
                }
                else if (comboBox2.SelectedItem.ToString() == "Skor Kualitas")
                {
                    dgv_manuals.Rows.Clear();
                    dgv_manuals.Columns.Clear();
                    dgv_manuals.Columns.Add("", "");
                    dgv_manuals.Columns.Add("Tinggi", "Tinggi");
                    dgv_manuals.Columns.Add("Sedang", "Sedang");
                    dgv_manuals.Columns.Add("Rendah", "Rendah");
                    dgv_manuals.Columns.Add("lcSK", "LC(Skor Kualitas)");
                    dgv_manuals.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv_manuals.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    show_Logical_Consistancy(new string[] { "Tinggi", "Sedang", "Rendah" }, fahp.skalaPenilaian_SK);
                }
                else if (comboBox2.SelectedItem.ToString() == "Posisi Rata-rata")
                {
                    dgv_manuals.Rows.Clear();
                    dgv_manuals.Columns.Clear();
                    dgv_manuals.Columns.Add("", "");
                    dgv_manuals.Columns.Add("Tertinggi", "Tertinggi");
                    dgv_manuals.Columns.Add("Teratas", "Teratas");
                    dgv_manuals.Columns.Add("Terendah", "Terendah");
                    dgv_manuals.Columns.Add("lcPos", "LC(Posisi Rata-rata)");
                    dgv_manuals.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv_manuals.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    show_Logical_Consistancy(new string[] { "Tertinggi", "Teratas", "Terendah" }, fahp.skalaPenilaian_pos);
                }
                else if (comboBox2.SelectedItem.ToString() == "Biaya Kata Kunci")
                {
                    dgv_manuals.Rows.Clear();
                    dgv_manuals.Columns.Clear();
                    dgv_manuals.Columns.Add("", "");
                    dgv_manuals.Columns.Add("Murah", "Murah");
                    dgv_manuals.Columns.Add("Sedang", "Sedang");
                    dgv_manuals.Columns.Add("Mahal", "Mahal");
                    dgv_manuals.Columns.Add("Sangat Mahal", "Sangat Mahal");
                    dgv_manuals.Columns.Add("lcBiaya", "LC(Biaya)");
                    dgv_manuals.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv_manuals.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    show_Logical_Consistancy(new string[] { "Murah", "Sedang", "Mahal", "Sangat Mahal" }, fahp.skalaPenilaian_biaya);
                }
                else if (comboBox2.SelectedItem.ToString() == "Semua Kriteria")
                {
                    dgv_manuals.Rows.Clear();
                    dgv_manuals.Columns.Clear();
                    dgv_manuals.Columns.Add("", "");
                    dgv_manuals.Columns.Add("Klik", "Klik");
                    dgv_manuals.Columns.Add("Tayangan", "Tayangan");
                    dgv_manuals.Columns.Add("CTR", "CTR");
                    dgv_manuals.Columns.Add("Skor Kualitas", "Skor Kualitas");
                    dgv_manuals.Columns.Add("Rata-rata Posisi", "Rata-rata Posisi");
                    dgv_manuals.Columns.Add("Biaya", "Biaya");
                    dgv_manuals.Columns.Add("lcKriteria", "LC(Semua Kriteria)");
                    dgv_manuals.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv_manuals.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    show_Logical_Consistancy(new string[] { "Klik", "Tayangan", "CTR", "Skor Kualitas", "Rata-rata Posisi", "Biaya" }, fahp.skalaPBK);
                }
                else if (comboBox2.SelectedItem.ToString() == "Consistancy Ratio")
                {
                    dgv_manuals.Rows.Clear();
                    dgv_manuals.Columns.Clear();
                    dgv_manuals.Columns.Add("", "");
                    dgv_manuals.Columns.Add("Si", "Si (Logical Consistancy)");
                    dgv_manuals.Columns.Add("n", "n(Kolom)");
                    dgv_manuals.Columns.Add("nmin1", "n-1");
                    dgv_manuals.Columns.Add("Ci", "Ci");
                    dgv_manuals.Columns.Add("bilRandom", "Bilangan Random");
                    dgv_manuals.Columns.Add("CR", "CR (Consistancy Ratio)");
                    dgv_manuals.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv_manuals.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv_manuals.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    List<List<string>> CR = new List<List<string>>();
                    CR.Add(CR_Manuals("Kriteria", fahp.skalaPBK));
                    CR.Add(CR_Manuals("Klik", fahp.skalaPenilaian_Klik));
                    CR.Add(CR_Manuals("Tayangan", fahp.skalaPenilaian_tyg));
                    CR.Add(CR_Manuals("CTR", fahp.skalaPenilaian_CTR));
                    CR.Add(CR_Manuals("Skor Kualitas", fahp.skalaPenilaian_SK));
                    CR.Add(CR_Manuals("Posisi Rata-rata", fahp.skalaPenilaian_pos));
                    CR.Add(CR_Manuals("Biaya", fahp.skalaPenilaian_biaya));
                    foreach (List<string> list in CR) {
                        dgv_manuals.Rows.Add(list.ToArray());
                    }
                }
            }
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

        private void desc_GA_LoadFile_MouseEnter(object sender, EventArgs e)
        {
            controller.slide_desc_bar();
            string txt = "Fitur untuk menentukan Group dan Kata kunci terbaik" +
                "\r\n\r\nPetunjuk:" +
                "\r\n\r\n1. Inputkan Semua Data Group Iklan Yang Telah Didapat Dari Google Adwords";
            controller.description_message("Groups Analysis", txt);
        }

        private void desc_GA_SelectGroup_MouseEnter(object sender, EventArgs e)
        {
            controller.slide_desc_bar();
            string txt = "Fitur untuk menentukan Group dan Kata kunci terbaik" +
                "\r\n\r\nPetunjuk:" +
                "\r\n\r\n1. Telah Didapatkan Nilai Performa Dari Setiap Group Iklan, Group Iklan Terbaik Memiliki Nilai BNP Terbesar" +
                "\r\n\r\n2. Untuk Dapat Melihat Performa Dari Kata Kunci Disetiap Group Iklan, User Dapat MengKlik Pada Group Iklan";
            controller.description_message("Groups Analysis", txt);
        }

        private void desc_GA_GroupResult_MouseEnter(object sender, EventArgs e)
        {
            controller.slide_desc_bar();
            string txt = "Fitur untuk menentukan Group dan Kata kunci terbaik" +
                "\r\n\r\nPetunjuk:" +
                "\r\n\r\n1. Didapatkan Nilai Performa Setiap Keyword Pada Semua Group Iklan" +
                "\r\n\r\n2. Keyword Dengan Performa Terbaik Diperoleh Pada Group Iklan Terbaik Yaitu Yang Memiliki Nilai BNP Tertinggi Dan Memiliki Nilai Skor AHP Tertinggi" +
                "\r\n\r\n3. Pada Penentuan Performa Keyword Terbaik Kriteria yang digunakan adalah Jumlah klik, Jumlah Tayangan, CTR, Skor Kualitas, Posisi rata-rata, Dan Biaya Iklan/Jumlah Klik";
            controller.description_message("Groups Analysis", txt);
        }

        private void manualisasi_FAHP_MouseEnter(object sender, EventArgs e)
        {
            controller.slide_desc_bar();
            string txt = "Ditampilkan Hasil Perhitungan Dari Proses FAHP Untuk Menentukan Group Iklan Terbaik" +
                "\r\n\r\nPetunjuk:" +
                "\r\n\r\n1. Ditampilkan Hasil Perhitungan Synthesis Of Prioriry Dan Logical Consistancy Dari Semua Kriteria";
            controller.description_message("Manualisasi FAHP", txt);
        }

        private void desc_GA_MouseLeave(object sender, EventArgs e)
        {
            controller.slide_desc_bar();
            //controller.description_message();
        }

        private void Bt_DetailsAds_Click(object sender, EventArgs e)
        {
            if (ads_detail == true)
            {
                dgv_jenis_iklan.Visible = false;
                ads_detail = false;
                labelBestAds.Visible = true;
                lb_bestAds.Visible = true;
            }
            else {
                dgv_jenis_iklan.Visible = true;
                ads_detail = true;
                labelBestAds.Visible = false;
                lb_bestAds.Visible = false;
            }
        }

        private void Bt_kDetails_Click(object sender, EventArgs e)
        {
            if (keyword_detail == true)
            {
                show_group_ads(selected_file);
                keyword_detail = false;
            }
            else {
                show_group_ads(selected_file);
                keyword_detail = true;
            }
        }
    }
}
