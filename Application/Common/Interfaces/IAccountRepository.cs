namespace Application.Common.Interfaces;

public interface IAccountRepository
{
    Task<bool> ExistsByPhoneAsync(string phone);

    Task<Account?> GetByPhoneAsync(string phone, CancellationToken cancellationToken);

    Task AddAsync(Account account);

    Task UpdateAsync(Account account);
}