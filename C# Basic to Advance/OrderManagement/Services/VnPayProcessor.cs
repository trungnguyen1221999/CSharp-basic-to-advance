using OrderManagement.Domain.Entities;

public class VnPayProcessor : IPaymentProcessor
{
    private readonly string _paymentMethod = "VnPay";
    public Task<PaymentResult> ProcessAsync(Order order, decimal amount)
    {
        var result = new PaymentResult(
            true,
            $"VnPay payment for order {order.Id} with amount {amount}",
            Guid.NewGuid(),
            _paymentMethod,
            false
         
        );

        return Task.FromResult(result);
    }
}