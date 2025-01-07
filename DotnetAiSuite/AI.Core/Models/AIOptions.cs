namespace AI.Core.Models;

public abstract class AIOptions
{
    public required string ApiKey { get; set; }
    public required string Endpoint { get; set; }
    public required string Model { get; set; }
}