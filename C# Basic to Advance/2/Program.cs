// var p = new Product("1", "Chuột gaming", Money.VND(850_000m), stockQuantity: 50);
 
// Console.WriteLine(p.Name);        // Chuột gaming
// Console.WriteLine(p.IsInStock);   // True
// Console.WriteLine(Product.ValidateSku("SKU-001")); // True
 
// p.ReduceStock(5);
// Console.WriteLine(p.StockQuantity); // 45
 
//  //p.ReduceStock(100); // Exception: không đủ hàng
//  //new Product("2", "", Money.VND(100m), 10); // Exception: tên rỗng

//Console.WriteLine($"Convert 15000 vnd to Money object: {Money.FromString("15000 VnD").Amount}");

var vnd = new Money (15_000m, "VND");
var usd = new Money (1, "USD");

var sum = vnd.Add(new Money(5_000m, "VND"));
Console.WriteLine(sum.Display); // 20.000 VND

var difference = vnd.Subtract(new Money(5_000m, "VND"));
Console.WriteLine(difference.Display); // 10.000 VND
var invalidMoney = new Money(5_000m, "ABC"); // Exception: Đơn vị tiền tệ không hợp lệ: ABC.