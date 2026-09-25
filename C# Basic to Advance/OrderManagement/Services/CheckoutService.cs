using OrderManagement.Domain.Entities;

public class CheckoutService : ICheckoutService
{
    private readonly IPaymentProcessor _paymentProcessor;

    public CheckoutService(IPaymentProcessor paymentProcessor)
    {
        _paymentProcessor = paymentProcessor;
    }

  
    public Task<PaymentResult> CheckoutAsync(Order order, decimal amount)
    {
        return _paymentProcessor.ProcessAsync(order, amount);
    }
}