// tạo api cho order
namespace Application.Common.Interfaces;

public interface IOrderRepository
{
    Task AddAsync(Order order, CancellationToken cancellationToken);
}