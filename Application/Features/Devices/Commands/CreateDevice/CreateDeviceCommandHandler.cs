namespace Application.Features.Devices.Commands.CreateDevice;

public class CreateDeviceCommandHandler 
    : IRequestHandler<CreateDeviceCommand, CreateDeviceResponse>
{
    private readonly IDeviceRepository _repository;
    private readonly IAppLogger<CreateDeviceCommandHandler> _logger;

    public CreateDeviceCommandHandler(
        IDeviceRepository repository,
        IAppLogger<CreateDeviceCommandHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<CreateDeviceResponse> Handle(
        CreateDeviceCommand request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new device");

        var device = new Device(
            request.StoreId,
            request.BranchId,
            request.Name,
            request.SerialNumber,
            request.WifiSSID,
            request.WifiPassword);

        await _repository.AddAsync(device);

        _logger.LogInformation("Device created successfully");

        return new CreateDeviceResponse(
            device.Id,
            device.Name,
            device.SerialNumber,
            device.IsActive,
            device.WifiSSID,
            device.WifiPassword);
    }
}