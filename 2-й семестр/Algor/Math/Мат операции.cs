using System.Reflection.Metadata;

interface Function
{
    double Add(double a, double b);
    double Subtract(double a, double b);
    double Multiply(double a, double b);
    double Divide(double a, double b);
    double Sqrt(double a, double b);
    double Sin(double a);
    double Cos(double a);
}

class Program : Function
{
    public double Add(double a, double b)
    {
        return a + b;
    }

    public double Subtract(double a, double b)
    {
        return a - b;
    }

    public double Multiply(double a, double b)
    {
        return a * b;
    }

    public double Divide(double a, double b)
    {
        try
        {
            if (b == 0) throw new Exception("На ноль делить нельзя!");
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return a / b;
    }

    public double Sqrt(double a, double b)
    {
        try
        {
            if (a < 0 && b % 2 == 0) throw new Exception("Корень из отрицательного числа!");

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return Math.Pow(a, 1.0 / b);
    }

    public double Sin(double a)
    {
        return Math.Sin(a);
    }

    public double Cos(double a)
    {
        return Math.Cos(a);
    }

    public delegate double BiFunction(double a, double b);
    public delegate double UnFunction(double a);

    public static void Main()
    {
        Program program = new Program();

        Console.WriteLine("Выберите операцию:\n"
            + "1) + \n"
            + "2) - \n"
            + "3) * \n"
            + "4) / \n"
            + "5) Sqrt \n"
            + "6) Sin \n"
            + "7) Cos \n");

        int choice = Convert.ToInt32(Console.ReadLine());
        BiFunction bi = new BiFunction(program.Add);
        UnFunction un = new UnFunction(program.Sin);

        switch (choice)
        {
            case 1:
                {
                    bi = new BiFunction(program.Add);
                    break;
                }
            case 2:
                {
                    bi = new BiFunction(program.Subtract);
                    break;
                }
            case 3:
                {
                    bi = new BiFunction(program.Multiply);
                    break;
                }
            case 4:
                {
                    bi = new BiFunction(program.Divide);
                    break;
                }
            case 5:
                {
                    bi = new BiFunction(program.Sqrt);
                    break;
                }
            case 6:
                {
                    un = new UnFunction(program.Sin);
                    break;
                }
            case 7:
                {
                    un = new UnFunction(program.Cos);
                    break;
                }
        }

        if(choice >=1 && choice <=4)
        {
            Console.WriteLine("Введите два операнда: ");
            double a = Convert.ToDouble(Console.ReadLine());
            double b = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Результат: \t{bi(a,b)}");
        }
        else if(choice == 5)
        {
            Console.WriteLine("Введите два операнда: сначала подкоренное выражение, потом степень корня ");
            double a = Convert.ToDouble(Console.ReadLine());
            double b = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Результат: \t{bi(a, b)}");
        }
        else if (choice == 6 | choice == 7)
        {
            Console.WriteLine("Введите операнд: ");
            double c = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Результат: \t{un(c)}");
        }
        
    }
}
