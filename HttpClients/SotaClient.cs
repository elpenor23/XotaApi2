using Microsoft.Extensions.Options;
using XotaApi2.Models;

namespace XotaApi2.HttpClients;

public class SotaClient(HttpClient httpClient, IOptions<ProgramOptions> settings) : XotaClientBase(httpClient), ISotaClient
{
    public async Task<T?> GetXotaListAsync<T>() where T: class
    {
        var x = await GetAsync<T>(settings.Value.Sota.ApiEndpoint);
        return x;
    }
}
