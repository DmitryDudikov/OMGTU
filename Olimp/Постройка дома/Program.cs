
using System;
using System.Collections;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main()
        {
            int X = Convert.ToInt32(Console.ReadLine());
            int Y = Convert.ToInt32(Console.ReadLine());
            int L = Convert.ToInt32(Console.ReadLine());
            int C1 = Convert.ToInt32(Console.ReadLine());
            int C2 = Convert.ToInt32(Console.ReadLine());
            int C3 = Convert.ToInt32(Console.ReadLine());
            int C4 = Convert.ToInt32(Console.ReadLine());
            int C5 = Convert.ToInt32(Console.ReadLine());
            int C6 = Convert.ToInt32(Console.ReadLine());
            int[] TeorS = new int[2];
            int P = 2 * (X + Y), Summ = (P - L) * (C5 + C4);
            if ((L <= X) && (L <= Y))
            {
                if (C4 + C5 + C6 + C2 < C1)
                {
                    Summ += L * (C4 + C5 + C6 + C2);
                }
                else
                {
                    Summ += L * C1;
                }
                Console.WriteLine($"Summ: {Summ}");
            }
            else
            {
                if (L > X)
                {
                    Console.WriteLine("X :: ");
                    if (C4 + C5 + C6 + C2 < C1)
                    {
                        Console.WriteLine("Новая 1 ::");
                        Summ += (C4 + C5 + C6 + C2) * X;
                    }
                    else
                    {
                        Console.WriteLine("Восстановить ::");
                        Summ += X * C1;
                    }
                    if (C4 + C5 + C6 + C2 < C2 + C3)
                    {
                        Console.WriteLine("Новая 2 ::");
                        Summ += (C4 + C5 + C6 + C2) * (L - X);
                    }
                    else
                    {
                        Console.WriteLine("Переместить ::");
                        Summ += (L - X) * (C2 + C3);
                        
                    }
                    TeorS[0] = Summ;
                }
                Summ = (P - L) * (C5 + C4);
                if (L > Y)
                {
                    Console.WriteLine("Y :: ");
                    if (C4 + C5 + C6 + C2 < C1)
                    {
                        Console.WriteLine("Новая 1 ::");
                        Summ += (C4 + C5 + C6 + C2) * Y;
                    }
                    else
                    {
                        Console.WriteLine("Восстановить ::");
                        Summ += Y * C1;
                    }
                    if (C4 + C5 + C6 + C2 < C2 + C3)
                    {
                        Console.WriteLine("Новая 2 ::");
                        Summ += (C4 + C5 + C6 + C2) * (L - Y);
                    }
                    else
                    {
                        Console.WriteLine("Переместить ::");
                        Summ += (L - Y) * (C2 + C3);
                       
                    } 
                    TeorS[1] = Summ;
                }

            }
            Console.WriteLine($"Минимальный {Math.Min(TeorS[0], TeorS[1])}");
            Console.ReadKey();
            
        }
    }
}
