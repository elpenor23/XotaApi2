using System.Text.Json.Serialization;

namespace XotaApi2.Models;
public class PotaItem //: Models.XotaItem, Models.IXotaItem
{
    [JsonPropertyName("spotId")]
    public int SpotId { get; set; }
    [JsonPropertyName("activator")]
    public string ActivatorCallsign { get; set; } = string.Empty;
    [JsonPropertyName("frequency")]
    public string Frequency { get; set; } = string.Empty;
    [JsonPropertyName("mode")]
    public string Mode { get; set; } = string.Empty;
    [JsonPropertyName("reference")]
    public string Reference { get; set; } = string.Empty;
    [JsonPropertyName("parkName")]
    public object ParkName { get; set; } = string.Empty;
    [JsonPropertyName("spotTime")]
    public DateTime SpotTime { get; set; }
    [JsonPropertyName("spotter")]
    public string SpotterCallSign { get; set; } = string.Empty;
    [JsonPropertyName("comments")]
    public string Comments { get; set; } = string.Empty;
    [JsonPropertyName("source")]
    public string SpotSource { get; set; } = string.Empty;
    [JsonPropertyName("invalid")]
    public object Invalid { get; set; } = string.Empty;
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    [JsonPropertyName("locationDesc")]
    public string LocationDescription { get; set; } = string.Empty;
    [JsonPropertyName("grid4")]
    public string Grid4 { get; set; } = string.Empty;
    [JsonPropertyName("grid6")]
    public string Grid6 { get; set; } = string.Empty;
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }
    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }
    [JsonPropertyName("count")]
    public int Count { get; set; }
    [JsonPropertyName("expire")]
    public int Expire { get; set; }
}