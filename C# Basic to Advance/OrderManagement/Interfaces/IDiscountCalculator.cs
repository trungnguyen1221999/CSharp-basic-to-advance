using OrderManagement.Domain.Entities;

public interface IDiscountCalculator
{
    decimal Calculate(Order order);
    string DiscountType { get; }
}