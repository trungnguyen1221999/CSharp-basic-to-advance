using System;
using System.Collections.Generic;
using System.Text;

namespace C__Basic_to_Advance.Models
{
    public class Order
    {
        public string OrderId { get; init; }
        public string CustomerId { get; init; }
        public DateTime CreatedAt { get; init; }
        public string Status { get; set; }
        public decimal DiscountAmount { get; set; }
        public string Notes { get; set; }

        // List chứa các dòng đơn hàng
        private List<OrderItem> _items = new List<OrderItem>();

        // Chỉ đọc từ bên ngoài, tránh bị replace cả list
        public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();

        // Tổng tiền hàng (trước giảm giá)
        public decimal SubTotal => _items.Sum(i => i.LineTotal);

        // Tổng thanh toán
        public decimal TotalAmount => SubTotal - DiscountAmount;

        public Order(string orderId, string customerId)
        {
            OrderId = orderId;
            CustomerId = customerId;
            CreatedAt = DateTime.UtcNow;
            Status = "Pending";
            DiscountAmount = 0m;
        }

        public void AddItem(OrderItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            _items.Add(item);
        }

        public void RemoveItem(string productId)
        {
            if (string.IsNullOrWhiteSpace(productId))
                throw new ArgumentException(
                    "ProductId cannot be null or empty.",
                    nameof(productId)
                );
            var productToRemove = _items.FirstOrDefault(i => i.ProductId == productId);
            if (productToRemove != null)
            {
                _items.Remove(productToRemove);
            }
        }

        public int ItemCount => _items.Count;

        public void UpdateStatus(string newStatus)
        {
            if (string.IsNullOrWhiteSpace(newStatus))
                throw new ArgumentException("Status cannot be null or empty.", nameof(newStatus));

            var validFlow = new[] { "Pending", "Processing", "Shipped", "Delivered" };
            var currentIndex = Array.IndexOf(validFlow, Status);
            var newIndex = Array.IndexOf(validFlow, newStatus);

            if (currentIndex < 0)
                throw new InvalidOperationException(
                    $"Current order status '{Status}' is invalid and cannot be transitioned."
                );

            if (newIndex < 0)
                throw new InvalidOperationException(
                    $"Status '{newStatus}' is not supported. Valid statuses: Pending, Processing, Shipped, Delivered."
                );

            if (newIndex != currentIndex + 1)
                throw new InvalidOperationException(
                    $"Invalid status transition from '{Status}' to '{newStatus}'. Allowed next status is '{validFlow[currentIndex + 1]}'."
                );

            Status = newStatus;
        }
    }
}
