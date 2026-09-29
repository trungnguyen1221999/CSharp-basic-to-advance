public class InsufficientStockException : OrderDomainException
{
    public Guid ProductId { get; }
    public string ProductName { get; }
     public int RequestedQty { get; }
    public int AvailableQty { get; }

    public InsufficientStockException(Guid productId, string productName, int requestedQty, int availableQty) : base($"Insufficient stock available for product '{productName}' (ID: {productId}). Requested: {requestedQty}, Available: {availableQty}.")
    {
        ProductId = productId;
        ProductName = productName;
        RequestedQty = requestedQty;
        AvailableQty = availableQty;
    }


    public InsufficientStockException(Guid productId, string productName, int requestedQty, int availableQty, Exception innerException) : base($"Insufficient stock available for product '{productName}' (ID: {productId}). Requested: {requestedQty}, Available: {availableQty}.", innerException)
    {
        ProductId = productId;
        ProductName = productName;
        RequestedQty = requestedQty;
        AvailableQty = availableQty;
    }
}