using NUnit.Framework;
using OpenAI.Chat;
using System;
using System.Threading.Tasks;

namespace OpenAI.Examples;

public partial class ChatExamples
{
    [Test]
    public async Task Example01_SimpleChatAsync()
    {
        ChatClient client = new(model: "gpt-4o", apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

        ChatCompletion completion = await client.CompleteChatAsync("Say 'this is a test.'");

        Console.WriteLine($"[ASSISTANT]: {completion.Content[0].Text}");
    }
    
    [Test]
    public async Task Example01_SimpleChat_ProxyAsync()
    {
        var (option, credentials) = ProxyBuilder.Build();

        // 初始化 OpenAIClient
        var client = new OpenAIClient(credentials, option);
        var chat = client.GetChatClient(model: "gpt-3.5-turbo");

        ChatCompletion completion = await chat.CompleteChatAsync("Say 'this is a test.'");

        Console.WriteLine($"[ASSISTANT]: {completion.Content[0].Text}");
    }
}
