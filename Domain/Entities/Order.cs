namespace Domain.Entities;
using Domain.Enums;

public class Order
{
    public Guid Id { get; set; }

    // FK
    public Guid UserId { get; set; }

    // Enum
    public OrderStatus Status { get; set; }

    // Navigation
    public User User { get; set; } = null!;

    // Ví dụ thêm field
    public DateTime CreatedAt { get; set; }
}