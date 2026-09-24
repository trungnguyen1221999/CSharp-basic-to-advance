public class Order
{
    public string OrderId { get; init; }
    public string CustomerId { get; init; }
    public DateTime CreatedAt { get; init; }
    public Status Status { get; set; }
    public decimal? DiscountAmount { get; set; }
    public string? Notes { get; set; }

    public int ItemCount => _items.Count;
    // List chứa các dòng đơn hàng
    private List<OrderItem> _items = new List<OrderItem>();


    // Chỉ đọc từ bên ngoài, tránh bị replace cả list
    public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();


    // Tổng tiền hàng (trước giảm giá)
    public decimal SubTotal => _items.Sum(i => i.LineTotal);


    // Tổng thanh toán
    public decimal TotalAmount => SubTotal - (DiscountAmount ?? 0);


    public Order(string orderId, string customerId)
    {
        OrderId = orderId;
        CustomerId = customerId;
        CreatedAt = DateTime.UtcNow;
        Status = Status.Pending;
        DiscountAmount = 0m;
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
}

public enum Status
{
    Pending,
    Processing,
    Shipped,
    Delivered,
    Cancelled
}
