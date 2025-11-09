using Microsoft.Extensions.Diagnostics.HealthChecks;
using XotaApi2.HttpClients;

namespace XotaApi2.HealthChecks;

public class SotaHealthCheck(ISotaClient sotaClient) : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await sotaClient.HealthCheck();
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
