var item = new OrderItem
{
    Id = 1,
    ProductName = "Sony WH-1000XM5 Headphones",
    Quantity = 3,
    UnitPrice = 1_250_000m,
    DiscountPercent = 10,
    IsGift = false
};

Console.WriteLine($"{item.ProductName}");
Console.WriteLine($"  {item.Quantity} x {item.UnitPrice:N0}đ"
    + $" (discount {item.DiscountPercent ?? 0}%)");
Console.WriteLine($"  Total: {item.LineTotal:N0}đ");
