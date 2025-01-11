namespace AI.Providers.OpenAI.Chat;

public partial class ChatExamples
{
    // [Test]
    // public void Example02_SimpleChatStreaming()
    // {
    //     ChatClient client = new(model: "gpt-4o", apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
    //
    //     CollectionResult<StreamingChatCompletionUpdate> completionUpdates = client.CompleteChatStreaming("Say 'this is a test.'");
    //
    //     Console.Write($"[ASSISTANT]: ");
    //     foreach (StreamingChatCompletionUpdate completionUpdate in completionUpdates)
    //     {
    //         if (completionUpdate.ContentUpdate.Count > 0)
    //         {
    //             Console.Write(completionUpdate.ContentUpdate[0].Text);
    //         }
    //     }
    // }
}
