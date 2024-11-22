using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get;  set; }
        public Guid ProductId { get; private set; }

        public Guid OrderId { get; set; }
        public int Quantity { get; private set; }

        public Product Product { get; private set; }// 1 to 1 navigational reference

        public OrderItem(Guid ProductId, int Quantity)
        {
            this.ProductId = ProductId;
            this.Quantity = Quantity;
        }
        public bool UpdateQuantity(int quantity)
        {
            if (Product.Stock<quantity)
                throw new InvalidOperationException($"Quantity:- {quantity} not available for {Product.Name}");
            this.Quantity = quantity;
            return true;
        }
    }
}
