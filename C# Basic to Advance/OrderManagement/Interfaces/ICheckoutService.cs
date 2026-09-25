using OrderManagement.Domain.Entities;

public interface ICheckoutService
{
    Task<PaymentResult> CheckoutAsync(Order order, decimal amount);
}