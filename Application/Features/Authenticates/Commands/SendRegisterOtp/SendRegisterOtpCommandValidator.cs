namespace Application.Features.Authenticates.Commands.SendRegisterOtp;

public class SendRegisterOtpCommandValidator
    : AbstractValidator<SendRegisterOtpCommand>
{
    public SendRegisterOtpCommandValidator()
    {
        RuleFor(x => x.Phone)
            .NotEmpty()
            .Matches(@"^(0[0-9]{9})$")
            .WithMessage("Phone number is invalid");
    }
}