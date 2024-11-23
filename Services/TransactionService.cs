using Domain.Entities;
using Infrastructure.Repositories;

public class TransactionService:ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IOrderRepository _orderRepository;

    public TransactionService(ITransactionRepository transactionRepository, IOrderRepository orderRepository)
    {
        _transactionRepository = transactionRepository;
        _orderRepository = orderRepository;
    }

    //public async Task<MTransaction> ProcessPaymentAsync(int orderId, decimal amount)
    //{
    //    var order = await _orderRepository.GetByIdAsync(orderId);
    //    if (order == null)
    //    {
    //        throw new Exception("Order not found.");
    //    }

    //    var transaction = new Transaction
    //    {
    //        OrderId = orderId,
    //        Amount = amount,
    //        Status = "Completed",
    //        TransactionDate = DateTime.UtcNow,
    //        TransactionId = Guid.NewGuid().ToString()
    //    };

    //    await _transactionRepository.AddAsync(transaction);
    //    return transaction;
    //}
}
