using System;
using System.Collections.Generic;
using System.Text;

namespace C__Basic_to_Advance.Models
{
    public class Product
    {
        // init: ProductId không được thay đổi sau khi tạo
        public string ProductId { get; init; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        // Price có validation — không cho âm
        private decimal _price;

        public decimal Price
        {
            get;
            set
            {
                if (value < 0)
                    throw new ArgumentException(
                        $"Gia san pham khong duoc am. Gia nhan duoc: {value}m"
                    );
                field = value;
            }
        }

        private int _stockQuantity;

        public int StockQuantity
        {
            get;
            set
            {
                if (value < 0)
                    throw new ArgumentException("So luong ton kho khong duoc am.");
                field = value;
            }
        }

        // Computed property
        public bool IsInStock => StockQuantity > 0;

        public Product(string productId, string name, decimal price)
        {
            ProductId = productId;
            Name = name;
            Price = price; // gọi qua property setter để có validation
            StockQuantity = 0;
        }

        public Product(string productId, string name, decimal price, int stockQuantity)
            : this(productId, name, price)
        {
            StockQuantity = stockQuantity;
        }
    }
}
