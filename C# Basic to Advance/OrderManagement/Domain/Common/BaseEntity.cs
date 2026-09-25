namespace OrderManagement.Domain.Common;


public abstract class BaseEntity : IEntity
{
    // Id dùng Guid — chuẩn cho hệ thống distributed
    public Guid Id { get; private set; }


    // DateTimeOffset lưu kèm offset múi giờ — an toàn khi deploy toàn cầu
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset UpdatedAt { get; private set; }


    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTimeOffset.UtcNow;
        UpdatedAt = DateTimeOffset.UtcNow;
    }


    // Abstract: mỗi entity phải tự mô tả bản thân mình
    public abstract string GetDisplayInfo();


    // Virtual: có implementation mặc định, class con có thể override thêm
    public virtual bool IsValid() => Id != Guid.Empty;


    // Protected: chỉ class con mới gọi được
    protected void SetUpdatedAt()
    {
        UpdatedAt = DateTimeOffset.UtcNow;
    }
    public virtual void UpdateInfo()
    {
        SetUpdatedAt();
    }
}

