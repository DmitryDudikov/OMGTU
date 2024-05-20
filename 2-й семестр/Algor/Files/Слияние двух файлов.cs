class Program
{
    static void Main()
    {
        StreamReader file1 = new StreamReader(@"C:\Users\kiril\OneDrive\Рабочий стол\файл1.txt");
        StreamReader file2 = new StreamReader(@"C:\Users\kiril\OneDrive\Рабочий стол\файл2.txt");

        int data1 = Convert.ToInt32(file1.ReadLine());
        int data2 = Convert.ToInt32(file2.ReadLine());
        int check = 0;

        while (true)
        {
            if (data1 < data2)
            {
                Console.WriteLine(data1);
                string read1 = file1.ReadLine();
                if (read1 != null)
                {
                    data1 = Convert.ToInt32(read1);
                }
                else { check = 1; break; }
            }
            else
            {
                Console.WriteLine(data2);
                string read2 = file2.ReadLine();
                if (read2 != null)
                {
                    data2 = Convert.ToInt32(read2);
                }
                else { check = 2; break; }
            }
        }

        if (check == 2)
        {
            Console.WriteLine(data1);
            while (true)
            {
                string read1 = file1.ReadLine();
                if (read1 != null)
                {
                    data1 = Convert.ToInt32(read1);
                    Console.WriteLine(data1);
                }
                else { break; }
            }
        }

        else if (check == 1)
        {
            Console.WriteLine(data2);
            while (true)
            {
                string read2 = file2.ReadLine();
                if (read2 != null)
                {
                    data2 = Convert.ToInt32(read2);
                    Console.WriteLine(data2);
                }
                else { break; }
            }
        }
    }
}
