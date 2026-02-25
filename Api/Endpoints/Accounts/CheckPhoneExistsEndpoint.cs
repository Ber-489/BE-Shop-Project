namespace Api.Endpoints.Accounts;

public class CheckPhoneExistsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/accounts/check-phone-exists",
            async (string phone, bool? requireStore, IMediator mediator) =>
            {
                var result = await mediator.Send(
                    new CheckPhoneExistsQuery(phone, requireStore));

                var response = ApiResponse<CheckPhoneExistsResponse>
                    .Success(result);

                return Results.Ok(response);             
            })
            .WithTags("Accounts") 
            .WithName("CheckPhoneExists")
            .Produces<ApiResponse<CheckPhoneExistsResponse>>(200)
            .ProducesValidationProblem();
    }
}