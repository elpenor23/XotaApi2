using Microsoft.Extensions.Options;
using XotaApi2.Models;

namespace XotaApi2.HttpClients;

public class PotaClient(HttpClient httpClient, IOptions<ProgramOptions> settings) : XotaClientBase(httpClient), IPotaClient
{
    public async Task<T?> GetXotaListAsync<T>() where T: class
    {
        var x = await GetAsync<T>(settings.Value.Pota.ApiEndpoint);
        return x;
    }
}
