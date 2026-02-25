namespace Application.Users;

public class GetUsersQueryHandler
    : IRequestHandler<GetUsersQuery, List<UserDto>>
{
    private readonly IUserRepository _repo;
    private readonly IAppLogger<GetUsersQueryHandler> _logger;

    public GetUsersQueryHandler(IUserRepository repo, IAppLogger<GetUsersQueryHandler> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public async Task<List<UserDto>> Handle(
        GetUsersQuery request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Querying users from database");

        var users = await _repo.GetAllAsync();

        return users
            .Select(u => new UserDto(u.Id, u.Email))
            .ToList();
    }
}