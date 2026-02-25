namespace Application.Features.Accounts.Queries;

public record CheckPhoneExistsQuery(string Phone, bool? RequireStore)
    : IRequest<CheckPhoneExistsResponse>;