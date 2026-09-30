public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? ShipCity { get; set; }
    public Customer? Customer { get; set; }
    public List<OrderItem> Items { get; set; } = [];
}
    