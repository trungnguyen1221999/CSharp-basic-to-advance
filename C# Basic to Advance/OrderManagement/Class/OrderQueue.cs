using OrderManagement.Domain.Entities;

public class OrderQueue
{
    private readonly Queue<Order> _orders = new ();
    public IReadOnlyCollection<Order> Orders => _orders.ToList().AsReadOnly();

    public void EnqueueOrder(Order order)
    {
        _orders.Enqueue(order);
    }

    public void ProcessNext()
    {
        
    }
}