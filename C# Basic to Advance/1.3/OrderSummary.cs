public class OrderSummary
{
    public decimal Subtotal       { get; init; }
    public decimal TotalDiscount  { get; init; }
    public decimal VatAmount      { get; init; }
    public decimal ShippingFee    { get; init; }
    public decimal GrandTotal     { get; init; }
    public bool    IsFreeShipping { get; init; }
}
