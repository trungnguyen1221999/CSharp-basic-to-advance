using OrderManagement.Domain.Common;

namespace OrderManagement.Domain.Entities;
public abstract class PaymentMethod : BaseEntity
{
    public string PaymentCode { get; protected set; }
    public PaymentMethod(string paymentCode) : base()
    {
        PaymentCode = paymentCode;
    }
    public abstract decimal CalculateFee(decimal amount);
    public override string GetDisplayInfo()
        => $"Mã thanh toán: {PaymentCode} | Cập nhật lần cuối: {UpdatedAt} | Tạo lúc: {CreatedAt}";
}