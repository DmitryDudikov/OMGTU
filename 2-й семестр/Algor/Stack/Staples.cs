class Program
{
    static void Main()
    {
        Console.WriteLine("Введите выражение, содержащее 3 вида скобок: () {} []: ");
        string str = Console.ReadLine();
        char[] staples = new char [] { '(', ')', '[', ']', '{', '}' };

        Stack<char> stack = new Stack<char>();

        foreach(char c in str)
        {
            int index = Array.IndexOf(staples, c);
            if(c == '(' || c == '[' || c == '{') stack.Push(c);
            else if (index != -1)
            {
                if (stack.Count > 0 && stack.Peek() == staples[index-1]) stack.Pop();
            }   else stack.Push(c);
        }

        if (stack.Count > 0) Console.WriteLine("Неверно расставлены скобки");
        else Console.WriteLine("Скобки расставлены верно");

    }
}
