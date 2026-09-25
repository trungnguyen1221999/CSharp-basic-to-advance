using OrderManagement.Domain.Entities;

public class MoMoProcessor : IPaymentProcessor
{
    private readonly string _paymentMethod = "MoMo";

    public Task<PaymentResult> ProcessAsync(Order order, decimal amount)
    {
        var result = new PaymentResult(
            true,
            $"MoMo payment for order {order.Id} with amount {amount}",
            Guid.NewGuid(),
            _paymentMethod,
            false
        );

        return Task.FromResult(result);
    }
}