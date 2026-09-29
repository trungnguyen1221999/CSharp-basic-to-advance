public class OrderNotFoundException : OrderDomainException
{
    public Guid OrderId { get; }

    public OrderNotFoundException(Guid orderId) : base($"Order with ID '{orderId}' was not found.")
    {
        OrderId = orderId;
    }

    public OrderNotFoundException(Guid orderId, Exception innerException) : base($"Order with ID '{orderId}' was not found.", innerException)
    {
        
    }
}