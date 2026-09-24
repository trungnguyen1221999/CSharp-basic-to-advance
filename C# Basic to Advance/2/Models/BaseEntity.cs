public abstract class BaseEntity
{
    public Guid Id { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset UpdatedAt { get; private set; }


    // Protected constructor — chỉ class con mới gọi được
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTimeOffset.UtcNow;
        UpdatedAt = DateTimeOffset.UtcNow;
    }


    // Method cập nhật UpdatedAt — class con có thể gọi
    protected void SetUpdatedAt()
    {
        UpdatedAt = DateTimeOffset.UtcNow;
    }

   public virtual string 	GetDisplayInfo()
    {
        return $"Id: {Id}, Tạo lúc: {CreatedAt:dd/MM/yyyy HH:mm}";
    }

    // Abstract method: không có thân ({}) — class con PHẢI override
    //public abstract string GetDisplayInfo();


}
