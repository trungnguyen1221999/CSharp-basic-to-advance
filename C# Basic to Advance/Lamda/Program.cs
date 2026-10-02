// // Phía sử dụng
// var may = new MayBom();
// Action handler = () => Console.WriteLine("Xử lý sự kiện");


// // Đăng ký handler bằng lambda
// may.BomNuoc += handler;
// may.BomNuoc += () => Console.WriteLine("Nước đang bơm lên bể!");
// may.BomNuoc += () => Console.WriteLine("Ghi log: máy bơm hoạt động");
// may.BomNuoc -= () => Console.WriteLine("Nước đang bơm lên bể!");
// may.BomNuoc -= handler;

// may.Bat();
// // Output:
// // Máy bơm đang chạy...
// // Nước đang bơm lên bể!
// // Ghi log: máy bơm hoạt động



// public class MayBom
// {
//     // Khai báo event với delegate Action
//     public event Action? BomNuoc;


//     public void Bat()
//     {
//         Console.WriteLine("Máy bơm đang chạy...");
//         // Raise event — gọi tất cả handler đã đăng ký
//         // Dùng ?. để an toàn khi chưa có ai đăng ký
//         BomNuoc?.Invoke();
//     }
// }

var orderService = new OrderService();
void ProcessingOrder (object ? sender, OrderEventArgs e)
{
    Console.WriteLine($"Processing order {e.OrderId} from status {e.FromStatus} to status {e.ToStatus}");
}
orderService.OrderStatusChanged += ProcessingOrder;

orderService.UpdateOrderStatus(new OrderEventArgs("123", "Pending", "Processing"));

public class OrderEventArgs : EventArgs
{
    public string OrderId { get; }
    public string FromStatus { get; }
    public string ToStatus {get;}

    public DateTime Time { get; }

    public OrderEventArgs(string orderId, string fromStatus, string toStatus)
    {
        OrderId = orderId;
        FromStatus = fromStatus;
        ToStatus = toStatus;
        Time = DateTime.UtcNow;
    }
}


public class OrderService {
    public event EventHandler<OrderEventArgs>? OrderStatusChanged;

    protected virtual void OnOrderStatusChanged(OrderEventArgs e)
    {
        OrderStatusChanged?.Invoke(this, e);
    }

    public void UpdateOrderStatus(OrderEventArgs e)
    {
        Console.WriteLine($"Updating order {e.OrderId} from status {e.FromStatus} to status {e.ToStatus}");
        OnOrderStatusChanged(e);
    }
}