namespace Api.Endpoints.Devices;

public class DeleteDeviceEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/devices/{id}",
            async (
                Guid id,
                [FromHeader(Name = "X-Store-Id")] Guid? storeId,
                [FromHeader(Name = "X-Branch-Id")] Guid? branchId,
                IMediator mediator) =>
            {
                if (storeId is null || branchId is null)
                {
                    return Results.BadRequest("X-Store-Id and X-Branch-Id are required");
                }

                var result = await mediator.Send(
                    new DeleteDeviceCommand(
                        id,
                        storeId.Value,
                        branchId.Value));

                return Results.Ok(result);
            })
            .RequireAuthorization()
            .WithTags("Devices")
            .WithName("DeleteDevice")
            .WithSummary("Xoá thiết bị")
            .WithDescription("Xoá thiết bị theo Id")
            .Produces<ApiResponse<DeleteDeviceResponse>>(200)
            .Produces(401)
            .Produces(403)
            .Produces(404);
    }
}