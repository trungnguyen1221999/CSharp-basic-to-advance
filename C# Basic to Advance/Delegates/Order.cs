public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string Status { get; set; } = "Pending";
    public decimal TotalAmount { get; set; }
    public int ItemCount { get; set; }
    public bool IsMember { get; set; }
    public string PromoCode { get; set; } = string.Empty;
    public List<string> ProcessingLog { get; } = new();
}
