public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public decimal Price { get; set; }        // decimal cho tiền — không dùng double
    public int Stock { get; set; }
    public Category? Category { get; set; }
}
