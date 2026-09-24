public sealed class GuestOrder : Order
{
    public string GuestEmail { get; private set; }
    public GuestOrder(string guestEmail) : base(Guid.Empty)
    {
        GuestEmail = guestEmail;
    }

    public override string GetDisplayInfo() => $"{base.GetDisplayInfo()} | Guest Email: {GuestEmail}";
}