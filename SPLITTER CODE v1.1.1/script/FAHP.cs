using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class FAHP
    {

        double[,] skalaPBK = new double[,] {{ 1, 2, 3, 3, 5, 7},{((double)1/2), 1, 3, 3, 3, 5},{((double)1/3),((double)1/3), 1, 3, 5, 7},
        {((double)1/3),((double)1/3),((double)1/3), 1, 3, 5},{((double)1/5),((double)1/3),((double)1/5),((double)1/3), 1, 7},
        {((double)1/7),((double)1/5),((double)1/7),((double)1/5),((double)1/7), 1}};
        double[,] skalaPenilaian_Klik = new double[,] { { 1, 5, 7 }, { ((double)1 / 5), 1, 3 }, { ((double)1 / 7), ((double)1 / 3), 1 } };
        double[,] skalaPenilaian_tyg = new double[,] { { 1, 5, 7 }, { ((double)1 / 5), 1, 3 }, { ((double)1 / 7), ((double)1 / 3), 1 } };
        double[,] skalaPenilaian_CTR = new double[,] { { 1, 3, 5 }, { ((double)1 / 3), 1, 3 }, { ((double)1 / 5), ((double)1 / 3), 1 } };
        double[,] skalaPenilaian_SK = new double[,] { { 1, 5, 7 }, { ((double)1 / 5), 1, 3 }, { ((double)1 / 7), ((double)1 / 3), 1 } };
        double[,] skalaPenilaian_pos = new double[,] { { 1, 5, 7 }, { ((double)1 / 5), 1, 3 }, { ((double)1 / 7), ((double)1 / 3), 1 } };
        double[,] skalaPenilaian_biaya = new double[,] { { 1, 3, 5, 7 }, { ((double)1 / 3), 1, 3, 5 }, { ((double)1 / 5), ((double)1 / 3), 1, 3 }, { ((double)1 / 7), ((double)1 / 5), ((double)1 / 3), 1 } };
        Dictionary<double, double[]> skalafuzzy = new Dictionary<double, double[]>() {
            {(1), new double[]{ 1, 1, 1}},{(2), new double[]{ 1, 2, 4 }},{(3), new double[]{ 1, 3, 5 }},{(5), new double[]{ 3, 5, 7 }}, {(7), new double[]{ 5, 7, 9 }},
            {((double)1/2), new double[]{((double)1/4), ((double)1/2), 1 }}, {((double)1/3), new double[]{((double)1/5), ((double)1/3), 1 }},
            {((double)1/5), new double[]{((double)1/7), ((double)1/5), ((double)1/3) }}, {((double)1/7), new double[]{((double)1/9), ((double)1/7), ((double)1/5) }}
        };
        double[,] rasioInterval = new double[,] { { ((double)1 / 5), ((double)1 / 5), ((double)1 / 3) }, { ((double)1 / 5), ((double)1 / 3), 1 }, { 1, 1, 1 }, { 1, 3, 5 }, { 3, 5, 5 } };
        double cr_kriteria, cr_klik, cr_tyg, cr_CTR, cr_SK, cr_pos, cr_biaya;
        double[,] bf_kriteria, bf_klik, bf_tyg, bf_CTR, bf_SK, bf_pos, bf_biaya;
        double[,] gw_klik, gw_tyg, gw_CTR, gw_SK, gw_pos, gw_biaya;
        int nLC;
        double[] random = new double[] { 0, 0.58, 0.9, 1.12, 1.24, 1.32, 1.41, 1.45, 1.49 };
        double[] bil_random = new double[] { 0, 0, 0.58, 0.9, 1.12, 1.24, 1.32, 1.41, 1.45, 1.49 };
        double[,] sintesis_performa;
        public double[] BNP;
        public Dataset[] all_data;
        //public static Dataset[] all_data;
        public FAHP()
        {
            hitungConsistencyRatio();
            hitungBobotFuzzy();
            hitungGlobalWeight();
            Console.WriteLine("FAHP DONE");
        }

        public void run_FAHP(Dataset[] all_csv)
        {
            this.all_data = all_csv;
            prosesDataMasukan();
            hitungFSD();
            hitungBNP();

        }

        public double[,] assign_matrix(double[,] result, int index, double[] b)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
                result[index, j] = b[j];
            }
            return result;
        }

        public void hitungBNP()
        {
            this.BNP = new double[this.sintesis_performa.GetLength(0)];
            for (int i = 0; i < this.sintesis_performa.GetLength(0); i++)
            {
                this.BNP[i] = (((this.sintesis_performa[i, 2] - this.sintesis_performa[i, 0]) + (this.sintesis_performa[i, 1] - this.sintesis_performa[i, 0])) / 3) + (this.sintesis_performa[i, 0]);
            }
            printArr(this.BNP);
        }

        public void hitungFSD()
        {
            this.sintesis_performa = new double[this.all_data.GetLength(0), 3];
            for (int i = 0; i < this.all_data.GetLength(0); i++)
            {
                this.sintesis_performa = assign_matrix(sintesis_performa, i, FSDXGW(this.all_data[i]));
            }

        }

        public double[] FSDXGW(Dataset dt)
        {
            //double[,] temp = new double[dt.fitur.GetLength(0), dt.fitur.GetLength(1)];
            /*
            double[,] banyak_klik = perkalian_dot_product(dt.klik, gw_klik);
            double[,] tayangan = perkalian_dot_product(dt.tyg, gw_tyg);
            double[,] ctr = perkalian_dot_product(dt.CTR, gw_CTR);
            double[,] Skor_kualitas = perkalian_dot_product(dt.SK, gw_SK);
            double[,] posisi = perkalian_dot_product(dt.pos, gw_pos);
            double[,] biaya = perkalian_dot_product(dt.biaya, gw_biaya);
            */
            double[] result = new double[3];
            result = sum_kolom(result, perkalian_dot_product(dt.klik, gw_klik));
            result = sum_kolom(result, perkalian_dot_product(dt.tyg, gw_tyg));
            result = sum_kolom(result, perkalian_dot_product(dt.CTR, gw_CTR));
            result = sum_kolom(result, perkalian_dot_product(dt.SK, gw_SK));
            result = sum_kolom(result, perkalian_dot_product(dt.pos, gw_pos));
            result = sum_kolom(result, perkalian_dot_product(dt.biaya, gw_biaya));
            return result;

        }

        public double[] sum_kolom(double[] result, double[,] b)
        {
            //double[] result = new double[3];
            for (int j = 0; j < b.GetLength(1); j++)
            {
                for (int i = 0; i < b.GetLength(0); i++)
                {
                    result[j] = result[j] + b[i, j];
                }
            }
            return result;
        }

        public double[,] perkalian_dot_product(double[,] a, double[,] b)
        {
            double[,] result = new double[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    result[i, j] = a[i, j] * b[i, j];
                }
            }
            return result;
        }

        public void prosesDataMasukan()
        {
            for (int i = 0; i < this.all_data.GetLength(0); i++)
            {
                Console.WriteLine(this.all_data[i].filepath);
                this.all_data[i].hitungRasio_klik(Dataset.find_range(this.all_data, 0), gw_klik.GetLength(0));
                this.all_data[i].hitungRasio_tyg(Dataset.find_range(this.all_data, 1), gw_tyg.GetLength(0));
                this.all_data[i].hitungRasio_CTR(Dataset.find_AVERAGE(this.all_data, 2), gw_CTR.GetLength(0));
                this.all_data[i].hitungRasio_SK();
                this.all_data[i].hitungRasio_pos();
                this.all_data[i].hitungRasio_biaya();
                /*
                printArr(this.all_data[i].klik);
                printArr(this.all_data[i].tyg);
                printArr(this.all_data[i].CTR);
                printArr(this.all_data[i].SK);
                printArr(this.all_data[i].pos);
                printArr(this.all_data[i].biaya);
                */
            }
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

        public void printArr(double[] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.WriteLine(arr[i] + "\t");
            }
            Console.WriteLine();
        }

        public void hitungConsistencyRatio()
        {
            this.nLC = 0;
            this.cr_kriteria = hitungConsistencyRatio(this.skalaPBK);
            this.cr_klik = hitungConsistencyRatio(this.skalaPenilaian_Klik);
            this.cr_tyg = hitungConsistencyRatio(this.skalaPenilaian_tyg);
            this.cr_CTR = hitungConsistencyRatio(this.skalaPenilaian_CTR);
            this.cr_SK = hitungConsistencyRatio(this.skalaPenilaian_SK);
            this.cr_pos = hitungConsistencyRatio(this.skalaPenilaian_pos);
            this.cr_biaya = hitungConsistencyRatio(this.skalaPenilaian_biaya);
        }

        public void hitungBobotFuzzy()
        {
            this.bf_kriteria = hitungBobotFuzzy(this.skalaPBK);
            this.bf_klik = hitungBobotFuzzy(this.skalaPenilaian_Klik);
            this.bf_tyg = hitungBobotFuzzy(this.skalaPenilaian_tyg);
            this.bf_CTR = hitungBobotFuzzy(this.skalaPenilaian_CTR);
            this.bf_SK = hitungBobotFuzzy(this.skalaPenilaian_SK);
            this.bf_pos = hitungBobotFuzzy(this.skalaPenilaian_pos);
            this.bf_biaya = hitungBobotFuzzy(this.skalaPenilaian_biaya);
        }

        public void hitungGlobalWeight()
        {
            this.nLC = 0;
            this.gw_klik = hitungGlobalWeight(this.bf_kriteria, this.bf_klik);
            this.gw_tyg = hitungGlobalWeight(this.bf_kriteria, this.bf_tyg);
            this.gw_CTR = hitungGlobalWeight(this.bf_kriteria, this.bf_CTR);
            this.gw_SK = hitungGlobalWeight(this.bf_kriteria, this.bf_SK);
            this.gw_pos = hitungGlobalWeight(this.bf_kriteria, this.bf_pos);
            this.gw_biaya = hitungGlobalWeight(this.bf_kriteria, this.bf_biaya);
            /*
            printArr(this.gw_klik);
            printArr(this.gw_tyg);
            printArr(this.gw_CTR);
            printArr(this.gw_SK);
            printArr(this.gw_pos);
            printArr(this.gw_biaya);
            */

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

        public double hitungConsistencyRatio(double[,] skala)
        {
            double[] x = hitungPriorityVector(skala);
            double logicalConsistency = hitungLogicalConsistency(skala, x);
            double Ci = (logicalConsistency - skala.GetLength(0)) / (skala.GetLength(0) - 1);
            //double consistencyRatio = Ci * this.bilanganRandom[this.nLC];
            double consistencyRatio = Ci * this.bil_random[skala.GetLength(1)];
            this.nLC++;
            return consistencyRatio;
        }
        /*
        public string[] showSoP(double[,] skala)
        {
            string[,] sop = new string[skala.GetLength(0), skala.GetLength(1)+4];
            for (int i = 0; i < sop.GetLength(0); i++)
            {
                double hasilKali = 1;
                for (int j = 0; j < skala.GetLength(1); j++)
                {
                    sop[i, j] = skala[i, j].ToString();
                    hasilKali *= skala[i, j];
                }
                sop[i, skala.GetLength(1)] = hasilKali.ToString();
                sop[i, skala.GetLength(1)+1] = Math.Pow(hasilKaliBaris[i], ((double)1 / Ai.GetLength(0)));
                totalAi += Ai[i];
            }
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = Ai[i] / totalAi;
            }
            return x;
        }
        */
        public string[,] show_logical_consistency_result(string kriteria)
        {
            string[,] table;
            if (kriteria == "All Criteria")
            {
                //table = new string[this.skalaPBK.GetLength(0) + 1, this.skalaPBK.GetLength(0) + 4];
                //return table;
            }
            else if (kriteria == "Klik")
            {

            }
            else if (kriteria == "Tayangan")
            {

            }
            else if (kriteria == "CTR")
            {

            }
            else if (kriteria == "Score Kualitas")
            {

            }
            else if (kriteria == "Posisi Rata-rata")
            {

            }
            else if (kriteria == "Biaya")
            {

            }
            table = new string[this.skalaPBK.GetLength(0) + 1, this.skalaPBK.GetLength(0) + 4];
            return table;
        }

        public double[] hitungSPC(double[,] skala)
        {
            double[,] skalaTFN = new double[skala.GetLength(0), skala.GetLength(1) * 3];
            double[] spc = new double[skala.GetLength(1) * 3];
            for (int i = 0; i < skala.GetLength(0); i++)
            {
                for (int j = 0; j < skala.GetLength(1); j++)
                {
                    double[] temp = this.skalafuzzy[(double)skala[i, j]];
                    for (int k = 0; k < temp.GetLength(0); k++)
                    {
                        skalaTFN[i, ((3 * j) + k)] = temp[k];
                    }
                }
            }
            for (int i = 0; i < skalaTFN.GetLength(1); i++)
            {
                double hasilKali = 1;
                for (int j = 0; j < skalaTFN.GetLength(0); j++)
                {
                    hasilKali *= skalaTFN[j, i];
                }
                spc[i] = Math.Pow(hasilKali, ((double)1 / skala.GetLength(0)));
            }
            return spc;
        }

        public double[,] hitungGeometricFuzzyMean(double[] spc)
        {
            double[,] geometricFuzzyMean = new double[(spc.GetLength(0) / 3) + 1, 3];
            for (int i = 0; i < geometricFuzzyMean.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < geometricFuzzyMean.GetLength(1); j++)
                {
                    geometricFuzzyMean[i, j] = spc[(3 * i) + j];
                }
            }
            for (int i = 0; i < geometricFuzzyMean.GetLength(1); i++)
            {
                double sum = 0;
                for (int j = 0; j < geometricFuzzyMean.GetLength(0) - 1; j++)
                {
                    sum += geometricFuzzyMean[j, i];
                }
                geometricFuzzyMean[geometricFuzzyMean.GetLength(0) - 1, i] = sum;
            }
            //printArr(geometricFuzzyMean);

            return geometricFuzzyMean;
        }

        public double[,] hitungBobotFuzzy(double[,] skala)
        {
            double[] spc = hitungSPC(skala);
            double[,] geometricFuzzyMean = hitungGeometricFuzzyMean(spc);
            double[,] bf = new double[geometricFuzzyMean.GetLength(0) - 1, geometricFuzzyMean.GetLength(1)];
            for (int i = 0; i < geometricFuzzyMean.GetLength(1); i++)
            {
                //for (int j = 0; j < geometricFuzzyMean.GetLength(0); j++)
                for (int j = 0; j < geometricFuzzyMean.GetLength(0) - 1; j++)
                {
                    bf[j, i] = geometricFuzzyMean[j, i] / geometricFuzzyMean[geometricFuzzyMean.GetLength(0) - 1, i];
                }
            }
            //printArr(bf);
            return bf;
        }

        public double[,] hitungGlobalWeight(double[,] bf_kriteria, double[,] bf)
        {
            double[,] globalWeight = new double[bf.GetLength(0), bf.GetLength(1)];
            for (int i = 0; i < bf.GetLength(0); i++)
            {
                for (int j = 0; j < bf.GetLength(1); j++)
                {
                    globalWeight[i, j] = bf_kriteria[this.nLC, j] * bf[i, j];
                }
            }
            this.nLC++;
            //printArr(globalWeight);
            return globalWeight;
        }

    }
}
