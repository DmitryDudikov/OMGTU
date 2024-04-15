using System.Collections;
using System.Security.Cryptography.X509Certificates;

class Program
{
    public static void HashtableSolve()
    {
        Hashtable callLog = new Hashtable();

        Queue<string> queue = new Queue<string>();

        Console.WriteLine("Введите данные о звонке: номер телефона, дата разговора, время начало разговора, количество минут разговора.\n"
            + "Чтобы закончить ввод, введите 'стоп'\n");

        string data = Console.ReadLine();

        while (data != "стоп")
        {
            Console.WriteLine("Введите данные о звонке:");
            queue.Enqueue(data);
            data = Console.ReadLine();
            Console.WriteLine();
        }

        int queueCount = queue.Count;
        for (int i = 0; i < queueCount; i++)
        {
            string number = queue.Dequeue();
            string[] elementOfQueue = number.Split();

            string dateOfCall = elementOfQueue[1];
            double CountMinuteOfCall = Convert.ToDouble(elementOfQueue[3]);

            if (callLog.ContainsKey(dateOfCall))
            {
                callLog[dateOfCall] = Convert.ToDouble(callLog[dateOfCall]) + CountMinuteOfCall;
            }
            else callLog.Add(dateOfCall, CountMinuteOfCall);
        }

        Console.WriteLine("Суммарное время разговора по датам: ");
        foreach (DictionaryEntry date in callLog)
        {
            Console.WriteLine($"Дата: {date.Key}, сумма минут разговора: {date.Value}");
        }
    }

    public static void DictionatySolve()
    {
        var callLog = new Dictionary<string, double>();

        Queue<string> queue = new Queue<string>();

        Console.WriteLine("Введите данные о звонке: номер телефона, дата разговора, время начало разговора, количество минут разговора.\n"
            + "Чтобы закончить ввод, введите 'стоп'\n");

        string data = Console.ReadLine();

        while (data != "стоп")
        {
            Console.WriteLine("Введите данные о звонке:");
            queue.Enqueue(data);
            data = Console.ReadLine();
            Console.WriteLine();
        }

        int queueCount = queue.Count;
        for (int i = 0; i < queueCount; i++)
        {
            string[] elementOfQueue = queue.Dequeue().Split();

            string dateOfCall = elementOfQueue[1];
            double CountMinuteOfCall = Convert.ToDouble(elementOfQueue[3]);

            if (callLog.ContainsKey(dateOfCall))
            {
                callLog[dateOfCall] = Convert.ToDouble(callLog[dateOfCall]) + CountMinuteOfCall;
            }
            else callLog.Add(dateOfCall, CountMinuteOfCall);
        }

        Console.WriteLine("Суммарное время разговора по датам: ");
        foreach (var date in callLog)
        {
            Console.WriteLine($"Дата: {date.Key}, сумма минут разговора: {date.Value}"); 
        }
    }

    static void Main()
    {
        Console.WriteLine("Что будем использовать?\n"
            + "1) Хэштаблицу\n"
            + "2) Словарь");

        int choice = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        if (choice == 1)
        {
            Console.WriteLine("Данные из хэштаблицы:\n");
            HashtableSolve();
        }
        else if (choice == 2)
        {
            Console.WriteLine("Данные из словаря:\n ");
            DictionatySolve();
        }
        else Console.WriteLine("Введено неверное значение!");
    }
}
