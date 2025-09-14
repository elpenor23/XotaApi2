using System.Text.Json.Serialization;

namespace XotaApi2.Models;

public class RadarObject //: Models.XotaItem, Models.IXotaItem
{
    public string total { get; set; } = string.Empty;
    public List<RadarItem> rows { get; set; } = [];
}

public class RadarItem
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;
    [JsonPropertyName("Callsign")]
    public string ActivatorCallsign { get; set; } = string.Empty;
    public string RST_RCVD { get; set; } = string.Empty;
    public string SRX { get; set; } = string.Empty;
    public string Other_Callsign { get; set; } = string.Empty;
    public string RST_SENT { get; set; } = string.Empty;
    public string STX { get; set; } = string.Empty;
    public object SNR { get; set; } = string.Empty;
    public string Reference { get; set; } = string.Empty;
    [JsonPropertyName("Date")]
    public string SpotDate { get; set; } = string.Empty;
    [JsonPropertyName("Time")]
    public string SpotTime { get; set; } = string.Empty;
    public string Frequency { get; set; } = string.Empty;
    public string Mode { get; set; } = string.Empty;
    public string Power { get; set; } = string.Empty;
    public string RaDAR { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string ModeOfTransport { get; set; } = string.Empty;
    public string Grid { get; set; } = string.Empty;
    public string Other_Grid { get; set; } = string.Empty;
    public string Archive { get; set; } = string.Empty;
    public string GridCheck { get; set; } = string.Empty;
    public string Star { get; set; } = string.Empty;

    public DateTime SpotDateTime
    {
        get
        {
            var dt = SpotDate + SpotTime;
            DateTime.TryParse(dt, out var spotDate);
            return spotDate;
        }
    }

    // public override void FillFromJson(dynamic json_object)
    // { 
    //     //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(json_object));
    //     const string constUnknown = "UNKNOWN";
    //     double freq;
    //     if(!double.TryParse(json_object["Frequency"].ToString(), out freq))
    //         freq = GetFrequencyFromRandomString(json_object["Frequency"].ToString());

    //     int band = base.GetBandFromFrequency(freq);

    //     //Yeah this is going to need work to fit into everything
    //     this._id = json_object["Callsign"] + "|" + band.ToString() + "|" + json_object["id"];
    //     this._source = "RaDAR";
    //     this._band = band;
    //     this._frequency = freq.ToString();

    //     this._activatorCallsign = json_object["Callsign"];
    //     this._activatorName = constUnknown;
    //     this._locationCode = constUnknown;
    //     this._locationDetails = constUnknown;

    //     var x = System.DateTime.Now;
    //     string strDateTime = json_object["myDate"] + " " + json_object["myTime"];
    //     Console.WriteLine(strDateTime);
    //     var test = System.DateTime.TryParse(strDateTime, out x);
    //     this._dateTime = x;
    //     this._mode = json_object["Mode"];
    // }
}
