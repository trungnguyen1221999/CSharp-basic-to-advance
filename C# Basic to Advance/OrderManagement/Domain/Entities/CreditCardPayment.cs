using OrderManagement.Domain.Common;

namespace OrderManagement.Domain.Entities;
public sealed  class CreditCardPayment : PaymentMethod
{
    public CreditCardPayment() : base("CC")
    {
    }

    public override decimal CalculateFee(decimal amount)
        => amount * 0.02m; // Credit card payment has a 2% fee

    public override string GetDisplayInfo()
        => $"Thanh toán thẻ tín dụng | Mã thanh toán: {PaymentCode} | Cập nhật lần cuối: {UpdatedAt} | Tạo lúc: {CreatedAt}";
}