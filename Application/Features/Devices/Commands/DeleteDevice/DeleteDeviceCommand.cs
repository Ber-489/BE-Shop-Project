namespace Application.Features.Devices.Commands.DeleteDevice;

public record DeleteDeviceCommand(
    Guid Id,
    Guid StoreId,
    Guid BranchId
) : IRequest<ApiResponse<DeleteDeviceResponse>>;