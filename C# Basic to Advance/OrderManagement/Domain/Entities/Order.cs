using OrderManagement.Domain.Common;

namespace OrderManagement.Domain.Entities;
public class Order : BaseEntity , IPublicOrderInfo, IInternalOrderInfo
{
    public string OrderNumber { get; private set; }
    public decimal TotalAmount { get; private set; }
    public Guid CustomerId { get; private set; }
    public string Status { get; private set; }


    // Các trạng thái hợp lệ — dùng const cho giá trị compile-time
    public const string StatusPending    = "Pending";
    public const string StatusProcessing = "Processing";
    public const string StatusShipped    = "Shipped";
    public const string StatusDelivered  = "Delivered";


    public Order(string orderNumber, Guid customerId) : base()
    {
        if (string.IsNullOrWhiteSpace(orderNumber))
            throw new ArgumentException("OrderNumber không được rỗng", nameof(orderNumber));
        if (customerId == Guid.Empty)
            throw new ArgumentException("CustomerId không hợp lệ", nameof(customerId));


        OrderNumber = orderNumber;
        CustomerId = customerId;
        TotalAmount = 0;
        Status = StatusPending;
    }


    public void AddAmount(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount phải lớn hơn 0");
        TotalAmount += amount;
        SetUpdatedAt();
    }


    public void UpdateStatus(string newStatus)
    {
        var validStatuses = new[] { StatusPending, StatusProcessing, StatusShipped, StatusDelivered };
        if (!validStatuses.Contains(newStatus))
            throw new ArgumentException($"Trạng thái '{newStatus}' không hợp lệ");
        Status = newStatus;
        SetUpdatedAt();
    }


    public override string GetDisplayInfo()
        => $"Đơn hàng: {OrderNumber} | Tổng tiền: {TotalAmount:C} | Trạng thái: {Status}";


    public override bool IsValid()
        => base.IsValid()
           && !string.IsNullOrWhiteSpace(OrderNumber)
           && CustomerId != Guid.Empty;

    string IPublicOrderInfo.GetSummary()
    {
        return $"Customer Information Summary: {OrderNumber} | Total Amount: {TotalAmount:C} | Status: {Status}";
    }

    string IInternalOrderInfo.GetSummary()
    {
        return $"Internal Order Summary: {OrderNumber} | Total Amount: {TotalAmount:C} | Status: {Status} | CustomerId: {CustomerId}";
    }
}
