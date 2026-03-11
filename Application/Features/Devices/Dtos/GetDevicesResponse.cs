namespace Application.Features.Devices.Dtos;

public class GetDevicesResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string SerialNumber { get; set; } = default!;
    public bool IsActive { get; set; }
    public DateTime? LastActive { get; set; }
}