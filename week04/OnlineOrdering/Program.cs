using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address(
            "123 Main Street",
            "New York",
            "NY",
            "USA");

        Customer customer1 = new Customer(
            "John Smith",
            address1);

        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop", "P101", 850, 1));
        order1.AddProduct(new Product("Mouse", "P102", 25, 2));
        order1.AddProduct(new Product("Keyboard", "P103", 45, 1));


        Address address2 = new Address(
            "45 Wellington Bassey Way",
            "Uyo",
            "Akwa Ibom",
            "Nigeria");

        Customer customer2 = new Customer(
            "Mfon Usanga",
            address2);

        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Office Chair", "P201", 120, 2));
        order2.AddProduct(new Product("Desk Lamp", "P202", 35, 1));


        Console.WriteLine("====================================");
        Console.WriteLine("ORDER 1");
        Console.WriteLine("====================================");

        Console.WriteLine("\nPacking Label");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine("Shipping Label");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine($"\nTotal Cost: ${order1.CalculateTotalCost():F2}");

        Console.WriteLine("\n====================================");
        Console.WriteLine("ORDER 2");
        Console.WriteLine("====================================");

        Console.WriteLine("\nPacking Label");
        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine("Shipping Label");
        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine($"\nTotal Cost: ${order2.CalculateTotalCost():F2}");
    }
}