using AI.Core.Interfaces;

namespace AI.Core;

public class AiManager
{
    private readonly Dictionary<string, IAIService> _providers = new();

    public void RegisterProvider(string name, IAIService service)
    {
        _providers.TryAdd(name, service);
    }

    public IAIService GetProvider(string name)
    {
        if (!_providers.TryGetValue(name, out var value))
        {
            throw new Exception($"AI provider '{name}' is not registered.");
        }

        return value;
    }
}