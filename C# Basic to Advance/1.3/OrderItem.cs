enum OrderStatus { Pending, Processing, Shipped, Delivered, Cancelled }
 
// Record để lưu thông tin sản phẩm trong đơn
// (record sẽ học kỹ ở Bài 2.6 — giờ dùng như class đơn giản)
public class OrderItem
{
    public string  ProductName  { get; set; } = string.Empty;
    public decimal UnitPrice    { get; set; }  // decimal cho tiền — KHÔNG dùng double
    public int     Quantity     { get; set; }
}
