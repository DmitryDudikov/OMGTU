using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public string Article { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public string Warehouse { get; set; }
}

public class Program
{
    public static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product { Article = "01", Name = "Молоко", Category = "Продукты", Quantity = 50, Price = 70, Warehouse = "Пятерочка" },
            new Product { Article = "02", Name = "Хлеб", Category = "Продукты", Quantity = 30, Price = 50, Warehouse = "Пятерочка" },
            new Product { Article = "03", Name = "Футболка", Category = "Одежда", Quantity = 20, Price = 700, Warehouse = "Сэконд Хенд" },
            new Product { Article = "04", Name = "Шорты", Category = "Шорты", Quantity = 20, Price = 500, Warehouse = "Сэконд Хенд" },
            new Product { Article = "05", Name = "Ручка", Category = "Канцелярские товары", Quantity = 100, Price = 10, Warehouse = "Степлер" },
            new Product { Article = "06", Name = "Карандаш", Category = "Канцелярские товары", Quantity = 100, Price = 7, Warehouse = "Степлер" }
        };

        Console.WriteLine("\nOбъем товара в денежном эквиваленте по каждом складу:\n");
        var warehouseValues = products.GroupBy(p => p.Warehouse)
            .Select(g => new { Warehouse = g.Key, Value = g.Sum(p => p.Quantity * p.Price) });

        foreach (var warehouseValue in warehouseValues)
        {
            Console.WriteLine($"Склад {warehouseValue.Warehouse}: {warehouseValue.Value}");
        }

        Console.WriteLine("\nМаксимальная цена по каждой категории:\n");
        var maxPrices = products.GroupBy(p => p.Category)
            .Select(g => new { Category = g.Key, MaxPrice = g.Max(p => p.Price) });

        foreach (var maxPrice in maxPrices)
        {
            Console.WriteLine($"Категория {maxPrice.Category}: {maxPrice.MaxPrice}");
        }

        Console.WriteLine("\nСредняя цена товара по каждому складу и по всем складам:\n");
        var averagePrices = products.GroupBy(p => p.Warehouse)
            .Select(g => new { Warehouse = g.Key, AveragePrice = g.Average(p => p.Price) });

        foreach (var averagePrice in averagePrices)
        {
            Console.WriteLine($"Склад {averagePrice.Warehouse}: {averagePrice.AveragePrice}");
        }

        double totalAveragePrice = products.Average(p => p.Price);
        Console.WriteLine($"\nСредняя цена по всем складам: {totalAveragePrice}\n");

        var cheapestProduct = products.OrderBy(p => p.Price).First();
        Console.WriteLine($"\nСамый дешевый товар: {cheapestProduct.Name}, цена: {cheapestProduct.Price}\n");

        var cheapestWarehouse = products.GroupBy(p => p.Warehouse)
            .OrderBy(g => g.Sum(p => p.Quantity * p.Price))
            .First();

        Console.WriteLine($"\nСклад с наименьшей суммарной стоимостью товаров: {cheapestWarehouse.Key}\n");
        foreach (var product in cheapestWarehouse)
        {
            Console.WriteLine($"{product.Article}, {product.Name}, {product.Category}, {product.Quantity}, {product.Price}, {product.Warehouse}");
        }
    }
}
