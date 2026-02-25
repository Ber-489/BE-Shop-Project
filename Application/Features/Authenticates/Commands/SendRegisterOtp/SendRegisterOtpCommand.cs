namespace Application.Features.Authenticates.Commands.SendRegisterOtp;

public record SendRegisterOtpCommand(string Phone)
    : IRequest<SendRegisterOtpResponse>;