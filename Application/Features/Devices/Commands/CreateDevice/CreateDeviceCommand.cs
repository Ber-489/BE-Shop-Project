namespace Application.Features.Devices.Commands.CreateDevice;

public record CreateDeviceCommand(
    Guid StoreId,
    Guid BranchId,
    string Name,
    string SerialNumber,
    string WifiSSID,
    string WifiPassword
) : IRequest<CreateDeviceResponse>;