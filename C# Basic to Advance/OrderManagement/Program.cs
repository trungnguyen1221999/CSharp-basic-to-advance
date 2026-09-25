var @event = new OrderStatusChangedEvent (
    Guid.NewGuid(), 
    OrderStatus.Pending, 
    OrderStatus.Processing, 
    DateTime.UtcNow, 
    "Kai@gmail.com");


Console.WriteLine(@event.IsValidTransition());

var event2 = new OrderStatusChangedEvent (
    Guid.NewGuid(), 
    OrderStatus.Pending, 
    OrderStatus.Shipped, 
    DateTime.UtcNow, 
    "Kai@gmail.com");

    Console.WriteLine(event2.IsValidTransition());

    var retry = event2 with {ChangedAt = DateTime.UtcNow};