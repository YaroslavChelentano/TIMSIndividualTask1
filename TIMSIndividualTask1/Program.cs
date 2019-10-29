using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIMSIndividualTask1
{
    public class Program
    {
        public static double[] Emperichna(int[] mi,int[] xi,double n)
        {
            double[] wi = Wi(mi, n);
            double[] fx = new double[xi.Length + 1];
            double sum = 0;
            fx[0] = 0;
            for (int i = 0,j=1; i < xi.Length; i++,j++)
            {
                sum += wi[i];
                fx[j] = sum;
            }
            return fx;
        }
        public static double[] Wi(int[] mi,  double n)
        {
            double[] wi = new double[mi.Length];
            for (int i=0;i<mi.Length;i++)
            {
                wi[i] = mi[i] / n;
            }
            return wi;
        }
        public static double Excess(int[] mi, int[] xi, double n)
        {
            List<double> news = NewS(mi, xi, n);
            double news4 = news[3];
            double s4 = Math.Pow(Math.Sqrt(LineDB(mi, xi, n)), 4);
            double result = news4 / s4;
            return result;
        }
        public static double Asimetria(int[] mi, int[] xi, double n)
        {
            List<double> news = NewS(mi, xi, n);
            double news3 = news[2];
            double s3 = Math.Pow(Math.Sqrt(LineDB(mi, xi, n)), 3);
            double result = news3 / s3;
            return result;
        }
        public static List<double> NewS(int[] mi, int[] xi, double n)
        { 
            List<double> NewSArray = new List<double> { };
            double sum0 = 0, sum1 = 0, sum2 = 0, sum3 = 0;
            for (int i = 0; i < mi.Length; i++)
            {
                sum0 += Math.Pow(Math.Abs(xi[i] - LineXB(mi, xi, n)),1) * (mi[i] / n);
            }
            for (int i = 0; i < mi.Length; i++)
            {
                sum1 += Math.Pow(Math.Abs(xi[i] - LineXB(mi, xi, n)), 2) * (mi[i] / n);
            }
            for (int i = 0; i < mi.Length; i++)
            {
                sum2 += Math.Pow(Math.Abs(xi[i] - LineXB(mi, xi, n)), 3) * (mi[i] / n);
            }
            for (int i = 0; i < mi.Length; i++)
            {
                sum3 += Math.Pow(Math.Abs(xi[i] - LineXB(mi, xi, n)), 4) * (mi[i] / n);
            }
            NewSArray.Add(sum0);
            NewSArray.Add(sum1);
            NewSArray.Add(sum2);
            NewSArray.Add(sum3);
            return NewSArray;
        }
        public static List<double>  Ms(int[] mi, int[] xi, double n)
        {
            List<double> Ms = new List<double> { };
            double sum0=0 , sum1=0 ,sum2=0 , sum3 = 0;
            for (int i = 0; i < mi.Length; i++)
            {
                sum0 += Math.Pow(xi[i],1) * (mi[i] / n);
            }
            for (int i = 0; i < mi.Length; i++)
            {
                sum1 += Math.Pow(xi[i], 2) * (mi[i] / n);
            }
            for (int i = 0; i < mi.Length; i++)
            {
                sum2 += Math.Pow(xi[i], 3) * (mi[i] / n);
            }
            for (int i = 0; i < mi.Length; i++)
            {
                sum3 += Math.Pow(xi[i], 4) * (mi[i] / n);
            }
            Ms.Add(sum0);
            Ms.Add(sum1);
            Ms.Add(sum2);
            Ms.Add(sum3);
            return Ms;
        }
        public static double LineVP(int[] mi, int[] xi, double n)
        {
            double sum = 0;
            sum = (ShapockaP(mi, xi, n) / LineXB(mi, xi, n)) * 100;
            return sum;
        }
        public static double LineVS(int[] mi, int[] xi, double n)
        {
            double sum = 0;
            sum = Math.Sqrt(LineDB(mi, xi, n)) / LineXB(mi, xi, n) * 100;
            return sum;
        }
        // дисперсія 
        public static double ShapockaP(int[] mi, int[] xi, double n)
        {
            double sum = 0;
            for (int i = 0; i < mi.Length; i++)
            {
                sum += (Math.Abs(xi[i] - LineXB(mi, xi, n)) * (mi[i]));
            }
            return 1/n*sum;
        }
        // статистична дисперсія
        public static double LineDB(int[] mi, int[] xi, double n)
        {
            double sum = 0;
            for (int i = 0; i < mi.Length; i++)
            {
                sum += Math.Pow(xi[i]- LineXB(mi, xi, n),2) * (mi[i] / n);
            }
            return sum;
        }
        // середнє арифметичне значення вибірки
        public static double LineXB(int[] mi, int[] xi , double n)
        {
            double sum = 0;
            for (int i = 0; i < mi.Length; i++)
            {
                sum += xi[i] * (mi[i] / n);
            }
            return sum;
        }
        // Медіана
        public static double Mediana(int[] sortedArray)
        {
            double mediana = 0;
            double sortedArrayDoubleLength = (double)(sortedArray.Length);
            double indexForOdd = sortedArrayDoubleLength / 2.0 ;
            if (sortedArray.Length%2==0)
            {
                mediana = (sortedArray[(int)sortedArrayDoubleLength / 2 - 1] + sortedArray[(int)sortedArrayDoubleLength / 2]) / 2.0;
            }
            if (sortedArray.Length%2 == 1)
            {
                mediana = sortedArray[(int)indexForOdd];
            }
            return mediana;
        }
        public static int[] GetArray()
        {
            string filePath = @"D:\Навчання\Програмування\git\TIMSIndividualTask1\TIMSIndividualTask1\Вибірка.txt";
            Random randomNumber = new Random();
            int[] array = new int[100];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = randomNumber.Next(0, 10);
                Console.Write(" " + array[i]);
            }
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                foreach (var number in array)
                {
                    streamWriter.Write(number + " ");
                }
                streamWriter.Close();
            }
            Array.Sort(array);
            return array;
        }
        public static int[] array = GetArray();
        public static Dictionary<int, int> counts = array.GroupBy(x => x)
                                      .ToDictionary(g => g.Key,
                                                    g => g.Count());
        public static int[] mi = counts.Values.ToArray(); // випишемо mi окремо в масив
        public static int[] xi = counts.Keys.ToArray(); // випишемо xi окремо в масив
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            string filePath = @"D:\Навчання\Програмування\git\TIMSIndividualTask1\TIMSIndividualTask1\Вибірка.txt";
            Random randomNumber = new Random();
            //int[] array = new int[100];
            //for (int i = 0; i < array.Length; i++)
            //{
            //    array[i] = randomNumber.Next(0, 10);
            //    Console.Write(" " + array[i]);
            //}
            //using (StreamWriter streamWriter = new StreamWriter(filePath))
            //{
            //    foreach (var number in array)
            //    {
            //        streamWriter.Write(number + " ");
            //    }
            //    streamWriter.Close();
            //} 
            // ініціалізація масиву
            // сортування
            Array.Sort(array);
            Console.WriteLine();
            // вивід масиву з повторами
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(" " + array[i]);
            }
            // створення таблиці xi mi в словнику
            
            Console.WriteLine();

            Console.WriteLine("xi");
            foreach(var xii in xi)
            {
                Console.Write(xii+" ");
            }

            Console.WriteLine("\nmi");
            foreach (var mii in mi)
            {
                Console.Write(mii + " ");
            }
            Console.WriteLine("\nМода");
            var max = mi.Max();
            foreach (KeyValuePair<int, int> keyValue in counts)
            {
                // Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
                if (keyValue.Value == max)
                {
                    Console.WriteLine(keyValue.Key);
                }
            }
            //for (int i = 0; i < mi.Length; i++)
            //{
            //    Console.Write(" " + mi[i]);
            //}
            Console.WriteLine("Середнє арифметичне");
            Console.WriteLine(LineXB(mi, xi, array.Length));

            Console.WriteLine("Mediana");
            Console.WriteLine(Mediana(array));

            Console.WriteLine("Розмах");
            Console.WriteLine(xi[xi.Length - 1] - xi[0]);

            Console.WriteLine("Статистична дисперсія");
            Console.WriteLine(LineDB(mi, xi, array.Length));

            Console.WriteLine("Середнє статистичне відхилення");
            Console.WriteLine(Math.Sqrt(LineDB(mi, xi, array.Length)));

            Console.WriteLine("Виправлена статистична дисперсія");
            Console.WriteLine((array.Length / (array.Length - 1)) * Math.Pow(LineDB(mi, xi, array.Length), 2));

            Console.WriteLine("Середнє лінійне відхилення");
            Console.WriteLine(ShapockaP(mi, xi, array.Length));

            Console.WriteLine("Коефіцієнт варіації за середнім лінійним відхиленням");
            Console.WriteLine($"{LineVP(mi, xi, array.Length)}%");

            Console.WriteLine("Коефіцієнт варіації за середнім квадратичним відхиленням");
            Console.WriteLine($"{LineVS(mi, xi, array.Length)}%");

            Console.WriteLine("Початковий статистичний момент вибірки");
            foreach (var msi in Ms(mi, xi, array.Length))
                Console.WriteLine(msi);

            Console.WriteLine("Центральний статистичний момент");
            foreach (var newsi in NewS(mi, xi, array.Length))
                Console.WriteLine(newsi);

            Console.WriteLine("Асиметрія");
            Console.WriteLine(Asimetria(mi, xi, array.Length));

            Console.WriteLine("Ексцес");
            Console.WriteLine(Excess(mi, xi, array.Length));

            Console.WriteLine("Відносна частота");
            foreach (var wi in Wi(mi, array.Length))
                Console.WriteLine(wi);

            Console.WriteLine("Емпірична функція розподілу");
            foreach (var fx in Emperichna(mi, xi, array.Length))
                Console.WriteLine(fx);
            Application.Run(new PoligonChastotForm());
            Application.Run(new PoligonChastotWIForm());
            Application.Run(new DiskretniyForm());
            Application.Run(new Histograma());
        }
    }
}
