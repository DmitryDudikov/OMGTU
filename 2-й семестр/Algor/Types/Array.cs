class Program
{
    static void Main()
    {
        try
        {

            Console.WriteLine("Введите элементы Array: ");
            double[] array = Console.ReadLine().Split(" ").Select(s => Convert.ToDouble(s)).ToArray();
            bool enter = true;

            while (enter)
            {
                Menu();

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine($"Count: {array.Count()}");
                        break;

                    case "2":
                        double[] BinArray = (double[])array.Clone();
                        Array.Sort(BinArray);
                        Console.WriteLine("Введите элемент поиска: ");
                        double element = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine(Array.BinarySearch(BinArray, element));
                        break;

                    case "3":
                        Console.WriteLine("Введите второй массив: ");
                        double[] array2 = Console.ReadLine().Split(" ").Select(s => Convert.ToDouble(s)).ToArray();
                        Array.Copy(array2, array, 3);
                        Console.WriteLine($"array после копирования: ");
                        PrintArray(array);
                        break;

                    case "4":
                        Console.WriteLine("Поиск первого четного числа");
                        Console.WriteLine(Array.Find(array, n => n % 2 == 0));
                        break;

                    case "5":
                        Console.WriteLine("Поиск последнего четного числа");
                        Console.WriteLine(Array.FindLast(array, n => n % 2 == 0));
                        break;

                    case "6":
                        Console.WriteLine("Поиска индекса числа. Введите число: ");
                        double num = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Индекс числа num: " + Array.IndexOf(array, num));
                        break;

                    case "7":
                        Console.WriteLine("array в обратном порядке: ");
                        PrintArray(array);
                        break;
                    case "8":
                        Console.WriteLine("Сколько элементов должно остаться в array? ");
                        byte resize = Convert.ToByte(Console.ReadLine());
                        Array.Resize(ref array, resize);
                        PrintArray(array);
                        break;
                    case "9":
                        Array.Sort(array);
                        PrintArray(array);
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
                "4) Find\n" +
                "5) FindLast\n" +
                "6) IndexOf\n" +
                "7) Reserve\n" +
                "8) Resize\n" +
                "9) Sort\n" +
                "0) Выход из программы");
    }
    static void PrintArray(double[] array)
    {
        foreach (double d in array) Console.Write($"{d}");
        Console.WriteLine();
    }
}
/**********************
1 2 3 45 67 8 0 - 23 - 12 100 */
