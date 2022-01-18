using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSet
{
    internal class Program
    {

        /// <summary>
        /// Метод печати HashSet
        /// </summary>
        /// <param name="HashSet">HashSet</param>
        static void Print(HashSet<int> HashSet)
        {
            Console.Write("HashSet: ");
            foreach (var e in HashSet) 
            { 
                Console.Write($"{e} "); 
            }
        }
        static void Main(string[] args)
        {
            HashSet<int> HashSet = new HashSet<int>();
            Random r = new Random();
            int InputNumber;

            for (int i = 0; i < 50; i++)
            {
                HashSet.Add(r.Next(100));
            }

            Print(HashSet);

            Console.Write("\nВведите число для внесения в HashSet: ");

            InputNumber = Convert.ToInt32(Console.ReadLine());

            if (!HashSet.Contains(InputNumber))
            {
                HashSet.Add(InputNumber);
                Console.WriteLine("Число успешно внесено!");
            }
            else Console.WriteLine("Число не внесено, так как уже присутствовало!");

            Print(HashSet);

            Console.ReadKey();
        }
    }
}
