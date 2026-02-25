using Application.Users;

namespace Api.Endpoints.Users;

public class PostUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/users");

        // POST /users
        group.MapPost(string.Empty, async (
            CreateUserCommand command,
            IMediator mediator,
            ILogger<PostUserEndpoint> logger,
            CancellationToken ct) =>
        {
            logger.LogInformation(
                "POST /users called with email {Email}",
                command.Email
            );

            await mediator.Send(command, ct);

            logger.LogInformation("User created successfully");

            return Results.Created("/users", null);
        });
    }
}