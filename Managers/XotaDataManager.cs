using Microsoft.Extensions.Options;
using XotaApi2.HttpClients;
using XotaApi2.Models;

namespace XotaApi2.Managers;

public class XotaDataManager(IPotaClient potaClient, ISotaClient sotaClient, IRadarClient radarClient, ILogger<XotaDataManager> logger, IOptions<ProgramOptions> options) : IXotaDataManager
{
    private readonly ProgramOptions _options = options.Value;
    public async Task<List<XotaItem>?> TestPota(){
        var potaTestData = await potaClient.GetXotaListAsync();
        
        var returnData = potaTestData?.Select(x => new XotaItem(x)).ToList();

        return returnData;
    }

    public async Task<List<XotaItem>?> TestSota(){
        var sotaTestData = await sotaClient.GetXotaListAsync();

        var returnData = sotaTestData?.Select(x => new XotaItem(x)).ToList();

        return returnData;
    }

    public async Task<List<XotaItem>?> TestRadar(){
        var radarTestData = await radarClient.PostXotaListAsync<RadarObject>();

        var returnData = radarTestData?.rows?.Select(x => new XotaItem(x)).ToList();

        return returnData;
    }

    public async Task<List<XotaItem>> GetXotaItems(int durationMinutes = 0,string[]? xotaEntities = null)
    {
        xotaEntities ??= ["All"];

        var data = await GetXotaItemsByEntity(xotaEntities, durationMinutes);

        if (data.Count == 0) return [];

        //TODO: We need some serious deduplication
        //  Only show the latest if there is more then 1 for a person for a spot for a day
        //  Combine them if there is duplicate for muliple sources

        var sortedData = data.OrderByDescending(x => x.Band).ToList();

        return sortedData;
    }

    private async Task<List<XotaItem>> GetXotaItemsByEntity(string[] xotaEntities, int durationMinutes){
        
        var data = new List<XotaItem>();

        if (xotaEntities.Contains("All"))
        {
            if (_options.Pota.Active)
                data.AddRange(await GetPotaItems());

            if (_options.Sota.Active)
                data.AddRange(await GetSotaItems());

            if (_options.Radar.Active)
                data.AddRange(await GetRadarItems());

            return data;
        }

        if (xotaEntities.Contains("POTA"))
            data.AddRange(await GetPotaItems());

        if (xotaEntities.Contains("SOTA"))  
            data.AddRange(await GetSotaItems());

        if (xotaEntities.Contains("RaDAR"))
            data.AddRange(await GetRadarItems());


        logger.LogError("Total Data Count {totalDataCount}", data.Count);
        var minimalData = data.Where(x => x.SpotDateTime > DateTime.Now.AddMinutes(-durationMinutes)).ToList();

        logger.LogError("Minimal Data Count {totalDataCount}", minimalData.Count);

        return minimalData;
    }

    private async Task<List<XotaItem>> GetPotaItems()
    {
        List<XotaItem> data = [];
        var itemData = await potaClient.GetXotaListAsync();

        var itemReturnData = itemData?.Select(x => new XotaItem(x));
        
        if (itemReturnData is not null)
        {
           data.AddRange(itemReturnData); 
        }

        return data;
    }

    private async Task<List<XotaItem>> GetSotaItems()
    {
        List<XotaItem> data = [];
        var itemData = await sotaClient.GetXotaListAsync();

        var itemReturnData = itemData?.Select(x => new XotaItem(x));
        
        if (itemReturnData is not null)
        {
           data.AddRange(itemReturnData); 
        }

        return data;
    }

    private async Task<List<XotaItem>> GetRadarItems()
    {
        List<XotaItem> data = [];
        var itemData = await radarClient.PostXotaListAsync<RadarObject>();

        var itemReturnData = itemData?.rows?.Select(x => new XotaItem(x)).ToList();
        
        if (itemReturnData is not null)
        {
           data.AddRange(itemReturnData); 
        }

        return data;
    }

    private static List<XotaItem> RemoveDuplicates(List<XotaItem> xotaList)
    {
        //TODO: Fix this when we have determined the best ID that will work
        //      for all Xota types.

        var nonDupList = xotaList.GroupBy(x => x.Id).Select(y => y.First()).ToList();

        foreach (var xm in nonDupList){

        }

        return xotaList;
    }
    
}