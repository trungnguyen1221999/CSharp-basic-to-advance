public sealed class PaymentResult
{
    public bool IsSuccessful { get; private set; }
    public string? Message { get; private set; }
    public string PaymentMethod { get; private set; }
    public Guid TransactionId { get; private set; }
    public bool IsRefunded { get; private set; }
    public DateTimeOffset TransactionDate { get; private set; }
    public PaymentResult(bool isSuccessful, string? message, Guid transactionId, string paymentMethod , bool isRefunded)
    {
        IsSuccessful = isSuccessful;
        Message = message;
        TransactionId = transactionId;
        PaymentMethod = paymentMethod;
        IsRefunded = isRefunded;
        TransactionDate = DateTimeOffset.UtcNow;
    }
}