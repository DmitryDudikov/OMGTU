using System.Security.Cryptography.X509Certificates;

public class Automobils
{
    public string name;
    public bool isWashed;

    public Automobils(string name) 
    { 
        this.name = name;
        this.isWashed = false;
    }
}

class Garage
{
    public List<Automobils> auto = new List<Automobils>();

    public Garage (List<Automobils> auto)
    {
        this.auto = auto;
    }
}

class WashingCar
{
    public static void Wash (Automobils automobil)
    {
        automobil.isWashed=true;
    }
}

class Program
{
    public delegate void WashingCarDelegate (Automobils automobil);

    public static void Main () 
    { 
        WashingCarDelegate wash = WashingCar.Wash;

        Garage garage = new Garage(new List<Automobils>()
        {
            new Automobils("Волга"),
            new Automobils("Жигуль"),
            new Automobils("Мерс"),
            new Automobils("Девятка"),
        });

        foreach (var auto in garage.auto)
        {
            Console.WriteLine($"{auto.name}: Помыта? - {auto.isWashed}");
        }

        foreach (var auto in garage.auto)
        {
            wash(auto);
        }

        Console.WriteLine("\nПроцесс мытья машины...\n");

        foreach (var auto in garage.auto)
        {
            Console.WriteLine($"{auto.name}: Помыта? - {auto.isWashed}");
        }
    }
}
