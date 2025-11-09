using XotaApi2.Models;

namespace XotaApi2.HttpClients;

public interface IPotaClient : IXotaClient
{
    Task<List<PotaItem>> GetXotaListAsync();
}
