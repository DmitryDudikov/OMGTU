using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = new int[] { 11, 132, 133, 666, 997, 119, 9, 0, 3 };

        Console.WriteLine("Элементы с последней цифрой кратной 3:");

        elements.Where(e => e % 10 % 3 == 0).ToList().ForEach(e => Console.Write(e + " "));
        }
    }
