using System;

namespace Prog
{
    class Program
    {
        public static void Main()
        {

int N = Convert.ToInt32(Console.ReadLine()),
sum = 0;

int[] min_r1 = { Int32.MaxValue, Int32.MaxValue }, min_r2 = { Int32.MaxValue, Int32.MaxValue };
            
            for (int i = 0; i < N; i++)
            {
string[] Nums = Console.ReadLine().Split(' ');

int num1 = Convert.ToInt32(Nums[0]),
num2 = Convert.ToInt32(Nums[1]),
mainparam = Math.Abs(num1 - num2);

                if (mainparam % 3 == 1)
                {
                    if (mainparam < min_r1[0])
                    {
                        min_r1[0] = mainparam;
                    }
                    else if (mainparam < min_r1[1])
                    {
                        min_r1[1] = mainparam;
                    }
                }
                else if (mainparam % 3 == 2)
                {
                    if (mainparam < min_r2[0])
                    {
                        min_r2[0] = mainparam;
                    }
                    else if (mainparam < min_r2[1])
                    {
                        min_r2[1] = mainparam;
                    }
                }

                sum += Math.Max(num1, num2);
            }

            bool bo1 = (min_r1[0] < Int32.MaxValue || min_r1[1] < Int32.MaxValue)|| (min_r2[0] < Int32.MaxValue && min_r2[1] < Int32.MaxValue),
                 bo2 = (min_r2[0] < Int32.MaxValue || min_r2[1] < Int32.MaxValue)|| (min_r1[0] < Int32.MaxValue && min_r1[1] < Int32.MaxValue);

            if (sum % 3 == 0)
            {
                Console.WriteLine($"Максимальная сумма кратная трем: {sum}" );
            }
            else if (sum % 3 == 1 && bo1)
            {
                int r1 = ((min_r1[0] < min_r1[1]) ? min_r1[0] : min_r1[1]);
                int min = r1;

                if (min_r2[0] < Int32.MaxValue && min_r2[1] < Int32.MaxValue)
                {
                    int r2 = min_r2[0] + min_r2[0];
                    min = (min < r2 ? min : r2);
                }

                if (min < Int32.MaxValue)
                {
                    sum = sum - min;
                }

                Console.WriteLine($"сумма кратная 3: {sum}");
            }
            else if (sum % 3 == 2 && bo2)
            {
                int r2 = ((min_r2[0] < min_r2[1]) ? min_r2[0] : min_r2[1]);
                int min = r2;

                if (min_r1[0] < Int32.MaxValue && min_r1[1] < Int32.MaxValue)
                {
                    int r1 = min_r1[0] + min_r1[0];
                    min = (min < r1 ? min : r1);
                }

                if (min < Int32.MaxValue)
                {
                    sum = sum - min;
                }

                Console.WriteLine($"сумма кратная 3: {sum}");
            }

            else
            {
                Console.WriteLine("Невозможно");
            }

        }
    }
}