
public class Product
{
    // init: ProductId không được thay đổi sau khi tạo
    public string ProductId { get; init; }
    public string  Name { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }


    // Price có validation — không cho âm
    public Money Price 
    {
       get;set;
    }


    public int StockQuantity
    {
        get;
         set
        {
            if (value < 0)
                throw new ArgumentException("So luong ton kho khong duoc am.");
            field = value;
        }
    }


    // Computed property
    public bool IsInStock => StockQuantity > 0;
    public static bool  ValidateSku(string sku)
    {
        sku = sku.Trim().ToUpperInvariant();
    
        if (sku.Contains("SKU-") && sku.Length >= 7)
            return true;
        return false;
    }

    public Product(string productId, string name, Money price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.", nameof(name));
        ProductId = productId;
        Name = name;
        Price = price;   // gọi qua property setter để có validation
        StockQuantity = 0;
    }


    public Product(string productId, string name, Money price, int stockQuantity)
        : this(productId, name, price)
    {
        StockQuantity = stockQuantity;
    }

    public void ReduceStock( int quantity)
    {
        if (StockQuantity < quantity)
            throw new Exception($"Not enough stock for ProductId '{ProductId}'. Requested: {quantity}, Available: {StockQuantity}");
        StockQuantity -= quantity;
    }
}

