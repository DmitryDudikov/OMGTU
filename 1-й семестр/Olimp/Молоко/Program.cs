using System;
using System.IO;
namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            string line;
            float[] C = new float[8];
            float Pr = 1290450000000;
            int Str=0,Best_str=0;
            StreamReader sr = new StreamReader("C:\\Users\\dudik\\Downloads\\Telegram Desktop\\input4.txt");
            sr.ReadLine();


            for (line = sr.ReadLine(); line != null;line = sr.ReadLine())
            {
                Str += 1;
                int k = 0;
                float V_1, V_2, S_1, S_2;
                line = line.Replace('.', ',');
                Console.WriteLine(line);
                foreach (string i in line.Split(' '))
                {
                    
                    
                    C[k] = Convert.ToSingle(i);
                   
                    Console.WriteLine(C[k]);
                    
                     
                k++;
                }
                V_1 = C[0] * C[1] * C[2] ;
                V_2 = C[3] * C[4] * C[5] ;

                S_1 =  2* ( C[0] * C[1] + C[1] * C[2] + C[2] * C[0]); 
                S_2 =  2* ( C[3] * C[4] + C[4] * C[5] + C[3] * C[5]);
                Console.WriteLine((C[7] * S_1 - C[6] * S_2) / (V_2 * S_1 - V_1 * S_2));
                if ((C[7]*S_1 - C[6]*S_2)/(V_2* S_1 - V_1*S_2)< Pr)
                {
                Best_str = Str;
                Pr = (C[7] * S_1 - C[6] * S_2) / (V_2 * S_1 - V_1 * S_2);
                }

            }
            Console.WriteLine($"{Best_str} : {Pr*1000:N2}");


        }
           
    }
}