using System.Collections;

class Program
{
    static void Main()
    {
        try
        {

            Console.WriteLine("Введите элементы ArrayList: ");
            var array = Console.ReadLine().Split(" ").Select(s => Convert.ToDouble(s)).ToArray();
            var array_list = new ArrayList();
            array_list.AddRange(array);
            
            bool enter = true;

            while (enter)
            {
                Menu();

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine($"Count: {array_list.Count}");
                        break;

                    case "2":
                        var BinArrayList = new ArrayList(array_list);
                        BinArrayList.Sort();
                        Console.WriteLine("Введите элемент поиска: ");
                        double element = Convert.ToDouble(Console.ReadLine());
                        double bin_search = BinArrayList.BinarySearch(element);
                        Console.WriteLine($"Идекс элемента: {bin_search}");
                        break;

                    case "3":
                        var array_list2 = new ArrayList(array_list);
                        Console.WriteLine($"array_list после копирования: ");
                        PrintArrayList(array_list);
                        break;

                    case "4":
                        Console.WriteLine("Поиска индекса числа. Введите число: ");
                        double num = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Индекс числа num: " + array_list.IndexOf(num));
                        break;

                    case "5":
                        Console.WriteLine("Вставка числа в ArrayList\n Введите индекс: ");
                        int index = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите число: ");
                        double number = Convert.ToDouble(Console.ReadLine());
                        
                        array_list.Insert(index, number);
                        Console.WriteLine("ArrayList после вставки: ");
                        PrintArrayList(array_list);
                        break;

                    case "6":
                        Console.WriteLine("array в обратном порядке: ");
                        array_list.Reverse();
                        PrintArrayList(array_list);
                        break;

                    case "7":
                        array_list.Sort();
                        PrintArrayList(array_list);
                        break;

                    case "8":
                        Console.WriteLine("Введите число, которое будет добавлено в ArrayList: ");
                        double number_ = Convert.ToDouble(Console.ReadLine());
                        array_list.Add(number_);
                        Console.WriteLine("ArrayList после добавления числа: ");
                        PrintArrayList(array_list);
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
                "1) Count\n" +
                "2) BinSearch\n" +
                "3) Copy\n" +
                "4) IndexOf\n" +
                "5) Insert\n" +
                "6) Reserve\n" +
                "7) Sort\n" +
                "8) Add\n" + 
                "0) Выход из программы");
    }
    static void PrintArrayList(ArrayList arrayList)
    {
        foreach (double d in arrayList) Console.Write($"{d}");
        Console.WriteLine();
    }
}
/**********************
1 2 3 45 67 8 0 -23 -12 100 */
