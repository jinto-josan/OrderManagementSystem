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
        public Money Price { get; private set; }
        public int Stock {  get; private set; }

        public void UpdatePrice(Money price) =>    Price = price;
        public void UpdateStock(int stock) => Stock = stock;
    }
}
