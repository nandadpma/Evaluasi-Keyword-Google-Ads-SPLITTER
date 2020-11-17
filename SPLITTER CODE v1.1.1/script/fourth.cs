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
        }

        string csv_fname;
        Dataset csv;
        String dirName;

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
                AHP run_AHP = new AHP(this.csv);
                //this.fahp.run_FAHP(this.all_csv);
                for (int i = 0; i < run_AHP.data_keyword.keyword.GetLength(0); i++)
                {
                    dgv_keyword_analysis.Rows.Add(run_AHP.data_keyword.keyword[i], run_AHP.data_keyword.status_keyword[i], run_AHP.data_keyword.fitur[i,0], "$"+ run_AHP.data_keyword.fitur[i, 1], run_AHP.data_keyword.fitur[i, 2], run_AHP.rating_keyword[i]);
                    dgv_keyword_analysis.Update();
                }
                
            }
        }
    }
}
