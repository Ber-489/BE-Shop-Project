namespace Application.Features.Accounts.Queries;

public class CheckPhoneExistsQueryHandler 
    : IRequestHandler<CheckPhoneExistsQuery, CheckPhoneExistsResponse>
{
    private readonly IAccountRepository _accountRepository;
    private readonly ILogger<CheckPhoneExistsQueryHandler> _logger;

    public CheckPhoneExistsQueryHandler(
        IAccountRepository accountRepository,
        ILogger<CheckPhoneExistsQueryHandler> logger)
    {
        _accountRepository = accountRepository;
        _logger = logger;
    }

    public async Task<CheckPhoneExistsResponse> Handle(
        CheckPhoneExistsQuery request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Checking phone existence for {Phone}", request.Phone);

        var account = await _accountRepository
            .GetByPhoneAsync(request.Phone, cancellationToken);

        if (account is null)
        {
            _logger.LogInformation("Phone {Phone} does not exist", request.Phone);

            return new CheckPhoneExistsResponse
            {
                Exists = false,
                IsFirstLogin = false
            };
        }

        var isFirstLogin = string.IsNullOrEmpty(account.PasswordHash);

        _logger.LogInformation(
            "Phone {Phone} exists. IsFirstLogin: {IsFirstLogin}",
            request.Phone,
            isFirstLogin);

        return new CheckPhoneExistsResponse
        {
            Exists = true,
            IsFirstLogin = isFirstLogin
        };
    }
}