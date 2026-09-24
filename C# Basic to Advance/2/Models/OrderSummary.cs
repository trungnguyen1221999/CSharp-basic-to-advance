public class OrderSummary
{
    public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();
    
    private readonly List<OrderItem> _items = new ();

    public Money SubTotal => _items.Aggregate(Money.Zero, (sum, item) => sum.Add(item.LineTotal));
    public int ItemsCount => _items.Count;

    public Money DiscountAmount()
    {
        switch (SubTotal.Amount)
        {
            case var amount when amount >= 10_000_000m:
                return Money.VND(amount * 0.1m); // 10% discount for orders >= 100,000 VND
            case var amount when amount >= 5_000_000m:
                return Money.VND(amount * 0.05m); // 5% discount for orders >= 50,000 VND
            default:
                return Money.VND(0); // No discount
        }
    }

    public Money Total => SubTotal.Add(ShippingFee).Subtract(DiscountAmount());

    public Money ShippingFee {get; internal set;} 
    public static Money CalculateShipping(decimal distanceKm)
    {
        var shippingFee = distanceKm * 1000m; // Example calculation: 1000 VND per km
        return Money.VND(Math.Max(Money.VND(shippingFee).Amount, 15_000m)); // Maximum shipping fee is 15,000 VND
    }

}