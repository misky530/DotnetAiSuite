using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace Gemini.Examples;

public class GeminiClient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _apiEndpoint;


    public GeminiClient(IConfiguration configuration)
    {
        _apiKey = configuration["GeminiApiKey"] ??
                  throw new ArgumentNullException("GeminiApiKey", "API Key not found in configuration");
        _apiEndpoint =
            configuration["GeminiApiEndpoint"] ?? "YOUR_GEMINI_API_ENDPOINT"; // Default API Endpoint if not configured
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        // Set API Key in headers
    }

    private async Task<T> SendRequestAsync<T>(string endpoint, object requestData)
    {
        var jsonRequest = JsonSerializer.Serialize(requestData);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        //Add Authentication header
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

        HttpResponseMessage response = await _httpClient.PostAsync(endpoint, content);
        response.EnsureSuccessStatusCode();
        var jsonResponse = await response.Content.ReadAsStringAsync();
        try
        {
            return JsonSerializer.Deserialize<T>(jsonResponse);
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to deserialize response: {ex.Message}. Response: {jsonResponse}", ex);
        }
    }

    public async Task<TextResponse> GenerateTextAsync(string prompt)
    {
        var requestData = new
        {
            prompt = prompt
        };
        return await SendRequestAsync<TextResponse>($"{_apiEndpoint}/generateText", requestData);
    }

    public async Task<ImageResponse> GenerateImageAsync(string prompt, string imageUrl)
    {
        var requestData = new
        {
            prompt = prompt,
            image_url = imageUrl // Adjust this according to your API's input format
        };
        return await SendRequestAsync<ImageResponse>($"{_apiEndpoint}/generateImage", requestData);
    }
}