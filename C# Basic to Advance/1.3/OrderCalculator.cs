public enum CustomerType { Normal, VIP, Premium };

public class OrderCalculator
{
    private const decimal VatRate = 0.1m;
    private const decimal FreeShipThreshold = 500_000m;

    public OrderSummary Calculate(
        List<OrderItem> items,
        decimal? percentDiscount = null,
        decimal? fixedDiscount   = null)
    {
        // ── Bước 1: Tính subtotal ──────────────────────────────────────
        decimal subtotal = 0m;
        foreach (var item in items)
        {
            // Toán tử * và +=
            subtotal += item.UnitPrice * item.Quantity;
        }
 
        // ── Bước 2: Tính discount amount ──────────────────────────────
        // ?? — dùng 0 nếu không có giảm giá %
        decimal pctDiscount = percentDiscount ?? 0m;
 
        // Clamp về [0, 100] — toán tử so sánh + conditional
        pctDiscount = pctDiscount < 0m ? 0m : pctDiscount > 100m ? 100m : pctDiscount;
 
        decimal discountFromPercent = subtotal * pctDiscount / 100m;
        decimal discountFromFixed   = fixedDiscount ?? 0m;
 
        // Tổng discount không được vượt quá subtotal
        decimal totalDiscount = discountFromPercent + discountFromFixed;
        totalDiscount = totalDiscount > subtotal ? subtotal : totalDiscount;
 
        // ── Bước 3: Tính tiền sau giảm ────────────────────────────────
        decimal amountAfterDiscount = subtotal - totalDiscount;
 
        // ── Bước 4: Tính VAT và tổng cuối ────────────────────────────
        decimal vatAmount = amountAfterDiscount * VatRate;
        decimal totalAmount = amountAfterDiscount + vatAmount;
 
        // ── Bước 5: Phí ship ──────────────────────────────────────────
        // ? : — freeship nếu đủ ngưỡng
        decimal shippingFee = totalAmount >= FreeShipThreshold ? 0m : 30_000m;
        decimal grandTotal = totalAmount + shippingFee;
 
        return new OrderSummary
        {
            Subtotal       = subtotal,
            TotalDiscount  = totalDiscount,
            VatAmount      = vatAmount,
            ShippingFee    = shippingFee,
            GrandTotal     = grandTotal,
            IsFreeShipping = shippingFee == 0m
        };
    }
    public bool IsEligibleForFreeShip(decimal amount, CustomerType memberType)
    {
        if ((memberType == CustomerType.VIP || memberType == CustomerType.Premium) && amount >= 200_000m )
        {
            return true;
        }
        return amount >= FreeShipThreshold;
    }
}
