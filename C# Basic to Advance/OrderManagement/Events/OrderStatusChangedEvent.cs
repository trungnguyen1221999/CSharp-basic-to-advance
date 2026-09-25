public enum OrderStatus { Pending, Processing, Shipped, Delivered }


public record OrderStatusChangedEvent(
    Guid OrderId,
    OrderStatus OldStatus,
    OrderStatus NewStatus,
    DateTime ChangedAt,
    string ChangedBy
)
{
    public bool IsValidTransition() => (OldStatus, NewStatus) switch
    {
        (OrderStatus.Pending, OrderStatus.Processing) => true,
        (OrderStatus.Processing, OrderStatus.Shipped) => true,
        (OrderStatus.Shipped, OrderStatus.Delivered) => true,
        _ => false
    };
   
}
