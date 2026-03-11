namespace Application.Features.Devices.Queries.GetDevices;

public record GetDevicesQuery(
    string? Keyword,
    int PageIndex,
    int PageSize,
    Guid StoreId,
    Guid BranchId
) : IRequest<PaginatedResponse<GetDevicesResponse>>;