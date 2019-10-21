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

        static void Main(string[] args)
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
            Console.WriteLine();
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(" " +array[i]);
            }

            Dictionary<int, int> counts = array.GroupBy(x => x)
                                      .ToDictionary(g => g.Key,
                                                    g => g.Count());
            Console.WriteLine();
            int[] mi=
            foreach (KeyValuePair<int, int> keyValue in counts)
            {
                // keyValue.Value представляет класс Person
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
        }
    }
}
