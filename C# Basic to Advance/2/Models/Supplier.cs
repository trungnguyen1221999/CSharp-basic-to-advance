// Bài tập 1 (Dễ): Tạo class Supplier (nhà cung cấp) với các property: SupplierId, Name, ContactEmail, PhoneNumber, Country.
// Yêu cầu: SupplierId và Country dùng init (không thay đổi sau khi tạo).
// Viết 2 constructor: (supplierId, name, country) và overload thêm email + phone.
// Thêm computed property DisplayContact trả về chuỗi 'Name | Email | Phone'.
public class Supplier
{
    public string SupplierId { get; init; }
    public string Name { get; set; }
    public string ContactEmail { get; set; }
    public string PhoneNumber { get; set; }
    public string Country { get; init; }

    public string DisplayContact => $"{Name} | {ContactEmail} | {PhoneNumber}";

    public Supplier(string supplierId, string name, string country)
    {
        SupplierId = supplierId;
        Name = name;
        Country = country;
    }

    public Supplier(string supplierId, string name, string country, string contactEmail, string phoneNumber)
        : this(supplierId, name, country)
    {
        ContactEmail = contactEmail;
        PhoneNumber = phoneNumber;
    }
}