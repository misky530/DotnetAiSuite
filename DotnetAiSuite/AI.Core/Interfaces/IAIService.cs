using AI.Core.Models;

namespace AI.Core.Interfaces;

public interface IAIService
{
    Task<string> GenerateTextAsync(string prompt, AIOptions options);
    Task<Stream> GenerateAudioAsync(string text, AIOptions options);
    Task<string> TranslateAsync(string text, string sourceLanguage, string targetLanguage, AIOptions options);
}