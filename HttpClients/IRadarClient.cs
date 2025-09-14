namespace XotaApi2.HttpClients;

public interface IRadarClient : IXotaClient
{
    Task<T?> PostXotaListAsync<T>() where T : class;
}
