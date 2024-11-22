using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IProductRepository
    {
        public Task<Order> GetOrderByIdAsync(Guid id);
        public Task AddOrderByAsync(Order order);
    }
}
