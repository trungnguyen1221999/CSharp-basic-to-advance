public class Customer
{
    public int CustomerId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? City { get; set; }
    public string Tier { get; set; } = "Standard";
    public List<Order> Orders { get; set; } = [];
}
