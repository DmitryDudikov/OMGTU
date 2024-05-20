using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> list = new List<string>() {"apple", "no", "car", "cat", "dog", "computer", "visual", "studio"};
        Console.WriteLine("Oтбор элементов четной длины: ");
        GetLength2(list);
        for (int i = 0; i <= list.Count; i++)
        {
            if ((i + 1) % 2 == 0)
            {
                list.Remove(list[i]);
            }
        }
        Console.WriteLine();
        Console.WriteLine("Список после удаления элементов: ");
        GetLength2(list);
    }
    static void GetLength2(List<string> list1)
    {
        var result = list1.Where(e => e.Length % 2 == 0).Select(e => e);
        foreach (string i in result)
        {
            Console.Write(i + "   ");
        }
    }
}
