using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            SortedList list = new SortedList();

            bool enter = true;

            while (enter)
            {
                Menu();

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Введите количество элементов SortedList: ");
                        int count_ = Convert.ToInt32(Console.ReadLine());
                        object key, value;
                        for (int i = 0; i < count_; i++)
                        {
                            Console.WriteLine("Введите ключ: ");
                            key = Console.ReadLine();
                            Console.WriteLine("Введите значение ключа: ");
                            value = Console.ReadLine();
                            list.Add(key, value);
                        }
                        Console.Write("SortedList:\t ");
                        PrintSortedList(list);
                        break;

                    case "2":
                        Console.WriteLine("Введите ключ: ");
                        key = Console.ReadLine();
                        int index = list.IndexOfKey(key);
                        Console.WriteLine($"Индекс ключа: {index}");
                        break;

                    case "3":
                        Console.WriteLine("Введите значение ключа: ");
                        value = Console.ReadLine();
                        index = list.IndexOfValue(value);
                        Console.WriteLine($"Индекс значения ключа: {index}");
                        break;

                    case "4":
                        Console.WriteLine("Введите ключ:");
                        key = Console.ReadLine();
                        index = list.IndexOfKey(key);

                        value = list.GetByIndex(index);
                        Console.WriteLine($"Значение ключа - {value}");
                        break;

                    case "5":
                        Console.WriteLine("Введите значение:");
                        value = Console.ReadLine();
                        index = list.IndexOfValue(value);

                        key = list.GetKey(index);
                        Console.WriteLine($"Ключ значения - {key}");
                        break;

                    case "0":
                        enter = false;
                        break;
                }
            }
        }
        catch
        {
            Console.WriteLine("Неправильный ввод данных");
        }
    }

    static void Menu()
    {
        Console.WriteLine(
                "Выберите действие: \n" +
                "1) Добавление элементов SortedList\n" +
                "2) Вывод ключа по индексу\n" +
                "3) Вывод значения по индексу\n" +
                "4) Поиск значения по ключу\n" +
                "5) Поиск ключа по значению\n" +
                "0) Выход из программы");
    }
    static void PrintSortedList(SortedList list)
    {
        for (int i = 0; i < list.Count; i += 1)
        {
            Console.WriteLine("Ключ: {0},\tЗначение: {1}", list.GetKey(i), list.GetByIndex(i));
        }
    }
}
