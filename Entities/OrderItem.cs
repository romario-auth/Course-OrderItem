using System;
using Order.Entities;

namespace Order.Entities
{
    class OrderItem
    {
        public int Quantity{get; set;}
        public double Price{get; set;}
        public Product Product{get; set;}

        public OrderItem(int quantity, double price, Product product)
        {
            Quantity = quantity;
            Price = price;
            Product = Product;
        }

        public double SubTotal()
        {
            return Quantity * Price;
        }
    }
}