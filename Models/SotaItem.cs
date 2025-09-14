using System.Text.Json.Serialization;

namespace XotaApi2.Models;
public class SotaItem //: Models.XotaItem, Models.IXotaItem
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("userID")]
    public int UserID { get; set; }
    [JsonPropertyName("timeStamp")]
    public DateTime SpotTime { get; set; }
    [JsonPropertyName("comments")]
    public string Comments { get; set; } = string.Empty;
    [JsonPropertyName("callsign")]
    public string Callsign { get; set; } = string.Empty;
    [JsonPropertyName("associationCode")]
    public string AssociationCode { get; set; } = string.Empty;
    [JsonPropertyName("summitCode")]
    public string SummitCode { get; set; } = string.Empty;
    [JsonPropertyName("activatorCallsign")]
    public string ActivatorCallsign { get; set; } = string.Empty;
    [JsonPropertyName("activatorName")]
    public string ActivatorName { get; set; } = string.Empty;
    [JsonPropertyName("frequency")]
    public string Frequency { get; set; } = string.Empty;
    [JsonPropertyName("mode")]
    public string Mode { get; set; } = string.Empty;
    [JsonPropertyName("summitDetails")]
    public string SummitDetails { get; set; } = string.Empty;
    [JsonPropertyName("highlightColor")]
    public object? HighlightColor { get; set; }

    // public override void FillFromJson(dynamic json_object)
    // {
    //     //TODO: Update ID so that we can more easily remove duplicates
    //     //      and combine with other Xota types

    //     double freq = json_object["frequency"];
    //     double fixedFreq = this.FixFrequency(freq);

    //     int band = base.GetBandFromFrequency(fixedFreq);


    //     this._id = json_object["activatorCallsign"] + "|" + band.ToString() + "|" + json_object["summitCode"];
    //     this._source = "SOTA";
    //     this._band = band;
    //     this._frequency = freq.ToString();
    //     this._activatorCallsign = json_object["activatorCallsign"];
    //     this._activatorName = json_object["activatorName"];
    //     this._locationCode = json_object["summitCode"];
    //     this._locationDetails = json_object["summitDetails"];
    //     this._dateTime = json_object["timeStamp"];
    //     this._mode = json_object["mode"];
    // }

    // private double FixFrequency(double frequency){
    //         if (frequency > 500){
    //             frequency = frequency / 1000;
    //         }

    //         return frequency;
    //     }
}