public class OrderProcessingPipeline
{
     private Action<Order>? _validationSteps;
    private Action<Order>? _processingSteps;
        private Func<Order, decimal>? _discountStrategy;
    private Predicate<Order>? _runCondition;

    public OrderProcessingPipeline AddValidation(Action<Order> step)
    {
        _validationSteps += step;
        return this;
    }

    public OrderProcessingPipeline AddProcessingStep(Action<Order> step)
    {
        _processingSteps += step;
        return this;
    }
    

    public OrderProcessingPipeline SetDiscountStrategy(Func<Order, decimal> strategy)
    {
        _discountStrategy = strategy;
        return this;
    }
     public OrderProcessingPipeline OnlyWhen(Predicate<Order> condition)
    {
        _runCondition = condition;
        return this;
    }

     public ProcessingResult Execute(Order order)
    {
        // Kiểm tra điều kiện chạy
        if (_runCondition != null && !_runCondition(order))
        {
            return new ProcessingResult
            {
                IsSuccess = false,
                Message = "Đơn hàng không đủ điều kiện xử lý"
            };
        }


        // Bước 1: Chạy toàn bộ validation steps
        _validationSteps?.Invoke(order);


        // Bước 2: Tính discount
        decimal discount = _discountStrategy?.Invoke(order) ?? 0m;
        decimal finalAmount = order.TotalAmount - discount;
        order.ProcessingLog.Add($"Discount áp dụng: {discount:N0} VND");


        // Bước 3: Chạy processing steps
        order.Status = "Processing";
        _processingSteps?.Invoke(order);
        order.Status = "Completed";


        return new ProcessingResult
        {
            IsSuccess = true,
            Message = $"Đơn hàng #{order.Id} xử lý thành công",
            FinalAmount = finalAmount
        };
    }


}