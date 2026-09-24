public class OrderItem
{
    public string ProductId { get; init; }
    public string ProductName { get; init; }
    public Money UnitPrice { get; init; }
    public int Quantity { get; set; }


    // Computed: thành tiền của dòng này
    public Money LineTotal => UnitPrice.MultiplyBy(Quantity);


    public OrderItem(string productId, string productName, Money unitPrice, int quantity)
    {
        ProductId = productId;
        ProductName = productName;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }
}


