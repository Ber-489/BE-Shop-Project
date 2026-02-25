// dùng để tạo hangfire
namespace Application.Common.Interfaces;

public interface IOrderJob
{
    Task SendOrderCreatedEmail(Guid orderId);
}