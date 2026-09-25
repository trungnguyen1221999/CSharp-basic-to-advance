using OrderManagement.Domain.Entities;

public class FlatDiscount : IDiscountCalculator
{
    private readonly decimal _amount;
    public string DiscountType => $"Flat Discount ({_amount:C})";

    public FlatDiscount(decimal amount)
    {
        _amount = amount;
    }

    public decimal Calculate(Order order) => _amount;
}