namespace Application.Features.Devices.Queries.GetDevices;

public class GetDevicesQueryHandler 
    : IRequestHandler<GetDevicesQuery, PaginatedResponse<GetDevicesResponse>>
{
    public async Task<PaginatedResponse<GetDevicesResponse>> Handle(
        GetDevicesQuery request,
        CancellationToken cancellationToken)
    {
        // Tạm thời mock data để Swagger chạy được
        var devices = new List<GetDevicesResponse>
        {
            new GetDevicesResponse
            {
                Id = Guid.NewGuid(),
                Name = "Device 1",
                SerialNumber = "SN001",
                IsActive = true,
                LastActive = DateTime.UtcNow
            }
        };

        return new PaginatedResponse<GetDevicesResponse>
        {
            Code = "200",
            Message = "Success",
            TraceId = Guid.NewGuid().ToString(),
            Data = devices,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            Total = devices.Count
        };
    }
}