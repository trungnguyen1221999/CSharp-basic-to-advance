public class Customer
{
    public string CustomerId { get; init; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }


    // Chỉ set được trong class này (gán khi tạo, không đổi sau đó)
    public DateTime RegisteredAt { get; private set; }


    // Computed: tên rút gọn để hiển thị
    public string DisplayName => $"[{CustomerId}] {FullName}";


    public Customer(string customerId, string fullName, string email)
    {
        CustomerId = customerId;
        FullName = fullName;
        Email = email;
        RegisteredAt = DateTime.UtcNow;
    }


    // Overload: thêm phone
    public Customer(string customerId, string fullName, string email, string phone)
        : this(customerId, fullName, email)
    {
        Phone = phone;
    }
}
