using XotaApi2.HttpClients;
using XotaApi2.Models;

namespace XotaApi2.Managers;

public class XotaDataManager(IPotaClient potaClient, ISotaClient sotaClient, IRadarClient radarClient, ILogger<XotaDataManager> logger) : IXotaDataManager
{
    public async Task<List<XotaItem>?> TestPota(){
        var potaTestData = await potaClient.GetXotaListAsync<List<PotaItem>>();
        
        var returnData = potaTestData?.Select(x => new XotaItem(x)).ToList();

        return returnData;
    }

    public async Task<List<XotaItem>?> TestSota(){
        var sotaTestData = await sotaClient.GetXotaListAsync<List<SotaItem>>();

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
        xotaEntities = xotaEntities ?? ["All"];

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
            data.AddRange(await GetPotaItems());
            data.AddRange(await GetSotaItems());
            //data.AddRange(await GetRadarItems());
            return data;
        }

        if (xotaEntities.Contains("POTA"))
            data.AddRange(await GetPotaItems());

        if (xotaEntities.Contains("SOTA"))  
            data.AddRange(await GetSotaItems());

        if (xotaEntities.Contains("RaDAR"))
            data.AddRange(await GetRadarItems());

        //TODO: Each of these should be put into a class with an interface
        //  So instead of adding code here we can just add a class that implements that interface
        //  and we can just loop through those classes here maybe with an array so we can just add
        //  class types to the array and the manager will stay nice and clean and those classes
        //  can deal with all of the nitty gritty for getting each of the item types
        //  since we are probably going to have to do more complicated things then just hit API's
        //  for some of the other types.
        logger.LogError("Total Data Count {totalDataCount}", data.Count);
        var minimalData = data.Where(x => x.SpotDateTime > DateTime.Now.AddMinutes(-durationMinutes)).ToList();

        logger.LogError("Minimal Data Count {totalDataCount}", minimalData.Count);

        return minimalData;
    }

    private async Task<List<XotaItem>> GetPotaItems()
    {
        List<XotaItem> data = [];
        var itemData = await potaClient.GetXotaListAsync<List<PotaItem>>();

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
        var itemData = await sotaClient.GetXotaListAsync<List<SotaItem>>();

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