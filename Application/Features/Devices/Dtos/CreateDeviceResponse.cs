namespace Application.Features.Devices.Dtos;

public record CreateDeviceResponse(
    Guid Id,
    string Name,
    string SerialNumber,
    bool IsActive,
    string WifiSSID,
    string WifiPassword
);