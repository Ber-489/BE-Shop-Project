namespace Application.Features.Authenticates.Commands.SendRegisterOtp;

public class SendRegisterOtpCommandHandler
    : IRequestHandler<SendRegisterOtpCommand, SendRegisterOtpResponse>
{
    private readonly IOtpRepository _otpRepo;
    // private readonly IBackgroundJobClient _backgroundJob;
    private readonly IAppLogger<SendRegisterOtpCommandHandler> _logger;
    private readonly OtpSettings _otpSettings;

    public SendRegisterOtpCommandHandler(
    IOtpRepository otpRepository,
    IOptions<OtpSettings> otpSettings,
    IAppLogger<SendRegisterOtpCommandHandler> logger)
    {
        _otpRepo = otpRepository;  
        _otpSettings = otpSettings.Value;
        _logger = logger;
    }

    public async Task<SendRegisterOtpResponse> Handle(
        SendRegisterOtpCommand request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Sending register OTP for phone {Phone}", request.Phone);

        var otp = new Random().Next(1000, 9999).ToString();
        var session = new OtpSession
        {
            Id = Guid.NewGuid(),
            PhoneNumber = request.Phone,
            OtpCode = otp,
            ExpiredAt = DateTime.UtcNow.AddMinutes(5),
            IsUsed = false
        };

        await _otpRepo.CreateAsync(session);

        // 👉 chỗ này sau sẽ enqueue Hangfire gửi SMS
        _logger.LogInformation("OTP {Otp} generated for {Phone}", otp, request.Phone);

        return new SendRegisterOtpResponse(
            session.Id,
            session.PhoneNumber,
            5
        );
    }
}