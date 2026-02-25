namespace Infrastructure.Repositories;

public class OtpRepository : IOtpRepository
{
    private readonly AppDbContext _db;

    public OtpRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task CreateAsync(OtpSession session)
    {
        _db.OtpSessions.Add(session);
        await _db.SaveChangesAsync();
    }

    public async Task<OtpSession?> GetValidOtpAsync(string phoneNumber, string otpCode)
    {
        return await _db.OtpSessions
            .FirstOrDefaultAsync(x =>
                x.PhoneNumber == phoneNumber &&
                x.OtpCode == otpCode &&
                !x.IsVerified &&
                x.ExpiredAt > DateTime.UtcNow);
    }

    public async Task UpdateAsync(OtpSession session)
    {
        _db.OtpSessions.Update(session);
        await _db.SaveChangesAsync();
    }
}