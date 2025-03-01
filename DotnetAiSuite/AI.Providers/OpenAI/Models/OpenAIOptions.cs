﻿namespace AI.Providers.OpenAI.Models;

public class OpenAIOptions
{
    public string ApiKey { get; set; }
    public string Endpoint { get; set; } = "https://api.openai.com/v1/completions";
}