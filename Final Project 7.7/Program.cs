using System.Diagnostics.Metrics;
using System.Globalization;
using System;

class Product
{
    private int Id { get; set; }
    private string Name { get; set; }
    private string Description { get; set; }
}
public abstract class ProductBase
{
    public virtual string ProductNumNum()
    {
        return "Мы доставили ...";
    }

    public override string ToString()
    {
        return $"Product:({ProductNumNum()})";
    }
    public int Price { get; set; }
    public Delivery Delivery { get; set; }
}

class Coffe : ProductBase
{
    public override string ProductNumNum()
    {
        Console.WriteLine();
        return "Мы доставили кофе";
    }
    public Coffe(int price)
    {
        Price = price;
        Delivery = new HomeDelivery("Доставка в офис");
    }
}

public class Bread : ProductBase
{
    public override string ProductNumNum()
    {
        Console.WriteLine();
        return "Мы доставили булочку";
    }

    public Bread(string name, int price)
    {
        Name = name;
        Price = price;
    }


    public string Name { get; private set; }
}

public abstract class Delivery
{
    public string Address;
    private string _typeDelivery;

    public void DisplayAddress()
    {
        Console.WriteLine(Address);
    }

    public string WaydDelivery()
    {
        Console.WriteLine(_typeDelivery);
        return _typeDelivery;
    }
    public Delivery(string typeDelivery)
    {
        _typeDelivery = typeDelivery;
    }
    public Delivery()
    {

    }
}

class HomeDelivery : Delivery
{

    public void DisplayAddress()
    {

    }
    public HomeDelivery(string typeDelivery) : base(typeDelivery)
    {

    }

}

class PickPointDelivery<T> : Delivery
{
    public DateTime TimeOfGetting;
    public string NameOfClient;

    public PickPointDelivery(string address, DateTime time, DateTime timeofgetting, string nameOfClient)
    {
        TimeOfGetting = timeofgetting;
        NameOfClient = nameOfClient;
    }
}

class ShopDelivery : Delivery
{
    public void DisplayDateTime(DateTime date)
    {
        Console.WriteLine("Необходимо отвезти заказ в розничный магазин к {0}");
    }
}

class Order<TDelivery,
TStruct> where TDelivery : Delivery
{
    public TDelivery Delivery;

    public int Number;

    public string Description;

    public void DisplayAddress()
    {
        Console.WriteLine(Delivery.Address);
    }
}
class Program
{
    static void Main(string[] args)
    {
        string address = null;
        Console.Write("Введите адрес доставки домой (улица дом квартира): ");
        address = Console.ReadLine();

        string addres = null;
        Console.Write("Введите адрес доставки в офис (улица дом этаж): ");
        address = Console.ReadLine();

        var product = new List<ProductBase>()
            {
                new Bread("Bread", 99) {Delivery = new HomeDelivery("Доставка домой")},
                new Coffe(120) {Delivery = new HomeDelivery("Доставка в офис")},

            };

        foreach (var item in product)
        {
            Console.WriteLine(item.ProductNumNum());
            Console.WriteLine(item.Price);
            Console.WriteLine(item.Delivery);
            Console.WriteLine(item.Delivery.WaydDelivery());
        }


        Console.WriteLine("Заказы доставлены");

        Console.ReadKey();
    }
}