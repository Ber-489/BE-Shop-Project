using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly AppDbContext _context;

    public AccountRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsByPhoneAsync(string phone)
    {
        return await _context.Accounts
            .AnyAsync(x => x.Phone == phone);
    }

    public async Task<Account?> GetByPhoneAsync(string phone, CancellationToken cancellationToken)
    {
        return await _context.Accounts
            .FirstOrDefaultAsync(x => x.Phone == phone, cancellationToken);
    }

    public async Task AddAsync(Account account)
    {
        await _context.Accounts.AddAsync(account);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Account account)
    {
        _context.Accounts.Update(account);
        await _context.SaveChangesAsync();
    }
}