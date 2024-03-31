static void Main()
{
    int MaxN = Convert.ToInt32(Console.ReadLine());

    int cmbs = 0;
    for (int i = 1; i < MaxN + 1; i++)
    {
        for (int j = 2; j < 18; j++)
        {
            if (j % Math.Pow(2, i - 1) == 0)
                cmbs++;
        }
    }
    Console.WriteLine(MaxN + cmbs);
}