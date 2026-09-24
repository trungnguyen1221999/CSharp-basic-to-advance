public class OrderItem
{
    // long instead of int: a large e-commerce system may exceed 2.1 billion order lines
    public long Id { get; set; }

    // string (without ?): product name is REQUIRED — guaranteed not null
    public string ProductName { get; set; } = "";

    // int: quantity does not need long and is never fractional
    public int Quantity { get; set; }

    // decimal: MONEY — never use double
    public decimal UnitPrice { get; set; }

    // int?: discount is OPTIONAL — null means "no discount",
    // different in meaning from 0 ("there is a discount program, but at 0%")
    public int? DiscountPercent { get; set; }

    // string?: optional note
    public string? Note { get; set; }

    // bool: gift status flag
    public bool IsGift { get; set; }

    // Computed property: derived from other data, not stored
    public decimal LineTotal
        => UnitPrice * Quantity * (100 - (DiscountPercent ?? 0)) / 100m;
}
