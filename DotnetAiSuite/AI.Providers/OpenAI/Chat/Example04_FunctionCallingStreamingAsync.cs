﻿namespace AI.Providers.OpenAI.Chat;

public partial class ChatExamples
{
    // See Example03_FunctionCalling.cs for the tool and function definitions.

    // [Test]
    // public async Task Example04_FunctionCallingStreamingAsync()
    // {
    //     ChatClient client = new("gpt-4-turbo", Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
    //
    //     #region
    //     List<ChatMessage> messages =
    //     [
    //         new UserChatMessage("What's the weather like today?"),
    //     ];
    //
    //     ChatCompletionOptions options = new()
    //     {
    //         Tools = { getCurrentLocationTool, getCurrentWeatherTool },
    //     };
    //     #endregion
    //
    //     #region
    //     bool requiresAction;
    //
    //     do
    //     {
    //         requiresAction = false;
    //         StringBuilder contentBuilder = new();
    //         StreamingChatToolCallsBuilder toolCallsBuilder = new();
    //
    //         AsyncCollectionResult<StreamingChatCompletionUpdate> completionUpdates = client.CompleteChatStreamingAsync(messages, options);
    //
    //         await foreach (StreamingChatCompletionUpdate completionUpdate in completionUpdates)
    //         {
    //             // Accumulate the text content as new updates arrive.
    //             foreach (ChatMessageContentPart contentPart in completionUpdate.ContentUpdate)
    //             {
    //                 contentBuilder.Append(contentPart.Text);
    //             }
    //
    //             // Build the tool calls as new updates arrive.
    //             foreach (StreamingChatToolCallUpdate toolCallUpdate in completionUpdate.ToolCallUpdates)
    //             {
    //                 toolCallsBuilder.Append(toolCallUpdate);
    //             }
    //
    //             switch (completionUpdate.FinishReason)
    //             {
    //                 case ChatFinishReason.Stop:
    //                     {
    //                         // Add the assistant message to the conversation history.
    //                         messages.Add(new AssistantChatMessage(contentBuilder.ToString()));
    //                         break;
    //                     }
    //
    //                 case ChatFinishReason.ToolCalls:
    //                     {
    //                         // First, collect the accumulated function arguments into complete tool calls to be processed
    //                         IReadOnlyList<ChatToolCall> toolCalls = toolCallsBuilder.Build();
    //
    //                         // Next, add the assistant message with tool calls to the conversation history.
    //                         AssistantChatMessage assistantMessage = new(toolCalls);
    //
    //                         if (contentBuilder.Length > 0)
    //                         {
    //                             assistantMessage.Content.Add(ChatMessageContentPart.CreateTextPart(contentBuilder.ToString()));
    //                         }
    //
    //                         messages.Add(assistantMessage);
    //
    //                         // Then, add a new tool message for each tool call to be resolved.
    //                         foreach (ChatToolCall toolCall in toolCalls)
    //                         {
    //                             switch (toolCall.FunctionName)
    //                             {
    //                                 case nameof(GetCurrentLocation):
    //                                     {
    //                                         string toolResult = GetCurrentLocation();
    //                                         messages.Add(new ToolChatMessage(toolCall.Id, toolResult));
    //                                         break;
    //                                     }
    //
    //                                 case nameof(GetCurrentWeather):
    //                                     {
    //                                         // The arguments that the model wants to use to call the function are specified as a
    //                                         // stringified JSON object based on the schema defined in the tool definition. Note that
    //                                         // the model may hallucinate arguments too. Consequently, it is important to do the
    //                                         // appropriate parsing and validation before calling the function.
    //                                         using JsonDocument argumentsJson = JsonDocument.Parse(toolCall.FunctionArguments);
    //                                         bool hasLocation = argumentsJson.RootElement.TryGetProperty("location", out JsonElement location);
    //                                         bool hasUnit = argumentsJson.RootElement.TryGetProperty("unit", out JsonElement unit);
    //
    //                                         if (!hasLocation)
    //                                         {
    //                                             throw new ArgumentNullException(nameof(location), "The location argument is required.");
    //                                         }
    //
    //                                         string toolResult = hasUnit
    //                                             ? GetCurrentWeather(location.GetString(), unit.GetString())
    //                                             : GetCurrentWeather(location.GetString());
    //                                         messages.Add(new ToolChatMessage(toolCall.Id, toolResult));
    //                                         break;
    //                                     }
    //
    //                                 default:
    //                                     {
    //                                         // Handle other unexpected calls.
    //                                         throw new NotImplementedException();
    //                                     }
    //                             }
    //                         }
    //
    //                         requiresAction = true;
    //                         break;
    //                     }
    //
    //                 case ChatFinishReason.Length:
    //                     throw new NotImplementedException("Incomplete model output due to MaxTokens parameter or token limit exceeded.");
    //
    //                 case ChatFinishReason.ContentFilter:
    //                     throw new NotImplementedException("Omitted content due to a content filter flag.");
    //
    //                 case ChatFinishReason.FunctionCall:
    //                     throw new NotImplementedException("Deprecated in favor of tool calls.");
    //
    //                 case null:
    //                     break;
    //             }
    //         }
    //     } while (requiresAction);
    //     #endregion
    //
    //     #region
    //     foreach (ChatMessage message in messages)
    //     {
    //         switch (message)
    //         {
    //             case UserChatMessage userMessage:
    //                 Console.WriteLine($"[USER]:");
    //                 Console.WriteLine($"{userMessage.Content[0].Text}");
    //                 Console.WriteLine();
    //                 break;
    //
    //             case AssistantChatMessage assistantMessage when assistantMessage.Content.Count > 0:
    //                 Console.WriteLine($"[ASSISTANT]:");
    //                 Console.WriteLine($"{assistantMessage.Content[0].Text}");
    //                 Console.WriteLine();
    //                 break;
    //
    //             case ToolChatMessage:
    //                 // Do not print any tool messages; let the assistant summarize the tool results instead.
    //                 break;
    //
    //             default:
    //                 break;
    //         }
    //     }
    //     #endregion
    // }
}
