namespace Application.Common.Interfaces;

public interface IOtpRepository
{
    Task CreateAsync(OtpSession session);
    Task<OtpSession?> GetValidOtpAsync(string phoneNumber, string otpCode);
    Task UpdateAsync(OtpSession session);
}