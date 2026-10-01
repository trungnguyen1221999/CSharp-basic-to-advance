var order = new Order
{
    Id = 2024,
    CustomerName = "Nguyen Van An",
    TotalAmount = 750000m,
    ItemCount = 5,
    IsMember = true,
    PromoCode = "SUMMER24"
};


var pipeline = new OrderProcessingPipeline()
    // Thêm các bước validate
    .AddValidation(o =>
    {
        if (o.TotalAmount <= 0)
            throw new InvalidOperationException("Tổng tiền không hợp lệ");
        o.ProcessingLog.Add("✓ Validate tổng tiền: OK");
    })
    .AddValidation(o =>
    {
        if (o.ItemCount == 0)
            throw new InvalidOperationException("Đơn hàng trống");
        o.ProcessingLog.Add($"✓ Validate số lượng ({o.ItemCount} sản phẩm): OK");
    })
    // Chiến lược discount: member 15%, promo 10%, cộng dồn tối đa 20%
    .SetDiscountStrategy(o =>
    {
        decimal rate = 0m;
        if (o.IsMember) rate += 0.15m;
        if (o.PromoCode == "SUMMER24") rate += 0.10m;
        rate = Math.Min(rate, 0.20m);  // Tối đa 20%
        return o.TotalAmount * rate;
    })
    // Các bước xử lý
    .AddProcessingStep(o =>
    {
        o.ProcessingLog.Add("✓ Trừ tồn kho thành công");
    })
    .AddProcessingStep(o =>
    {
        o.ProcessingLog.Add($"✓ Gửi email xác nhận tới {o.CustomerName}");
    })
    // Chỉ chạy với đơn hàng hợp lệ
    .OnlyWhen(o => o.Status == "Pending" && o.TotalAmount > 0);


ProcessingResult result = pipeline.Execute(order);


Console.WriteLine($"Kết quả: {result.Message}");
Console.WriteLine($"Số tiền thanh toán: {result.FinalAmount:N0} VND");
Console.WriteLine("\nLog xử lý:");
