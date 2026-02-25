namespace Application.Users;

public record CreateUserCommand(string Email) : IRequest<string>;