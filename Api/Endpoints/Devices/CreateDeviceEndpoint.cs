using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Common.Models;
using Application.Features.Devices.Commands.CreateDevice;

namespace Api.Endpoints.Devices;

public class CreateDeviceEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/devices",
            async (
                [FromHeader(Name = "X-Store-Id")] Guid storeId,
                [FromHeader(Name = "X-Branch-Id")] Guid branchId,
                CreateDeviceRequest request,
                IMediator mediator) =>
            {
                var result = await mediator.Send(
                    new CreateDeviceCommand(
                        storeId,
                        branchId,
                        request.Name,
                        request.SerialNumber,
                        request.WifiSSID,
                        request.WifiPassword));

                var response = ApiResponse<CreateDeviceResponse>
                    .Success(result);

                return Results.Ok(response);
            })
            .RequireAuthorization()
            .WithTags("Devices")
            .WithName("CreateDevice")
            .WithSummary("Tạo thiết bị mới")
            .WithDescription("Thêm một thiết bị mới với tên và serial number cho chi nhánh. Serial phải duy nhất.")
            .Produces<ApiResponse<CreateDeviceResponse>>(200)
            .Produces(400)
            .Produces(401);
    }
}

public record CreateDeviceRequest(
    string Name,
    string SerialNumber,
    string WifiSSID,
    string WifiPassword);