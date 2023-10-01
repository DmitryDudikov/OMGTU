using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            int N_Loop;
            N_Loop = Convert.ToInt32(Console.ReadLine());
            int Num = 0,
                Previous_Num = Num,
                Min_Num = 0,
                num_Min_Num = 0,
                num_Less_prev = 0,
                num_of_change = 0;
            for (int i = 0;i < N_Loop;i++ )
            
            {
                
                Num = Convert.ToInt32(Console.ReadLine());
                //5. 
                if (i==0)
                {
                    Previous_Num = Num;
                    Min_Num = Num;
                }
                if (Num < Previous_Num)
                {
                    num_Less_prev++;
                }

                //6. 
                if (Num < Min_Num)
                {
                    Min_Num = Num;
                    num_Min_Num++;
                }
                //7. 
                if (Previous_Num * Num < 0) num_of_change += 1;
                Previous_Num = Num;
            }
            Console.WriteLine($"Кол-во элементов, значение которых меньше предыдущего: {num_Less_prev}\n" +
                $"Кол-во элементов значение которых меньше всех предыдущих элементов: {num_Min_Num}\n" +
                $"Кол-во смены знаков в последовательности:{num_of_change} ");
        }
    }
}
