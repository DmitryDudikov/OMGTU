using System;
using System.Collections.Generic;
using System.Linq;

class Worker
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public double Salary { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
}

class Program
{
    static void Main()
    {
        var workers = new List<Worker>
            {
                new Worker { Id = 1, Name = "Иванов Иван Иванович", Position = "Пекарь", Salary = 300000, Category = "Корзиночка", Quantity = 100, Price = 35 },
                new Worker { Id = 2, Name = "Петров Петр Петрович", Position = "Пекарь", Salary = 400000, Category = "Лодочка с перцем", Quantity = 100, Price = 60 },
                new Worker { Id = 3, Name = "Горин Геннадий Аркадьевич ", Position = "Сварщик", Salary = 35000, Category = "Труба", Quantity = 30, Price = 1500 },
                new Worker { Id = 4, Name = "Пупкин Василий Аркадьевич", Position = "Кондитер", Salary = 50000, Category = "Наполеон", Quantity = 30, Price = 600 },
                new Worker { Id = 5, Name = "Гончаров Илья Ильич", Position = "Гончар", Salary = 60000, Category = "Ваза", Quantity = 50, Price = 1000 }
            };

        var workersLess = workers.Where(w => w.Salary < w.Quantity * w.Price).Count();
        Console.WriteLine($"\nКол-во рабочих, которые получают ЗП меньшей суммы выработанной продукции: {workersLess}\n");

        Console.WriteLine("\nКол-во произведённой продукции по каждой категории (в количественном и денежном эквиваленте):\n");
        var productionByCategory = workers.GroupBy(w => w.Category)
            .Select(g => new { Category = g.Key, Quantity = g.Sum(w => w.Quantity), Amount = g.Sum(w => w.Quantity * w.Price) });
        foreach (var item in productionByCategory)
        {
            Console.WriteLine($"Категория: {item.Category}, Кол-во: {item.Quantity}, Сумма: {item.Amount}");
        }

        var totalProductionAmount = workers.Sum(w => w.Quantity * w.Price);
        Console.WriteLine($"\nОбщий суммарный объём произведённой продукции: {totalProductionAmount}\n");

        var workersMore = workers.Where(w => w.Salary > w.Quantity * w.Price * 0.5).Count();
        Console.WriteLine($"\nКол-во сотрудников, получающих больше 50% от суммы производимого ими продукта: {workersMore}\n");
    }
}

