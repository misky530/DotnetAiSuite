namespace AI.Providers.OpenAI.Chat;

public partial class ChatExamples
{
    // [Test]
    // public async Task Example05_VisionAsync()
    // {
    //     ChatClient client = new("gpt-4o", Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
    //
    //     string imageFilePath = Path.Combine("Assets", "images_dog_and_cat.png");
    //     using Stream imageStream = File.OpenRead(imageFilePath);
    //     BinaryData imageBytes = BinaryData.FromStream(imageStream);
    //
    //     List<ChatMessage> messages =
    //     [
    //         new UserChatMessage(
    //             ChatMessageContentPart.CreateTextPart("Please describe the following image."),
    //             ChatMessageContentPart.CreateImagePart(imageBytes, "image/png")),
    //     ];
    //
    //     ChatCompletion completion = await client.CompleteChatAsync(messages);
    //
    //     Console.WriteLine($"[ASSISTANT]: {completion.Content[0].Text}");
    // }
}