class Program
{
    static void Main()
    {
        Console.WriteLine("Ввелите выражение в обратой польской записи: ");
        string pollish_string = Console.ReadLine();

        var elements = pollish_string.Split(' ');
      
        Stack<double> stack = new Stack<double>();

        foreach (var element in elements)
        {
            if (element == "+" || element == "-" || element == "*" || element == "/")
            {
                double a = (double)stack.Pop();
                double b = (double)stack.Pop();

              try
                {
                    switch (element)
                    {
                        case "+":
                            stack.Push(a + b); break;

                        case "-":
                            stack.Push(a - b); break;

                        case "*":
                            stack.Push(a * b); break;

                        case "/":
                            if (a == 0) throw new Exception("На ноль делить нельзя!");

                            stack.Push(a / b); break;
                    }
                }

                catch (Exception e) { Console.WriteLine(e.Message); }

            }
            else
            {
                try
                {
                    stack.Push(double.Parse(element));
                }

                catch
                {
                    Console.WriteLine("Запись введена неверно!");
                }
            }
        }

        Console.WriteLine($"Результат: {stack.Peek()}");
    }
}
