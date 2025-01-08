using System.ClientModel;
using System.Diagnostics;
using OpenAI;

namespace AI.Demo.ConApp;

using OpenAI.Chat;

public static class OpenAiDemo
{
    public static void Run()
    {
        ChatClient client = new(model: "gpt-4o", apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

        ChatCompletion completion = client.CompleteChat("Say 'this is a test.'");

        Console.WriteLine($"[ASSISTANT]: {completion.Content[0].Text}");
    }

    public static void RunProxy()
    {
        var option = new OpenAIClientOptions
        {
            Endpoint = new Uri("https://api.openai-proxy.org/v1")
        };

        var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
        Debug.Assert(apiKey != null, nameof(apiKey) + " != null");
        var credentials = new ApiKeyCredential(apiKey);

        // 初始化 OpenAIClient
        var client = new OpenAIClient(credentials, option);
        var chat = client.GetChatClient(model: "gpt-3.5-turbo");

        ChatCompletion completion = chat.CompleteChat("What’s the weather like in San Francisco?");

        Console.WriteLine($"[ASSISTANT]: {completion.Content[0].Text}");
    }
    
}