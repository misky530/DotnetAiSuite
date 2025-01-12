using System.ClientModel;
using System.Diagnostics;

namespace OpenAI.Examples;

public class ProxyBuilder
{
    public static (OpenAIClientOptions, ApiKeyCredential) Build()
    {
        var option = new OpenAIClientOptions
        {
            Endpoint = new Uri("https://api.openai-proxy.org/v1")
        };

        var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
        Debug.Assert(apiKey != null, nameof(apiKey) + " != null");
        var credentials = new ApiKeyCredential(apiKey);

        return (option, credentials);
    }
}