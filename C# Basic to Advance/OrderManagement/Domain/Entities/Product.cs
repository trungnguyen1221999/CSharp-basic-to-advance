using OrderManagement.Domain.Common;

namespace OrderManagement.Domain.Entities;


public class Product : BaseEntity
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public int StockQty { get; private set; }

    public Guid? CategoryId { get; private set; }

    public Product(string name, decimal price, int stockQty, Guid? categoryId) : base()
    {
        if (price < 0)
            throw new ArgumentException("Giá sản phẩm không thể âm");
        if (stockQty < 0)
            throw new ArgumentException("Số lượng tồn kho không thể âm");


        Name = name;
        Price = price;
        StockQty = stockQty;
        CategoryId = categoryId;
    }

    public void ReduceStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Số lượng giảm phải lớn hơn 0");
        if (StockQty < quantity)
            throw new InvalidOperationException(
                $"Tồn kho không đủ. Hiện tại: {StockQty}, yêu cầu: {quantity}");


        StockQty -= quantity;
        SetUpdatedAt();
    }


    public override string GetDisplayInfo()
        => $"Sản phẩm: {Name} | Giá: {Price:C} | Danh mục: {(CategoryId.HasValue ? CategoryId.ToString() : "Chưa có")} | Tồn kho: {StockQty}";
}
