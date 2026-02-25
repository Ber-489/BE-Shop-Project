namespace Application.Features.Accounts.Queries;

public class CheckPhoneExistsQueryValidator 
    : AbstractValidator<CheckPhoneExistsQuery>
{
    public CheckPhoneExistsQueryValidator()
    {
        RuleFor(x => x.Phone)
            .NotEmpty()
            .Matches(@"^(0|\+84)[0-9]{9}$")
            .WithMessage("Invalid phone number format");
    }
}