using OrderManagement.Domain.Common;

namespace OrderManagement.Domain.Entities;
public sealed class CodPayment : PaymentMethod
{
    public CodPayment() : base("COD")
    {
    }

    public override decimal CalculateFee(decimal _)
        => 15_000m; // COD payment has no additional fee

    public override string GetDisplayInfo()
        => $"Thanh toán COD | Mã thanh toán: {PaymentCode} | Cập nhật lần cuối: {UpdatedAt} | Tạo lúc: {CreatedAt}";
}