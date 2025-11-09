using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace XotaApi2.HttpClients;

public interface IXotaClient
{
    Task HealthCheck();
}
