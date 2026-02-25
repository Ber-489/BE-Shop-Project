namespace Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;

    // 1 Customer – n Order
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}