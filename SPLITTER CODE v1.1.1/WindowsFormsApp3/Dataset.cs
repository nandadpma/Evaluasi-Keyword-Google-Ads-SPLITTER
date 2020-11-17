using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class Dataset
    {

        public string filepath;
        public string filename;
        public double[,] fitur;
        public double[,] fitur_kw;
        public string[] keyword;
        public double[,] klik, tyg, CTR, SK, pos, biaya;
        double[,] bfa = new double[,] { {((double) 1/5),((double) 1/5),((double) 1/3)},
            {((double) 1/5),((double) 1/3),1}, {1,1,1}, {1,3,5},{3,5,5} };
        public double[,] rating_kriteria;
        public Dataset(string filepath)
        {
            this.filepath = filepath;
            filename = Path.GetFileName(filepath);
            List<string> lines = File.ReadAllLines(this.filepath).ToList();
            string pattern = "([a-zA-Z]+[:]\\s[0-9]+[,][0-9]+)|(([+]?[a-zA-Z]+[-]?\\s?)+)|([\\d]+[.][\\d]+)|([\"][\\d]+[,][\\d]+[%]?[\"])|([\\d]+)";
            List<string> selected_line = new List<string>();
            foreach (string line in lines)
            {
                string temp = line.Replace("--", "0");
                MatchCollection matches = Regex.Matches(temp, pattern, RegexOptions.IgnoreCase);
                int nColumn = 0;
                foreach (Match match in matches)
                {
                    if (match.Groups[0].Success) nColumn++;
                }
                if (nColumn == 16) selected_line.Add(temp);
            }
            string[,] collection = new string[selected_line.Count, 16];
            int document = 0;
            foreach (string line in selected_line)
            {
                MatchCollection matches = Regex.Matches(line, pattern, RegexOptions.IgnoreCase);
                int column = 0;
                foreach (Match match in matches)
                {
                    //GroupCollection groups = match.Groups;
                    string temp = (match.Groups[0]).ToString();
                    temp = temp.Replace("%", "").Replace(",", ".").Replace("\"", "");
                    collection[document, column] = temp;
                    column++;
                }
                document++;
            }
            this.fitur = new double[collection.GetLength(0), 6];
            this.keyword = new string[collection.GetLength(0)];
            for (int i = 0; i < collection.GetLength(0); i++)
            {
                this.keyword[i] = collection[i, 1];
                this.fitur[i, 0] = Convert.ToDouble(collection[i, 5]);//klik
                this.fitur[i, 1] = Convert.ToDouble(collection[i, 6]);//tyg
                this.fitur[i, 2] = Convert.ToDouble(collection[i, 7]) / 100;//CTR
                this.fitur[i, 3] = Convert.ToDouble(collection[i, 11]);//SK
                this.fitur[i, 4] = Convert.ToDouble(collection[i, 10]) / 10;//pos
                double biaya = (Convert.ToDouble(collection[i, 9]) / Convert.ToDouble(collection[i, 5])) / 100;//biaya
                //this.fitur[i, 5] = biaya;
                
                if (Double.IsNaN(biaya))
                {
                    this.fitur[i, 5] = 0;
                }
                else {
                    this.fitur[i, 5] = biaya;
                }
                
            }
            this.rating_kriteria = new double[this.fitur.GetLength(0), this.fitur.GetLength(1)];
        }

        public Dataset(string filepath, bool isKeywordAnalysis) {
            this.filepath = filepath;
            filename = Path.GetFileName(filepath);
            List<string> lines = File.ReadAllLines(this.filepath).ToList();
            string pattern = "(([a-zA-Z]+\\s?)+)|([\\d]+[.][\\d]+)|([\\d]+)";
            List<string> selected_line = new List<string>();
            foreach (string line in lines)
            {
                string temp = line;
                MatchCollection matches = Regex.Matches(temp, pattern, RegexOptions.IgnoreCase);
                int nColumn = 0;
                foreach (Match match in matches)
                {
                    if (match.Groups[0].Success) nColumn++;
                }
                if (nColumn == 4) selected_line.Add(temp);
            }
            string[,] collection = new string[selected_line.Count-1, 4];
            int document = -1;
            foreach (string line in selected_line)
            {
                if (document >= 0) {
                    MatchCollection matches = Regex.Matches(line, pattern, RegexOptions.IgnoreCase);
                    int column = 0;
                    foreach (Match match in matches)
                    {
                        //GroupCollection groups = match.Groups;
                        string temp = (match.Groups[0]).ToString();
                        //temp = temp.Replace("%", "").Replace(",", ".").Replace("\"", "");
                        collection[document, column] = temp;
                        column++;
                    }
                }
                document++;
            }
            this.fitur = new double[collection.GetLength(0), 3];
            this.keyword = new string[collection.GetLength(0)];
            for (int i = 0; i < collection.GetLength(0); i++)
            {
                this.keyword[i] = collection[i, 0];
                this.fitur[i, 0] = Convert.ToDouble(collection[i, 1]);//pencarian
                this.fitur[i, 1] = Convert.ToDouble(collection[i, 2])/100;//harga
                this.fitur[i, 2] = Convert.ToDouble(collection[i, 3]);//kompetisi
            }
            //Console.WriteLine("Print CSV");
            //printArr(this.fitur);
            this.rating_kriteria = new double[this.fitur.GetLength(0), this.fitur.GetLength(1)+1];
        }

        public void printArr(double[] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.WriteLine(arr[i] + "\t");
            }
            Console.WriteLine();
        }

        public void printArr(double[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void get_one_row(double[,] result, int index_of_result, double[,] array, int index)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
                result[index_of_result, j] = array[index, j];
            }
        }

        public double[,] fuzzyfication(double[] rasio)
        {
            double[,] result = new double[rasio.GetLength(0), this.bfa.GetLength(1)];
            for (int i = 0; i < rasio.GetLength(0); i++)
            {
                for (int j = 0; j < this.bfa.GetLength(0); j++)
                {
                    if (rasio[i] <= (0.2 * (j + 1)))
                    {
                        get_one_row(result, i, bfa, j);
                        break;
                    }

                }
            }
            return result;
        }

        public void hitungRasio_biaya()
        {
            double[] dt = fetch_one_Column(5);
            double[] jumlah = new double[4];
            for (int i = 0; i < dt.GetLength(0); i++)
            {
                if (dt[i] <= 2000)
                    jumlah[0]++;
                else if ((dt[i] > 2000) && (dt[i] <= 3000))
                    jumlah[1]++;
                else if ((dt[i] > 3000) && (dt[i] <= 4000))
                    jumlah[2]++;
                else if (dt[i] > 4000)
                    jumlah[3]++;
            }
            for (int i = 0; i < jumlah.GetLength(0); i++)
            {
                jumlah[i] = jumlah[i] / dt.GetLength(0);
            }
            this.biaya = fuzzyfication(jumlah);
        }

        public void hitungRasio_pos()
        {
            double[] dt = fetch_one_Column(4);
            double[] jumlah = new double[3];
            for (int i = 0; i < dt.GetLength(0); i++)
            {
                if (dt[i] == 1)
                    jumlah[0]++;
                //else if ((dt[i] > 1) && dt[i] <= 8)
                else if (dt[i] <= 8)
                    jumlah[1]++;
                //else if ((dt[i] > 9) && (dt[i] <= 16))
                else if (dt[i] <= 16)
                    jumlah[2]++;
            }
            for (int i = 0; i < jumlah.GetLength(0); i++)
            {
                jumlah[i] = jumlah[i] / dt.GetLength(0);
            }
            this.pos = fuzzyfication(jumlah);
        }

        public void hitungRasio_SK()
        {
            double[] dt = fetch_one_Column(3);
            double[] jumlah = new double[3];
            for (int i = 0; i < dt.GetLength(0); i++)
            {
                if ((dt[i] >= 0) && (dt[i] <= 3))
                    jumlah[0]++;
                else if ((dt[i] > 3) && (dt[i] < 8))
                    jumlah[1]++;
                else if ((dt[i] >= 8) && (dt[i] <= 10))
                    jumlah[2]++;
            }
            for (int i = 0; i < jumlah.GetLength(0); i++)
            {
                jumlah[i] = jumlah[i] / dt.GetLength(0);
            }
            this.SK = fuzzyfication(jumlah);
        }

        public void hitungRasio_CTR(double average, int skala)
        {
            double[] dt = fetch_one_Column(2);
            double[] jumlah = new double[skala];
            for (int i = 0; i < dt.GetLength(0); i++)
            {
                if (dt[i] < average)
                    jumlah[0]++;
                else if (dt[i] == average)
                    jumlah[1]++;
                else if (dt[i] > average)
                    jumlah[2]++;
            }
            for (int i = 0; i < jumlah.GetLength(0); i++)
            {
                jumlah[i] = jumlah[i] / dt.GetLength(0);
            }
            this.CTR = fuzzyfication(jumlah);
        }

        public void hitungRasio_tyg(double range, int skala)
        {
            double[] dt = fetch_one_Column(1);
            double basis = range / skala;
            double[] jumlah = new double[skala];
            for (int i = 0; i < dt.GetLength(0); i++)
            {
                for (int j = 0; j < skala; j++)
                {
                    if (dt[i] <= Math.Round(basis * (j + 1)))
                    {
                        jumlah[j]++;
                        break;
                    }
                }
            }
            for (int i = 0; i < jumlah.GetLength(0); i++)
            {
                jumlah[i] = jumlah[i] / dt.GetLength(0);
            }
            this.tyg = fuzzyfication(jumlah);
        }

        public void hitungRasio_klik(double range, int skala)
        {
            double[] dt = fetch_one_Column(0);
            double basis = range / skala;
            double[] jumlah = new double[skala];
            for (int i = 0; i < dt.GetLength(0); i++)
            {
                for (int j = 0; j < skala; j++)
                {
                    if (dt[i] <= Math.Round(basis * (j + 1)))
                    {
                        jumlah[j]++;
                        break;
                    }
                }
            }
            for (int i = 0; i < jumlah.GetLength(0); i++)
            {
                jumlah[i] = jumlah[i] / dt.GetLength(0);
            }
            this.klik = fuzzyfication(jumlah);
        }

        public double[] fetch_one_Column(int index)
        {
            double[] column = new double[this.fitur.GetLength(0)];
            for (int i = 0; i < this.fitur.GetLength(0); i++)
            {
                column[i] = fitur[i, index];
            }
            return column;
        }

        public static double find_range(Dataset[] all_csv, int index)
        {
            double[] all_max_temp = new double[all_csv.GetLength(0)];
            double[] all_min_temp = new double[all_csv.GetLength(0)];
            int index_csv = 0;
            foreach (Dataset csv in all_csv)
            {
                double max_temp = csv.fitur[0, index];
                double min_temp = csv.fitur[0, index];
                for (int i = 1; i < csv.fitur.GetLength(0); i++)
                {
                    if (csv.fitur[i, index] > max_temp) max_temp = csv.fitur[i, index];
                }
                for (int i = 1; i < csv.fitur.GetLength(0); i++)
                {
                    if (csv.fitur[i, index] < min_temp) min_temp = csv.fitur[i, index];
                }
                all_max_temp[index_csv] = max_temp;
                all_min_temp[index_csv] = min_temp;
                index_csv++;
            }
            double max_of_all = all_max_temp[0];
            double min_of_all = all_min_temp[0];
            for (int i = 1; i < all_max_temp.GetLength(0); i++)
            {
                if (all_max_temp[i] > max_of_all) max_of_all = all_max_temp[i];
            }
            for (int i = 1; i < all_min_temp.GetLength(0); i++)
            {
                if (all_min_temp[i] < min_of_all) min_of_all = all_min_temp[i];
            }
            //double[] maxmin = new double[] { max_of_all, min_of_all };
            //Console.WriteLine("\t" + max_of_all + "\t" + min_of_all);
            Console.WriteLine("RANGE : " + (max_of_all - min_of_all));
            return max_of_all - min_of_all;
        }

        public static double find_AVERAGE(Dataset[] all_csv, int index)
        {
            double[] sum_of_all = new double[all_csv.GetLength(0)];
            int index_csv = 0;
            foreach (Dataset csv in all_csv)
            {
                double sum = 0;
                for (int i = 0; i < csv.fitur.GetLength(0); i++)
                {
                    sum = sum + csv.fitur[i, index];
                }
                sum_of_all[index_csv] = (sum / csv.fitur.GetLength(0));
                index_csv++;
            }
            double result = 0;
            for (int i = 0; i < sum_of_all.GetLength(0); i++)
            {
                result = result + sum_of_all[i];
            }
            return result / sum_of_all.GetLength(0);
        }

        public void hitungRating_biaya(double[] rating)
        {
            double[] dt = fetch_one_Column(5);
            for (int i = 0; i < dt.GetLength(0); i++)
            {
                if (dt[i] <= 2000)
                    this.rating_kriteria[i, 5] = rating[0];
                else if ((dt[i] > 2000) && (dt[i] <= 3000))
                    this.rating_kriteria[i, 5] = rating[1];
                else if ((dt[i] > 3000) && (dt[i] <= 4000))
                    this.rating_kriteria[i, 5] = rating[2];
                else if (dt[i] > 4000)
                    this.rating_kriteria[i, 5] = rating[3];
            }
        }

        public void hitungRating_pos(double[] rating)
        {
            double[] dt = fetch_one_Column(4);
            for (int i = 0; i < dt.GetLength(0); i++)
            {
                if (dt[i] == 1)
                    this.rating_kriteria[i, 4] = rating[0];
                //else if ((dt[i] > 1) && dt[i] <= 8)
                else if (dt[i] > 1 && dt[i] <= 8)
                    this.rating_kriteria[i, 4] = rating[1];
                //else if ((dt[i] > 9) && (dt[i] <= 16))
                else if (dt[i] > 8 && dt[i] <= 16)
                    this.rating_kriteria[i, 4] = rating[2];
            }
        }

        public void hitungRating_SK(double[] rating)
        {
            double[] dt = fetch_one_Column(3);
            for (int i = 0; i < dt.GetLength(0); i++)
            {
                if ((dt[i] >= 0) && (dt[i] <= 3))
                    this.rating_kriteria[i, 3] = rating[2];
                else if ((dt[i] > 3) && (dt[i] < 8))
                    this.rating_kriteria[i, 3] = rating[1];
                else if ((dt[i] >= 8) && (dt[i] <= 10))
                    this.rating_kriteria[i, 3] = rating[0];
            }
        }

        public void hitungRating_CTR(double average, double[] rating)
        {
            double[] dt = fetch_one_Column(2);
            for (int i = 0; i < dt.GetLength(0); i++)
            {
                if (dt[i] < average)
                    this.rating_kriteria[i, 2] = rating[2];
                else if (dt[i] == average)
                    this.rating_kriteria[i, 2] = rating[1];
                else if (dt[i] > average)
                    this.rating_kriteria[i, 2] = rating[0];
            }
        }

        public void hitungRating_tyg(double range, double[] rating)
        {
            double[] dt = fetch_one_Column(1);
            double basis = range / rating.GetLength(0);
            for (int i = 0; i < dt.GetLength(0); i++)
            {
                for (int j = 0; j < rating.GetLength(0); j++)
                {
                    if (dt[i] <= Math.Round(basis * (j + 1)))
                    {
                        this.rating_kriteria[i, 1] = rating[j];
                        //break;
                    }
                }
            }
        }

        public void hitungRating_klik(double range, double[] rating)
        {
            double[] dt = fetch_one_Column(0);
            double basis = range / rating.GetLength(0);
            for (int i = 0; i < dt.GetLength(0); i++)
            {
                for (int j = 0; j < rating.GetLength(0); j++)
                {
                    if (dt[i] <= Math.Round(basis * (j + 1)))
                    {
                        this.rating_kriteria[i, 0] = rating[j];
                        //break;
                    }
                }
            }
        }

        public string[] status_keyword;

        public void hitungRating_Spesifikasi(double[] rating)
        {
            this.status_keyword = new string[this.rating_kriteria.GetLength(0)];
            string[] dt = this.keyword;
            string pattern = "([a-zA-Z]+)";
            for (int i = 0; i < dt.GetLength(0); i++)
            {
                string temp = dt[i];
                MatchCollection matches = Regex.Matches(temp, pattern, RegexOptions.IgnoreCase);
                int nTerm = 0;
                foreach (Match match in matches)
                {
                    if (match.Groups[0].Success) nTerm++;
                }
                if (nTerm == 1)
                {
                    this.rating_kriteria[i, 0] = rating[0];
                    this.status_keyword[i] = "Umum";
                }
                else if (nTerm == 2)
                {
                    this.rating_kriteria[i, 0] = rating[1];
                    this.status_keyword[i] = "Normal";
                }
                else if (nTerm == 3)
                {
                    this.rating_kriteria[i, 0] = rating[2];
                    this.status_keyword[i] = "Spesifik";
                }
                else
                {
                    this.rating_kriteria[i, 0] = rating[3];
                    this.status_keyword[i] = "Sangat Spesifik";
                }
            }
        }

        public void hitungRating_Pencarian(double[] rating)
        {
            double[] dt = fetch_one_Column(0);
            for (int i = 0; i < dt.GetLength(0); i++)
            {
                if (dt[i] <= 500)
                    this.rating_kriteria[i, 1] = rating[0];
                else if ((dt[i] > 500) && (dt[i] <= 1000))
                    this.rating_kriteria[i, 1] = rating[1];
                else if ((dt[i] > 1000) && (dt[i] <= 2000))
                    this.rating_kriteria[i, 1] = rating[2];
                else if ((dt[i] > 2000) && (dt[i] <= 5000))
                    this.rating_kriteria[i, 1] = rating[3];
                else if (dt[i] > 5000)
                    this.rating_kriteria[i, 1] = rating[4];
            }
        }

        public void hitungRating_Harga(double[] rating)
        {
            double[] dt = fetch_one_Column(1);
            for (int i = 0; i < dt.GetLength(0); i++)
            {
                if (dt[i] <= 0.2)
                    this.rating_kriteria[i, 3] = rating[0];
                else if ((dt[i] > 0.2) && (dt[i] <= 0.5))
                    this.rating_kriteria[i, 3] = rating[1];
                else if ((dt[i] > 0.5) && (dt[i] <= 1))
                    this.rating_kriteria[i, 3] = rating[2];
                else if (dt[i] > 1)
                    this.rating_kriteria[i, 3] = rating[3];
            }
        }

        public void hitungRating_Competition(double[] rating)
        {
            double[] dt = fetch_one_Column(2);
            for (int i = 0; i < dt.GetLength(0); i++)
            {
                if (dt[i] <= (double)1/3)
                    this.rating_kriteria[i, 2] = rating[0];
                else if ((dt[i] > (double)1 / 3) && (dt[i] <= (double)2 / 3))
                    this.rating_kriteria[i, 2] = rating[1];
                else if (dt[i] > (double)2 / 3)
                    this.rating_kriteria[i, 2] = rating[2];
            }
        }

    }
}
