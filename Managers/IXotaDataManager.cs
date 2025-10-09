using XotaApi2.Models;

namespace XotaApi2.Managers;
public interface IXotaDataManager
{
    Task<List<XotaItem>> GetXotaItems(int durationMinutes = 0, string[]? xotaEntities = null);

    Task<List<XotaItem>?> TestPota();
    Task<List<XotaItem>?> TestSota();
    Task<List<XotaItem>?> TestRadar();
}