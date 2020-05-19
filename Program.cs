using System;
using System.Globalization;

using Order.Entities;
using Order.Entities.Enum;

namespace Order
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("E-mail: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order date: ");
            Console.Write("Status: ");
            OrderStatus orderStatus = Enum.Parse<OrderStatus>(Console.ReadLine());
            
            Client buyer = new Client(name, email, birth);

            Order car = new Order();
            car.Buyer = buyer;
            car.Moment = DateTime.Now;

            Console.Write("How many item to this order? ");
            int quantityOrder = int.Parse(Console.ReadLine());
            for (int i = 1; i <= quantityOrder; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Name: ");
                string itemName = Console.ReadLine();
                Console.Write("Price: ");
                double itemPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int itemQuantity = int.Parse(Console.ReadLine());

                Product product = new Product(itemName, itemPrice);
                OrderItem orderItems = new OrderItem(itemQuantity, itemPrice, product); 
        
                car.addItem(orderItems);
            }

            System.Console.WriteLine(car);

        }
    }
}
