using System;
using System.Collections.Generic;
using System.Text;

namespace C__Basic_to_Advance.Models
{
    public class OrderItem
    {
        public string ProductId { get; init; }
        public string ProductName { get; init; }
        public decimal UnitPrice { get; init; }
        public int Quantity { get; set; }

        // Computed: thành tiền của dòng này
        public decimal LineTotal => UnitPrice * Quantity;

        public OrderItem(string productId, string productName, decimal unitPrice, int quantity)
        {
            ProductId = productId;
            ProductName = productName;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }
    }
}
