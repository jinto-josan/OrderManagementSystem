using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }

        public Product Product { get; private set; }

        public OrderItem(Guid ProductId, int Quantity)
        {
            this.ProductId = ProductId;
            this.Quantity = Quantity;
        }
        public bool UpdateQuantity(int quantity)
        {
            if(Product.Stock<quantity) 
                return false;
            this.Quantity = quantity;
            return true;
        }
    }
}
