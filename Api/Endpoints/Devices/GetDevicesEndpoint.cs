namespace Api.Endpoints.Devices;

public class GetDevicesEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/devices",
            async (
                string? keyword,
                int? pageIndex,
                int? pageSize,
                [FromHeader(Name = "X-Store-Id")] Guid? storeId,
                [FromHeader(Name = "X-Branch-Id")] Guid? branchId,
                IMediator mediator,
                HttpContext context) =>
            {
                if (storeId is null || branchId is null)
                {
                    return Results.BadRequest("X-Store-Id and X-Branch-Id are required");
                }

                var result = await mediator.Send(
                    new GetDevicesQuery(
                        keyword,
                        pageIndex ?? 1,
                        pageSize ?? 10,
                        storeId.Value,
                        branchId.Value));

                result.TraceId = context.TraceIdentifier;

                return Results.Ok(result);
            })
            .RequireAuthorization()
            .WithTags("Devices")
            .WithName("GetDevices")
            .WithSummary("Danh sách thiết bị")
            .WithDescription("Lấy danh sách thiết bị theo chi nhánh")
            .Produces<PaginatedResponse<GetDevicesResponse>>(200)
            .Produces(401);
    }
}