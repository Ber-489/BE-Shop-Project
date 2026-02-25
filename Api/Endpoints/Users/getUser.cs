using Application.Users;
using System.Text.Json;

namespace Api.Endpoints.Users;

public class GetUsersEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/users");

        // GET /users
        group.MapGet(string.Empty, async (
            IMediator mediator,
            IDistributedCache cache,
            ILogger<GetUsersEndpoint> logger) =>
        {
            const string cacheKey = "users_all";

            logger.LogInformation("GET /users called");

            var cached = await cache.GetStringAsync(cacheKey);
            if (cached is not null)
            {
                logger.LogInformation("Cache HIT");
                return Results.Ok(
                    JsonSerializer.Deserialize<List<UserDto>>(cached)
                );
            }

            logger.LogInformation("Users cache MISS, querying DB");

            var users = await mediator.Send(new GetUsersQuery());

            await cache.SetStringAsync(
                cacheKey,
                JsonSerializer.Serialize(users),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                });

            return Results.Ok(users);
        });
    }
}
