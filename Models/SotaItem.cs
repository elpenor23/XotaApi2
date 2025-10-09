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
}