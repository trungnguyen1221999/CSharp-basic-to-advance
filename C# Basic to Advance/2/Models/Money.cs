public class Money
{
    // === FIELDS (private) ===
    private decimal _amount;
    private readonly string _currency;
 
    // === CONSTANTS (static) ===
    public static readonly Money Zero = new Money(0m, "VND");
 
    // === CONSTRUCTOR ===
    public Money(decimal amount, string currency = "VND")
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount),
                $"Giá trị tiền không thể âm. Nhận: {amount}");
 
        if (string.IsNullOrWhiteSpace(currency))
            throw new ArgumentNullException(nameof(currency),
                "Đơn vị tiền tệ không được để trống.");
 
        _amount   = amount;
        _currency = currency.ToUpperInvariant();
        EnsureValidCurrency(_currency);
    }
 
    // === PROPERTIES ===
 
    // Readonly: chỉ đọc, không gán lại sau khi tạo
    public decimal Amount   => _amount;
    public string  Currency => _currency;
 
    // Computed property: hiển thị định dạng đẹp
    public string Display =>
        $"{Amount:N0} {Currency}";  // ví dụ: "1.500.000 VND"
 
    // Static property: kiểm tra xem có phải zero không
    public bool IsZero => _amount == 0m;
 
    // === METHODS ===
 
    // Cộng hai Money cùng currency
    public Money Add(Money other)
    {
        EnsureCurrencyMatch(other);
 
        return new Money(_amount + other._amount, _currency);
    }
    public Money Subtract(Money other)
    {
        EnsureCurrencyMatch(other);

        decimal resultAmount = _amount - other._amount;
        if (resultAmount < 0)
            throw new InvalidOperationException(
                "Kết quả tiền không thể âm.");

        return new Money(resultAmount, _currency);
    }

    private void EnsureCurrencyMatch(Money other)
    {
        if (other.Currency != Currency)
            throw new InvalidOperationException(
                $"Không thể thực hiện phép toán với các đơn vị tiền khác nhau: {Currency} và {other.Currency}.");
    }

    private void EnsureValidCurrency(string currency)
    {
        if (!Enum.TryParse(typeof(CurrencyList), currency, out _))
            throw new InvalidOperationException(
                $"Đơn vị tiền tệ không hợp lệ: {currency}.");
    }
 
    // Nhân với hệ số (ví dụ: tính discount)
    public Money MultiplyBy(decimal factor)
    {
        if (factor < 0)
            throw new ArgumentOutOfRangeException(nameof(factor),
                "Hệ số nhân không thể âm.");
 
        return new Money(_amount * factor, _currency);
    }
 
    // Static factory method: tạo Money VND
    public static Money VND(decimal amount) => new Money(amount, "VND");
 
    // Override ToString để log dễ đọc
    public override string ToString() => Display;
    public static Money FromString(string value)
    {
        value = value.Trim().ToUpperInvariant();
        string[] parts = value.Split(' ');
        decimal amount = decimal.Parse(parts[0]);
        string currency = parts[1];
        return new Money(amount, currency);
    }
}

public enum CurrencyList { VND, USD, EUR };