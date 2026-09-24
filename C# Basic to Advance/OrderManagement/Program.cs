using OrderManagement.Domain.Entities;
using System.Threading;
var amount = 100_000m; // Example amount for payment

var creditCardPayment = new CreditCardPayment();
Console.WriteLine(creditCardPayment.GetDisplayInfo());
Console.WriteLine($"Phí thanh toán: {creditCardPayment.CalculateFee(amount)}");

var codPayment = new CodPayment();
Console.WriteLine(codPayment.GetDisplayInfo());
Console.WriteLine($"Phí thanh toán: {codPayment.CalculateFee(amount)}");