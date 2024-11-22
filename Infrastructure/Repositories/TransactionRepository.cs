using Application.Entities;

namespace Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public Task AddOrderByAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
