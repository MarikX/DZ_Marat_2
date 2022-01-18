using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    internal class Program
    {
        /// <summary>
        /// Метод печати всего справочника
        /// </summary>
        /// <param name="Dict">Справочник</param>
        static void PrintAll(Dictionary<long, string> Dict)
        {
            foreach (KeyValuePair<long, string> e in Dict)
            {
                Console.WriteLine($"Телефон: - {e.Key} Фамилия: {e.Value}");
            }
            Console.ReadKey(true);
        }
        /// <summary>
        /// Метод добавления новых телефоных номеров в справочник
        /// </summary>
        /// <param name="Dict">Справочник in</param>
        /// <returns>Справочник out</returns>
        static Dictionary<long, string> Add(Dictionary<long, string> Dict)
        {
            for (; ; )
            {
                string str;
                Console.WriteLine("Введите Фамилию владельца телефона, либо Enter для выхода: ");
                str = Console.ReadLine();
                if (str != "")

                    for (byte i=1 ; ; i++)
                    {
                        Console.WriteLine($"Введите {i} номер телефона, либо Enter для выхода: ") ;
                        string NumInput = Console.ReadLine();
                        if (NumInput != "")
                        {
                            Dict.Add(Convert.ToInt64(NumInput), str);
                        }
                        else break;
                    }
                else break;
            }
            return Dict;
        }
        /// <summary>
        /// Метод поиска владельца по ключу
        /// </summary>
        /// <param name="Dict">Справочник in</param>
        /// <param name="Key">Номер телефона</param>
        static void Search (Dictionary<long, string> Dict, long Key)
        {
            string value = "";
            if (Dict.TryGetValue(Key, out value))
            {
                Console.WriteLine($"Владелец даного телефона - {value}."); 
            }
            else
            {
                Console.WriteLine("Даный телефон в базе не найден.");
            }
            Console.ReadKey(true);
        }
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<long, string>();
            dictionary.Add(9235554447,"Петров");
            dictionary.Add(9235554442, "Иванов");
            dictionary.Add(9235354427, "Сидоров");
            dictionary.Add(9235554441, "Петров");
            dictionary.Add(9236754447, "Ильясов");

            Console.WriteLine("Добавление новых номеров");
            dictionary = Add(dictionary);
            Console.WriteLine("Печать всего справочника");
            PrintAll(dictionary);
            Console.Write("Введите номер телефона для поиска владельца: ");
            Search(dictionary, Convert.ToInt64(Console.ReadLine()));

        }
    }
}
