using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public Money Price { get; private   set; }
        public int Stock {  get; private set; }

        public string Description { get; set; }
        public string Category { get; set; }

        public string ImageUrl { get; set; } = "No Image";

        public void UpdatePrice(Money price) => Price = price;

        public void UpdateStock(int newStock)
        {
            if (newStock < 0)
                throw new InvalidOperationException("Stock cant be negitive");
            Stock = newStock;

        }

        public Product(string name,int stock) { 
            Name = name;
            Stock = stock;
        }

        public Product() { }
    }
}
