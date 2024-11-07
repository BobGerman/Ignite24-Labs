using Microsoft.Bot.Builder;
using Microsoft.Teams.AI.AI.Action;
using Microsoft.Teams.AI.AI.Planners;
using Microsoft.Teams.AI.AI;
using AdaptiveCards;
using Microsoft.Bot.Schema;
using Newtonsoft.Json.Linq;

namespace Custom.Engine.Agent;

internal class Actions
{
    [Action(AIConstants.SayCommandActionName, isDefault: false)]
    public static async Task<string> SayCommandAsync([ActionTurnContext] ITurnContext turnContext, [ActionParameters] PredictedSayCommand command, CancellationToken cancellationToken = default)
    {
        IMessageActivity activity;
        if (command?.Response?.Context?.Citations?.Count > 0)
        {
            AdaptiveCard card = ResponseCardCreator.CreateResponseCard(command.Response);
            Attachment attachment = new()
            {
                ContentType = AdaptiveCard.ContentType,
                Content = card
            };
            activity = MessageFactory.Attachment(attachment);

            activity.Entities =
            [
                new Entity
                {
                    Type = "https://schema.org/Message",
                    Properties = new()
                    {
                        { "@type", "Message" },
                        { "@context", "https://schema.org" },
                        { "@id", string.Empty },
                        { "additionalType", JArray.FromObject(new string[] { "AIGeneratedContent" } ) },
                        { "usageInfo", JObject.FromObject(
                            new JObject(){
                                { "@type", "CreativeWork" },
                                { "name", "Confidential" },
                                { "description", "Sensitive information, do not share outside of your organization." },
                            })
                        }
                    }
                }
            ];
        }
        else
        {
            activity = MessageFactory.Text(command.Response.GetContent<string>());
        }

        activity.ChannelData = new
        {
            feedbackLoopEnabled = true
        };

        await turnContext.SendActivityAsync(activity, cancellationToken);

        return string.Empty;
    }
}
