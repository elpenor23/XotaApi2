using XotaApi2.Models;
using System.Net.Http.Headers;
using XotaApi2.model;

namespace XotaApi2.Managers;

public class XotaDataManager{

    private IConfiguration Configuration { get; }

    public XotaDataManager(IConfiguration configuration){
        Configuration = configuration;
    }

    public async Task<List<IXotaItem>> GetXotaItems(string[]? xotaEntities = null){
        xotaEntities = xotaEntities ?? new string[] {"All"};

        List<IXotaItem> data = new List<IXotaItem>();

        //TODO: Each of these should be put into a class with an interface
        //      So instead of adding code here we can just add a class that implements that interface
        //      and we can just loop through those classes here maybe with an array so we can just add
        //      class types to the array and the manager will stay nice and clean and those classes
        //      can deal with all of the nitty gritty for getting each of the item types
        //      since we are probably going to have to do more complicated things then just hit API's
        //      for some of the other types.
        
        var potaTestData = await this.GetXotaListAsync(Configuration["ApiEndPoints:PotaEndpoint"]);
        var potaData = this.ConvertJsonToXotaItem<PotaItem>(potaTestData);

        data.AddRange(potaData);

        var sotaTestData = await this.GetXotaListAsync(Configuration["ApiEndPoints:SotaEndpoint"]);
        var sotaData = this.ConvertJsonToXotaItem<SotaItem>(sotaTestData);

        data.AddRange(sotaData);

        var radarTestData = await this.GetXotaListAsync(Configuration["ApiEndPoints:RaDAREndpoint"]);
        var radarData = this.ConvertJsonToXotaItem<RadarItem>(radarTestData);

        data.AddRange(radarData);

        if (data.Count == 0) return new List<IXotaItem>();

        var sortedData = data.OrderByDescending(x => x.Band).ToList();

        return sortedData;
    }

    private List<IXotaItem> RemoveDuplicates(List<IXotaItem> xotaList)
    {
        //TODO: Fix this when we have determined the best ID that will work
        //      for all Xota types.

        var nonDupList = xotaList.GroupBy(x => x.Id).Select(y => y.First()).ToList();

        foreach (IXotaItem xm in nonDupList){

        }

        return xotaList;
    }
    private async Task<string> GetXotaListAsync(string uri)
    {
        string result = "[{}]";

        using(var client = new HttpClient())
        {
            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method
            HttpResponseMessage response = await client.GetAsync(uri);
            
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            else
            {
                var errorMessage = string.Format($"Error Getting data from {uri}. Status Code: {response.StatusCode}");
                throw new Exception(errorMessage);
            }
        }
        //Console.WriteLine(result);
        return result;
    }

    public List<Models.IXotaItem> ConvertJsonToXotaItem<T>(string json_string) where T : Models.IXotaItem, new()
    {
        var returnData = new List<Models.IXotaItem>();

        dynamic? jsonData = Newtonsoft.Json.JsonConvert.DeserializeObject(json_string);

        if (jsonData != null)
        {
            foreach (var item in jsonData)
            {
                T xotaItem = new T();

                xotaItem.FillFromJson(item);
                returnData.Add(xotaItem);
            }
        }

        return returnData;
    }
}