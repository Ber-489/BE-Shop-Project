namespace Application.Features.Devices.Commands.DeleteDevice;

public class DeleteDeviceCommandHandler
    : IRequestHandler<DeleteDeviceCommand, ApiResponse<DeleteDeviceResponse>>
{
    public async Task<ApiResponse<DeleteDeviceResponse>> Handle(
        DeleteDeviceCommand request,
        CancellationToken cancellationToken)
    {
        var response = new DeleteDeviceResponse
        {
            IsSuccess = true
        };

        return ApiResponse<DeleteDeviceResponse>.Success(response);
    }
}