namespace XotaApi2.Models;
public class ProgramOptions
{
    public readonly static string Location = "ProgramOptions";
    public required string Name { get; set; }
    public required Program Pota { get; set; }
    public required Program Sota { get; set; }
    public required Program Radar { get; set; }
}

public class Program
{
    public required string BaseAddress { get; set; }
    public required string ApiEndpoint { get; set; }
    public int Page { get; set; }
    public int Rows { get; set; }
}
