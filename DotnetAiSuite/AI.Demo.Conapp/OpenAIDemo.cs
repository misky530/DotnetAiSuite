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
}