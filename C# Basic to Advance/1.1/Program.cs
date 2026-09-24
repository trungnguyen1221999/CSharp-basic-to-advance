// ── Order information ──────────────────────────────────
int    orderId       = 1001;
string customerName  = "Nguyễn Văn A";
string productName   = "Laptop Dell XPS 15";
int    quantity      = 2;
decimal unitPrice    = 35_000_000;   // decimal for currency (do not use double!)
string orderStatus   = "Pending";
DateTime orderDate   = DateTime.Now;
string paymentMethod = "Credit Card";
int discountPercent  = 10; // 10% discount

// ── Calculations ────────────────────────────────────────
decimal totalAmount  = quantity * unitPrice;
decimal discountAmount = totalAmount * discountPercent / 100;
decimal finalAmount = totalAmount - discountAmount;


// ── Print results ───────────────────────────────────────
Console.WriteLine("============================================");
Console.WriteLine("             ORDER INVOICE                ");
Console.WriteLine("============================================");
Console.WriteLine($"Order ID     : #{orderId}");
Console.WriteLine($"Customer     : {customerName}");
Console.WriteLine($"Product      : {productName}");
Console.WriteLine($"Quantity     : {quantity}");
Console.WriteLine($"Unit price   : {unitPrice:N0} VND");
Console.WriteLine($"Total amount : {totalAmount:N0} VND");
Console.WriteLine($"Discount     : {discountAmount:N0} VND");
Console.WriteLine($"Final amount : {finalAmount:N0} VND");
Console.WriteLine($"Status       : {orderStatus}");
Console.WriteLine($"Payment      : {paymentMethod}");
Console.WriteLine($"Order date   : {orderDate:dd/MM/yyyy HH:mm}");
Console.WriteLine("============================================");
