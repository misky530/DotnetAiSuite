using AI.Core.Models;
using Microsoft.Extensions.Configuration;

namespace AI.Core;

public class AiConfiguration(IConfiguration configuration)
{
    public AIOptions? GetOptions(string provider)
    {
        return configuration.GetSection($"AIProviders:{provider}").Get<AIOptions>();
    }
}