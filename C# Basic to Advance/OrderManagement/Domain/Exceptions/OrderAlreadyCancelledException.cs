public class OrderAlreadyCancelledException : OrderDomainException
{
    public Guid OrderId { get; }
    public OrderAlreadyCancelledException(Guid orderId) : base($"Order with ID '{orderId}' has already been cancelled.")
    {
        
    }

    public OrderAlreadyCancelledException(Guid orderId, Exception innerException) : base($"Order with ID '{orderId}' has already been cancelled.", innerException)
    {
        
    }

}