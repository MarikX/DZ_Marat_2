using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace DirectoryOfWorkers
{
    internal class Program
    {
        /// <summary>
        /// Метод чтения данных из файла и запись их в массив
        /// </summary>
        /// <returns>Массив Структуры ListOfWorkers</returns>
        static ListOfWorkers[] ReadFile()
        {
            string text;
            using (FileStream fstream = new FileStream("Base.txt", FileMode.OpenOrCreate)) //создания потока для чтения файла
            {

                byte[] array = new byte[fstream.Length];    // преобразуем строку в байты

                fstream.Read(array, 0, array.Length);       // считываем данные

                text = System.Text.Encoding.UTF8.GetString(array);    // декодируем байты в строку
                                                                      //Console.WriteLine(text);
                                                                      //Console.ReadKey();
                                                                      // return fstream;
            }


            char[] separators = new char[] { '#', '\n', '\r' }; //
            string[] ArrayWords = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);// перевод текста  из файла в массив строк

            ListOfWorkers[] list = new ListOfWorkers[File.ReadAllLines("Base.txt").Length];

            int j = 0;
            for (int i = 0; i < (ArrayWords.Length); i += 7) // Перевод из массива string в Структуру
                //ListOfWorkers
            {
                Console.WriteLine($">>{ArrayWords[i]}>>{j}");
                Console.WriteLine($">>{i}>>{j}");
                list[j].Id = Convert.ToInt32(ArrayWords[i]);
                list[j].TimeWrite = Convert.ToDateTime(ArrayWords[i + 1]);
                list[j].NameWorker = ArrayWords[i + 2];
                list[j].Age = Convert.ToUInt32(ArrayWords[i + 3]);
                list[j].Height = Convert.ToUInt32(ArrayWords[i + 4]);
                list[j].Birthday = Convert.ToDateTime(ArrayWords[i + 5]);
                list[j].Birthplace = ArrayWords[i + 6];
                //Console.WriteLine($">> {list[j].Id}");
                j++;
                //Console.WriteLine(list.id + " " + list.TimeWrite); 
            }
            return list; // Возрат ListOfWorkers
        }
        /// <summary>
        /// Метод вывода списка всех сотрудников
        /// </summary>
        /// <param name="list">Структура с данными всех сотрудников</param>
        static void Print(ListOfWorkers[] list)
        {
            Console.WriteLine("  ID\t Дата и время записи\t\t\tФИО сотрудника\t" +
    "   Возраст\t Рост\t  Дата рождения\t\t   Место рождения");
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i].Print());
            }
            Console.ReadKey(true);
        }
        /// <summary>
        /// Метод вывода информации в диапозоне дат
        /// </summary>
        /// <param name="list">Структурированый массив</param>
        /// <param name="x1">Дата 1</param>
        /// <param name="x2">Дата 2</param>
        static void Print(ListOfWorkers[] list, DateTime x1, DateTime x2)
        {
            Console.WriteLine("  ID\t Дата и время записи\t\t\tФИО сотрудника\t" +
    "   Возраст\t Рост\t  Дата рождения\t\t   Место рождения");
            DateTime x3;
            if (x1 > x2) { x3 = x1; x1 = x2; x2 = x3;  } //
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].TimeWrite>=x1 && list[i].TimeWrite<=x2)
                Console.WriteLine(list[i].Print());
            }
            Console.ReadKey(true);
        }
        /// <summary>
        /// Метод вывода данных о сотруднике по введеному ID
        /// </summary>
        /// <param name="list">Структура с данными всех сотрудников</param>
        /// <param name="index">ID порядковый номер сотрудника</param>
        static void Print(ListOfWorkers[] list, int index)
        {
            Console.WriteLine("  ID\t Дата и время записи\t\t\tФИО сотрудника\t" +
    "   Возраст\t Рост\t  Дата рождения\t\t   Место рождения");
            for (int i = 0; i < list.Length; i++) // Поиск и печать нужных данных о сотруднике
            {
                if (list[i].Id == index)
                {
                    Console.WriteLine(list[i].Print());
                    break;
                }
            }
            Console.ReadKey(true);
        }
        /// <summary>
        /// Метод удаления данных о сотруднике по веденому ID
        /// </summary>
        /// <param name="list">Структура с данными всех сотрудников</param>
        /// <param name="id">ID порядковый номер сотрудника</param>
        /// <returns>Массив структуры ListOfWorkers</returns>
        static ListOfWorkers[] Delete (ListOfWorkers[] list, int id)
            {
            ListOfWorkers[] list2 = new ListOfWorkers[list.Length-1];
            byte flag = 0;
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine($">>{i}>>{list.Length}>>{list2.Length}");
                if (list[i].Id != id)
                {
                    if (list[i].Id < id) list2[i-flag] = list[i];
                    else
                    {
                        list2[i - flag] = list[i];
                        list2[i - flag].Id--;
                    }
                }
                else flag = 1;
                    
            }
            return list2;
            }
        /// <summary>
        /// Метод добавления нового сотрудника в базу
        /// </summary>
        static void AddWorker()
        { 
            string[] Arr = new string[7];
            int a;
            Console.Clear();
            //using (FileStream SR = new FileStream("Base.txt", FileMode.OpenOrCreate)) { } // Исключение ошибки, если файл отсутствет
            //if (File.Exists(@"Base.txt"))     // Исключение ошибки, если файл отсутствет
            a = File.ReadAllLines("Base.txt").Length;  // Нахождение количество строк в файле. Это будет ID сотрудника
            //else a=0;

            Console.WriteLine("Введите следующие данные о сотруднике: ");

            Arr[0] = Convert.ToString(a + 1); // Присвоение ID

            Arr[1] = Convert.ToString(DateTime.Now); // Запись текущего времени

            Console.Write("Введите ФИО сотрудника: "); 
            Arr[2] = Console.ReadLine();  // Ввод ФИО

            Console.Write("Введите рост сотрудника: "); // Ввод роста
            Arr[4] = Console.ReadLine();

            Console.WriteLine("Укажите дату рождения сотрудника");
            string[] Message = { "День", "Месяц", "Год" };
            for (int i = 0; i< 3; i++) //ввод даты рождения
            {
                Console.Write($"Введите {Message[i]} рождения: ");
                Arr[5] += Console.ReadLine() + " "; //запись даты в массив через пробел
            }

            DateTime date = Convert.ToDateTime(Arr[5]); // Конвертирование строки в дату
            Arr[5] = Convert.ToString(date.Day) + "." + Convert.ToString(date.Month) + "." + Convert.ToString(date.Year); // приобразование строки к виду ##.##.##
            //Console.WriteLine($">> {Arr[5]}");
            int age = DateTime.Now.Year - date.Year; // Вычесление возраста, путем вычетания года рождения сотрудника из текущего года 
            if (DateTime.Now.DayOfYear<date.DayOfYear) age--; // проверка был ли уже ДР, если нет минус год
            Arr[3] = Convert.ToString(age); // запись возраста в строку

            Console.Write("Введите место рождения сотрудника: ");
            Arr[6] = Console.ReadLine(); // ввод места рождения

            string res = Arr[0];
            for (int i = 1; i< 7; i++) // Сбор массива в форматированую строку
            {
                res += "#" + Arr[i];
            }
            //return res; // Вовращения результата
            WriteFile(res, true);
            //Console.WriteLine(res);
        }
        /// <summary>
        /// Метод записи данных в файл
        /// </summary>
        /// <param name="Text">Данные string для записи</param>
        /// <param name="X">Лог. значение true для доб. в файл false перезаписать</param>
        static void WriteFile(string Text, bool X)
        {
            using (StreamWriter sr = new StreamWriter("Base.txt", X)) // создания потока для записи файла
            {
                sr.WriteLine(Text); // запись строки в файл
            }
            Console.WriteLine("Данные успешно изменены. Для продолжения нажмите любую клавишу...");
            Console.ReadKey();// пауза
        }
        /// <summary>
        /// Метод записи структуриного массива в файл
        /// </summary>
        /// <param name="list">Структуривоный Массив</param>
        static void FullWrite(ListOfWorkers[] list)
        {
            string Text = null;
            for (int i = 0; i < list.Length; i++) // Перевод структуры ListOfWorkers в строковую переменую
            {
                Text += Convert.ToString(list[i].Id) + "#" +
                    Convert.ToString(list[i].TimeWrite) + "#" +
                    list[i].NameWorker + "#" +
                    Convert.ToString(list[i].Age) + "#" +
                    Convert.ToString(list[i].Height) + "#" +
                    Convert.ToString(list[i].Birthday) + "#";
                    if (i!=list.Length-1)  Text += list[i].Birthplace + Environment.NewLine;
                    else Text += list[i].Birthplace;
            }
            WriteFile(Text, false);
            //using (StreamWriter sr = new StreamWriter("Base.txt", true)) // создания потока для записи файла
            //{
            //  sr.WriteLine(Text); // запись строки в файл
            // }
            //Console.WriteLine(Text);
            //Console.WriteLine("Данные успешно изменены. Для продолжения нажмите любую клавишу...");
            //Console.ReadKey();// пауза
        }
        /// <summary>
        /// Метод редактирования сотрудника
        /// </summary>
        /// <param name="list">Массив</param>
        /// <param name="Str">ФИО Сотрудника</param>
        /// <returns></returns>
        static ListOfWorkers[] EditWorkers (ListOfWorkers[] list, string Str)
        {
            bool flag = true;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].NameWorker == Str)
                {
                    Console.Write("Введите заного ФИО Сотрудника: ");
                    list[i].NameWorker = Console.ReadLine();
                    flag = false;
                    FullWrite(list);
                    break;
                }
            }
            if (flag) Console.WriteLine("Сотрудник не найден. для продолжения нажмите любую клавишу");
            return list;
        }
        static void Main(string[] args)
            {
            using (FileStream SR = new FileStream("Base.txt", FileMode.OpenOrCreate)) { } // Исключение ошибки, если файл отсутствет
            ListOfWorkers[] workers = new ListOfWorkers[File.ReadAllLines("Base.txt").Length];
            ListOfWorkers[] res = new ListOfWorkers[workers.Length - 1];
            string Str = null ;
            workers = ReadFile();

            for (int i = 0; i == 0;)
            {
                Console.Clear();
                Console.WriteLine("Нажмите одну из следующих клавиш:\nQ - для выхода\n" +
                    "D - для удаления сотрудника\n" +
                    "A - для занесения данных о новом сотруднике\n" +
                    "P - для печати информации о сотрудниках\n" +
                    "S - для сортировки по дате записи\n" +
                    "R - для вывода информации в промежутке дат\n"+
                    "E - для редактирования данных о сотрудниках");
                switch (Console.ReadKey(true).Key.ToString())
                {
                    case "Q": 
                        i = 1; break;
                    case "D":
                        #region Удаление записи
                        Console.Clear();
                        Console.WriteLine("Введите ID Сотрудника для удаления или нажмите Enter " +
                            "для выхода в основное меню");
                        Str = Console.ReadLine();
                        if (Str != "")
                        {
                            workers = Delete(workers, Convert.ToInt32(Str));
                            //Print(res);
                            FullWrite(workers);
                            //workers = ReadFile();
                        }
                        break;
                        #endregion
                    case "P":
                        #region Case P(Печать)
                        Console.Clear();
                        Console.WriteLine("Введите ID сотрудника или нажмите Enter для печати всего файла");
                        // if (Console.ReadKey(true).Key.ToString() == "Enter")
                        Str = Console.ReadLine();
                        if (Str  == "")
                        { Print(workers); break; }
                        else
                        {
                            Print(workers, Convert.ToInt32(Str));
                            //Console.WriteLine(workers[Convert.ToInt32(Console.ReadLine())].Print());
                            break;
                        }
                    #endregion
                    case "A": 
                        AddWorker(); workers = ReadFile(); break;
                    case "S":
                        #region Сортировка
                        Console.Clear();
                        Console.WriteLine("Нажмите одну из следующих клавиш:\nU - По возрастанию\n" +
                        "D - По убыванию");
                        for (int j = 0; j == 0;)
                        {
                            switch (Console.ReadKey(true).Key.ToString())
                            {
                                case "U":
                                    Array.Sort(workers, (x, y) => DateTime.Compare(x.TimeWrite, y.TimeWrite));
                                    j++;
                                    break;
                                case "D":
                                    Array.Sort(workers, (x, y) => DateTime.Compare(y.TimeWrite, x.TimeWrite));
                                    j++;
                                    break;
                            }
                        }
                        Console.Clear();
                        Console.WriteLine("\nДля записи данных в файл нажмите W, " +
                            "или любую другую клавишу для перехода в основное меню");
                        Print(workers);
                        if (Console.ReadKey(true).Key.ToString() == "W")
                        { FullWrite(workers); workers = ReadFile(); }
                        
                        //Console.ReadKey();
                        break;
                    #endregion
                    case "R":
                        #region Вывод информации в диопозоне дат
                        DateTime x1, x2;
                        Console.WriteLine("Введите первую дату в формате гггг.мм.чч");
                        x1 = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Введите Вторую дату в формате гггг.мм.чч");
                        x2 = Convert.ToDateTime(Console.ReadLine());
                        Print(workers,x1,x2);
                        break;
                    #endregion
                    case "E":
                        #region Редактирование
                        Console.Clear();
                        Console.Write("Введите ФИО сотрудника: ");
                        Str = Console.ReadLine();
                        workers = EditWorkers(workers, Str);
                        //FullWrite(workers);
                        break;
                        #endregion


                }
                //Console.WriteLine(Console.ReadKey(true).Key.ToString());
            }
        }
    }
}
