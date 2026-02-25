// dùng để tạo hangfire  (gửi mail, gọi service, retry)
namespace Infrastructure.Jobs;

public class OrderJob : IOrderJob
{
    private readonly IBackgroundJobClient _backgroundJob;

    public OrderJob(IBackgroundJobClient backgroundJob)
    {
        _backgroundJob = backgroundJob;
    }

    public Task SendOrderCreatedEmail(Guid orderId)
    {
        _backgroundJob.Enqueue(() =>
            ExecuteSendOrderCreatedEmail(orderId)
        );

        return Task.CompletedTask;
    }

    // job nền
    public Task ExecuteSendOrderCreatedEmail(Guid orderId)
    {
        Console.WriteLine($"📧 [Hangfire] Sending email for order {orderId}");
        return Task.CompletedTask;
    }
}