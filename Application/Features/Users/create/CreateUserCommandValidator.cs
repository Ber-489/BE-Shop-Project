using Domain.Constants;
namespace Application.Users;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(ValidationMessages.EmailRequired)
            .EmailAddress().WithMessage(ValidationMessages.EmailInvalid);
    }
}