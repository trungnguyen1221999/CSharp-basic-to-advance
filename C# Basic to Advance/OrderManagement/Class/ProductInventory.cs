public class ProductInventory
{
    private readonly Dictionary<string, int> _stock = new ();
    public IReadOnlyDictionary<string, int> Stock => _stock.AsReadOnly();

    public void AddProduct(string code, int quantity)
    {
        if (_stock.ContainsKey(code))
        {
            _stock[code] += quantity;
        }
        else
        {
            _stock[code] = quantity;
        }
    }

    public void ReduceStock(string code, int quantity)
    {
        if (_stock.ContainsKey(code))
        {
            if (_stock[code] >= quantity)
            {
                _stock[code] -= quantity;
            }
            else
            {
                throw new InvalidOperationException($"Insufficient stock for product with code '{code}'.");
            }
        }
        else
        {
            throw new KeyNotFoundException($"Product with code '{code}' not found in inventory.");
        }
    }

    public bool IsInStock(string code) => _stock.ContainsKey(code) && _stock[code] > 0;
    public IEnumerable<string> GetLowStockProducts(int threshold) => _stock.Where(kv => kv.Value <= threshold).Select(kv => kv.Key);
}