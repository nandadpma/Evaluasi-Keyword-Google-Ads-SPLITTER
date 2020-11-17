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
        String dirName;
        FAHP fahp = new FAHP();
        public second()
        {
            InitializeComponent();
        }

        private void dgv_jenis_iklan_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = this.dgv_jenis_iklan.CurrentCell.RowIndex;
            int columnindex = this.dgv_jenis_iklan.CurrentCell.ColumnIndex;
            string filename = this.dirName + "\\" + dgv_jenis_iklan.Rows[rowindex].Cells[columnindex].Value.ToString();
            this.selected_ads = new Dataset(filename);
            AHP ahp = new AHP(this.selected_ads, this.fahp);
            this.dgv_rating_keyword.Rows.Clear();
            for (int i = 0; i < ahp.data_iklan.keyword.GetLength(0); i++)
            {
                dgv_rating_keyword.Rows.Add(ahp.keyword[i], ahp.fitur[i, 0], ahp.fitur[i, 1], ahp.fitur[i, 2],
                    ahp.fitur[i, 3], ahp.fitur[i, 4], ahp.fitur[i, 5], ahp.rating_keyword[i]);
                dgv_rating_keyword.Update();
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
                this.dirName = (Path.GetDirectoryName(chooseTrainfile.FileName));
                this.all_csv = new Dataset[this.all_csv_fname.GetLength(0)];
                int n_file = 0;
                foreach (string csv_fname in all_csv_fname)
                {
                    this.all_csv[n_file] = new Dataset(csv_fname);
                    n_file++;
                }
                this.fahp.run_FAHP(this.all_csv);
                for (int i = 0; i < this.fahp.all_data.GetLength(0); i++)
                {
                    dgv_jenis_iklan.Rows.Add(this.fahp.all_data[i].filename, this.fahp.BNP[i]);
                    dgv_jenis_iklan.Update();
                }
            }
        }
    }
}
