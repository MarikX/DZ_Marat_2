using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    internal class Program
    {
        /// <summary>
        /// Метод заполнение List случайными данными
        /// </summary>
        /// <returns>List<byte></returns>
        static List<byte> RandomList()
        {
            List<byte> list = new List<byte>();
            Random r = new Random();
            for (byte i = 0; i < 100; i++)
            {
                list.Add(Convert.ToByte(r.Next(101)));
            }
            return list;
        }
        /// <summary>
        /// Метод печати List
        /// </summary>
        /// <param name="list"></param>
        static void Print(List<byte> list)
        {
            byte flag = 1;
            foreach (var e in list)
            {
                Console.Write($"{e,3} ");
                if (flag != 25) flag++;
                else { flag = 1; Console.WriteLine(); }
            }
        }
        /// <summary>
        /// Метод удаление чисел в диапозоне от 25 до50
        /// </summary>
        /// <param name="list">List<byte></param>
        /// <returns>List<byte></returns>
        static List<byte> Remove(List<byte> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                //Console.WriteLine($"[{list[i]}] <{i}> [{list.Count}]");
                if (list[i] > 25 && list[i] < 50)
                {
                    list.RemoveAt(i);
                    i--;
                }

            }

            return list;
        }
        static void Main(string[] args)
        {
            List<byte> list = new List<byte>();

            list = RandomList();
            Console.WriteLine("Сгенерированные данные List: ");
            Print(list);
            list = Remove(list);
            Console.WriteLine("Данные List после удаления диапозона от 25 до 50: ");
            Print(list);
            Console.ReadKey();


        }
    }
}
