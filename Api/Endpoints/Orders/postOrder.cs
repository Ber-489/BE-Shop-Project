// tạo api cho order
namespace Api.Endpoints.Orders;

public class PostOrderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/users/{userId:guid}/orders", async (
            Guid userId,
            ISender sender) =>
        {
            var orderId = await sender.Send(
                new CreateOrderCommand(userId)
            );

            return Results.Created(
                $"/users/{userId}/orders/{orderId}",
                new { OrderId = orderId }
            );
        });
    }
}