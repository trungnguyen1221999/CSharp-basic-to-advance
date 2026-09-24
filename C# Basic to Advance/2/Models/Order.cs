public class Order : BaseEntity
{
    public Guid CustomerId { get; private set; }
    public Status Status { get; private set; }
    public Money? DiscountAmount { get; private set; }
    public Money ShippingFee { get; private set; }
    public string? Notes { get; private set; }

    public int ItemCount => _items.Count;
    // List chứa các dòng đơn hàng
    private List<OrderItem> _items = new List<OrderItem>();


    // Chỉ đọc từ bên ngoài, tránh bị replace cả list
    public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();


    // Tổng tiền hàng (trước giảm giá)
    public Money SubTotal => _items.Aggregate(Money.Zero, (sum, item) => sum.Add(item.LineTotal));


    // Tổng thanh toán
    public Money TotalAmount => SubTotal.Add(ShippingFee).Subtract(DiscountAmount ?? Money.Zero);


    public Order(Guid customerId) : base()
    {
        CustomerId = customerId;
        Status = Status.Pending;
        DiscountAmount = Money.Zero;
    }


    public void AddItem(OrderItem item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));
        _items.Add(item);
    }

    public void RemoveItem(string productId)
    {
        var item = _items.FirstOrDefault(i => i.ProductId == productId);
        if (item == null)
         throw new Exception($"Order item with ProductId '{productId}' not found.");
        _items.Remove(item);
    }

    public void UpdateStatus(Status newStatus)
    {
        switch (newStatus)
        {
            case Status.Processing when Status == Status.Pending:
            case Status.Shipped when Status == Status.Processing:
            case Status.Delivered when Status == Status.Shipped:
                Status = newStatus;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newStatus), $"Invalid status: {newStatus}");
        }
    }
    public override string GetDisplayInfo()
    {
return $"{base.GetDisplayInfo()} | Customer: {CustomerId} | Notes: {Notes} | Total Amount: {TotalAmount:C}";
    }
}

public enum Status
{
    Pending,
    Processing,
    Shipped,
    Delivered,
    Cancelled
}
