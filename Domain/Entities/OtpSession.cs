namespace Domain.Entities;

public class OtpSession
{
    public Guid Id { get; set; }
    public string PhoneNumber { get; set; } = default!;
    public string OtpCode { get; set; } = default!;
    public DateTime ExpiredAt { get; set; }
    public bool IsUsed { get; set; }
    public bool IsVerified { get; private set; } = false;
    public void MarkAsVerified()
    {
        IsVerified = true;
    }
}