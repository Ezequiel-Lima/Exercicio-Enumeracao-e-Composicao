using Exercicio_18.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio_18.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoverItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double sum = 0;

            foreach (var item in Items)
            {
                sum += item.SubTotal();
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("ORDER SUMMARY: ");
            stringBuilder.AppendLine("Order moment: " + Moment.ToString("dd/MM/yyyy"));
            stringBuilder.AppendLine("Order status: " + Status.ToString());
            stringBuilder.AppendLine("Client: " + Client.Name + "(" + Client.BirthDate.ToString("dd/MM/yyy") + ") - " + Client.Email);
            stringBuilder.AppendLine("Order items:");
            foreach (var item in Items)
            {
                stringBuilder.AppendLine(item.Product.Name + ", $" + item.Product.Price + ", Quantity: " + item.Quantity + "," + "Subtotal: $" + item.SubTotal().ToString("F2"));
            }
            stringBuilder.AppendLine("Total price: $" + Total().ToString("F2"));

            return stringBuilder.ToString();
        }
    }
}
