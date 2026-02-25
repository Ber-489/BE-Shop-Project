namespace Application.Orders.Create;

public record CreateOrderCommand(Guid UserId) : IRequest<Guid>;