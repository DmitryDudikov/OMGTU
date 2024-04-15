using System.Collections;

class Program
{
    static void Main()
    {
        List<string> phoneCall = new List<string>();
        Console.WriteLine("Введите данные о звонке через пробел: номер телефона звонителя, номер телефона звонимого, дата разговора, количество минут разговора.\n"
                   + "Чтобы закончить ввод, введите 'стоп'\n");

        string data = Console.ReadLine();

        while (data != "стоп")
        {
            Console.WriteLine("Введите данные о звонке или введите стоп");
            phoneCall.Add(data);
            data = Console.ReadLine();
            Console.WriteLine();
        }

        Hashtable result = new Hashtable();

        List<string> listData = new List<string>();

        for (int i = 0; i < phoneCall.Count; i++)
        {
            Hashtable countMinCall = new Hashtable();
            string dataOfCall = phoneCall[i].Split()[2];

            for (int j = 0; j < phoneCall.Count; j++)
            {
                string number = phoneCall[j];
                string[] splitData = number.Split();

                string adresat = splitData[1];
                string date = splitData[2];
                double countMinuteOfCall = Convert.ToDouble(splitData[3]);

                if (date == dataOfCall && !listData.Contains(date))
                {
                    if (countMinCall.ContainsKey(adresat))
                    {
                        countMinCall[adresat] = Convert.ToDouble(countMinCall[adresat]) + 1;
                    }
                    else countMinCall.Add(adresat, 1);
                }
            }

            string phone = "";
            double max = 0;

            foreach (DictionaryEntry entry in countMinCall)
            {
                if (Convert.ToDouble(entry.Value) > max)
                {
                    max = Convert.ToDouble(entry.Value);
                    phone = Convert.ToString(entry.Key);
                }
            }

            if (!result.ContainsKey(dataOfCall)) result.Add(dataOfCall, phone);

            listData.Add(dataOfCall);
        }

        Console.WriteLine("На какой номер чаще всего звонили по датам: ");
        foreach (DictionaryEntry entry in result)
        {
            Console.WriteLine($"Дата: {entry.Key}\t Номер телефона: {entry.Value}");
            Console.WriteLine();
        }
    }
}
