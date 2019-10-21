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

        public static double Mediana(int[] sortedArray)
        {

            double mediana = 0;
            double sortedArrayDoubleLength = (double)(sortedArray.Length);
            double indexForOdd = sortedArrayDoubleLength / 2.0 ;
            double indexForEven = sortedArrayDoubleLength / 2 - 1 ;
            double indexForEvenPlusOne = sortedArrayDoubleLength / 2;
            if (sortedArray.Length%2==0)
            {
                mediana = (sortedArray[(int)indexForEven] + sortedArray[(int)indexForEvenPlusOne]) / 2.0;
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
            int[] array = new int[7] { 1, 1, 2, 3, 4 , 3 , 2};
            Array.Sort(array);
            Console.WriteLine();
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(" " +array[i]);
            }

            Dictionary<int, int> counts = array.GroupBy(x => x)
                                      .ToDictionary(g => g.Key,
                                                    g => g.Count());
            Console.WriteLine();
            int[] mi = counts.Values.ToArray();
            int[] xi = counts.Keys.ToArray();
            var max = mi.Max();
            foreach (KeyValuePair<int, int> keyValue in counts)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
            Console.WriteLine("Мода");
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
        }
    }
}
