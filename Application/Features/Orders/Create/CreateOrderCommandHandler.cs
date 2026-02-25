namespace Application.Orders.Create;

public class CreateOrderCommandHandler
    : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;
    private readonly IOrderJob _orderJob;

    public CreateOrderCommandHandler(
        IOrderRepository orderRepository,
        IUserRepository userRepository,
        IOrderJob orderJob)
    {
        _orderRepository = orderRepository;
        _userRepository = userRepository;
        _orderJob = orderJob;
    }

    public async Task<Guid> Handle(
        CreateOrderCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
        if (user is null)
            throw new NotFoundException("User không tồn tại");

        var order = new Order
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            Status = OrderStatus.Pending,
            CreatedAt = DateTime.UtcNow
        };

        await _orderRepository.AddAsync(order, cancellationToken);

        // GỌI HANGFIRE
        await _orderJob.SendOrderCreatedEmail(order.Id);

        return order.Id;
    }
}