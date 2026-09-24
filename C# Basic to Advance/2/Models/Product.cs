
public class Product
{
    // init: ProductId không được thay đổi sau khi tạo
    public string ProductId { get; init; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }


    // Price có validation — không cho âm
    public decimal Price 
    {
        get;
        private set
        {
            if (value < 0)
                throw new ArgumentException($"Gia san pham khong duoc am. Gia nhan duoc: {value}m");
            field = value;
        }
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


    public Product(string productId, string name, decimal price)
    {
        ProductId = productId;
        Name = name;
        Price = price;   // gọi qua property setter để có validation
        StockQuantity = 0;
    }


    public Product(string productId, string name, decimal price, int stockQuantity)
        : this(productId, name, price)
    {
        StockQuantity = stockQuantity;
    }
}

