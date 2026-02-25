namespace Application.Users;

public record GetUsersQuery() : IRequest<List<UserDto>>;

public record UserDto(Guid Id, string Email);