public class Warehouse
{
    public IReadOnlyDictionary<string, Product> Products => _products.AsReadOnly();
    private Dictionary<string, Product> _products = new();

    public void AddProduct(Product product)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));
        if (_products.ContainsKey(product.ProductId))
            throw new Exception($"Product with ProductId '{product.ProductId}' already exists.");

        _products.Add(product.ProductId, product);
    }

    public void RemoveProduct(string productId)
    {
        if (!_products.ContainsKey(productId)) throw new Exception($"Product with ProductId '{productId}' not found.");
        _products.Remove(productId);
    }

    public void RestockProduct(string productId, int quantity)
    {
        if (!_products.ContainsKey(productId)) throw new Exception($"Product with ProductId '{productId}' not found.");
        _products[productId].StockQuantity += quantity;
    }
    public void ReserveStock(string productId, int quantity)
    {
        if (!_products.ContainsKey(productId)) throw new Exception($"Product with ProductId '{productId}' not found.");
        var product = _products[productId];
        if (product.StockQuantity < quantity)
            throw new Exception($"Not enough stock for ProductId '{productId}'. Requested: {quantity}, Available: {product.StockQuantity}");
        product.StockQuantity -= quantity;
    }
}