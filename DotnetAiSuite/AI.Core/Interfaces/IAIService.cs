using AI.Core.Models;

namespace AI.Core.Interfaces;

public interface IAiService
{
    Task<string> GenerateTextAsync(string prompt, AiOptions options);
    Task<Stream> GenerateAudioAsync(string text, AiOptions options);
    Task<string> TranslateAsync(string text, string sourceLanguage, string targetLanguage, AiOptions options);
}