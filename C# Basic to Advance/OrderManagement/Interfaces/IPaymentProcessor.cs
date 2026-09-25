using OrderManagement.Domain.Entities;

public interface IPaymentProcessor
{
    Task<PaymentResult> ProcessAsync(Order order, decimal amount);
}