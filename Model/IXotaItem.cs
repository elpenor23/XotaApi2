namespace XotaApi2.Models
{
    public interface IXotaItem //:IComparable<IXotaItem>
    {
        string? Id { get; }
        string? Source { get; }
        int? Band { get; }
        string? Frequency { get; }
        string? LocationDetails { get; }
        string? LocationCode { get; }
        string ActivatorName { get; }
        string? ActivatorCallsign { get; }
        DateTime? DateTime { get; }
        string? Mode { get; }
        void FillFromJson(dynamic jsonInput);
    }
}