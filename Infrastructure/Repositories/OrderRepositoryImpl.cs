using Application.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OrderRepositoryImpl : IOrderRepository
    {
        private readonly OrderDbContext _context;
        public OrderRepositoryImpl(OrderDbContext orderDbContext) { 
            _context = orderDbContext;
        }
        public async Task AddOrderByAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> GetOrderByIdAsync(Guid id)
        {

            return await _context.Orders.FindAsync(id)?? throw new NullReferenceException("Order doesnt exist");
        }
    }
}
