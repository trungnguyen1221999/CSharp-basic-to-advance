using System;
using System.Collections.Generic;
using System.Linq;

namespace C__Basic_to_Advance.Models
{
    public class Warehouse
    {
        public string WarehouseId { get; init; }

        private Dictionary<string, Product> _products = new();

        public IReadOnlyList<Product> Products => _products.Values.ToList().AsReadOnly();
        public int ProductCount => _products.Count;

        public Warehouse(string warehouseId)
        {
            if (string.IsNullOrWhiteSpace(warehouseId))
                throw new ArgumentException(
                    "WarehouseId cannot be null or empty.",
                    nameof(warehouseId)
                );
            WarehouseId = warehouseId;
        }

        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (_products.ContainsKey(product.ProductId))
                throw new InvalidOperationException(
                    $"Product with ID {product.ProductId} already exists in the warehouse."
                );
            _products.Add(product.ProductId, product);
        }

        public void RestockProduct(string productId, int quantity)
        {
            var product = ProductStockValidation(productId, quantity);
            product.StockQuantity += quantity;
        }

        public void ReserveStock(string productId, int quantity)
        {
            var product = ProductStockValidation(productId, quantity);

            if (product.StockQuantity < quantity)
                throw new InvalidOperationException(
                    $"Insufficient stock for product with ID {productId}."
                );
            product.StockQuantity -= quantity;
        }

        private Product ProductStockValidation(string productId, int quantity)
        {
            if (string.IsNullOrWhiteSpace(productId))
                throw new ArgumentException(
                    "ProductId cannot be null or empty.",
                    nameof(productId)
                );
            if (quantity <= 0)
                throw new ArgumentException(
                    "Quantity must be greater than zero.",
                    nameof(quantity)
                );
            if (!_products.TryGetValue(productId, out var product))
                throw new InvalidOperationException(
                    $"Product with ID {productId} does not exist in the warehouse."
                );
            return product;
        }
    }
}
