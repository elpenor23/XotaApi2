namespace XotaApi2.HttpClients;

public interface IXotaClient
{
    Task<T?> GetXotaListAsync<T>() where T: class;
}
