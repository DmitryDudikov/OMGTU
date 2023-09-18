using System;

namespace Задача
{
    class Program
    {
        static void Main()
        {
            int X, Y;
            X = Convert.ToInt32(Console.ReadLine());
            Y = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Большее: " +
                $"{(X + Y + Math.Abs(X - Y) ) / 2}" 
                +
                $"\nМеньшее: {(X + Y - Math.Abs(X - Y))/2}");
        }
    }
}