using AI.Core.Models;
using Microsoft.Extensions.Configuration;

namespace AI.Core;

public class AiConfiguration(IConfiguration configuration)
{
    public AiOptions? GetOptions(string provider)
    {
        return configuration.GetSection($"AIProviders:{provider}").Get<AiOptions>();
    }
}