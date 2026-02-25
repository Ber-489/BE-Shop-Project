namespace Application.Features.Authenticates.Commands.VerifyOtp;

public class VerifyOtpCommandHandler 
    : IRequestHandler<VerifyOtpCommand, VerifyOtpResponse>
{
    private readonly IOtpRepository _otpRepository;

    public VerifyOtpCommandHandler(IOtpRepository otpRepository)
    {
        _otpRepository = otpRepository;
    }

    public async Task<VerifyOtpResponse> Handle(
    VerifyOtpCommand request,
    CancellationToken cancellationToken)
    {
        var session = await _otpRepository.GetValidOtpAsync(
            request.PhoneNumber,
            request.Otp);

        if (session is null)
        {
            throw new BadRequestException("Invalid or expired OTP");
        }

        if (session.Id != request.SessionId)
        {
            throw new BadRequestException("Invalid session");
        }

        session.MarkAsVerified();

        await _otpRepository.UpdateAsync(session);

        return new VerifyOtpResponse(true);
    }
}