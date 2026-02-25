// tạo api cho user
namespace Application.Common.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user, CancellationToken cancellationToken);
    Task<List<User>> GetAllAsync();
    Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken);
    // Task<bool> ExistsByPhoneAsync(string phone);
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}