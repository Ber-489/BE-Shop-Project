namespace Application.Features.Authenticates.Commands.VerifyOtp;

public record VerifyOtpCommand(
    string PhoneNumber,
    Guid SessionId,
    string Otp
) : IRequest<VerifyOtpResponse>;