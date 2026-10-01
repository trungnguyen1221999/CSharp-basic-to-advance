var discountService = new DiscountService();
var order = new Orders { TotalAmount = 200000m };
var discount = discountService.Apply(order, DiscountService.Percent10Discount);
Console.WriteLine($"Discount: {discount}");
Func<Orders, decimal> discountStrategy;
public class DiscountService
{
    // Các chiến lược discount — mỗi cái là một method
    public static decimal NoDiscount(Orders order) => 0m;


    public static decimal Percent10Discount(Orders order)
        => order.TotalAmount * 0.10m;


    public static decimal Fixed50KDiscount(Orders order)
        => Math.Min(50000m, order.TotalAmount);  // Không giảm quá tổng tiền


    public static decimal MemberDiscount(Orders order)
        => order.TotalAmount * 0.15m;

    public decimal Apply (Orders order, Func<Orders, decimal> discountStrategy)
    => discountStrategy(order);
}

public class Orders {
    public decimal TotalAmount { get; set; }
}

