class Program
{
    static void Main()
    {
        SortedSet<double> set1 = new SortedSet<double>();
        SortedSet<double> set2 = new SortedSet<double>();
        SortedSet<double> set3 = new SortedSet<double>();

        Console.WriteLine("Введите количество элементов первого множества");
        int number1 = Convert.ToInt32 (Console.ReadLine());

        Console.WriteLine("Введите количество элементов второго множества");
        int number2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите количество элементов третьего множества");
        int number3 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите элементы первого множества: ");

        for (int i = 0; i < number1; i++)
        {
            double elementOfSet1 = Convert.ToDouble(Console.ReadLine());
            set1.Add(elementOfSet1);

        }

        Console.WriteLine("Введите элементы второго множества: ");

        for (int i = 0; i < number2; i++)
        {
            double elementOfSet2 = Convert.ToDouble(Console.ReadLine());
            set2.Add(elementOfSet2);

        }

        Console.WriteLine("Введите элементы третьего множества: ");

        for (int i = 0; i < number3; i++)
        {
            double elementOfSet3 = Convert.ToDouble(Console.ReadLine());
            set3.Add(elementOfSet3);

        }

        Console.WriteLine("Элементы первого множества: ");
        foreach (double elementOfSet in set1) Console.Write($"{elementOfSet}" + " ");
        Console.WriteLine();


        Console.WriteLine("Элементы второго множества: ");
        foreach (double elementOfSet in set2) Console.Write($"{elementOfSet}" + " ");
        Console.WriteLine();


        Console.WriteLine("Элементы третьего множества: ");
        foreach (double elementOfSet in set3) Console.Write($"{elementOfSet}" + " ");
        Console.WriteLine();

        SortedSet<double> intersection = new SortedSet<double>(from x in set1.Intersect(set2).Intersect(set3) select x);
        Console.WriteLine("Пересечение всех множеств: ");
        foreach (double elementOfSet in intersection) Console.Write($"{elementOfSet}" + " ");
        Console.WriteLine();

        SortedSet<double> union = new SortedSet<double>(from x in set1.Union(set2).Union(set3) select x);
        Console.WriteLine("Объединение всех множеств: ");
        foreach (double elementOfSet in union) Console.Write($"{elementOfSet}" + " ");
        Console.WriteLine();

        SortedSet<double> additionForSet1 = new SortedSet<double>(from x in union.Except(set1) select x);
        Console.WriteLine("Дополнение для set1: ");
        foreach (double elementOfSet in additionForSet1) Console.Write($"{elementOfSet}" + " ");
        Console.WriteLine();

        SortedSet<double> additionForSet2 = new SortedSet<double>(from x in union.Except(set2) select x);
        Console.WriteLine("Дополнение для set2: ");
        foreach (double elementOfSet in additionForSet2) Console.Write($"{elementOfSet}" + " ");
        Console.WriteLine();

        SortedSet<double> additionForSet3 = new SortedSet<double>(from x in union.Except(set3) select x);
        Console.WriteLine("Дополнение для set3: ");
        foreach (double elementOfSet in additionForSet3) Console.Write($"{elementOfSet}" + " ");
        Console.WriteLine();
    }
}
