﻿namespace AI.Providers.OpenAI.Chat;

public partial class ChatExamples
{
    // [Test]
    // public void Example01_SimpleChat()
    // {
    //     ChatClient client = new(model: "gpt-3.5-turbo", apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
    //
    //     ChatCompletion completion = client.CompleteChat("Say 'this is a test.'");
    //
    //     Console.WriteLine($"[ASSISTANT]: {completion.Content[0].Text}");
    // }
    //
    // [Test]
    // public void Example02_SimpleChat()
    // {
    //     var option = new OpenAIClientOptions
    //     {
    //         Endpoint = new Uri("https://api.openai-proxy.org/v1")
    //     };
    //
    //     var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
    //     Debug.Assert(apiKey != null, nameof(apiKey) + " != null");
    //     var credentials = new ApiKeyCredential(apiKey);
    //
    //     // 初始化 OpenAIClient
    //     var client = new OpenAIClient(credentials, option);
    //     var chat = client.GetChatClient(model: "gpt-3.5-turbo");
    //
    //     ChatCompletion completion = chat.CompleteChat("What’s the weather like in San Francisco?");
    //
    //     Console.WriteLine($"[ASSISTANT]: {completion.Content[0].Text}");
    //
    // }
}