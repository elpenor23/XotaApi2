using XotaApi2.Models;

namespace XotaApi2.HttpClients;

public interface ISotaClient : IXotaClient
{
    Task<List<SotaItem>> GetXotaListAsync();
}
