using Microsoft.Extensions.Logging;

namespace Globomatics.Infrastructure.Services;

public class FakePaymentService(ILogger<IPaymentService> logger) : IPaymentService
{
    public Task<PaymentStatus> GetStatusAsync(Guid orderId)
    {
        logger.LogInformation("Retrieving payment status for {OrderId}", orderId);

        return Task.FromResult(PaymentStatus.Processing);
    }
}