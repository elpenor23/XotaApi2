using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using XotaApi2.Models;

namespace XotaApi2.HttpClients;

public class SotaClient(HttpClient httpClient, IOptions<ProgramOptions> settings) : XotaClientBase(httpClient), ISotaClient
{
    public async Task<List<SotaItem>> GetXotaListAsync()
    {
        var x = await GetAsync<List<SotaItem>>(settings.Value.Sota.ApiEndpoint);
        return x ?? [];
    }

    public async Task HealthCheck()
    {
        await GetAsync<List<SotaItem>>(settings.Value.Sota.HealthCheck);
    }
}
