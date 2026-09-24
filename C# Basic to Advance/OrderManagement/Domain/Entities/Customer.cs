using OrderManagement.Domain.Common;

namespace OrderManagement.Domain.Entities;


public class Customer : BaseEntity
{
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }


    public Customer(string fullName, string email, string phoneNumber) : base()
    {
        FullName = fullName;
        Email = email;
        PhoneNumber = phoneNumber;
    }


    public void UpdateContact(string email, string phoneNumber)
    {
        Email = email;
        PhoneNumber = phoneNumber;
        SetUpdatedAt();
    }


    public override string GetDisplayInfo()
        => $"Khách hàng: {FullName} | Email: {Email} | ĐT: {PhoneNumber} | Cập nhật lần cuối: {UpdatedAt} | Tạo lúc: {CreatedAt}";


    public override bool IsValid()
        => base.IsValid()
           && !string.IsNullOrWhiteSpace(FullName)
           && !string.IsNullOrWhiteSpace(Email);

    public override void UpdateInfo()
    {
        UpdateContact("kai@gmail.com", "123456");
        base.UpdateInfo();
    }
}
