using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class AHP
    {
        double[,] skalaPBK = new double[,] {{ 1, 2, 3, 3, 5, 7},{((double)1/2), 1, 3, 3, 3, 5},{((double)1/3),((double)1/3), 1, 3, 5, 7},
        {((double)1/3),((double)1/3),((double)1/3), 1, 3, 5},{((double)1/5),((double)1/3),((double)1/5),((double)1/3), 1, 7},
        {((double)1/7),((double)1/5),((double)1/7),((double)1/5),((double)1/7), 1}};
        double[,] skalaPenilaian_Klik = new double[,] { { 1, 5, 7 }, { ((double)1 / 5), 1, 3 }, { ((double)1 / 7), ((double)1 / 3), 1 } };
        //double[,] skalaPenilaian_Klik = new double[,] { { 1, 4, 7 }, { ((double)1 / 4), 1, 3 }, { ((double)1 / 7), ((double)1 / 3), 1 } };
        double[,] skalaPenilaian_tyg = new double[,] { { 1, 5, 7 }, { ((double)1 / 5), 1, 3 }, { ((double)1 / 7), ((double)1 / 3), 1 } };
        double[,] skalaPenilaian_CTR = new double[,] { { 1, 3, 5 }, { ((double)1 / 3), 1, 3 }, { ((double)1 / 5), ((double)1 / 3), 1 } };
        double[,] skalaPenilaian_SK = new double[,] { { 1, 5, 7 }, { ((double)1 / 5), 1, 3 }, { ((double)1 / 7), ((double)1 / 3), 1 } };
        double[,] skalaPenilaian_pos = new double[,] { { 1, 5, 7 }, { ((double)1 / 5), 1, 3 }, { ((double)1 / 7), ((double)1 / 3), 1 } };
        double[,] skalaPenilaian_biaya = new double[,] { { 1, 3, 5, 7 }, { ((double)1 / 3), 1, 3, 5 }, { ((double)1 / 5), ((double)1 / 3), 1, 3 }, { ((double)1 / 7), ((double)1 / 5), ((double)1 / 3), 1 } };
        double[,] rasioInterval = new double[,] { { ((double)1 / 5), ((double)1 / 5), ((double)1 / 3) }, { ((double)1 / 5), ((double)1 / 3), 1 }, { 1, 1, 1 }, { 1, 3, 5 }, { 3, 5, 5 } };
        int nLC;
        double[] bil_random = new double[] { 0, 0, 0.58, 0.9, 1.12, 1.24, 1.32, 1.41, 1.45, 1.49 };
        public double[] BNP;
        public Dataset data_iklan;
        public string[] keyword;
        public double[,] fitur;
        //public double[,] fitur_KA;
        double[] TPV;
        double[] rating_klik, rating_tyg, rating_CTR, rating_sk, rating_pos, rating_biaya;
        public double[] rating_keyword;
        FAHP fahp;
        //double[] TPV_kriteria;
        double[] rating_spesifikasi, rating_pencarian, rating_kompetisi, rating_harga;
        double[,] kriteria = new double[,] { { 1, ((double)1/7), 2, 2}, { 7, 1, 7, 7},
            { ((double)1/2), ((double)1/7), 1, ((double)1/3) }, { ((double)1/2), ((double)1/7), 3, 1} };

        double[,] spesifikasi = new double[,] { { 1, ((double)1/3), ((double)1/5), ((double)1/3)}, { 3, 1, ((double)1/3), 1},
            { 5, 3, 1, 3 }, { 3, 1, ((double)1/3), 1} };

        double[,] pencarian = new double[,] { { 1, ((double)1/3), ((double)1/5), ((double)1/7), ((double)1/9)},
            { 3, 1, ((double)1/3), ((double)1/5), ((double)1/7)}, { 5, 3, 1, ((double)1/3), ((double)1/5)},
            { 7, 5, 3, 1, ((double)1/3)}, { 9, 7, 5, 3, 1} };

        double[,] kompetisi = new double[,] { { 1, 3, 5}, { ((double)1/3), 1, 3}, { ((double)1/5), ((double)1/3), 1 }};

        double[,] harga = new double[,] { { 1, 3, 5, 7 }, { ((double)1/3), 1, 3, 5 },
            { ((double)1/5), ((double)1/3), 1, 3 }, { ((double)1/7), ((double)1/5), ((double)1/3), 1} };
        public Dataset data_keyword;

        //double cr_kriteria;

        public AHP(Dataset data)
        {
            this.data_keyword = data;
            hitungRatingKeywordAnalysis();
            prosesDataMasukan_KeywordAnalysis();
        }

        public AHP(Dataset data, FAHP fahp)
        {
            this.data_iklan = data;
            this.fahp = fahp;
            hitungRating();
            prosesDataMasukan();
        }

        public void prosesDataMasukan()
        {
            Console.WriteLine(this.data_iklan.filepath);
            this.data_iklan.hitungRating_klik(Dataset.find_range(fahp.all_data, 0), this.rating_klik);
            this.data_iklan.hitungRating_tyg(Dataset.find_range(fahp.all_data, 1), this.rating_tyg);
            this.data_iklan.hitungRating_CTR(Dataset.find_AVERAGE(fahp.all_data, 2), this.rating_CTR);
            this.data_iklan.hitungRating_SK(this.rating_sk);
            this.data_iklan.hitungRating_pos(this.rating_pos);
            this.data_iklan.hitungRating_biaya(this.rating_biaya);
            this.keyword = this.data_iklan.keyword;
            this.fitur = this.data_iklan.fitur;
            this.rating_keyword = new double[this.data_iklan.keyword.GetLength(0)];
            Console.WriteLine("Data Masukan");
            for (int i = 0; i < this.data_iklan.fitur.GetLength(0); i++) {
                Console.Write(this.data_iklan.keyword[i]+" : \t");
                for (int j = 0; j < this.data_iklan.fitur.GetLength(1); j++)
                {
                    Console.Write(this.data_iklan.rating_kriteria[i, j]+"\t");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < this.data_iklan.fitur.GetLength(0); i++)
            {
                double total = 0;
                for (int j = 0; j < this.data_iklan.fitur.GetLength(1); j++)
                {
                    total = total + (this.data_iklan.rating_kriteria[i, j] * this.TPV[j]);
                }
                this.rating_keyword[i] = total;
            }
            for (int i = 0; i < this.data_iklan.fitur.GetLength(0); i++)
            {
                for (int j = i + 1; j < this.data_iklan.fitur.GetLength(0); j++)
                {
                    if (this.rating_keyword[j] > this.rating_keyword[i]) {

                        double temp_rating_keyword = this.rating_keyword[i];
                        this.rating_keyword[i] = this.rating_keyword[j];
                        this.rating_keyword[j] = temp_rating_keyword;

                        string temp_keyword = this.keyword[i];
                        this.keyword[i] = this.keyword[j];
                        this.keyword[j] = temp_keyword;

                        double[] temp_fitur = this.getFiturRow(i);
                        switchFitur(i, this.getFiturRow(j));
                        switchFitur(j, temp_fitur);
                    }
                }

            }
        }

        public double[] getFiturRow(int index) {
            double[] fitur = new double[6];
            for (int i = 0; i < fitur.GetLength(0); i++) {
                fitur[i] = this.fitur[index, i];
            }
            return fitur;
        }

        public void switchFitur(int index, double[] a) {
            for (int i = 0; i < this.fitur.GetLength(1); i++)
            {
                this.fitur[index, i] = a[i];
            }
        }

        public double[] getFiturRow_KA(int index)
        {
            double[] fitur = new double[3];
            for (int i = 0; i < fitur.GetLength(0); i++)
            {
                fitur[i] = this.fitur[index, i];
            }
            return fitur;
        }

        public void switchFitur_KA(int index, double[] a)
        {
            for (int i = 0; i < this.fitur.GetLength(1); i++)
            {
                this.fitur[index, i] = a[i];
            }
        }

        public void prosesDataMasukan_KeywordAnalysis()
        {
            this.data_keyword.hitungRating_Spesifikasi(this.rating_spesifikasi);
            this.data_keyword.hitungRating_Pencarian(this.rating_pencarian);
            this.data_keyword.hitungRating_Harga(this.rating_harga);
            this.data_keyword.hitungRating_Competition(this.rating_kompetisi);
            this.keyword = this.data_keyword.keyword;
            this.fitur = this.data_keyword.fitur;
            /*
            Console.WriteLine("TPV");
            printArr(this.TPV);
            Console.WriteLine("RATING KRITERIA");
            printArr(this.data_keyword.rating_kriteria);
            */

            this.rating_keyword = new double[this.data_keyword.keyword.GetLength(0)];
            for (int i = 0; i < this.data_keyword.rating_kriteria.GetLength(0); i++)
            {
                double total = 0;
                for (int j = 0; j < this.data_keyword.rating_kriteria.GetLength(1); j++)
                {
                    //Console.Write((this.data_keyword.rating_kriteria[i, j] * this.TPV[j])+"\t");
                    total = total + (this.data_keyword.rating_kriteria[i, j] * this.TPV[j]);
                }
                //Console.WriteLine();
                this.rating_keyword[i] = total;
            }

            for (int i = 0; i < this.data_keyword.fitur.GetLength(0); i++)
            {
                for (int j = i + 1; j < this.data_keyword.fitur.GetLength(0); j++)
                {
                    if (this.rating_keyword[j] > this.rating_keyword[i])
                    {

                        double temp_rating_keyword = this.rating_keyword[i];
                        this.rating_keyword[i] = this.rating_keyword[j];
                        this.rating_keyword[j] = temp_rating_keyword;

                        string temp_keyword = this.keyword[i];
                        this.keyword[i] = this.keyword[j];
                        this.keyword[j] = temp_keyword;

                        double[] temp_fitur = this.getFiturRow_KA(i);
                        switchFitur_KA(i, this.getFiturRow_KA(j));
                        switchFitur_KA(j, temp_fitur);
                    }
                }

            }

            printArr(this.rating_keyword);
        }

        public double[] hitung_TPV(double[,] data)
        {
            double[,] temp_normalisasi_y = new double[data.GetLength(0), data.GetLength(1)];
            for (int j = 0; j < data.GetLength(1); j++)
            {
                double sum = 0;
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    sum = sum + data[i, j];
                }
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    temp_normalisasi_y[i, j] = data[i, j] / sum;
                }
            }
            double[] TPV = new double[data.GetLength(0)];
            for (int i = 0; i < data.GetLength(0); i++)
            {
                double sum = 0;
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    sum = sum + temp_normalisasi_y[i, j];
                }
                TPV[i] = sum / data.GetLength(1);
            }
            return TPV;
        }
        


        public double hitungConsistencyRatio_Kriteria(double[,] data, double[] TPV)
        {
            //this.TPV = hitung_TPV(data);
            double[,] matrix_hasil_kali = new double[data.GetLength(0), data.GetLength(1)];
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    matrix_hasil_kali[i, j] = data[i, j] * TPV[j];
                }
            }
            double[] sigma_baris = new double[data.GetLength(0)];
            for (int i = 0; i < data.GetLength(0); i++)
            {
                double sum = 0;
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    sum = sum + matrix_hasil_kali[i, j];
                }
                sigma_baris[i] = sum;
            }
            double sigma = 0;
            for (int i = 0; i < sigma_baris.GetLength(0); i++)
            {
                sigma = sigma + sigma_baris[i];
            }
            double lambda = sigma / data.GetLength(0);
            double CI = lambda / (data.GetLength(1) - 1);
            double CR = CI * this.bil_random[data.GetLength(1)];
            return CR;
        }

        public void hitungRating()
        {
            this.nLC = 0;
            this.TPV = hitung_TPV(this.skalaPBK);
            Console.WriteLine("=====TPV=====");
            printArr(this.TPV);
            Console.WriteLine("=============");
            //this.cr_kriteria = hitungConsistencyRatio_Kriteria(this.skalaPBK);
            this.rating_klik = hitungRating(this.skalaPenilaian_Klik);
            this.rating_tyg = hitungRating(this.skalaPenilaian_tyg);
            this.rating_CTR = hitungRating(this.skalaPenilaian_CTR);
            this.rating_sk = hitungRating(this.skalaPenilaian_SK);
            this.rating_pos = hitungRating(this.skalaPenilaian_pos);
            this.rating_biaya = hitungRating(this.skalaPenilaian_biaya);
            
            Console.WriteLine("Rating Kriteria");
            printArr(this.rating_klik);
            printArr(this.rating_tyg);
            printArr(this.rating_CTR);
            printArr(this.rating_sk);
            printArr(this.rating_pos);
            printArr(this.rating_biaya);
            
        }

        public void hitungRatingKeywordAnalysis()
        {
            this.nLC = 0;
            this.TPV = hitung_TPV(this.kriteria);
            //this.cr_kriteria = hitungConsistencyRatio_Kriteria(this.kriteria, this.TPV);
            this.rating_spesifikasi = hitungRating(this.spesifikasi);
            this.rating_pencarian = hitungRating(this.pencarian);
            this.rating_harga = hitungRating(this.harga);
            this.rating_kompetisi = hitungRating(this.kompetisi);
        }


        public double[] hitungRating(double[,] skala)
        {
            double[] temp_TPV = hitung_TPV(skala);
            double max_TPV = temp_TPV[0];
            for (int i = 1; i < temp_TPV.GetLength(0); i++) {
                if (temp_TPV[i] > max_TPV)
                    max_TPV = temp_TPV[i];
            }
            double[] rating = new double[temp_TPV.GetLength(0)];
            for (int i = 0; i < temp_TPV.GetLength(0); i++)
            {
                //rating[i] = TPV[i] / TPV[0];
                rating[i] = temp_TPV[i] / max_TPV;
            }
            //printArr(rating);
            //Console.WriteLine();
            return rating;
        }

        public double hitungConsistencyRatio(double[] rating, double[,] skala)
        {
            //double[] x = hitungPriorityVector(skala);
            //double logicalConsistency = hitungLogicalConsistency(skala, x);
            double[] TPV = hitung_TPV(skala);
            rating = new double[TPV.GetLength(0)];
            for (int i = 1; i < TPV.GetLength(0); i++)
            {
                rating[i] = TPV[i] / TPV[0];
            }
            double[,] matrix_hasil_kali = new double[skala.GetLength(0), skala.GetLength(1)];
            for (int i = 0; i < skala.GetLength(0); i++)
            {
                for (int j = 0; j < skala.GetLength(1); j++)
                {
                    matrix_hasil_kali[i, j] = skala[i, j] * TPV[j];
                }
            }
            double[] sigma_baris = new double[skala.GetLength(0)];
            for (int i = 0; i < skala.GetLength(0); i++)
            {
                double sum = 0;
                for (int j = 0; j < skala.GetLength(1); j++)
                {
                    sum = sum + matrix_hasil_kali[i, j];
                }
                sigma_baris[i] = sum;
            }
            double[] lambda = new double[skala.GetLength(0)];
            double sum_lambda = 0;
            for (int i = 0; i < sigma_baris.GetLength(0); i++)
            {
                lambda[i] = sigma_baris[i] * TPV[i];
                sum_lambda = sum_lambda + lambda[i];
            }
            double max_lambda = sum_lambda / skala.GetLength(0);

            double Ci = (max_lambda - skala.GetLength(0)) / (skala.GetLength(0) - 1);
            //double consistencyRatio = Ci * this.bilanganRandom[this.nLC];
            double consistencyRatio = Ci * this.bil_random[skala.GetLength(1)];
            this.nLC++;
            return consistencyRatio;
        }

        public double[] hitungPriorityVector(double[,] skala)
        {
            double[] hasilKaliBaris = new double[skala.GetLength(0)];
            double[] Ai = new double[skala.GetLength(0)];
            double[] x = new double[skala.GetLength(0)];
            double totalAi = 0;
            for (int i = 0; i < skala.GetLength(0); i++)
            {
                double hasilKali = 1;
                for (int j = 0; j < skala.GetLength(1); j++)
                {
                    hasilKali *= skala[i, j];
                }
                hasilKaliBaris[i] = hasilKali;
                Ai[i] = Math.Pow(hasilKaliBaris[i], ((double)1 / Ai.GetLength(0)));
                totalAi += Ai[i];
            }
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = Ai[i] / totalAi;
            }
            return x;
        }

        public double hitungLogicalConsistency(double[,] skala, double[] x)
        {
            double logicalConsistency = 0;
            for (int i = 0; i < skala.GetLength(1); i++)
            {
                double sumOfColumn = 0;
                for (int j = 0; j < skala.GetLength(0); j++)
                {
                    sumOfColumn += skala[j, i];
                }
                logicalConsistency += (sumOfColumn * x[i]);
            }
            return logicalConsistency;
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

        public void printArr(string[] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.WriteLine(arr[i] + "\t");
            }
            Console.WriteLine();
        }

        public void printArr(double[] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.WriteLine(arr[i] + "\t");
            }
            Console.WriteLine();
        }
    }
}
