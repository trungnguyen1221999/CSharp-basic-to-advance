// Tạo sản phẩm
Product laptop = new Product("SP001", "Laptop Dell XPS 13", 28500000m, 5);
Product mouse  = new Product("SP002", "Mouse Logitech MX3",  2200000m, 20);


// Tạo khách hàng
Customer customer = new Customer("C001", "Nguyen Van A", "a@email.com", "0912345678");
Console.WriteLine(customer.DisplayName);
// Output: [C001] Nguyen Van A


// Tạo đơn hàng
Order order = new Order("ORD-001", customer.CustomerId);


order.AddItem(new OrderItem(laptop.ProductId, laptop.Name, laptop.Price, 1));
order.AddItem(new OrderItem(mouse.ProductId,  mouse.Name,  mouse.Price,  2));


order.DiscountAmount = 500000m;  // giảm 500k


Console.WriteLine($"Don hang: {order.OrderId}");
Console.WriteLine($"Trang thai: {order.Status}");
Console.WriteLine($"Tong tien hang: {order.SubTotal:N0} VND");
Console.WriteLine($"Giam gia: {order.DiscountAmount:N0} VND");
Console.WriteLine($"Tong thanh toan: {order.TotalAmount:N0} VND");
Console.WriteLine($"So luong mat hang: {order.ItemCount}");

order.RemoveItem(mouse.ProductId);
Console.WriteLine($"So luong mat hang sau khi xoa: {order.ItemCount}");
Console.WriteLine($"Tong tien hang sau khi xoa: {order.SubTotal:N0} VND");
Console.WriteLine($"Tong thanh toan sau khi xoa: {order.TotalAmount:N0} VND");

Console.WriteLine($"Trang thai don hang sau khi xoa: {order.Status}");
order.UpdateStatus(Status.Processing);
Console.WriteLine($"Trang thai don hang sau khi cap nhat: {order.Status}");

order.UpdateStatus(Status.Delivered);
Console.WriteLine($"Trang thai don hang sau khi cap nhat: {order.Status}");

// Output:
// Don hang: ORD-001
// Trang thai: Pending
// Tong tien hang: 32,900,000 VND
// Giam gia: 500,000 VND
// Tong thanh toan: 32,400,000 VND


var supplier = new Supplier("SUP001", "ABC Supplier", "Vietnam", "contact@abc.com", "0987654321");
Console.WriteLine(supplier.DisplayContact);
// Output: ABC Supplier | contact@abc.com | 0987654321S

var warehouse = new Warehouse();
warehouse.AddProduct(laptop);
warehouse.AddProduct(mouse);
warehouse.RestockProduct(laptop.ProductId, 10);
warehouse.RestockProduct(mouse.ProductId, 5);

Console.WriteLine($"So luong san pham trong kho: {warehouse.Products.Count}");
Console.WriteLine($"So luong Laptop trong kho: {warehouse.Products["SP001"].StockQuantity}");
Console.WriteLine($"So luong Mouse trong kho: {warehouse.Products["SP002"].StockQuantity}");

warehouse.ReserveStock(laptop.ProductId, 3);
warehouse.RemoveProduct("213");

Console.WriteLine($"So luong san pham trong kho sau khi xoa: {warehouse.Products.Count}");
Console.WriteLine($"So luong Laptop trong kho sau khi xoa: {warehouse.Products["SP001"].StockQuantity}");
Console.WriteLine($"So luong Mouse trong kho sau khi xoa: {warehouse.Products["SP002"].StockQuantity}");