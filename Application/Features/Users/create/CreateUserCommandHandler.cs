using Domain.Entities;
using Domain.Constants;

namespace Application.Users;

public class CreateUserCommandHandler
    : IRequestHandler<CreateUserCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IAppLogger<CreateUserCommandHandler> _logger;

    public CreateUserCommandHandler(
        IUserRepository userRepository,
        IAppLogger<CreateUserCommandHandler> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }
    public async Task<string> Handle(
        CreateUserCommand request,
        CancellationToken cancellationToken)
    {
        var exists = await _userRepository.ExistsByEmailAsync(
            request.Email,
            cancellationToken
        );

        if (exists)
        {
            _logger.LogWarning(
                "Attempt to create duplicate user with email {Email}",
                request.Email
            );

            throw new ConflictException("Email đã tồn tại");
        }

        _logger.LogInformation("Creating user with email {Email}", request.Email);
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = request.Email
        };

        await _userRepository.AddAsync(user, cancellationToken);

        return $"User created with id: {user.Id}";
    }
}