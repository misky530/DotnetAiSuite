using NUnit.Framework;
using OpenAI.Chat;
using System;
using System.ClientModel;

namespace OpenAI.Examples;

public partial class ChatExamples
{
    [Test]
    public void Example02_SimpleChatStreaming()
    {
        ChatClient client = new(model: "gpt-4o", apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

        CollectionResult<StreamingChatCompletionUpdate> completionUpdates =
            client.CompleteChatStreaming("Say 'this is a test.'");

        Console.Write($"[ASSISTANT]: ");
        foreach (StreamingChatCompletionUpdate completionUpdate in completionUpdates)
        {
            if (completionUpdate.ContentUpdate.Count > 0)
            {
                Console.Write(completionUpdate.ContentUpdate[0].Text);
            }
        }
    }

    [Test]
    public void Example02_SimpleChat_Proxy_Streaming()
    {
        var (option, credentials) = ProxyBuilder.Build();

        // 初始化 OpenAIClient
        var iOpenAiClient = new OpenAIClient(credentials, option);
        var client = iOpenAiClient.GetChatClient(model: "gpt-4o");

        CollectionResult<StreamingChatCompletionUpdate> completionUpdates =
            client.CompleteChatStreaming("Say 'this is a test.'");

        Console.Write($"[ASSISTANT]: ");
        foreach (var completionUpdate in completionUpdates)
        {
            if (completionUpdate.ContentUpdate.Count > 0)
            {
                Console.Write(completionUpdate.ContentUpdate[0].Text);
            }
        }
    }
}