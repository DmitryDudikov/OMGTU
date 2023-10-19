
namespace Prog 
{

    class Program
    {
        public static void Main()
        {
            int K = Convert.ToInt32(Console.ReadLine()), M = Convert.ToInt32(Console.ReadLine()), W = Convert.ToInt32(Console.ReadLine());

            int[] mice = new int[K];
            for (int i = 0; i < K; i++)
            {
                mice[i] = 0;
            }

            int pointer = 0;
            mice[pointer] = 1;

            while (mice.Count(c => c == 0) > 0)
            {
                int move = 0;

                while (move != M)
                {
                    ++pointer;

                    if (pointer > K - 1)
                    {
                        pointer = 0;
                    }

                    if (mice[pointer] == 0)
                    {
                        ++move;
                    }
                }

                mice[pointer] = 1;
            }

            int rs = pointer - W;
            int answer = (K - rs) % K;

            Console.WriteLine($"Ответ: {answer}");
        }
    }
}
