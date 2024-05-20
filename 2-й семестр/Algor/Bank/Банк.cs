class Data
{
    public int Account_number {  get; set; }
    public string Name { get; set; }
    public double Profit { get; set; }
    public double Expenditure { get; set; }
    public double Tax => Profit * 0.05;

    public Data (int id, string fio, double profit, double expenditure)
    {
        Account_number = id;
        Name = fio;
        Profit = profit;
        Expenditure = expenditure;
    }
}
class Program
{
    static void Main ()
    {
        Data[] data =
        {
            new Data(111, "Петров Илья Михайлович", 100000, 30000),
            new Data(112, "Иванов Иван Иванович", 70000, 60000),
            new Data(113, "Петров Петр Петрович", 50000, 10000),
            new Data(114, "Александров Сан Саныч", 300000, 50000),
            new Data(115, "Алексеев Алеша Попович", 10000, 20000)
        };

        var NegativeBalance = data.Where(d => d.Profit - d.Expenditure - d.Tax < 0);
        Console.WriteLine("Клиенты с отрицательным балансом: ");
        foreach (var n in NegativeBalance) Console.WriteLine(n.Name);
        Console.WriteLine();
        

        var PositiveBalance = data.Count(d => d.Profit - d.Expenditure - d.Tax > 0);
        Console.WriteLine($"Количество клиентов с положительным балансом: {PositiveBalance}");
        Console.WriteLine();

        var MaxProfit = data.Max(d => d.Profit);
        var MaxProfitUsers = data.Where(d => d.Profit ==  MaxProfit);
        Console.WriteLine("Клиенты с максимальным доходом: ");
        foreach (var user in MaxProfitUsers) Console.WriteLine(user.Name);
        Console.WriteLine();

        var SumTax = data.Sum(d => d.Tax);
        Console.WriteLine($"Общая сумма налогов клиентов: {SumTax}");

    }
}
