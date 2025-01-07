using System.Text;
using System.Text.Json;
using AI.Core.Interfaces;
using AI.Core.Models;
using AI.Providers.OpenAI.Models;

namespace AI.Providers.OpenAI;

public class OpenAIService : IAIService
{
    private readonly HttpClient _httpClient;
    private readonly OpenAIOptions _options;

    public OpenAIService(OpenAIOptions options)
    {
        _options = options;
        _httpClient = new HttpClient();
    }

    public async Task<string> GenerateTextAsync(string prompt, AIOptions options)
    {
        var requestBody = new
        {
            model = options.Model,
            prompt = prompt,
            max_tokens = 100
        };

        var requestContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {options.ApiKey}");

        var response = await _httpClient.PostAsync(_options.Endpoint, requestContent);
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<JsonElement>(responseBody);
        return result.GetProperty("choices")[0].GetProperty("text").GetString();
    }

    public Task<Stream> GenerateAudioAsync(string text, AIOptions options)
    {
        throw new System.NotImplementedException("Audio generation is not supported for OpenAI yet.");
    }

    public Task<string> TranslateAsync(string text, string sourceLanguage, string targetLanguage, AIOptions options)
    {
        throw new System.NotImplementedException("Translation is not supported for OpenAI.");
    }
}