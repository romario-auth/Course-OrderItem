using System;
using System.Text;
using System.Globalization;

using System.Collections.Generic;
using Order.Entities.Enum;
using Order.Entities;


namespace Order
{
    class Order
    {
        public DateTime Moment{get; set;}
        public OrderStatus Status {get; set;}
        public List<OrderItem> Items {get; set;} = new List<OrderItem>();
        public Client Buyer {get; set;}

        public void addItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void removeItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double total = 0.0;
            foreach(OrderItem item in Items)
            {
                total += item.SubTotal();
            }

            return total;
        }

        public override string ToString()
        {
            StringBuilder summary = new StringBuilder();
            summary.AppendLine("Oder Summary:");
            summary.Append("Order Momment: ");
            summary.AppendLine(Moment.ToString());
            summary.Append("Order Status: ");
            summary.AppendLine(Status.ToString());
            summary.Append("Client: ");
            summary.Append(Buyer.Name);
            summary.Append(" (");  
            summary.Append(Buyer.BirthDate.ToString("dd/MM/yyyy"));
            summary.Append(") - ");
            summary.AppendLine(Buyer.Email);
            summary.AppendLine("Items:");
            foreach(OrderItem item in Items)
            {
                summary.AppendLine(item.ToString());
            }
            summary.Append("Total: $");
            summary.Append(Total());

            return summary.ToString(); 
        }
    }
}