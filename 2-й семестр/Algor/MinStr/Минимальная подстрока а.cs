class Program
{
    static void Main()
    {
        string minSubstring = "";
        int minSubstringLength = 1000;

        foreach (string s in File.ReadLines(@"C:\Users\kiril\OneDrive\Рабочий стол\ТестФайл.txt")) 
        {
            int minLength = GetMinSubstringLength(s);
            if (minLength < minSubstringLength)
            {
                minSubstringLength = minLength;
                minSubstring = s;
            }
        }
        Console.WriteLine($"Cтрока с наименьшей длиной подпоследовательности состоящей из символов а: {minSubstring}");
        Console.WriteLine($"Ее длина: {minSubstringLength}");
    }

    static int GetMinSubstringLength (string line)
    {
        int minLength = 1000;
        int length = 0;
        bool count = false;

        foreach ( char c in line)
        {
            if (c == 'a')
            {
                if (!count)
                {
                    count = true;
                    length = 1;
                }
                else length++;
            }

            else if (count)
            {
                if (length < minLength) minLength = length;
                count = false;
                length = 0;
            }
        }
        if(count && length < minLength)  minLength = length;

        return minLength == 1000 ? 0 : minLength;
    }
}
