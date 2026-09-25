using OrderManagement.Domain.Entities;

public class PercentageDiscount : IDiscountCalculator
{
    private readonly decimal _percentage;
    public string DiscountType => $"Percentage Discount ({_percentage:P})";

    public PercentageDiscount(decimal percentage)
    {
        _percentage = percentage;
    }

    public decimal Calculate(Order order) => order.TotalAmount * _percentage;
    
}