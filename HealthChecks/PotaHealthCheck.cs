using Microsoft.Extensions.Diagnostics.HealthChecks;
using XotaApi2.HttpClients;

namespace XotaApi2.HealthChecks;

public class PotaHealthCheck(IPotaClient potaClient) : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await potaClient.HealthCheck();
            return HealthCheckResult.Healthy();
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy(
                ex.Message,
                exception: ex);
        }
    }
}
