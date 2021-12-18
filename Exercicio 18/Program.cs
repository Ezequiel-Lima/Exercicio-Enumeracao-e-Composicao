using Exercicio_18.Entities;
using Exercicio_18.Entities.Enums;
using System;

namespace Exercicio_18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter client data: ");
                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Email: ");
                string email = Console.ReadLine();

                Console.Write("Birth date (DD/MM/YYYY): ");
                DateTime birthDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter order data: ");
                Console.Write("Satus: ");
                OrderStatus orderStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), Console.ReadLine());

                Console.Write("How many items to this order? ");
                int quantityItems = int.Parse(Console.ReadLine());

                Client client = new Client(name, email, birthDate);
                Order order = new Order(DateTime.Now, orderStatus, client);

                for (int i = 0; i < quantityItems; i++)
                {
                    Console.WriteLine($"Enter #{i + 1} item data: ");
                    Console.Write("Product Name: ");
                    string productName = Console.ReadLine();

                    Console.Write("Product Price: ");
                    double price = double.Parse(Console.ReadLine());

                    Console.Write("Quantity: ");
                    int quantityProduct = int.Parse(Console.ReadLine());

                    Product product = new Product(productName, price);
                    OrderItem orderItem = new OrderItem(quantityProduct, price, product);

                    order.AddItem(orderItem);
                }

                Console.WriteLine($"{order}");

                Console.WriteLine("Press any key to finish");
                Console.ReadKey();
            }
            catch (Exception error)
            {
                Console.WriteLine($">{error.Message}");
                Console.ReadKey();
            }
        }
    }
}
