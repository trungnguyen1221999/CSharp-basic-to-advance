using C__Basic_to_Advance.Models;
using System;

namespace C__Basic_to_Advance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Tạo sản phẩm
            var laptop = new Product("SP001", "Laptop Dell XPS 13", 28500000m, 5);
            var mouse = new Product("SP002", "Mouse Logitech MX3", 2200000m, 20);

            // Tạo khách hàng
            var customer = new Customer("C001", "Nguyen Van A", "a@email.com", "0912345678");
            Console.WriteLine(customer.DisplayName);

            // Tạo đơn hàng
            var order = new Order("ORD-001", customer.CustomerId);
            order.AddItem(new OrderItem(laptop.ProductId, laptop.Name, laptop.Price, 1));
            order.AddItem(new OrderItem(mouse.ProductId, mouse.Name, mouse.Price, 2));
            order.DiscountAmount = 500000m;

            Console.WriteLine($"Don hang: {order.OrderId}");
            Console.WriteLine($"Trang thai: {order.Status}");
            Console.WriteLine($"Tong tien hang: {order.SubTotal:N0} VND");
            Console.WriteLine($"Giam gia: {order.DiscountAmount:N0} VND");
            Console.WriteLine($"Tong thanh toan: {order.TotalAmount:N0} VND");
        }
    }
}
