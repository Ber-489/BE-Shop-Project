namespace Application.Common.Interfaces;

public interface IDeviceRepository
{
    Task AddAsync(Device device);
}