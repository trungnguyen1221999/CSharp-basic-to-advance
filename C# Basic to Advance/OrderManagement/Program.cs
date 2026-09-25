using OrderManagement.Domain.Entities;

var orderRepo = new PagedRepository<Order>(new());
for (int i = 1; i <= 10; i++)
{
    await orderRepo.AddAsync(new Order (Guid.NewGuid().ToString(), Guid.NewGuid())); 
}

  var page1 = await orderRepo.GetPagedAsync(page: 1, pageSize: 3);
  Console.WriteLine(page1.TotalCount);    // 10
  Console.WriteLine(page1.TotalPages);    // 4
  Console.WriteLine(page1.Items.Count()); // 3
