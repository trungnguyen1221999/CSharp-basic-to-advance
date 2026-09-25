using OrderManagement.Domain.Entities;

var order = new Order ("123",Guid.NewGuid());
var amount = 100_000m;

var checkoutService = new CheckoutService(new MoMoProcessor());
var paymentResult = await checkoutService.CheckoutAsync(order, amount);
Console.WriteLine($"Payment Successful: {paymentResult.IsSuccessful}");
Console.WriteLine($"Message: {paymentResult.Message}");
Console.WriteLine($"Transaction ID: {paymentResult.TransactionId}");
Console.WriteLine($"Payment Method: {paymentResult.PaymentMethod}");
Console.WriteLine($"Is Refunded: {paymentResult.IsRefunded}");
Console.WriteLine($"Transaction Date: {paymentResult.TransactionDate}");