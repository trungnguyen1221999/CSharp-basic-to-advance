using OrderManagement.Domain.Entities;

var orders = new List<Order> ();
for (int i = 0; i < 10; i++)
{
    orders.Add (new Order ($"Order {i}", Guid.NewGuid()));
    orders[i].AddAmount(100 + i * 10);
}

orders[1].UpdateStatus("Processing");
orders[1].UpdateStatus("Shipped");
orders[1].UpdateStatus("Delivered");

orders[2].UpdateStatus("Processing");
orders[2].UpdateStatus("Shipped");
orders[2].UpdateStatus("Delivered");

var top3 = orders.OrderByDescending(o => o.TotalAmount).Take(3).Select(o => new { o.Id, o.TotalAmount }).ToList();
Console.WriteLine($"Top 3 Orders by Total Amount: {string.Join(", ", top3.Select(o => $"Id: {o.Id}, TotalAmount: {o.TotalAmount}"))}");