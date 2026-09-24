public class Customer : BaseEntity
{
    public string FullName { get; private set; }
    public string Email { get;  private set; }
    public string Phone { get; private set; }
    public string Address { get; private set; }


    // Computed: tên rút gọn để hiển thị
    public override string GetDisplayInfo()  => $"Customer: {FullName} | Email: {Email} | Phone: {Phone} | Address: {Address}";

    public Customer( string fullName, string email) : base()
    {
        FullName = fullName;
        Email = email;
    }


    // Overload: thêm phone
    public Customer(string fullName, string email, string phone)
        : this(fullName, email)
    {
        Phone = phone;
    }
}
