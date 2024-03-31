
using System;
using System.Collections;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main()
        {

int K = Convert.ToInt32(Console.ReadLine()), 
 N = Convert.ToInt32(Console.ReadLine()),
 minR = int.MaxValue,
 minI = 0,
 r = K;
int[] Towns = new int[k];
bool can = false; 

            for (int i = 0; i < K; i++) 
                Towns[i] = Convert.ToInt32(Console.ReadLine());



            for (int i = 1; i < K; i++) 
                r += Towns[i];


            for (int i = 0; i < Towns[Towns.Length - 1]; i++) 
            {
bool Canstayhere = true;


                foreach (int town in Towns) 
                {
                    if (town >= i) 
                        r--; 
                    else
                        r++; 
                    if (Math.Abs(town - i) < N) 
                        Canstayhere = false; 
                }


                if (Canstayhere) 
                {
can = true; 
                    if (r < minR) 
                    {
                        minR = r; 
                        minI = i;
                    }
                }
            }


            if (can) 
                Console.WriteLine
                    ($"Ответ: на километре {minI} минимальное расстояние будет {minR}");
            else
                Console.WriteLine
                    ("Нет таких мест для заправок");
            Console.ReadKey();
        }
    }
}
