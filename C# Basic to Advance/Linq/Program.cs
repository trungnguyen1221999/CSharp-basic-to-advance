 using Microsoft.EntityFrameworkCore;
 using Microsoft.Extensions.Configuration;

 var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
 var connectionString = config.GetConnectionString("Default")
     ?? throw new InvalidOperationException("Missing ConnectionStrings:Default in user-secrets.");

 using var db = new AppDbContext(connectionString);

// var customerWithOrders =  from c in db.Customers
//                              join o in db.Orders
//                              on c.CustomerId equals o.CustomerId into customerOrders
//                              select new
//                              {
//                                  c.FullName,
//                                  c.Tier,
//                                  OrderCount = customerOrders.Count(),
//                                  TotalSpent = customerOrders.Sum(o =>
//                                      db.OrderItems
//                                          .Where(oi => oi.OrderId == o.OrderId)
//                                          .Sum(oi => oi.Quantity * oi.UnitPrice)
//                                  )
//                              };

// foreach (var c in customerWithOrders)
// {
//     Console.WriteLine($"Customer: {c.FullName}, Tier: {c.Tier}, Order Count: {c.OrderCount}, Total Spend: {c.TotalSpent}");
// }

// var result = await db.Orders.SelectMany(o => o.Items).Where(i => i.UnitPrice > 5_000_000).ToListAsync();

// foreach (var r in result)
// {
//     Console.WriteLine($"Order Item: {r.OrderId}, ProductId: {r.ProductId}, Name: {r.Product?.Name}, UnitPrice: {r.UnitPrice}");
// }

// var a = new List<string> {
//     "Item1",
//     "Item2",
//     "Item3",
//     "Item1"
// };

// var b = new List<string> {
//     "Item4",
//     "Item5",
//     "Item1",
//     "Item2"
// };

// var distinctItems = a.Distinct().ToList();
// Console.WriteLine($"Distinct Items in List A: {string.Join(", ", distinctItems)}");

// var unionItems = a.Union(b).ToList();
// Console.WriteLine($"Union of List A and List B: {string.Join(", ", unionItems)}");

// var intersectItems = a.Intersect(b).ToList();
// Console.WriteLine($"Intersection of List A and List B: {string.Join(", ", intersectItems)}");
// var targetCity = "TP.HCM";
// var customersFromHCM = from o in db.Orders
//                        join c in db.Customers on o.CustomerId equals c.CustomerId
//                        join oi in db.OrderItems on o.OrderId equals oi.OrderId
//                        where c.City == targetCity
//                        select new
//                        {
//                            CustomerName = c.FullName,
//                            PlacedOrderDate = o.OrderDate,
//                            TotalOrderAmount = db.OrderItems.Where(oi => oi.OrderId == o.OrderId).Sum(oi => oi.Quantity * oi.UnitPrice),
//                        };
// customersFromHCM = customersFromHCM.OrderByDescending(c => c.TotalOrderAmount);

// foreach (var o in customersFromHCM)
//     Console.WriteLine($"#{o.PlacedOrderDate:dd/MM/yyyy} | {o.CustomerName} | {o.TotalOrderAmount:N0} VND");

var vipOrderList = from o in db.Orders
                join c in db.Customers on o.CustomerId equals c.CustomerId
                where c.Tier == "VIP"
                select o;

var standardOrderList = from o in db.Orders
                        join c in db.Customers on o.CustomerId equals c.CustomerId
                        where c.Tier == "Standard"
                        select o;
var products = vipOrderList.SelectMany(o => o.Items).Select(oi => oi.Product).Distinct().ToList().Except(
               standardOrderList.SelectMany(o => o.Items).Select(oi => oi.Product).Distinct().ToList()
               );

foreach (var p in products)
{
    Console.WriteLine($"Product: {p.ProductId} , Name: {p.Name}");
}