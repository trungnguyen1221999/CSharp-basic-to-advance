var viporder = new Order 
{
    Id = 1,
    CustomerName = "John Doe",
    TotalAmount = 2_000_005m
};

var pipeline = new NotificationPipline()
    .AddSendEmailNotification(order => Console.WriteLine($"Sending email for order {order.Id}"))
    .AddSendSmsNotification(order => Console.WriteLine($"Sending SMS for order {order.Id}"))
    .AddLogToFile(order => Console.WriteLine($"Logging order {order.Id} to file"))
    .AddSendVipNotification(order => {
        if (order.TotalAmount > 2_000_000)
         Console.WriteLine($"Sending VIP notification for order {order.Id}"); });
pipeline.Execute(viporder);
public class NotificationPipline
{
    private Action<Order> _sendEmailNotification;
    private Action<Order> _sendSmsNotification; 

    private Action<Order> _logToFile;

    private Action<Order> _sendVipNotification;

    public NotificationPipline AddSendEmailNotification(Action<Order> sendEmailNotification)
    {
        _sendEmailNotification += sendEmailNotification;
        return this;
    }
    
    public NotificationPipline AddSendSmsNotification(Action<Order> sendSmsNotification)
    {
        _sendSmsNotification += sendSmsNotification;
        return this;
    }

    public NotificationPipline AddLogToFile(Action<Order> logToFile)
    {
        _logToFile += logToFile;
        return this;
    }


    public NotificationPipline AddSendVipNotification(Action<Order> sendVipNotification)
    {
        if (sendVipNotification != null)
        {
            _sendVipNotification += sendVipNotification;
        }
        return this;
    }

    public void Execute(Order order)
    {
        _sendEmailNotification?.Invoke(order);
        _sendSmsNotification?.Invoke(order);
        _logToFile?.Invoke(order);
        _sendVipNotification?.Invoke(order);
    }
}

