public class Account
{
    public Guid Id { get; set; }

    public string Phone { get; set; } = default!;

    public string? PasswordHash { get; set; }

    public bool IsFirstLogin { get; set; } = true;

    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpiryTime { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}