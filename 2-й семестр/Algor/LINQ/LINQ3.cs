using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        int[] numbers = { 123, 456, 789, 111, 415, 800, 444, 555, 666, 1234561, 0, 112 };
        var result = numbers.Where(n => n.ToString().Select(c => int.Parse(c.ToString())).Sum() % 2 == 0);

        Console.WriteLine("Элементы с четной суммой цифр:\n ");
        foreach (var res in result)
        {
            Console.WriteLine(res);
        }
    }
}
