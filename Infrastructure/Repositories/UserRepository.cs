// tạo api cho user
namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _db;
    private readonly ILogger<UserRepository> _logger;

    public UserRepository(AppDbContext db, ILogger<UserRepository> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Adding user with email {Email}", user.Email);
        _db.Users.Add(user);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<User>> GetAllAsync()
    {
    _logger.LogInformation("EF Core: SELECT users");
    return await _db.Users.ToListAsync();
    }

    public async Task<bool> ExistsByEmailAsync(
    string email,
    CancellationToken cancellationToken)
    {
    return await _db.Users.AnyAsync(
        u => u.Email == email,
        cancellationToken
    );
    }

    // public async Task<bool> ExistsByPhoneAsync(string phone)
    // {
    //     return await _db.Users.AnyAsync(x => x.Phone == phone);
    // }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Users
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}