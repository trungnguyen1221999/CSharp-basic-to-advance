var items = new List<OrderItem>
{
    new() { ProductName = "Áo thun",     UnitPrice = 150_000m, Quantity = 2 },
    new() { ProductName = "Quần jean",   UnitPrice = 350_000m, Quantity = 1 },
    new() { ProductName = "Giày sneaker",UnitPrice = 850_000m, Quantity = 1 },
};
 
var calculator = new OrderCalculator();
 
// Test 1: Giảm 10% + freeship tự động
var summary1 = calculator.Calculate(items, percentDiscount: 10m);
 
Console.WriteLine($"=== Đơn hàng 1 ===");
Console.WriteLine($"Subtotal:      {summary1.Subtotal:N0} VND");
Console.WriteLine($"Giảm giá:     -{summary1.TotalDiscount:N0} VND");
Console.WriteLine($"VAT (10%):    +{summary1.VatAmount:N0} VND");
Console.WriteLine($"Phí ship:     +{summary1.ShippingFee:N0} VND");
Console.WriteLine($"Tổng cộng:    {summary1.GrandTotal:N0} VND");
Console.WriteLine($"Freeship:      {(summary1.IsFreeShipping ? "Có" : "Không")}");
 
// Test 2: Giảm 200,000 VND cố định
var summary2 = calculator.Calculate(items, fixedDiscount: 200_000m);
Console.WriteLine($"\n=== Đơn hàng 2 ===");
Console.WriteLine($"Tổng cộng: {summary2.GrandTotal:N0} VND");


var isEligibleForFreeShip = calculator.IsEligibleForFreeShip(summary2.GrandTotal, CustomerType.VIP);
Console.WriteLine($"Được freeship1 {(isEligibleForFreeShip ? "Có" : "Không")}");

var isEligibleForFreeShip2 = calculator.IsEligibleForFreeShip(1, CustomerType.Normal);
Console.WriteLine($"Được freeship2 {(isEligibleForFreeShip2 ? "Có" : "Không")}");