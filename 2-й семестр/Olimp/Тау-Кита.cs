using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputString = File.ReadAllText(@"E\Temp\input\input1.txt");
        string[] words = inputString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var circularList = new List<string>();

        if (words.Length % 2 == 0)
        {
            int middleIndex = words.Length / 2;
            circularList.Add(words[middleIndex]);
            for (int i = 1; i <= middleIndex; i++)
            {
                circularList.Add(words[middleIndex - i]);
                if (i < middleIndex)
                {
                    circularList.Add(words[middleIndex + i]);
                }
            }
        }
        else
        {
            int middleIndex = (words.Length - 1) / 2;
            circularList.Add(words[middleIndex]);
            for (int i = 1; i <= middleIndex; i++)
            {
                circularList.Add(words[middleIndex - i]);
                circularList.Add(words[middleIndex + i]);
            }
        }

        var palindromeList = new List<string>();
        foreach (var word in circularList)
        {
            string palindrome = "";
            if (word.Length % 2 == 0)
            {
                int middleIndex = word.Length / 2;
                palindrome += word[middleIndex];
                for (int i = 1; i <= middleIndex; i++)
                {
                    palindrome += word[middleIndex - i];
                    if (i < middleIndex)
                    {
                        palindrome += word[middleIndex + i];
                    }
                }
            }
            else
            {
                int middleIndex = (word.Length - 1) / 2;
                palindrome += word[middleIndex];
                for (int i = 1; i <= middleIndex; i++)
                {
                    palindrome += word[middleIndex - i];
                    palindrome += word[middleIndex + i];
                }
            }
            palindromeList.Add(palindrome);
        }

        string outputString = string.Join(" ", palindromeList);
        Console.WriteLine(outputString);
    }
}
