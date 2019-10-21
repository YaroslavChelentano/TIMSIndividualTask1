using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIMSIndividualTask1
{
    class Program
    {
        public static double LineVP(int[] mi, int[] xi, double n)
        {
            double sum = 0;
            sum = (ShapockaP(mi, xi, n) / LineXB(mi, xi, n)) * 100;
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

        static void Main(string[] args)
        {
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
            int[] array = new int[6] { 1, 1, 2, 3, 4, 3};
            // сортування
            Array.Sort(array);
            Console.WriteLine();
            // вивід масиву з повторами
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(" " + array[i]);
            }
            // створення таблиці xi mi в словнику
            Dictionary<int, int> counts = array.GroupBy(x => x)
                                      .ToDictionary(g => g.Key,
                                                    g => g.Count());
            Console.WriteLine();
            int[] mi = counts.Values.ToArray(); // випишемо mi окремо в масив
            int[] xi = counts.Keys.ToArray(); // випишемо xi окремо в масив
            foreach (KeyValuePair<int, int> keyValue in counts)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
            Console.WriteLine("Мода");
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
            Console.WriteLine(xi[xi.Length - 1 ] - xi[0]);

            Console.WriteLine("Статистична дисперсія");
            Console.WriteLine(LineDB(mi, xi, array.Length));

            Console.WriteLine("Середнє статистичне відхилення");
            Console.WriteLine(Math.Sqrt(LineDB(mi, xi, array.Length)));

            Console.WriteLine("Виправлена статистична дисперсія");
            Console.WriteLine((array.Length/(array.Length-1))*Math.Pow(LineDB(mi, xi, array.Length),2));

            Console.WriteLine("Середнє лінійне відхилення");
            Console.WriteLine(ShapockaP(mi, xi, array.Length));

            Console.WriteLine( "Коефіцієнт варіації за середнім лінійним відхиленням");
            Console.WriteLine($"{LineVP(mi, xi, array.Length)}%");

        }
    }
}
