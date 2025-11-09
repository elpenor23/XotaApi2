using Microsoft.Extensions.Options;
using XotaApi2.Models;

namespace XotaApi2.HttpClients;

public class PotaClient(HttpClient httpClient, IOptions<ProgramOptions> settings) : XotaClientBase(httpClient), IPotaClient
{
    public async Task<List<PotaItem>> GetXotaListAsync()
    {
        var x = await GetAsync<List<PotaItem>>(settings.Value.Pota.ApiEndpoint);
        return x ?? [];
    }

    public async Task HealthCheck()
    {
        await GetAsync<List<PotaItem>>(settings.Value.Pota.HealthCheck);
    }
}
